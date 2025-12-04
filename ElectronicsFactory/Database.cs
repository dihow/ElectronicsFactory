using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsFactory
{
    public static class Database
    {
        private static string _connectionString;

        public static void Initialize(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ==============================================================================
        // Методы для выполнения запросов БЕЗ транзакции (самостоятельно управляют соединением)
        // ==============================================================================

        // Метод для выполнения запросов без возврата данных
        public static int ExecuteNonQuery(string sql, params NpgsqlParameter[] parameters)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            using var command = new NpgsqlCommand(sql, connection);

            command.Parameters.AddRange(parameters);
            connection.Open();

            return command.ExecuteNonQuery();
        }

        // Универсальный метод для запросов с возвратом данных
        public static T? ExecuteScalar<T>(string sql, params NpgsqlParameter[] parameters)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            using var command = new NpgsqlCommand(sql, connection);

            command.Parameters.AddRange(parameters);
            connection.Open();

            var result = command.ExecuteScalar();
            return result == DBNull.Value || result == null ? default(T) : (T)result;
        }

        // Метод для получения DataTable
        public static DataTable ExecuteDataTable(string sql, params NpgsqlParameter[] parameters)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            using var command = new NpgsqlCommand(sql, connection);
            using var adapter = new NpgsqlDataAdapter(command);

            command.Parameters.AddRange(parameters);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            // connection.Close(); // Адаптер обычно закрывает соединение, если оно было открыто им, но явное закрытие через 'using' блок command и adapter гарантирует это.
            // Для connection, 'using' блок тоже закроет его.
            return dataTable;
        }

        // Метод для получения списка объектов
        public static List<T> ExecuteReader<T>(string sql, Func<NpgsqlDataReader, T> mapper, params NpgsqlParameter[] parameters)
        {
            var results = new List<T>();

            using var connection = new NpgsqlConnection(_connectionString);
            using var command = new NpgsqlCommand(sql, connection);

            command.Parameters.AddRange(parameters);
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                results.Add(mapper(reader));
            }

            return results;
        }

        // ==============================================================================
        // Методы для выполнения запросов ВНУТРИ ТРАНЗАКЦИИ (принимают только NpgsqlTransaction)
        // ==============================================================================

        public static int ExecuteNonQuery(string sql, NpgsqlTransaction transaction, params NpgsqlParameter[] parameters)
        {
            // Используем transaction.Connection для создания команды
            using var command = new NpgsqlCommand(sql, transaction.Connection!, transaction); // '!' для уверенности, что Connection не null
            command.Parameters.AddRange(parameters);
            return command.ExecuteNonQuery();
        }

        public static T? ExecuteScalar<T>(string sql, NpgsqlTransaction transaction, params NpgsqlParameter[] parameters)
        {
            // Используем transaction.Connection для создания команды
            using var command = new NpgsqlCommand(sql, transaction.Connection!, transaction);
            command.Parameters.AddRange(parameters);
            var result = command.ExecuteScalar();
            return result == DBNull.Value || result == null ? default(T) : (T)result;
        }

        public static DataTable ExecuteDataTable(string sql, NpgsqlTransaction transaction, params NpgsqlParameter[] parameters)
        {
            // Используем transaction.Connection для создания команды
            using var command = new NpgsqlCommand(sql, transaction.Connection!, transaction);
            using var adapter = new NpgsqlDataAdapter(command);

            command.Parameters.AddRange(parameters);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        // Добавим версию ExecuteReader для транзакции, если нужна
        public static List<T> ExecuteReader<T>(string sql, Func<NpgsqlDataReader, T> mapper, NpgsqlTransaction transaction, params NpgsqlParameter[] parameters)
        {
            var results = new List<T>();

            using var command = new NpgsqlCommand(sql, transaction.Connection!, transaction);
            command.Parameters.AddRange(parameters);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                results.Add(mapper(reader));
            }

            return results;
        }


        // ==============================================================================
        // TransactionManager
        // ==============================================================================
        public static class TransactionManager
        {
            // Изменяем сигнатуру, чтобы не передавать NpgsqlConnection в action/function
            public static void ExecuteInTransaction(Action<NpgsqlTransaction> action)
            {
                using var connection = new NpgsqlConnection(_connectionString);
                connection.Open();
                using var transaction = connection.BeginTransaction();

                try
                {
                    action(transaction); // Передаем только транзакцию
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            // Изменяем сигнатуру, чтобы не передавать NpgsqlConnection в action/function
            public static T ExecuteInTransaction<T>(Func<NpgsqlTransaction, T> function)
            {
                using var connection = new NpgsqlConnection(_connectionString);
                connection.Open();
                using var transaction = connection.BeginTransaction();

                try
                {
                    var result = function(transaction); // Передаем только транзакцию
                    transaction.Commit();
                    return result;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
