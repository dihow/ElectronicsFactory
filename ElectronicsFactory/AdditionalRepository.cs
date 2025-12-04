using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsFactory
{
    public class AdditionalRepository
    {
        // ========== MOVEMENT METHODS ==========

        public static List<MovementCardInfo> GetMovementsPage(int pageSize, int pageNumber, string? typeFilter = null)
        {
            int offset = (pageNumber - 1) * pageSize;

            string sql = @"SELECT * FROM movements 
                          WHERE 1=1";

            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@limit", pageSize),
                new NpgsqlParameter("@offset", offset)
            };

            if (!string.IsNullOrEmpty(typeFilter) && typeFilter != "Все")
            {
                sql += " AND movement_type = @typeFilter";
                parameters.Add(new NpgsqlParameter("@typeFilter", typeFilter));
            }

            sql += " ORDER BY movement_date DESC LIMIT @limit OFFSET @offset";

            var dataTable = Database.ExecuteDataTable(sql, parameters.ToArray());
            return DataTableToMovementCardInfoList(dataTable);
        }

        public static long GetTotalMovementsCount(string? typeFilter = null)
        {
            string sql = "SELECT COUNT(*) FROM movements WHERE 1=1";
            var parameters = new List<NpgsqlParameter>();

            if (!string.IsNullOrEmpty(typeFilter) && typeFilter != "Все")
            {
                sql += " AND movement_type = @typeFilter";
                parameters.Add(new NpgsqlParameter("@typeFilter", typeFilter));
            }

            return Database.ExecuteScalar<long>(sql, parameters.ToArray());
        }

        public static void AddMovement(Movement movement, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO movements (movement_type, product_type, description, value, movement_date)
                          VALUES (@movementType, @productType, @description, @value, @movementDate)";

            var parameters = new[]
            {
                new NpgsqlParameter("@movementType", movement.MovementType),
                new NpgsqlParameter("@productType", movement.ProductType),
                new NpgsqlParameter("@description", movement.Description ?? (object)DBNull.Value),
                new NpgsqlParameter("@value", movement.Value),
                new NpgsqlParameter("@movementDate", movement.MovementDate)
            };

            if (transaction == null)
            {
                Database.ExecuteNonQuery(sql, parameters);
            }
            else
            {
                Database.ExecuteNonQuery(sql, transaction, parameters);
            }
        }

        // ========== MOVEMENT CREATION METHODS ==========

        public static void CreatePcbMovement(string movementType, int pcbId, int quantity, string? description = null, NpgsqlTransaction? transaction = null)
        {
            var pcb = PcbRepository.GetPcbById(pcbId);
            if (pcb == null) return;

            string movementDescription = description ?? $"{movementType} {quantity} плат \"{pcb.Name}\"";

            var movement = new Movement(
                id: 0,
                movementType: movementType,
                productType: "Плата",
                description: movementDescription,
                value: quantity,
                movementDate: DateTime.Now
            );

            AddMovement(movement, transaction);
        }

        public static void CreateComponentMovement(string movementType, int componentId, int quantity, string? description = null, NpgsqlTransaction? transaction = null)
        {
            var component = PcbRepository.GetComponentById(componentId, transaction);
            if (component == null) return;

            string movementDescription = description ?? $"{movementType} {quantity} компонентов \"{component.Name}\"";

            var movement = new Movement(
                id: 0,
                movementType: movementType,
                productType: "Компонент",
                description: movementDescription,
                value: quantity,
                movementDate: DateTime.Now
            );

            AddMovement(movement, transaction);
        }

        public static void CreatePcbStockMovement(int pcbId, int oldQuantity, int newQuantity, NpgsqlTransaction? transaction = null)
        {
            int difference = newQuantity - oldQuantity;
            if (difference == 0) return;

            string movementType = difference > 0 ? "Поступление" : "Списание";
            CreatePcbMovement(movementType, pcbId, Math.Abs(difference), null, transaction);
        }

        public static void CreateComponentStockMovement(int componentId, int oldQuantity, int newQuantity, NpgsqlTransaction? transaction = null)
        {
            int difference = newQuantity - oldQuantity;
            if (difference == 0) return;

            string movementType = difference > 0 ? "Поступление" : "Списание";
            CreateComponentMovement(movementType, componentId, Math.Abs(difference), null, transaction);
        }

        public static int DeleteMovementsInPeriod(DateTime startDate, DateTime endDate, NpgsqlTransaction? transaction = null)
        {
            string sql = "DELETE FROM movements WHERE movement_date BETWEEN @startDate AND @endDate";
            var parameters = new[]
            {
        new NpgsqlParameter("@startDate", startDate),
        new NpgsqlParameter("@endDate", endDate)
    };

            if (transaction == null)
                return Database.ExecuteNonQuery(sql, parameters);
            else
                return Database.ExecuteNonQuery(sql, transaction, parameters);
        }

        public static long GetMovementsCountInPeriod(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT COUNT(*) FROM movements WHERE movement_date BETWEEN @startDate AND @endDate";
            var parameters = new[]
            {
        new NpgsqlParameter("@startDate", startDate),
        new NpgsqlParameter("@endDate", endDate)
    };

            return Database.ExecuteScalar<long>(sql, parameters);
        }

        // ========== EMPLOYEES METHODS ==========

        public static bool TryLoggingIn(string login, string password)
        {
            string sql = @"SELECT password_hash = crypt(@password, password_salt) as password_match
                          FROM employees 
                          WHERE login = @login";

            var parameters = new[]
            {
                new NpgsqlParameter("@login", login),
                new NpgsqlParameter("@password", password)
            };

            return Database.ExecuteScalar<bool>(sql, parameters);
        }

        public static EmployeeInfo? GetEmployeeInfo(string login)
        {
            string sql = @"SELECT id, full_name, is_admin FROM employees WHERE login = @login";
            var parameters = new[] { new NpgsqlParameter("@login", login) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new EmployeeInfo(
                Convert.ToInt32(row["id"]),
                row["full_name"].ToString() ?? "",
                Convert.ToBoolean(row["is_admin"])
            );
        }

        public class EmployeeInfo
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public bool IsAdmin { get; set; }

            public EmployeeInfo(int id, string fullName, bool isAdmin)
            {
                Id = id;
                FullName = fullName;
                IsAdmin = isAdmin;
            }
        }

        // ========== HELPER METHODS ==========

        private static List<MovementCardInfo> DataTableToMovementCardInfoList(DataTable dataTable)
        {
            var movements = new List<MovementCardInfo>();
            foreach (DataRow row in dataTable.Rows)
            {
                movements.Add(new MovementCardInfo(
                    id: Convert.ToInt32(row["id"]),
                    type: row["movement_type"].ToString() ?? "",
                    description: row["description"].ToString() ?? "",
                    date: Convert.ToDateTime(row["movement_date"])
                ));
            }
            return movements;
        }

        private static List<Movement> DataTableToMovementList(DataTable dataTable)
        {
            var movements = new List<Movement>();
            foreach (DataRow row in dataTable.Rows)
            {
                movements.Add(new Movement(
                    id: Convert.ToInt32(row["id"]),
                    movementType: row["movement_type"].ToString() ?? "",
                    productType: row["product_type"].ToString() ?? "",
                    description: row["description"].ToString(),
                    value: Convert.ToInt32(row["value"]),
                    movementDate: Convert.ToDateTime(row["movement_date"])
                ));
            }
            return movements;
        }
    }
}