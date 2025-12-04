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
    public partial class EditPcbComponentForm : Form
    {
        private PcbComponent? _pcbComponent;
        private bool _isEditMode;
        private int _pcbId;
        private int? _componentId;

        public EditPcbComponentForm(int pcbId, int? componentId = null, string? componentName = null)
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            _isEditMode = componentId != null;
            _pcbId = pcbId;
            _componentId = componentId;

            if (_isEditMode)
            {
                ComponentComboBox.Enabled = false;
                ComponentComboBox.Text = componentName;
                LoadData(componentId!.Value);
                if (Settings.IsAdmin)
                {
                    DeleteButton.Visible = true;
                }
            }
            else
            {
                FillComboBox();
            }
        }

        private void LoadData(int componentId)
        {
            try
            {
                _pcbComponent = PcbRepository.GetPcbComponent(_pcbId, componentId);
                if (_pcbComponent == null)
                {
                    Utils.ShowErrorMessage("Не удалось загрузить компонент");
                    Close();
                }
                else
                {
                    CountNumeric.Value = _pcbComponent.ComponentCount;
                    CoordinatesTextBox.Text = _pcbComponent.Coordinates;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Не удалось загрузить компонент:\n{ex.Message}");
                Close();
            }
        }

        private void FillComboBox()
        {
            try
            {
                var components = PcbRepository.GetOtherComponentNames(_pcbId);
                foreach (var component in components)
                {
                    ComponentComboBox.Items.Add(component);
                }
                ComponentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                if (ComponentComboBox.Items.Count > 0)
                {
                    ComponentComboBox.SelectedIndex = 0;
                }
                else
                {
                    Utils.ShowInfoMessage("На плате уже есть все доступные компоненты");
                    Close();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Не удалось загрузить имена компонентов:\n{ex.Message}");
                Close();
            }

        }

        private bool ValidateData()
        {
            return ComponentComboBox.Text != null;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (Utils.ShowQuestionMessage() == DialogResult.Yes)
            {
                Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                Utils.ShowErrorMessage("Не заполнены все необходимые поля!");
                return;
            }
            try
            {
                Database.TransactionManager.ExecuteInTransaction(transaction =>
                {
                    var pcb = PcbRepository.GetPcbById(_pcbId);
                    int componentId = PcbRepository.GetComponentIdByName(ComponentComboBox.Text);
                    var component = PcbRepository.GetComponentById(componentId);
                    if (pcb == null)
                    {
                        throw new Exception("Не удалось получить плату компонента");
                    }
                    if (component == null)
                    {
                        throw new Exception("Не удалось получить компонент");
                    }

                    int oldStock = _pcbComponent == null ? 0 : _pcbComponent.ComponentCount;
                    _pcbComponent = new PcbComponent(_pcbId, _componentId.HasValue ? _componentId.Value :
                    PcbRepository.GetComponentIdByName(ComponentComboBox.Text),
                    Convert.ToInt32(CountNumeric.Value), CoordinatesTextBox.Text);

                    int newStock = _pcbComponent.ComponentCount;
                    int stockDifference = newStock - oldStock;
                    if (stockDifference != 0)
                    {
                        int componentStockDifference = stockDifference * pcb.TotalQuantity;
                        int oldComponentStock = component.StockQuantity;
                        component.StockQuantity -= componentStockDifference;

                        if (component.StockQuantity < 0)
                        {
                            throw new Exception($"Недостаточно компонентов на складе.\n" +
                            $"Не хватает {-component.StockQuantity} ед. компонента \"{component.Name}\"\n" +
                            $"Требуется для изменения: {componentStockDifference}, доступно: {oldComponentStock}");
                        }

                        PcbRepository.UpdateComponent(component, transaction);

                        // Добавляем запись о движении компонентов
                        if (componentStockDifference != 0)
                        {
                            string movementType = componentStockDifference > 0 ? "Списание" : "Поступление";
                            int movementQuantity = Math.Abs(componentStockDifference);
                            AdditionalRepository.CreateComponentMovement(movementType, componentId, movementQuantity,
                                $"{movementType.ToLower()} со склада {movementQuantity} компонентов \"{component.Name}\" для платы \"{pcb.Name}\"", transaction);
                        }
                    }

                    if (_isEditMode)
                    {
                        if (_pcbComponent == null)
                        {
                            Utils.ShowErrorMessage($"Ошибка при сохранении данных");
                            Close();
                        }
                        else
                        {
                            PcbRepository.UpdatePcbComponent(_pcbComponent, transaction);
                        }
                    }
                    else
                    {
                        if (_pcbComponent == null)
                        {
                            Utils.ShowErrorMessage($"Ошибка при сохранении данных");
                            Close();
                        }
                        else
                        {
                            PcbRepository.AddPcbComponent(_pcbComponent, transaction);
                        }
                    }
                });
                Utils.ShowInfoMessage("Данные сохранены успешно");
                Close();
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Ошибка при сохранении данных: {ex.Message}");
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
                        PcbRepository.DeletePcbComponent(_pcbId, _componentId!.Value);
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
