using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ElectronicsFactory
{
    public partial class EditComponentForm : Form
    {
        private int? _componentId;
        private Component? _component;
        private bool _isEditMode;
        private List<ComponentSpecification> _specifications;
        private ComponentType _currentComponentType;

        public EditComponentForm(int? componentId = null)
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            _componentId = componentId;
            _isEditMode = componentId != null;
            _specifications = new List<ComponentSpecification>();

            if (_isEditMode)
            {
                LoadData();
                FillFields();
                if (Settings.IsAdmin)
                {
                    DeleteButton.Visible = true;
                }
            }
            else
            {
                // Устанавливаем тип по умолчанию для нового компонента
                TypeComboBox.SelectedIndex = 0;
            }
        }

        private void LoadData()
        {
            try
            {
                _component = PcbRepository.GetComponentById(_componentId!.Value);
                if (_component == null)
                {
                    Utils.ShowErrorMessage("Не удалось загрузить компонент");
                    Close();
                }

                // Загружаем спецификации
                _specifications = PcbRepository.GetComponentSpecifications(_componentId.Value);

                // Определяем тип компонента
                _currentComponentType = MapComponentType(_component.Type);
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Не удалось загрузить компонент:\n{ex.Message}");
                Close();
            }
        }

        private ComponentType MapComponentType(string type)
        {
            return type?.ToLower() switch
            {
                "резистор" => ComponentType.Resistor,
                "конденсатор" => ComponentType.Capacitor,
                "диод" => ComponentType.Diode,
                "транзистор" => ComponentType.Transistor,
                "микроконтроллер" => ComponentType.Microcontroller,
                _ => ComponentType.Other
            };
        }

        private string MapComponentType(ComponentType type)
        {
            return type switch
            {
                ComponentType.Resistor => "Резистор",
                ComponentType.Capacitor => "Конденсатор",
                ComponentType.Diode => "Диод",
                ComponentType.Transistor => "Транзистор",
                ComponentType.Microcontroller => "Микроконтроллер",
                _ => "Другое"
            };
        }

        private void FillFields()
        {
            if (_component != null)
            {
                NameTextBox.Text = _component.Name;
                ManufacturerTextBox.Text = _component.Manufacturer ?? "";
                PriceNumeric.Value = _component.Price;
                StockQuantity.Value = _component.StockQuantity;

                // Устанавливаем тип и обновляем спецификации
                TypeComboBox.SelectedItem = _component.Type;
                LoadSpecificationsFromDatabase();
            }
        }

        private void LoadSpecificationsFromDatabase()
        {
            // Очищаем NumericUpDown
            FirstSpecificationNumeric.Value = 0;
            SecondSpecificationNumeric.Value = 0;
            ThirdSpecificationNumeric.Value = 0;

            // Заполняем значения из спецификаций
            foreach (var spec in _specifications)
            {
                if (decimal.TryParse(spec.SpecificationValue, out decimal value))
                {
                    switch (spec.Specification)
                    {
                        case ComponentSpecification.RESISTANCE:
                        case ComponentSpecification.CAPACITANCE:
                        case ComponentSpecification.VOLTAGE_DROP:
                            FirstSpecificationNumeric.Value = value;
                            break;
                        case ComponentSpecification.TOLERANCE:
                        case ComponentSpecification.VOLTAGE:
                        case ComponentSpecification.REVERSE_VOLTAGE:
                            SecondSpecificationNumeric.Value = value;
                            break;
                        case ComponentSpecification.POWER:
                        case ComponentSpecification.MAX_TEMPERATURE:
                        case ComponentSpecification.FORWARD_CURRENT:
                            ThirdSpecificationNumeric.Value = value;
                            break;
                    }
                }
            }
        }

        private void ChangeSpecifications(ComponentType type)
        {
            _currentComponentType = type;

            switch (type)
            {
                case ComponentType.Resistor:
                    SpecificationsGroupBox.Text = "Характеристики резистора";

                    FirstSpecificationLabel.Text = "Сопротивление, Ом:";
                    SecondSpecificationLabel.Text = "Допуск, %:";
                    ThirdSpecificationLabel.Text = "Мощность, Вт:";

                    FirstSpecificationNumeric.DecimalPlaces = 2;
                    SecondSpecificationNumeric.DecimalPlaces = 1;
                    ThirdSpecificationNumeric.DecimalPlaces = 2;

                    FirstSpecificationNumeric.Maximum = 10000000; // 10 МОм
                    SecondSpecificationNumeric.Maximum = 20; // 20%
                    ThirdSpecificationNumeric.Maximum = 100; // 100 Вт
                    break;

                case ComponentType.Capacitor:
                    SpecificationsGroupBox.Text = "Характеристики конденсатора";

                    FirstSpecificationLabel.Text = "Ёмкость, мкФ:";
                    SecondSpecificationLabel.Text = "Напряжение, В:";
                    ThirdSpecificationLabel.Text = "Макс. температура, °C:";

                    FirstSpecificationNumeric.DecimalPlaces = 2;
                    SecondSpecificationNumeric.DecimalPlaces = 0;
                    ThirdSpecificationNumeric.DecimalPlaces = 0;

                    FirstSpecificationNumeric.Maximum = 100000; // 100 000 мкФ
                    SecondSpecificationNumeric.Maximum = 1000; // 1000 В
                    ThirdSpecificationNumeric.Maximum = 200; // 200°C
                    break;

                case ComponentType.Diode:
                    SpecificationsGroupBox.Text = "Характеристики диода";

                    FirstSpecificationLabel.Text = "Падение напряжения, В:";
                    SecondSpecificationLabel.Text = "Обратное напряжение, В:";
                    ThirdSpecificationLabel.Text = "Прямой ток, А:";

                    FirstSpecificationNumeric.DecimalPlaces = 2;
                    SecondSpecificationNumeric.DecimalPlaces = 0;
                    ThirdSpecificationNumeric.DecimalPlaces = 3;

                    FirstSpecificationNumeric.Maximum = 10; // 10 В
                    SecondSpecificationNumeric.Maximum = 1000; // 1000 В
                    ThirdSpecificationNumeric.Maximum = 100; // 100 А
                    break;

                default:
                    // Скрываем спецификации для других типов
                    FirstSpecificationLabel.Visible = false;
                    SecondSpecificationLabel.Visible = false;
                    ThirdSpecificationLabel.Visible = false;
                    FirstSpecificationNumeric.Visible = false;
                    SecondSpecificationNumeric.Visible = false;
                    ThirdSpecificationNumeric.Visible = false;
                    return;
            }

            // Показываем спецификации для основных типов
            FirstSpecificationLabel.Visible = true;
            SecondSpecificationLabel.Visible = true;
            ThirdSpecificationLabel.Visible = true;
            FirstSpecificationNumeric.Visible = true;
            SecondSpecificationNumeric.Visible = true;
            ThirdSpecificationNumeric.Visible = true;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                Utils.ShowErrorMessage("Название компонента не может быть пустым!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(ManufacturerTextBox.Text))
            {
                Utils.ShowErrorMessage("Производитель не может быть пустым!");
                return false;
            }

            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;
            try
            {
                Database.TransactionManager.ExecuteInTransaction(transaction =>
                {
                    string componentType = MapComponentType(_currentComponentType);

                    if (!_isEditMode)
                    {
                        _component = new Component(
                            id: 0,
                            name: NameTextBox.Text.Trim(),
                            manufacturer: ManufacturerTextBox.Text.Trim(),
                            price: PriceNumeric.Value,
                            type: componentType,
                            stockQuantity: (int)StockQuantity.Value,
                            createdAt: DateTime.Now
                        );

                        _component.Id = PcbRepository.AddComponent(_component, transaction);

                        if (_component.StockQuantity > 0)
                        {
                            AdditionalRepository.CreateComponentMovement("Поступление", _component.Id,
                                _component.StockQuantity, $"Поступление на склад {_component.StockQuantity} компонентов \"{_component.Name}\"", transaction);
                        }
                    }
                    else
                    {
                        int oldStock = _component!.StockQuantity;
                        int newStock = (int)StockQuantity.Value;

                        _component = new Component(
                            id: _componentId!.Value,
                            name: NameTextBox.Text.Trim(),
                            manufacturer: ManufacturerTextBox.Text.Trim(),
                            price: PriceNumeric.Value,
                            type: componentType,
                            stockQuantity: newStock,
                            createdAt: _component!.CreatedAt
                        );

                        PcbRepository.UpdateComponent(_component, transaction);

                        if (oldStock != newStock)
                        {
                            AdditionalRepository.CreateComponentStockMovement(_component.Id, oldStock, newStock, transaction);
                        }
                    }

                    if (_currentComponentType != ComponentType.Other)
                    {
                        SaveComponentSpecifications(_component.Id, transaction);
                    }
                });
                Utils.ShowInfoMessage("Данные сохранены успешно!");
                Close();
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void SaveComponentSpecifications(int componentId, NpgsqlTransaction? transaction = null)
        {
            // Удаляем старые спецификации
            var oldSpecs = PcbRepository.GetComponentSpecifications(componentId, transaction);
            foreach (var spec in oldSpecs)
            {
                PcbRepository.DeleteComponentSpecification(spec.Id, transaction);
            }

            // Добавляем новые спецификации в зависимости от типа компонента
            switch (_currentComponentType)
            {
                case ComponentType.Resistor:
                    PcbRepository.AddComponentSpecification(new ComponentSpecification(
                        0, componentId, ComponentSpecification.RESISTANCE,
                        FirstSpecificationNumeric.Value.ToString()
                    ), transaction);
                    PcbRepository.AddComponentSpecification(new ComponentSpecification(
                        0, componentId, ComponentSpecification.TOLERANCE,
                        SecondSpecificationNumeric.Value.ToString()
                    ), transaction);
                    PcbRepository.AddComponentSpecification(new ComponentSpecification(
                        0, componentId, ComponentSpecification.POWER,
                        ThirdSpecificationNumeric.Value.ToString()
                    ), transaction);
                    break;

                case ComponentType.Capacitor:
                    PcbRepository.AddComponentSpecification(new ComponentSpecification(
                        0, componentId, ComponentSpecification.CAPACITANCE,
                        FirstSpecificationNumeric.Value.ToString()
                    ), transaction);
                    PcbRepository.AddComponentSpecification(new ComponentSpecification(
                        0, componentId, ComponentSpecification.VOLTAGE,
                        SecondSpecificationNumeric.Value.ToString()
                    ), transaction);
                    PcbRepository.AddComponentSpecification(new ComponentSpecification(
                        0, componentId, ComponentSpecification.MAX_TEMPERATURE,
                        ThirdSpecificationNumeric.Value.ToString()
                    ), transaction);
                    break;

                case ComponentType.Diode:
                    PcbRepository.AddComponentSpecification(new ComponentSpecification(
                        0, componentId, ComponentSpecification.VOLTAGE_DROP,
                        FirstSpecificationNumeric.Value.ToString()
                    ), transaction);
                    PcbRepository.AddComponentSpecification(new ComponentSpecification(
                        0, componentId, ComponentSpecification.REVERSE_VOLTAGE,
                        SecondSpecificationNumeric.Value.ToString()
                    ), transaction);
                    PcbRepository.AddComponentSpecification(new ComponentSpecification(
                        0, componentId, ComponentSpecification.FORWARD_CURRENT,
                        ThirdSpecificationNumeric.Value.ToString()
                    ), transaction);
                    break;
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
            StockQuantity.Value += AddQuantityNumeric.Value;
            AddQuantityNumeric.Value = 0;
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeComboBox.SelectedItem != null)
            {
                string selectedType = TypeComboBox.SelectedItem.ToString()!;
                ComponentType componentType = MapComponentType(selectedType);
                ChangeSpecifications(componentType);
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
                        PcbRepository.DeleteComponentWithCleanup(_componentId!.Value, transaction);
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