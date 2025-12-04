using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ElectronicsFactory
{
    public partial class EditOrderForm : Form
    {
        private int? _orderId;
        private bool _isEditMode;
        private BindingList<OrderItemDisplay> _orderItems;

        public EditOrderForm(int? orderId = null)
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            _orderId = orderId;
            _isEditMode = orderId.HasValue;

            InitializeDataGridView();
            LoadComboBoxes();

            if (_isEditMode)
            {
                LoadData(orderId!.Value);
                if (Settings.IsAdmin)
                {
                    DeleteButton.Visible = true;
                }
            }
            else
            {
                InitializeNewOrder();
            }
        }

        private void InitializeDataGridView()
        {
            // Настройка внешнего вида
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // Создание колонок
            var columns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "PcbName",
                    HeaderText = "Название платы",
                    DataPropertyName = "PcbName",
                    ReadOnly = true,
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Количество",
                    DataPropertyName = "Quantity",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PricePerPcb",
                    HeaderText = "Цена за шт., руб.",
                    DataPropertyName = "PricePerPcb",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalPrice",
                    HeaderText = "Сумма, руб.",
                    DataPropertyName = "TotalPrice",
                    ReadOnly = true,
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                }
            };

            dataGridView1.Columns.AddRange(columns);

            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            dataGridView1.UserDeletingRow += DataGridView1_UserDeletingRow;
            dataGridView1.DataError += DataGridView1_DataError;
        }

        private void LoadComboBoxes()
        {
            // Загрузка клиентов
            var clients = ClientRepository.GetAllClientsForComboBox();
            ClientComboBox.DataSource = clients;
            ClientComboBox.DisplayMember = "Name";
            ClientComboBox.ValueMember = "Id";

            // Загрузка статусов
            StatusComboBox.Items.AddRange(new object[]
            {
                "Не подтверждён",
                "Оплачен",
                "Готов",
                "Отправлен"
            });

            // Загрузка плат для добавления
            var pcbs = PcbRepository.GetAllPcbsForComboBox();
            PcbComboBox.DataSource = pcbs;
            PcbComboBox.DisplayMember = "Name";
            PcbComboBox.ValueMember = "Id";
        }

        private void LoadData(int orderId)
        {
            try
            {
                var order = OrderRepository.GetOrderById(orderId);
                if (order == null)
                {
                    Utils.ShowErrorMessage("Заказ не найден");
                    Close();
                    return;
                }

                // Заполняем основные данные заказа
                ClientComboBox.SelectedValue = order.ClientId;
                StatusComboBox.Text = order.Status;
                TotalAmountLabel.Text = order.TotalAmount?.ToString("N2") ?? "0";

                if (order.ShipmentDate.HasValue)
                {
                    ShipmentDatePicker.Value = order.ShipmentDate.Value;
                    ShipmentDateCheckBox.Checked = true;
                }

                TransportCompanyTextBox.Text = order.TransportCompany ?? "";

                // Загружаем предметы заказа в DataGridView
                LoadOrderItems(orderId);
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Ошибка при загрузке данных: {ex.Message}");
                Close();
            }
        }

        private void LoadOrderItems(int orderId)
        {
            var orderItems = OrderRepository.GetOrderItems(orderId);
            _orderItems = new BindingList<OrderItemDisplay>();

            foreach (var orderItem in orderItems)
            {
                var pcb = PcbRepository.GetPcbById(orderItem.PcbId);
                if (pcb != null)
                {
                    _orderItems.Add(new OrderItemDisplay
                    {
                        Id = orderItem.Id,
                        PcbId = orderItem.PcbId,
                        PcbName = pcb.Name,
                        Quantity = orderItem.Quantity,
                        PricePerPcb = orderItem.PricePerPcb,
                        TotalPrice = orderItem.Quantity * orderItem.PricePerPcb
                    });
                }
            }

            dataGridView1.DataSource = _orderItems;
            UpdateTotalAmount();
        }

        private void InitializeNewOrder()
        {
            StatusComboBox.SelectedIndex = 0;
            _orderItems = new BindingList<OrderItemDisplay>();
            dataGridView1.DataSource = _orderItems;
            ShipmentDateCheckBox.Checked = false;
            ShipmentDatePicker.Enabled = false;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Quantity"].Index)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.DataBoundItem is OrderItemDisplay item)
                {
                    // Валидация количества
                    if (item.Quantity <= 0)
                    {
                        Utils.ShowErrorMessage("Количество должно быть больше 0");
                        item.Quantity = 1;
                        dataGridView1.Refresh();
                    }

                    // Пересчет суммы
                    item.TotalPrice = item.Quantity * item.PricePerPcb;
                    dataGridView1.InvalidateRow(e.RowIndex);
                    UpdateTotalAmount();
                }
            }
        }

        private void DataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Utils.ShowQuestionMessage("Удалить выбранную позицию из заказа?") != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Utils.ShowErrorMessage("Ошибка ввода данных. Проверьте правильность введенных значений");
            e.ThrowException = false;
        }

        private void UpdateTotalAmount()
        {
            decimal total = _orderItems.Sum(item => item.TotalPrice);
            TotalAmountLabel.Text = total.ToString("N2");
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            if (PcbComboBox.SelectedItem == null)
            {
                Utils.ShowErrorMessage("Выберите плату для добавления");
                return;
            }

            var selectedPcb = (PcbComboBox.SelectedItem as dynamic)?.Pcb;
            if (selectedPcb == null) return;

            // Проверяем, нет ли уже этой платы в заказе
            var existingItem = _orderItems.FirstOrDefault(item => item.PcbId == selectedPcb.Id);
            if (existingItem != null)
            {
                Utils.ShowErrorMessage("Эта плата уже есть в заказе. Измените количество в существующей строке");
                return;
            }

            var newItem = new OrderItemDisplay
            {
                PcbId = selectedPcb.Id,
                PcbName = selectedPcb.Name,
                Quantity = (int)QuantityNumeric.Value,
                PricePerPcb = selectedPcb.Price,
                TotalPrice = selectedPcb.Price
            };

            _orderItems.Add(newItem);
            dataGridView1.DataSource = new BindingList<OrderItemDisplay>(_orderItems);
            UpdateTotalAmount();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            try
            {
                Database.TransactionManager.ExecuteInTransaction(transaction =>
                {
                    // Получаем старые данные заказа для сравнения
                    List<OrderItem> oldOrderItems = new List<OrderItem>();
                    if (_isEditMode && _orderId.HasValue)
                    {
                        oldOrderItems = OrderRepository.GetOrderItems(_orderId.Value);
                    }

                    // Создаем/обновляем заказ
                    var order = new Order(
                        _orderId ?? 0,
                        (int)ClientComboBox.SelectedValue,
                        DateTime.Now,
                        StatusComboBox.Text,
                        decimal.Parse(TotalAmountLabel.Text),
                        ShipmentDateCheckBox.Checked ? ShipmentDatePicker.Value : (DateTime?)null,
                        TransportCompanyTextBox.Text
                    );

                    if (_isEditMode)
                    {
                        OrderRepository.UpdateOrder(order, transaction);
                    }
                    else
                    {
                        _orderId = OrderRepository.AddOrder(order, transaction);
                    }

                    // Обновляем остатки плат и сохраняем предметы заказа
                    UpdatePcbStocks(oldOrderItems, transaction);
                    SaveOrderItems(transaction);
                });

                Utils.ShowInfoMessage("Заказ сохранен успешно");
                Close();
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Ошибка при сохранении заказа:\n{ex.Message}");
            }
        }

        private void UpdatePcbStocks(List<OrderItem> oldOrderItems, NpgsqlTransaction transaction)
        {
            if (!_orderId.HasValue) return;

            // Создаем словари для быстрого доступа
            var oldItemsDict = oldOrderItems.ToDictionary(item => item.PcbId, item => item);
            var newItemsDict = _orderItems.ToDictionary(item => item.PcbId, item => item);

            // Обрабатываем все платы, которые были или есть в заказе
            var allPcbIds = oldItemsDict.Keys.Union(newItemsDict.Keys).Distinct();

            foreach (var pcbId in allPcbIds)
            {
                int oldQuantity = oldItemsDict.ContainsKey(pcbId) ? oldItemsDict[pcbId].Quantity : 0;
                int newQuantity = newItemsDict.ContainsKey(pcbId) ? newItemsDict[pcbId].Quantity : 0;
                int quantityDifference = newQuantity - oldQuantity;

                if (quantityDifference != 0)
                {
                    UpdatePcbStock(pcbId, quantityDifference, transaction);
                }
            }
        }

        private void UpdatePcbStock(int pcbId, int quantityDifference, NpgsqlTransaction transaction)
        {
            var pcb = PcbRepository.GetPcbById(pcbId);
            if (pcb == null)
            {
                throw new Exception($"Плата с ID {pcbId} не найдена");
            }

            if (quantityDifference > pcb.TotalQuantity)
            {
                throw new Exception(
                    $"Недостаточно плат \"{pcb.Name}\" на складе для выполнения заказа.\n" +
                    $"Не хватает {quantityDifference - pcb.TotalQuantity} шт. плат");
            }

            int oldQuantity = pcb.TotalQuantity;
            pcb.TotalQuantity -= quantityDifference;

            PcbRepository.UpdatePcb(pcb, transaction);

            // Добавляем запись о движении при списании плат для заказа
            if (quantityDifference > 0)
            {
                AdditionalRepository.CreatePcbMovement("Списание", pcbId, quantityDifference,
                    $"Списание со склада {quantityDifference} плат \"{pcb.Name}\" для заказа", transaction);
            }
        }

        private void SaveOrderItems(NpgsqlTransaction transaction)
        {
            if (!_orderId.HasValue) return;

            // Удаляем старые позиции заказа
            OrderRepository.DeleteAllOrderItems(_orderId.Value, transaction);

            // Добавляем новые позиции
            foreach (var item in _orderItems)
            {
                var orderItem = new OrderItem(
                    id: 0,
                    orderId: _orderId.Value,
                    pcbId: item.PcbId,
                    quantity: item.Quantity,
                    pricePerPcb: item.PricePerPcb
                );

                OrderRepository.AddOrderItem(orderItem, transaction);
            }
        }

        private bool ValidateData()
        {
            if (ClientComboBox.SelectedValue == null)
            {
                Utils.ShowErrorMessage("Выберите клиента");
                return false;
            }

            if (string.IsNullOrEmpty(StatusComboBox.Text))
            {
                Utils.ShowErrorMessage("Выберите статус заказа");
                return false;
            }

            if (_orderItems.Count == 0)
            {
                Utils.ShowErrorMessage("Добавьте хотя бы одну позицию в заказ");
                return false;
            }

            // Проверяем, что все количества положительные
            foreach (var item in _orderItems)
            {
                if (item.Quantity <= 0)
                {
                    Utils.ShowErrorMessage($"Количество для платы '{item.PcbName}' должно быть больше 0");
                    return false;
                }
            }

            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (Utils.ShowQuestionMessage() == DialogResult.Yes)
            {
                Close();
            }
        }

        private void ShipmentDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ShipmentDatePicker.Enabled = ShipmentDateCheckBox.Checked;
            if (!ShipmentDateCheckBox.Checked)
            {
                ShipmentDatePicker.Value = DateTime.Now;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Utils.ShowQuestionMessage("Вы уверены, что хотите удалить эту запись?") == DialogResult.Yes)
            {
                try
                {
                    Database.TransactionManager.ExecuteInTransaction(transaction =>
                    {
                        OrderRepository.DeleteOrderWithRestoreStock(_orderId!.Value, transaction);
                    });

                    Utils.ShowInfoMessage("Запись удалена успешно");
                    Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowErrorMessage($"Ошибка при удалении:\n{ex.Message}");
                }
            }
        }
    }

    class OrderItemDisplay
    {
        public int Id { get; set; }
        public int PcbId { get; set; }
        public string PcbName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerPcb { get; set; }
        public decimal TotalPrice { get; set; }
    }
}