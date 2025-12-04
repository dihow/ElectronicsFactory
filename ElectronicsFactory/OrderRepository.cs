using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ElectronicsFactory
{
    public static class OrderRepository
    {
        // ========== ORDER METHODS ==========

        public static List<OrderCardInfo> GetOrdersPage(int pageSize, int pageNumber,
            string? clientFilter = null, string? statusFilter = null, string? dateFilter = null)
        {
            int offset = (pageNumber - 1) * pageSize;

            // SQL с JOIN для получения имени клиента
            string sql = @"
                SELECT 
                    o.id,
                    o.status,
                    o.total_amount,
                    o.registration_date,
                    o.shipment_date,
                    COALESCE(i.full_name, le.company_name) as client_name
                FROM orders o
                LEFT JOIN clients c ON o.client_id = c.id
                LEFT JOIN individuals i ON c.id = i.client_id
                LEFT JOIN legal_entities le ON c.id = le.client_id
                WHERE 1=1";

            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@limit", pageSize),
                new NpgsqlParameter("@offset", offset)
            };

            // Фильтр по клиенту (поиск по имени/названию компании)
            if (!string.IsNullOrEmpty(clientFilter))
            {
                sql += @" AND (COALESCE(i.full_name, le.company_name) ILIKE @clientFilter)";
                parameters.Add(new NpgsqlParameter("@clientFilter", $"%{clientFilter}%"));
            }

            // Фильтр по статусу
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Все")
            {
                sql += " AND o.status = @statusFilter";
                parameters.Add(new NpgsqlParameter("@statusFilter", statusFilter));
            }

            // Сортировка в зависимости от dateFilter
            sql += dateFilter switch
            {
                "По дате регистрации" => " ORDER BY o.registration_date DESC",
                "По дате отгрузки" => @" ORDER BY 
                                CASE WHEN o.shipment_date IS NULL THEN 1 ELSE 0 END,
                                o.shipment_date DESC",
                _ => " ORDER BY o.id DESC" // "По умолчанию" или любой другой случай
            };

            sql += " LIMIT @limit OFFSET @offset";

            var dataTable = Database.ExecuteDataTable(sql, parameters.ToArray());
            return DataTableToOrderCardInfoList(dataTable);
        }

        private static List<OrderCardInfo> DataTableToOrderCardInfoList(DataTable dataTable)
        {
            var orders = new List<OrderCardInfo>();
            foreach (DataRow row in dataTable.Rows)
            {
                orders.Add(DataRowToOrderCardInfo(row));
            }
            return orders;
        }

        private static OrderCardInfo DataRowToOrderCardInfo(DataRow row)
        {
            return new OrderCardInfo(
                id: Convert.ToInt32(row["id"]),
                client: row["client_name"].ToString() ?? "Неизвестный клиент",
                status: row["status"].ToString() ?? "",
                totalAmount: row["total_amount"] == DBNull.Value ? 0 : Convert.ToDouble(row["total_amount"]),
                registrationDate: Convert.ToDateTime(row["registration_date"]),
                shipmentDate: row["shipment_date"] == DBNull.Value ? null : Convert.ToDateTime(row["shipment_date"])
            );
        }

        public static long GetTotalOrdersCount(string? clientFilter = null, string? statusFilter = null)
        {
            string sql = @"
        SELECT COUNT(*) 
        FROM orders o
        LEFT JOIN clients c ON o.client_id = c.id
        LEFT JOIN individuals i ON c.id = i.client_id
        LEFT JOIN legal_entities le ON c.id = le.client_id
        WHERE 1=1";

            var parameters = new List<NpgsqlParameter>();

            // Фильтр по клиенту (поиск по имени/названию компании)
            if (!string.IsNullOrEmpty(clientFilter))
            {
                sql += @" AND (COALESCE(i.full_name, le.company_name) ILIKE @clientFilter)";
                parameters.Add(new NpgsqlParameter("@clientFilter", $"%{clientFilter}%"));
            }

            // Фильтр по статусу
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Все")
            {
                sql += " AND o.status = @statusFilter";
                parameters.Add(new NpgsqlParameter("@statusFilter", statusFilter));
            }

            return Database.ExecuteScalar<long>(sql, parameters.ToArray());
        }

        public static Order? GetOrderById(int id)
        {
            string sql = "SELECT * FROM orders WHERE id = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            if (dataTable.Rows.Count == 0)
                return null;

            return DataRowToOrder(dataTable.Rows[0]);
        }

        public static List<Order> GetOrdersByClientId(int clientId)
        {
            string sql = "SELECT * FROM orders WHERE client_id = @clientId ORDER BY registration_date DESC";
            var parameters = new[] { new NpgsqlParameter("@clientId", clientId) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            return DataTableToOrderList(dataTable);
        }

        public static List<Order> GetOrdersByStatus(string status)
        {
            string sql = "SELECT * FROM orders WHERE status = @status ORDER BY registration_date DESC";
            var parameters = new[] { new NpgsqlParameter("@status", status) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            return DataTableToOrderList(dataTable);
        }

        public static int AddOrder(Order order, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO orders (client_id, registration_date, status, total_amount, 
                          shipment_date, transport_company)
                          VALUES (@clientId, @registrationDate, @status, @totalAmount, 
                          @shipmentDate, @transportCompany)
                          RETURNING id";

            var parameters = new[]
            {
                new NpgsqlParameter("@clientId", order.ClientId),
                new NpgsqlParameter("@registrationDate", order.RegistrationDate),
                new NpgsqlParameter("@status", order.Status),
                new NpgsqlParameter("@totalAmount", order.TotalAmount ?? (object)DBNull.Value),
                new NpgsqlParameter("@shipmentDate", order.ShipmentDate ?? (object)DBNull.Value),
                new NpgsqlParameter("@transportCompany", order.TransportCompany ?? (object)DBNull.Value)
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

        public static void UpdateOrder(Order order, NpgsqlTransaction? transaction = null)
        {
            string sql = @"UPDATE orders SET client_id = @clientId, registration_date = @registrationDate, 
                          status = @status, total_amount = @totalAmount, shipment_date = @shipmentDate, 
                          transport_company = @transportCompany 
                          WHERE id = @id";

            var parameters = new[]
            {
                new NpgsqlParameter("@clientId", order.ClientId),
                new NpgsqlParameter("@registrationDate", order.RegistrationDate),
                new NpgsqlParameter("@status", order.Status),
                new NpgsqlParameter("@totalAmount", order.TotalAmount ?? (object)DBNull.Value),
                new NpgsqlParameter("@shipmentDate", order.ShipmentDate ?? (object)DBNull.Value),
                new NpgsqlParameter("@transportCompany", order.TransportCompany ?? (object)DBNull.Value),
                new NpgsqlParameter("@id", order.Id)
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

        public static void DeleteOrder(int id, NpgsqlTransaction? transaction = null)
        {
            string sql = "DELETE FROM orders WHERE id = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id) };
            if (transaction == null)
            {
                Database.ExecuteNonQuery(sql, parameters);
            }
            else
            {
                Database.ExecuteNonQuery(sql, transaction, parameters);
            }
        }

        public static void UpdateOrderStatus(int orderId, string status)
        {
            string sql = "UPDATE orders SET status = @status WHERE id = @id";
            var parameters = new[]
            {
                new NpgsqlParameter("@status", status),
                new NpgsqlParameter("@id", orderId)
            };

            Database.ExecuteNonQuery(sql, parameters);
        }

        public static void DeleteOrderWithRestoreStock(int orderId, NpgsqlTransaction? transaction = null)
        {
            var order = GetOrderById(orderId);
            if (order == null) return;

            var orderItems = GetOrderItems(orderId);

            foreach (var item in orderItems)
            {
                var pcb = PcbRepository.GetPcbById(item.PcbId);
                if (pcb != null)
                {
                    pcb.TotalQuantity += item.Quantity;
                    PcbRepository.UpdatePcb(pcb, transaction);

                    // Запись о движении - возврат плат
                    AdditionalRepository.CreatePcbMovement("Поступление",
                        pcb.Id, item.Quantity,
                        $"Возврат плат после удаления заказа №{orderId}",
                        transaction);
                }
            }

            DeleteAllOrderItems(orderId, transaction);
            DeleteOrder(orderId, transaction);
        }

        // ========== ORDER ITEM METHODS ==========

        public static List<OrderItem> GetOrderItems(int orderId)
        {
            string sql = "SELECT * FROM order_items WHERE order_id = @orderId";
            var parameters = new[] { new NpgsqlParameter("@orderId", orderId) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            return DataTableToOrderItemList(dataTable);
        }

        public static DataTable GetOrderItemsDataTable(int orderId)
        {
            string sql = "SELECT * FROM order_items WHERE order_id = @orderId";
            var parameters = new[] { new NpgsqlParameter("@orderId", orderId) };

            return Database.ExecuteDataTable(sql, parameters);
        }

        public static void AddOrderItem(OrderItem orderItem, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO order_items (order_id, pcb_id, quantity, price_per_pcb)
                          VALUES (@orderId, @pcbId, @quantity, @pricePerPcb)";

            var parameters = new[]
            {
                new NpgsqlParameter("@orderId", orderItem.OrderId),
                new NpgsqlParameter("@pcbId", orderItem.PcbId),
                new NpgsqlParameter("@quantity", orderItem.Quantity),
                new NpgsqlParameter("@pricePerPcb", orderItem.PricePerPcb)
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

        public static void UpdateOrderItem(OrderItem orderItem)
        {
            string sql = @"UPDATE order_items SET quantity = @quantity, price_per_pcb = @pricePerPcb
                          WHERE id = @id";

            var parameters = new[]
            {
                new NpgsqlParameter("@quantity", orderItem.Quantity),
                new NpgsqlParameter("@pricePerPcb", orderItem.PricePerPcb),
                new NpgsqlParameter("@id", orderItem.Id)
            };

            Database.ExecuteNonQuery(sql, parameters);
        }

        public static void DeleteOrderItem(int id)
        {
            string sql = "DELETE FROM order_items WHERE id = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id) };
            Database.ExecuteNonQuery(sql, parameters);
        }

        public static void DeleteAllOrderItems(int orderId, NpgsqlTransaction? transaction = null)
        {
            string sql = "DELETE FROM order_items WHERE order_id = @orderId";
            var parameters = new[] { new NpgsqlParameter("@orderId", orderId) };
            if (transaction == null)
            {
                Database.ExecuteNonQuery(sql, parameters);
            }
            else
            {
                Database.ExecuteNonQuery(sql, transaction, parameters);
            }
        }

        // ========== HELPER METHODS ==========

        private static List<Order> DataTableToOrderList(DataTable dataTable)
        {
            var orders = new List<Order>();
            foreach (DataRow row in dataTable.Rows)
            {
                orders.Add(DataRowToOrder(row));
            }
            return orders;
        }

        private static Order DataRowToOrder(DataRow row)
        {
            return new Order(
                id: Convert.ToInt32(row["id"]),
                clientId: Convert.ToInt32(row["client_id"]),
                registrationDate: Convert.ToDateTime(row["registration_date"]),
                status: row["status"].ToString() ?? "",
                totalAmount: Convert.ToDecimal(row["total_amount"]),
                shipmentDate: row["shipment_date"] == DBNull.Value ? null : Convert.ToDateTime(row["shipment_date"]),
                transportCompany: row["transport_company"]?.ToString()
            );
        }

        private static List<OrderItem> DataTableToOrderItemList(DataTable dataTable)
        {
            var orderItems = new List<OrderItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                orderItems.Add(new OrderItem(
                    id: Convert.ToInt32(row["id"]),
                    orderId: Convert.ToInt32(row["order_id"]),
                    pcbId: Convert.ToInt32(row["pcb_id"]),
                    quantity: Convert.ToInt32(row["quantity"]),
                    pricePerPcb: Convert.ToDecimal(row["price_per_pcb"])
                ));
            }
            return orderItems;
        }
    }
}