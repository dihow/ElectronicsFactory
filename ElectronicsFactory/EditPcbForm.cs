using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicsFactory
{
    public partial class EditPcbForm : Form
    {
        private int? _pcbId;
        private Pcb? _pcb;
        private bool _isEditMode;
        private string? _imagePath;

        public EditPcbForm(int? pcbId = null)
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            _pcbId = pcbId;
            _isEditMode = pcbId != null;

            if (_isEditMode)
            {
                LoadData();
                FillFields();
                if (Settings.IsAdmin)
                {
                    DeleteButton.Visible = true;
                }
            }
        }

        private void LoadData()
        {
            _pcb = PcbRepository.GetPcbById(_pcbId!.Value);
            if (_pcb == null)
            {
                Utils.ShowErrorMessage("Не удалось загрузить печатную плату");
                Close();
            }
        }

        private void FillFields()
        {
            if (_pcb != null)
            {
                NameTextBox.Text = _pcb.Name;
                SerialNumberTextBox.Text = _pcb.SerialNumber;
                BatchTextBox.Text = _pcb.Batch;
                DescriptionTextBox.Text = _pcb.Description;
                PriceNumeric.Value = _pcb.Price;
                TotalQuantity.Value = _pcb.TotalQuantity;
                ManufactureDatePicker.Value = _pcb.ManufactureDate ?? DateTime.Now;
                LengthNumeric.Value = _pcb.Length ?? 0;
                WidthNumeric.Value = _pcb.Width ?? 0;
                LayersNumeric.Value = _pcb.LayersCount ?? 0;
                CommentTextBox.Text = _pcb.Comment;
                if (_pcb.ImagePath != null && _pcb.ImagePath != "")
                {
                    PcbImage.ImageLocation = _pcb.ImagePath;
                }
            }
            else
            {
                Utils.ShowErrorMessage("Не удалось загрузить печатную плату");
                Close();
            }
        }

        private bool ValidateData()
        {
            return (NameTextBox.Text != "") && (SerialNumberTextBox.Text != "");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                Utils.ShowErrorMessage("Не заполнены необходимые поля!");
                return;
            }

            try
            {
                Database.TransactionManager.ExecuteInTransaction(transaction =>
                {
                    if (!_isEditMode)
                    {
                        _pcbId = 0;
                    }

                    int oldStock = _isEditMode ? _pcb!.TotalQuantity : 0;
                    int newStock = (int)TotalQuantity.Value;
                    int stockDifference = newStock - oldStock;

                    if (_isEditMode && stockDifference != 0)
                    {
                        UpdateComponentStocks(_pcbId!.Value, stockDifference, transaction);
                    }

                    _pcb = new Pcb(
                        _pcbId!.Value, NameTextBox.Text, SerialNumberTextBox.Text,
                        BatchTextBox.Text, DescriptionTextBox.Text, PriceNumeric.Value,
                        newStock, ManufactureDatePicker.Value,
                        LengthNumeric.Value, WidthNumeric.Value, (int)LayersNumeric.Value,
                        CommentTextBox.Text, _imagePath
                    );

                    if (_isEditMode)
                    {
                        PcbRepository.UpdatePcb(_pcb, transaction);

                        if (stockDifference != 0)
                        {
                            AdditionalRepository.CreatePcbStockMovement(_pcb.Id, oldStock, newStock, transaction);
                        }
                    }
                    else
                    {
                        _pcb.Id = PcbRepository.AddPcb(_pcb, transaction);
                        
                        if (newStock > 0)
                        {
                            AdditionalRepository.CreatePcbMovement("Поступление", _pcb.Id, newStock,
                                $"Поступление на склад {newStock} плат \"{_pcb.Name}\"", transaction);
                        }
                    }
                });
                Utils.ShowInfoMessage("Данные были сохранены успешно");
                Close();
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void UpdateComponentStocks(int pcbId, int stockDifference, NpgsqlTransaction transaction)
        {
            var pcbComponents = PcbRepository.GetPcbComponents(pcbId, transaction);

            foreach (var pcbComponent in pcbComponents)
            {
                var component = PcbRepository.GetComponentById(pcbComponent.ComponentId, transaction);
                if (component == null)
                {
                    throw new Exception($"Компонент с ID {pcbComponent.ComponentId} не найден");
                }

                int componentStockDifference = stockDifference * pcbComponent.ComponentCount;
                int newComponentStock = component.StockQuantity - componentStockDifference;

                if (newComponentStock < 0)
                {
                    throw new Exception(
                        $"Недостаточно компонентов на складе.\n" +
                        $"Не хватает {-newComponentStock} ед. компонента \"{component.Name}\"\n" +
                        $"Требуется для изменения: {componentStockDifference}, доступно: {component.StockQuantity}");
                }

                component.StockQuantity = newComponentStock;

                PcbRepository.UpdateComponent(component, transaction);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (Utils.ShowQuestionMessage() == DialogResult.Yes)
            {
                Close();
            }
        }

        private void AddQuantityButton_Click(object sender, EventArgs e)
        {
            TotalQuantity.Value += AddQuantityNumeric.Value;
            AddQuantityNumeric.Value = 0;
        }

        private void PcbImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите изображение печатной платы";
                openFileDialog.Filter = "Изображения (*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg; *.jpeg; *.png; *.bmp; *.gif|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.ValidateNames = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _imagePath = openFileDialog.FileName;

                        PcbImage.Image?.Dispose();
                        PcbImage.Image = Image.FromFile(_imagePath);
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowErrorMessage($"Не удалось загрузить изображение:\n{ex.Message}");
                        _imagePath = null;
                        PcbImage.Image = Properties.Resources.circuit_placeholder;
                    }
                }
            }
        }

        private void ComponentsButton_Click(object sender, EventArgs e)
        {
            new ComponentsListForm(_pcbId).ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Utils.ShowQuestionMessage("Вы уверены, что хотите удалить эту запись?") == DialogResult.Yes)
            {
                try
                {
                    Database.TransactionManager.ExecuteInTransaction(transaction =>
                    {
                        PcbRepository.DeletePcbWithComponents(_pcbId!.Value, transaction);
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
}