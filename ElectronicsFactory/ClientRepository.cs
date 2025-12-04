using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ElectronicsFactory
{
    public static class ClientRepository
    {
        public static List<ClientCardInfo> GetFilteredClientsPage(int pageSize, int pageNumber, string? nameFilter = null, string? typeFilter = null)
        {
            var clients = new List<ClientCardInfo>();

            int offset = (pageNumber - 1) * pageSize;

            string sql = @"
                SELECT c.id, c.type, c.phone, c.email, 
                       COALESCE(i.full_name, le.company_name) as name
                FROM clients c
                LEFT JOIN individuals i ON c.id = i.client_id
                LEFT JOIN legal_entities le ON c.id = le.client_id
                WHERE 1=1";

            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@limit", pageSize),
                new NpgsqlParameter("@offset", offset)
            };

            if (!string.IsNullOrEmpty(typeFilter) && typeFilter != "Все")
            {
                string dbType = typeFilter == "Физические лица" ? "Физическое лицо" : "Юридическое лицо";
                sql += " AND c.type = @typeFilter";
                parameters.Add(new NpgsqlParameter("@typeFilter", dbType));
            }

            if (!string.IsNullOrEmpty(nameFilter))
            {
                sql += @" AND (COALESCE(i.full_name, le.company_name) ILIKE @nameFilter)
                          ORDER BY 
                            CASE 
                              WHEN COALESCE(i.full_name, le.company_name) ILIKE @namePatternStart THEN 1
                              WHEN COALESCE(i.full_name, le.company_name) ILIKE @namePatternAny THEN 2
                              ELSE 3
                            END,
                            COALESCE(i.full_name, le.company_name)";
                parameters.Add(new NpgsqlParameter("@nameFilter", $"%{nameFilter}%"));
                parameters.Add(new NpgsqlParameter("@namePatternStart", $"{nameFilter}%"));
                parameters.Add(new NpgsqlParameter("@namePatternAny", $"%{nameFilter}%"));
            }
            else
            {
                sql += " ORDER BY c.id";
            }

            sql += " LIMIT @limit OFFSET @offset";

            var dataTable = Database.ExecuteDataTable(sql, parameters.ToArray());

            foreach (DataRow row in dataTable.Rows)
            {
                var clientInfo = new ClientCardInfo(
                    id: Convert.ToInt32(row["id"]),
                    name: row["name"].ToString() ?? "",
                    type: row["type"].ToString() ?? "",
                    phone: row["phone"].ToString() ?? "",
                    email: row["email"].ToString() ?? ""
                );
                clients.Add(clientInfo);
            }

            return clients;
        }

        public static long GetFilteredClientsCount(string? nameFilter = null, string? typeFilter = null)
        {
            string sql = @"
                SELECT COUNT(*) 
                FROM clients c
                LEFT JOIN individuals i ON c.id = i.client_id
                LEFT JOIN legal_entities le ON c.id = le.client_id
                WHERE 1=1";

            var parameters = new List<NpgsqlParameter>();

            if (!string.IsNullOrEmpty(typeFilter) && typeFilter != "Все")
            {
                string dbType = typeFilter == "Физические лица" ? "Физическое лицо" : "Юридическое лицо";
                sql += " AND c.type = @typeFilter";
                parameters.Add(new NpgsqlParameter("@typeFilter", dbType));
            }

            if (!string.IsNullOrEmpty(nameFilter))
            {
                sql += " AND (COALESCE(i.full_name, le.company_name) ILIKE @nameFilter)";
                parameters.Add(new NpgsqlParameter("@nameFilter", $"%{nameFilter}%"));
            }

            return Database.ExecuteScalar<long>(sql, parameters.ToArray());
        }

        public static List<ClientComboBoxItem> GetAllClientsForComboBox()
        {
            var clients = new List<ClientComboBoxItem>();

            string sql = @"
        SELECT c.id, COALESCE(i.full_name, le.company_name) as name
        FROM clients c
        LEFT JOIN individuals i ON c.id = i.client_id
        LEFT JOIN legal_entities le ON c.id = le.client_id
        ORDER BY name";

            var dataTable = Database.ExecuteDataTable(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                clients.Add(new ClientComboBoxItem
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString() ?? "Неизвестный клиент"
                });
            }

            return clients;
        }

        public class ClientComboBoxItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static Client? GetClientById(int id)
        {
            string sql = "SELECT id, type, phone, email, inn FROM clients WHERE id = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new Client(
                id: Convert.ToInt32(row["id"]),
                type: row["type"].ToString() ?? "",
                phone: row["phone"].ToString() ?? "",
                email: row["email"].ToString() ?? "",
                inn: row["inn"].ToString() ?? ""
            );
        }

        public static Individual? GetIndividualById(int clientId)
        {
            string sql = "SELECT client_id, full_name, address, age FROM individuals WHERE client_id = @clientId";
            var parameters = new[] { new NpgsqlParameter("@clientId", clientId) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new Individual(
                clientId: Convert.ToInt32(row["client_id"]),
                fullName: row["full_name"].ToString() ?? "",
                address: row["address"].ToString() ?? "",
                age: Convert.ToInt32(row["age"])
            );
        }

        public static LegalEntity? GetLegalEntityById(int clientId)
        {
            string sql = @"SELECT client_id, company_name, contact_person, legal_address, actual_address 
                          FROM legal_entities WHERE client_id = @clientId";
            var parameters = new[] { new NpgsqlParameter("@clientId", clientId) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new LegalEntity(
                clientId: Convert.ToInt32(row["client_id"]),
                companyName: row["company_name"].ToString() ?? "",
                contactPerson: row["contact_person"].ToString() ?? "",
                legalAddress: row["legal_address"].ToString() ?? "",
                actualAddress: row["actual_address"].ToString() ?? ""
            );
        }

        public static int AddClient(Client client, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO clients (type, phone, email, inn)
                          VALUES (@type, @phone, @email, @inn)
                          RETURNING id";
            var parameters = new[]
            {
                new NpgsqlParameter("@type", client.Type),
                new NpgsqlParameter("@phone", client.Phone ?? (object)DBNull.Value),
                new NpgsqlParameter("@email", client.Email ?? (object)DBNull.Value),
                new NpgsqlParameter("@inn", client.Inn ?? (object)DBNull.Value)
            };

            if (transaction == null)
            {
                return Database.ExecuteScalar<int>(sql, parameters);
            }
            else
            {
                return Database.ExecuteScalar<int>(sql, transaction, parameters);
            }
        }

        public static void AddIndividual(Individual individual, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO individuals (client_id, full_name, address, age)
                          VALUES (@clientId, @fullName, @address, @age)";
            var parameters = new[]
            {
                new NpgsqlParameter("@fullName", individual.FullName),
                new NpgsqlParameter("@address", individual.Address ?? (object)DBNull.Value),
                new NpgsqlParameter("@age", individual.Age ?? (object)DBNull.Value),
                new NpgsqlParameter("@clientId", individual.ClientId)
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

        public static void AddLegalEntity(LegalEntity legalEntity, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO legal_entities
                         VALUES (@clientId, @companyName, @contactPerson, @legalAddress, @actualAddress)";
            var parameters = new[]
            {
                new NpgsqlParameter("@companyName", legalEntity.CompanyName),
                new NpgsqlParameter("@contactPerson", legalEntity.ContactPerson ?? (object)DBNull.Value),
                new NpgsqlParameter("@legalAddress", legalEntity.LegalAddress ?? (object)DBNull.Value),
                new NpgsqlParameter("@actualAddress", legalEntity.ActualAddress ?? (object)DBNull.Value),
                new NpgsqlParameter("@clientId", legalEntity.ClientId)
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

        public static void UpdateClient(Client client, NpgsqlTransaction? transaction = null)
        {
            string sql = @"UPDATE clients SET type = @type, phone = @phone, email = @email, inn = @inn 
                          WHERE id = @id";
            var parameters = new[]
            {
                new NpgsqlParameter("@type", client.Type),
                new NpgsqlParameter("@phone", client.Phone ?? (object)DBNull.Value),
                new NpgsqlParameter("@email", client.Email ?? (object)DBNull.Value),
                new NpgsqlParameter("@inn", client.Inn ?? (object)DBNull.Value),
                new NpgsqlParameter("@id", client.Id)
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

        public static void UpdateIndividual(Individual individual, NpgsqlTransaction? transaction = null)
        {
            string sql = @"UPDATE individuals SET full_name = @fullName, address = @address, age = @age 
                          WHERE client_id = @clientId";
            var parameters = new[]
            {
                new NpgsqlParameter("@fullName", individual.FullName),
                new NpgsqlParameter("@address", individual.Address ?? (object)DBNull.Value),
                new NpgsqlParameter("@age", individual.Age ?? (object)DBNull.Value),
                new NpgsqlParameter("@clientId", individual.ClientId)
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

        public static void UpdateLegalEntity(LegalEntity legalEntity, NpgsqlTransaction? transaction = null)
        {
            string sql = @"UPDATE legal_entities SET company_name = @companyName, 
                          contact_person = @contactPerson, legal_address = @legalAddress, 
                          actual_address = @actualAddress WHERE client_id = @clientId";
            var parameters = new[]
            {
                new NpgsqlParameter("@companyName", legalEntity.CompanyName),
                new NpgsqlParameter("@contactPerson", legalEntity.ContactPerson ?? (object)DBNull.Value),
                new NpgsqlParameter("@legalAddress", legalEntity.LegalAddress ?? (object)DBNull.Value),
                new NpgsqlParameter("@actualAddress", legalEntity.ActualAddress ?? (object)DBNull.Value),
                new NpgsqlParameter("@clientId", legalEntity.ClientId)
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

        public static void DeleteIndividual(int id, NpgsqlTransaction? transaction = null)
        {
            string sql = @"DELETE FROM individuals WHERE client_id = @clientId";
            var parameters = new[]
            {
                new NpgsqlParameter("@clientId", id)
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

        public static void DeleteLegalEntity(int id, NpgsqlTransaction? transaction = null)
        {
            string sql = @"DELETE FROM legal_entities WHERE client_id = @clientId";
            var parameters = new[]
            {
                new NpgsqlParameter("@clientId", id)
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

        public static void DeleteClient(int id, NpgsqlTransaction? transaction = null)
        {
            string sql = @"DELETE FROM clients WHERE id = @id";
            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
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

        public static void DeleteClientWithDependencies(int clientId, NpgsqlTransaction? transaction = null)
        {
            var client = GetClientById(clientId);
            if (client == null) return;

            var clientOrders = OrderRepository.GetOrdersByClientId(clientId);
            if (clientOrders.Count > 0)
            {
                throw new Exception("Невозможно удалить клиента, у которого есть заказы. Сначала удалите все заказы клиента.");
            }

            if (client.Type == "Физическое лицо")
            {
                DeleteIndividual(clientId, transaction);
            }
            else
            {
                DeleteLegalEntity(clientId, transaction);
            }

            DeleteClient(clientId, transaction);
        }
    }
}