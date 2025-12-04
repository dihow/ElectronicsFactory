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
    public static class PcbRepository
    {
        // ========== PCB METHODS ==========

        public static List<PcbCardInfo> GetPcbsPage(int pageSize, int pageNumber, string? nameFilter = null)
        {
            var pcbs = new List<PcbCardInfo>();

            int offset = (pageNumber - 1) * pageSize;

            string sql = @"SELECT id, name, description, price, total_quantity, image_path FROM pcbs";
            

            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@limit", pageSize),
                new NpgsqlParameter("@offset", offset)
            };

            if (!string.IsNullOrEmpty(nameFilter))
            {
                sql += @" WHERE (name ILIKE @nameFilter)
                          ORDER BY 
                            CASE 
                              WHEN name ILIKE @namePatternStart THEN 1
                              WHEN name ILIKE @namePatternAny THEN 2
                              ELSE 3
                            END,
                            name";
                parameters.Add(new NpgsqlParameter("@nameFilter", $"%{nameFilter}%"));
                parameters.Add(new NpgsqlParameter("@namePatternStart", $"{nameFilter}%"));
                parameters.Add(new NpgsqlParameter("@namePatternAny", $"%{nameFilter}%"));
            }
            else
            {
                sql += " ORDER BY id";
            }

            sql += " LIMIT @limit OFFSET @offset";

            var dataTable = Database.ExecuteDataTable(sql, parameters.ToArray());

            foreach (DataRow row in dataTable.Rows)
            {
                var pcbInfo = new PcbCardInfo(
                    id: Convert.ToInt32(row["id"]),
                    name: row["name"].ToString() ?? "",
                    description: row["description"].ToString() ?? "",
                    price: Convert.ToDouble(row["price"]),
                    quantity: Convert.ToInt32(row["total_quantity"]),
                    imagePath: row["image_path"].ToString()
                );
                pcbs.Add(pcbInfo);
            }

            return pcbs;
        }

        public static long GetTotalPcbsCount(string? nameFilter = null)
        {
            string sql = "SELECT COUNT(*) FROM pcbs";
            var parameters = new List<NpgsqlParameter>();

            if (!string.IsNullOrEmpty(nameFilter))
            {
                sql += " WHERE name ILIKE @nameFilter";
                parameters.Add(new NpgsqlParameter("@nameFilter", $"%{nameFilter}%"));
            }

            return Database.ExecuteScalar<long>(sql, parameters.ToArray());
        }

        public static List<PcbComboBoxItem> GetAllPcbsForComboBox()
        {
            var pcbs = new List<PcbComboBoxItem>();

            string sql = "SELECT id, name, serial_number, price FROM pcbs ORDER BY name";
            var dataTable = Database.ExecuteDataTable(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                pcbs.Add(new PcbComboBoxItem
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString() ?? "",
                    SerialNumber = row["serial_number"].ToString() ?? "",
                    Price = Convert.ToDecimal(row["price"])
                });
            }

            return pcbs;
        }

        public class PcbComboBoxItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string SerialNumber { get; set; }
            public decimal Price { get; set; }

            // Свойство для удобного доступа к объекту Pcb
            public Pcb Pcb => new Pcb(Id, Name, SerialNumber, null, null, Price, 0, null, null, null, null, null, null);
        }

        public static Pcb? GetPcbById(int id)
        {
            string sql = "SELECT * FROM pcbs WHERE id = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            if (dataTable.Rows.Count == 0)
                return null;

            return DataRowToPcb(dataTable.Rows[0]);
        }

        public static Pcb? GetPcbBySerialNumber(string serialNumber)
        {
            string sql = "SELECT * FROM pcbs WHERE serial_number = @serialNumber";
            var parameters = new[] { new NpgsqlParameter("@serialNumber", serialNumber) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            if (dataTable.Rows.Count == 0)
                return null;

            return DataRowToPcb(dataTable.Rows[0]);
        }

        public static int AddPcb(Pcb pcb, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO pcbs (name, serial_number, batch, description, price, total_quantity, 
                          manufacture_date, length, width, layers_count, comment, image_path)
                          VALUES (@name, @serialNumber, @batch, @description, @price, @totalQuantity, 
                          @manufactureDate, @length, @width, @layersCount, @comment, @imagePath)
                          RETURNING id";

            var parameters = new[]
            {
                new NpgsqlParameter("@name", pcb.Name),
                new NpgsqlParameter("@serialNumber", pcb.SerialNumber),
                new NpgsqlParameter("@batch", pcb.Batch ?? (object)DBNull.Value),
                new NpgsqlParameter("@description", pcb.Description ?? (object)DBNull.Value),
                new NpgsqlParameter("@price", pcb.Price),
                new NpgsqlParameter("@totalQuantity", pcb.TotalQuantity),
                new NpgsqlParameter("@manufactureDate", pcb.ManufactureDate ?? (object)DBNull.Value),
                new NpgsqlParameter("@length", pcb.Length ?? (object)DBNull.Value),
                new NpgsqlParameter("@width", pcb.Width ?? (object)DBNull.Value),
                new NpgsqlParameter("@layersCount", pcb.LayersCount ?? (object)DBNull.Value),
                new NpgsqlParameter("@comment", pcb.Comment ?? (object)DBNull.Value),
                new NpgsqlParameter("@imagePath", pcb.ImagePath ?? (object)DBNull.Value)
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

        public static void UpdatePcb(Pcb pcb, NpgsqlTransaction? transaction = null)
        {
            string sql = @"UPDATE pcbs SET name = @name, serial_number = @serialNumber, batch = @batch, 
                          description = @description, price = @price, total_quantity = @totalQuantity, 
                          manufacture_date = @manufactureDate, 
                          length = @length, width = @width, layers_count = @layersCount, 
                          comment = @comment, image_path = @imagePath 
                          WHERE id = @id";

            var parameters = new[]
            {
                new NpgsqlParameter("@name", pcb.Name),
                new NpgsqlParameter("@serialNumber", pcb.SerialNumber),
                new NpgsqlParameter("@batch", pcb.Batch ?? (object)DBNull.Value),
                new NpgsqlParameter("@description", pcb.Description ?? (object)DBNull.Value),
                new NpgsqlParameter("@price", pcb.Price),
                new NpgsqlParameter("@totalQuantity", pcb.TotalQuantity),
                new NpgsqlParameter("@manufactureDate", pcb.ManufactureDate ?? (object)DBNull.Value),
                new NpgsqlParameter("@length", pcb.Length ?? (object)DBNull.Value),
                new NpgsqlParameter("@width", pcb.Width ?? (object)DBNull.Value),
                new NpgsqlParameter("@layersCount", pcb.LayersCount ?? (object)DBNull.Value),
                new NpgsqlParameter("@comment", pcb.Comment ?? (object)DBNull.Value),
                new NpgsqlParameter("@imagePath", pcb.ImagePath ?? (object)DBNull.Value),
                new NpgsqlParameter("@id", pcb.Id)
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

        public static void DeletePcb(int id, NpgsqlTransaction? transaction = null)
        {
            string sql = "DELETE FROM pcbs WHERE id = @id";
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

        // PcbRepository.cs
        public static void DeletePcbWithComponents(int pcbId, NpgsqlTransaction? transaction = null)
        {
            // Получаем информацию о плате и её компонентах
            var pcb = GetPcbById(pcbId);
            if (pcb == null) return;

            var pcbComponents = GetPcbComponents(pcbId, transaction);

            // Возвращаем компоненты на склад
            foreach (var pcbComponent in pcbComponents)
            {
                var component = GetComponentById(pcbComponent.ComponentId, transaction);
                if (component != null)
                {
                    int returnedQuantity = pcbComponent.ComponentCount * pcb.TotalQuantity;
                    component.StockQuantity += returnedQuantity;
                    UpdateComponent(component, transaction);

                    // Запись о движении - возврат компонентов
                    AdditionalRepository.CreateComponentMovement("Поступление",
                        component.Id, returnedQuantity,
                        $"Возврат компонентов после удаления платы \"{pcb.Name}\"",
                        transaction);
                }
            }

            // Удаляем связи компонентов с платой
            string deleteComponentsSql = "DELETE FROM pcb_components WHERE pcb_id = @pcbId";
            var deleteParams = new[] { new NpgsqlParameter("@pcbId", pcbId) };

            if (transaction == null)
                Database.ExecuteNonQuery(deleteComponentsSql, deleteParams);
            else
                Database.ExecuteNonQuery(deleteComponentsSql, transaction, deleteParams);

            // Удаляем саму плату
            DeletePcb(pcbId, transaction);

            // Запись о движении - удаление плат
            AdditionalRepository.CreatePcbMovement("Списание", pcbId, pcb.TotalQuantity,
                $"Удаление платы \"{pcb.Name}\" администратором", transaction);
        }

        // ============ COMPONENT METHODS ==============

        public static List<ComponentCardInfo> GetFilteredComponentsPage(int pageSize, int pageNumber,
            string? nameFilter = null, string? typeFilter = null, int? pcbId = null)
        {
            var components = new List<ComponentCardInfo>();

            int offset = (pageNumber - 1) * pageSize;

            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@limit", pageSize),
                new NpgsqlParameter("@offset", offset)
            };

            string sql = "SELECT components.id, name, manufacturer, type, stock_quantity";

            if (pcbId != null)
            {
                sql += ", component_count, coordinates";
            }

            sql += " FROM components";

            if (pcbId != null)
            {
                sql += " JOIN pcb_components ON components.id = component_id";
            }

            sql += " WHERE 1=1";

            if (pcbId != null)
            {
                sql += " AND pcb_components.pcb_id = @pcbId";
                parameters.Add(new NpgsqlParameter("@pcbId", pcbId.Value));
            }

            if (!string.IsNullOrEmpty(typeFilter) && typeFilter != "Все")
            {
                sql += " AND type = @typeFilter";
                parameters.Add(new NpgsqlParameter("@typeFilter", typeFilter));
            }

            if (!string.IsNullOrEmpty(nameFilter))
            {
                sql += @" AND (name ILIKE @nameFilter)
                  ORDER BY 
                    CASE 
                      WHEN name ILIKE @namePatternStart THEN 1
                      WHEN name ILIKE @namePatternAny THEN 2
                      ELSE 3
                    END,
                    name";
                parameters.Add(new NpgsqlParameter("@nameFilter", $"%{nameFilter}%"));
                parameters.Add(new NpgsqlParameter("@namePatternStart", $"{nameFilter}%"));
                parameters.Add(new NpgsqlParameter("@namePatternAny", $"%{nameFilter}%"));
            }
            else
            {
                sql += " ORDER BY id";
            }

            sql += " LIMIT @limit OFFSET @offset";

            var dataTable = Database.ExecuteDataTable(sql, parameters.ToArray());

            foreach (DataRow row in dataTable.Rows)
            {
                var componentInfo = new ComponentCardInfo(
                    id: Convert.ToInt32(row["id"]),
                    name: row["name"].ToString() ?? "",
                    type: row["type"].ToString() ?? "",
                    manufacturer: row["manufacturer"].ToString(),
                    stockQuantity: Convert.ToInt32(row["stock_quantity"]),
                    pcbCount: pcbId.HasValue ? Convert.ToInt32(row["component_count"]) : null,
                    pcbCoordinates: pcbId.HasValue ? row["coordinates"].ToString() : null
                );
                components.Add(componentInfo);
            }

            return components;
        }

        public static long GetFilteredComponentsCount(string? nameFilter = null,
            string? typeFilter = null, int? pcbId = null)
        {
            string sql = "SELECT COUNT(*) FROM components";
            var parameters = new List<NpgsqlParameter>();

            if (pcbId.HasValue)
            {
                sql += " JOIN pcb_components ON components.id = pcb_components.component_id";
            }

            sql += " WHERE 1=1";

            if (pcbId.HasValue)
            {
                sql += " AND pcb_components.pcb_id = @pcbId";
                parameters.Add(new NpgsqlParameter("@pcbId", pcbId));
            }

            if (!string.IsNullOrEmpty(typeFilter) && typeFilter != "Все")
            {
                sql += " AND type = @typeFilter";
                parameters.Add(new NpgsqlParameter("@typeFilter", typeFilter));
            }

            if (!string.IsNullOrEmpty(nameFilter))
            {
                sql += " AND name ILIKE @nameFilter";
                parameters.Add(new NpgsqlParameter("@nameFilter", $"%{nameFilter}%"));
            }

            return Database.ExecuteScalar<long>(sql, parameters.ToArray());
        }

        public static List<string> GetComponentTypes()
        {
            var types = new List<string> { "Все" };

            string sql = "SELECT DISTINCT type FROM components WHERE type IS NOT NULL AND type != '' ORDER BY type";

            var dataTable = Database.ExecuteDataTable(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                types.Add(row["type"].ToString() ?? "");
            }

            return types;
        }

        public static List<ComponentCardInfo> GetComponentsPage(int pageSize, int pageNumber)
        {
            var components = new List<ComponentCardInfo>();

            int offset = (pageNumber - 1) * pageSize;

            string sql = @"SELECT id, name, manufacturer, type, stock_quantity FROM components 
                          ORDER BY id 
                          LIMIT @limit OFFSET @offset";

            var parameters = new[]
            {
                new NpgsqlParameter("@limit", pageSize),
                new NpgsqlParameter("@offset", offset)
            };

            var dataTable = Database.ExecuteDataTable(sql, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                var componentInfo = new ComponentCardInfo(
                    id: Convert.ToInt32(row["id"]),
                    name: row["name"].ToString() ?? "",
                    type: row["type"].ToString() ?? "",
                    manufacturer: row["manufacturer"].ToString(),
                    stockQuantity: Convert.ToInt32(row["stock_quantity"])
                );
                components.Add(componentInfo);
            }

            return components;
        }

        public static long GetTotalComponentsCount()
        {
            string sql = "SELECT COUNT(*) FROM components";
            return Database.ExecuteScalar<long>(sql);
        }

        public static Component? GetComponentById(int id, NpgsqlTransaction? transaction = null)
        {
            DataTable dataTable;
            string sql = "SELECT * FROM components WHERE id = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id) };

            if (transaction == null)
            {
                dataTable = Database.ExecuteDataTable(sql, parameters);
            }
            else
            {
                dataTable = Database.ExecuteDataTable(sql, transaction, parameters);
            }

            if (dataTable.Rows.Count == 0)
                return null;

            return DataRowToComponent(dataTable.Rows[0]);
        }

        public static int AddComponent(Component component, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO components (name, manufacturer, price, type, stock_quantity)
                          VALUES (@name, @manufacturer, @price, @type, @stockQuantity)
                          RETURNING id";

            var parameters = new[]
            {
                new NpgsqlParameter("@name", component.Name),
                new NpgsqlParameter("@manufacturer", component.Manufacturer ?? (object)DBNull.Value),
                new NpgsqlParameter("@price", component.Price),
                new NpgsqlParameter("@type", component.Type ?? (object)DBNull.Value),
                new NpgsqlParameter("@stockQuantity", component.StockQuantity)
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

        public static void UpdateComponent(Component component, NpgsqlTransaction? transaction = null)
        {
            string sql = @"UPDATE components SET name = @name, manufacturer = @manufacturer, 
                          price = @price, type = @type, stock_quantity = @stockQuantity 
                          WHERE id = @id";

            var parameters = new[]
            {
                new NpgsqlParameter("@name", component.Name),
                new NpgsqlParameter("@manufacturer", component.Manufacturer ?? (object)DBNull.Value),
                new NpgsqlParameter("@price", component.Price),
                new NpgsqlParameter("@type", component.Type ?? (object)DBNull.Value),
                new NpgsqlParameter("@stockQuantity", component.StockQuantity),
                new NpgsqlParameter("@id", component.Id)
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

        public static List<string> GetOtherComponentNames(int pcbId)
        {
            List<string> names = new List<string>();
            string sql = @"SELECT c.name FROM components c WHERE NOT EXISTS (
                          SELECT 1 FROM pcb_components pc WHERE pc.component_id = c.id
                          AND pc.pcb_id = @pcbId) ORDER BY c.name";

            var parameters = new[] { new NpgsqlParameter("@pcbId", pcbId) };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                names.Add(row["name"].ToString() ?? "");
            }

            return names;
        }

        public static int GetComponentIdByName(string name)
        {
            string sql = "SELECT id FROM components WHERE name = @name";
            var parameters = new[] { new NpgsqlParameter("@name", name) };
            return Database.ExecuteScalar<int>(sql, parameters);
        }

        public static void DeleteComponent(int id, NpgsqlTransaction? transaction = null)
        {
            string sql = "DELETE FROM components WHERE id = @id";
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

        // ========== COMPONENT SPECIFICATION METHODS ==========

        public static List<ComponentSpecification> GetComponentSpecifications(int componentId, NpgsqlTransaction? transaction = null)
        {
            string sql = "SELECT * FROM component_specifications WHERE component_id = @componentId";
            var parameters = new[] { new NpgsqlParameter("@componentId", componentId) };
            DataTable dataTable;

            if (transaction == null)
            {
                dataTable = Database.ExecuteDataTable(sql, parameters);
            }
            else
            {
                dataTable = Database.ExecuteDataTable(sql, transaction, parameters);
            }

            return DataTableToComponentSpecificationList(dataTable);
        }

        public static void AddComponentSpecification(ComponentSpecification specification, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO component_specifications (component_id, specification, specification_value)
                          VALUES (@componentId, @specification, @specificationValue)";

            var parameters = new[]
            {
                new NpgsqlParameter("@componentId", specification.ComponentId),
                new NpgsqlParameter("@specification", specification.Specification),
                new NpgsqlParameter("@specificationValue", specification.SpecificationValue)
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

        public static void DeleteComponentSpecification(int id, NpgsqlTransaction? transaction = null)
        {
            string sql = "DELETE FROM component_specifications WHERE id = @id";
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

        public static void DeleteComponentWithCleanup(int componentId, NpgsqlTransaction? transaction = null)
        {
            var component = GetComponentById(componentId, transaction);
            if (component == null) return;

            string deleteSpecsSql = "DELETE FROM component_specifications WHERE component_id = @componentId";
            var deleteSpecsParams = new[] { new NpgsqlParameter("@componentId", componentId) };

            if (transaction == null)
                Database.ExecuteNonQuery(deleteSpecsSql, deleteSpecsParams);
            else
                Database.ExecuteNonQuery(deleteSpecsSql, transaction, deleteSpecsParams);

            // Удаляем связи с платами
            string deletePcbLinksSql = "DELETE FROM pcb_components WHERE component_id = @componentId";
            var deletePcbLinksParams = new[] { new NpgsqlParameter("@componentId", componentId) };

            if (transaction == null)
                Database.ExecuteNonQuery(deletePcbLinksSql, deletePcbLinksParams);
            else
                Database.ExecuteNonQuery(deletePcbLinksSql, transaction, deletePcbLinksParams);

            DeleteComponent(componentId, transaction);

            AdditionalRepository.CreateComponentMovement("Списание", componentId, component.StockQuantity,
                $"Удаление компонента \"{component.Name}\" администратором", transaction);
        }

        // ========== PCB COMPONENT METHODS ==========

        public static List<PcbComponent> GetPcbComponents(int pcbId, NpgsqlTransaction? transaction = null)
        {
            DataTable dataTable;
            string sql = "SELECT * FROM pcb_components WHERE pcb_id = @pcbId";
            var parameters = new[] { new NpgsqlParameter("@pcbId", pcbId) };

            if (transaction == null)
            {
                dataTable = Database.ExecuteDataTable(sql, parameters);
            }
            else
            {
                dataTable = Database.ExecuteDataTable(sql, transaction, parameters);
            }
            
            return DataTableToPcbComponentList(dataTable);
        }

        public static List<Pcb> GetComponentPcbs(int componentId, NpgsqlTransaction? transaction = null)
        {
            DataTable dataTable;
            string sql = @"SELECT * FROM pcbs JOIN pcb_components ON pcbs.id = pcb_id
                          WHERE component_id = @componentId";
            var parameters = new[] { new NpgsqlParameter("@componentId", componentId) };

            if (transaction == null)
            {
                dataTable = Database.ExecuteDataTable(sql, parameters);
            }
            else
            {
                dataTable = Database.ExecuteDataTable(sql, transaction, parameters);
            }

            return DataTableToComponentPcbList(dataTable);
        }

        public static PcbComponent GetPcbComponent(int pcbId, int componentId)
        {
            string sql = "SELECT * FROM pcb_components WHERE pcb_id = @pcbId AND component_id = @componentId";
            var parameters = new[]
            {
                new NpgsqlParameter("@pcbId", pcbId),
                new NpgsqlParameter("@componentId", componentId)
            };

            var dataTable = Database.ExecuteDataTable(sql, parameters);
            return new PcbComponent(
                pcbId: Convert.ToInt32(dataTable.Rows[0]["pcb_id"]),
                componentId: Convert.ToInt32(dataTable.Rows[0]["component_id"]),
                componentCount: Convert.ToInt32(dataTable.Rows[0]["component_count"]),
                coordinates: dataTable.Rows[0]["coordinates"].ToString()
                );
        }

        public static void AddPcbComponent(PcbComponent pcbComponent, NpgsqlTransaction? transaction = null)
        {
            string sql = @"INSERT INTO pcb_components (pcb_id, component_id, component_count, coordinates)
                          VALUES (@pcbId, @componentId, @componentCount, @coordinates)";

            var parameters = new[]
            {
                new NpgsqlParameter("@pcbId", pcbComponent.PcbId),
                new NpgsqlParameter("@componentId", pcbComponent.ComponentId),
                new NpgsqlParameter("@componentCount", pcbComponent.ComponentCount),
                new NpgsqlParameter("@coordinates", pcbComponent.Coordinates ?? (object)DBNull.Value)
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

        public static void UpdatePcbComponent(PcbComponent pcbComponent, NpgsqlTransaction? transaction = null)
        {
            string sql = @"UPDATE pcb_components SET component_count = @componentCount, coordinates = @coordinates
                            WHERE pcb_id = @pcbId AND component_id = @componentId";

            var parameters = new[]
            {
                new NpgsqlParameter("@pcbId", pcbComponent.PcbId),
                new NpgsqlParameter("@componentId", pcbComponent.ComponentId),
                new NpgsqlParameter("@componentCount", pcbComponent.ComponentCount),
                new NpgsqlParameter("@coordinates", pcbComponent.Coordinates ?? (object)DBNull.Value)
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

        public static void DeletePcbComponent(int pcbId, int componentId)
        {
            string sql = "DELETE FROM pcb_components WHERE pcb_id = @pcbId AND component_id = @componentId";
            var parameters = new[] 
            { 
                new NpgsqlParameter("@pcbId", pcbId),
                new NpgsqlParameter("@componentId", componentId)
            };
            Database.ExecuteNonQuery(sql, parameters);
        }

        // ========== HELPER METHODS ==========

        private static List<Pcb> DataTableToPcbList(DataTable dataTable)
        {
            var pcbs = new List<Pcb>();
            foreach (DataRow row in dataTable.Rows)
            {
                pcbs.Add(DataRowToPcb(row));
            }
            return pcbs;
        }

        private static Pcb DataRowToPcb(DataRow row)
        {
            return new Pcb(
                id: Convert.ToInt32(row["id"]),
                name: row["name"].ToString() ?? "",
                serialNumber: row["serial_number"].ToString() ?? "",
                batch: row["batch"].ToString(),
                description: row["description"].ToString(),
                price: Convert.ToDecimal(row["price"]),
                totalQuantity: Convert.ToInt32(row["total_quantity"]),
                manufactureDate: row["manufacture_date"] == DBNull.Value ? null : Convert.ToDateTime(row["manufacture_date"]),
                length: row["length"] == DBNull.Value ? null : Convert.ToDecimal(row["length"]),
                width: row["width"] == DBNull.Value ? null : Convert.ToDecimal(row["width"]),
                layersCount: row["layers_count"] == DBNull.Value ? null : Convert.ToInt32(row["layers_count"]),
                comment: row["comment"].ToString(),
                imagePath: row["image_path"].ToString()
            );
        }

        private static List<Component> DataTableToComponentList(DataTable dataTable)
        {
            var components = new List<Component>();
            foreach (DataRow row in dataTable.Rows)
            {
                components.Add(DataRowToComponent(row));
            }
            return components;
        }

        private static Component DataRowToComponent(DataRow row)
        {
            return new Component(
                id: Convert.ToInt32(row["id"]),
                name: row["name"].ToString() ?? "",
                manufacturer: row["manufacturer"].ToString(),
                price: Convert.ToDecimal(row["price"]),
                type: row["type"].ToString(),
                stockQuantity: Convert.ToInt32(row["stock_quantity"]),
                createdAt: Convert.ToDateTime(row["created_at"])
            );
        }

        private static List<ComponentSpecification> DataTableToComponentSpecificationList(DataTable dataTable)
        {
            var specifications = new List<ComponentSpecification>();
            foreach (DataRow row in dataTable.Rows)
            {
                specifications.Add(new ComponentSpecification(
                    id: Convert.ToInt32(row["id"]),
                    componentId: Convert.ToInt32(row["component_id"]),
                    specification: row["specification"].ToString() ?? "",
                    specificationValue: row["specification_value"].ToString() ?? ""
                ));
            }
            return specifications;
        }

        private static List<PcbComponent> DataTableToPcbComponentList(DataTable dataTable)
        {
            var pcbComponents = new List<PcbComponent>();
            foreach (DataRow row in dataTable.Rows)
            {
                pcbComponents.Add(new PcbComponent(
                    pcbId: Convert.ToInt32(row["pcb_id"]),
                    componentId: Convert.ToInt32(row["component_id"]),
                    componentCount: Convert.ToInt32(row["component_count"]),
                    coordinates: row["coordinates"].ToString()
                ));
            }
            return pcbComponents;
        }

        private static List<Pcb> DataTableToComponentPcbList(DataTable dataTable)
        {
            var pcbs = new List<Pcb>();
            foreach (DataRow row in dataTable.Rows)
            {
                pcbs.Add(DataRowToPcb(row));
            }
            return pcbs;
        }
    }
}