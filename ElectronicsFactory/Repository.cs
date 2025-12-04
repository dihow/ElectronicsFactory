using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsFactory
{
    public static class Repository
    {
        public static List<ClientCardInfo> GetClientsPage(int pageSize, int pageNumber)
        {
            var clients = new List<ClientCardInfo>();

            int offset = (pageNumber - 1) * pageSize;

            string sql = @"
                SELECT c.id, c.type, c.phone, c.email, 
                       COALESCE(i.full_name, le.company_name) as name
                FROM clients c
                LEFT JOIN individuals i ON c.id = i.client_id
                LEFT JOIN legal_entities le ON c.id = le.client_id
                ORDER BY c.id
                LIMIT @limit OFFSET @offset";

            var parameters = new[]
            {
                new NpgsqlParameter("@limit", pageSize),
                new NpgsqlParameter("@offset", offset)
            };

            var dataTable = Database.ExecuteDataTable(sql, parameters);

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

        public static long GetTotalClientsCount()
        {
            string sql = "SELECT COUNT(*) FROM clients";
            return Database.ExecuteScalar<long>(sql);
        }

        public static Client? GetClientById(int id)
        {
            string sql = "SELECT id, type, phone, email, inn FROM clients WHERE id = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            if (dataTable.Rows.Count == 0)
                throw new Exception($"Клиент с ID {id} не найден");

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

        public static int AddClient(Client client)
        {
            string sql = @"INSERT INTO clients (type, phone, email, inn)
                          VALUES (@type, @phone, @email, @inn)
                          RETURNING id";
            var parameters = new[]
            {
                new NpgsqlParameter("@type", client.Type),
                new NpgsqlParameter("@phone", client.Phone ?? (object)DBNull.Value),
                new NpgsqlParameter("@email", client.Email ?? (object)DBNull.Value),
                new NpgsqlParameter("@inn", client.Inn ?? (object)DBNull.Value),
                new NpgsqlParameter("@id", client.Id)
            };

            return Database.ExecuteScalar<int>(sql, parameters);
        }

        public static void AddIndividual(Individual individual)
        {
            string sql = @"INSERT INTO individuals (client_id, full_name, address, age)
                          VALUES (@clientId, @fullName, @address, @age)";
            var parameters = new[]
            {
                new NpgsqlParameter("@fullName", individual.FullName),
                new NpgsqlParameter("@address", individual.Address ?? (object)DBNull.Value),
                new NpgsqlParameter("@age", individual.Age),
                new NpgsqlParameter("@clientId", individual.ClientId)
            };

            Database.ExecuteNonQuery(sql, parameters);
        }

        public static void AddLegalEntity(LegalEntity legalEntity)
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

            Database.ExecuteNonQuery(sql, parameters);
        }

        public static void UpdateClient(Client client)
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

            Database.ExecuteNonQuery(sql, parameters);
        }

        public static void UpdateIndividual(Individual individual)
        {
            string sql = @"UPDATE individuals SET full_name = @fullName, address = @address, age = @age 
                          WHERE client_id = @clientId";
            var parameters = new[]
            {
                new NpgsqlParameter("@fullName", individual.FullName),
                new NpgsqlParameter("@address", individual.Address ?? (object)DBNull.Value),
                new NpgsqlParameter("@age", individual.Age),
                new NpgsqlParameter("@clientId", individual.ClientId)
            };

            Database.ExecuteNonQuery(sql, parameters);
        }

        public static void UpdateLegalEntity(LegalEntity legalEntity)
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

            Database.ExecuteNonQuery(sql, parameters);
        }
    }
}