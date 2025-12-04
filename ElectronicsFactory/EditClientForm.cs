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
    public partial class EditClientForm : Form
    {
        private int? _clientId;
        private Client? _client;
        private Individual? _individual;
        private LegalEntity? _legalEntity;
        private const string individualType = "Физическое лицо";
        private const string legalEntityType = "Юридическое лицо";
        private bool _isEditMode;
        private string? _initialClientType;

        public EditClientForm(int? clientId = null)
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            _clientId = clientId;
            _isEditMode = clientId != null;
            if (!_isEditMode)
            {
                _initialClientType = individualType;
                TypeComboBox.SelectedItem = individualType;
            }
            LoadData();
            ChangeControls(_initialClientType!);
            if (_isEditMode)
            {
                FillFields();
                if (Settings.IsAdmin)
                {
                    DeleteButton.Visible = true;
                }
            }
        }

        private void LoadData()
        {
            if (_clientId != null)
            {
                _client = ClientRepository.GetClientById(_clientId.Value);
                if (_client != null)
                {
                    _initialClientType = _client.Type;
                    if (_client.Type == individualType)
                    {
                        _individual = ClientRepository.GetIndividualById(_clientId.Value);
                        if (_individual == null)
                        {
                            Utils.ShowErrorMessage("Не удалось получить физическое лицо");
                            Close();
                        }
                    }
                    else
                    {
                        _legalEntity = ClientRepository.GetLegalEntityById(_clientId.Value);
                        if (_legalEntity == null)
                        {
                            Utils.ShowErrorMessage("Не удалось получить юридическое лицо");
                            Close();
                        }
                    }
                }
                else
                {
                    Utils.ShowErrorMessage("Не удалось получить клиента");
                    Close();
                }
            }
        }

        private void FillFields()
        {
            TypeComboBox.SelectedItem = _client!.Type;
            PhoneTextBox.Text = _client!.Phone;
            EmailTextBox.Text = _client!.Email;

            if (_client!.Type == individualType)
            {
                IndividualInnTextBox.Text = _client.Inn;
                NameTextBox.Text = _individual!.FullName;
                AddressTextBox.Text = _individual.Address;
                if (_individual.Age.HasValue)
                {
                    AgeNumeric.Value = _individual.Age.Value;
                }
            }
            else
            {
                LegalEntityInnTextBox.Text = _client!.Inn;
                NameTextBox.Text = _legalEntity!.CompanyName;
                ContactPersonTextBox.Text = _legalEntity.ContactPerson;
                LegalAddressTextBox.Text = _legalEntity.LegalAddress;
                ActualAddressTextBox.Text = _legalEntity.ActualAddress;
            }
        }

        private void ChangeControls(string type)
        {
            if (type == individualType)
            {
                LegalEntityInnTextBox.Visible = false;
                ContactPersonTextBox.Visible = false;
                LegalAddressTextBox.Visible = false;
                ActualAddressTextBox.Visible = false;
                ActualAddressLabel.Visible = false;
                CompanyNameLabel.Visible = false;
                ContactPersonLabel.Visible = false;
                LegalAddressLabel.Visible = false;

                IndividualInnTextBox.Visible = true;
                AddressTextBox.Visible = true;
                AgeNumeric.Visible = true;
                NameLabel.Visible = true;
                AddressLabel.Visible = true;
                AgeLabel.Visible = true;
            }
            else
            {
                LegalEntityInnTextBox.Visible = true;
                ContactPersonTextBox.Visible = true;
                LegalAddressTextBox.Visible = true;
                ActualAddressTextBox.Visible = true;
                ActualAddressLabel.Visible = true;
                CompanyNameLabel.Visible = true;
                ContactPersonLabel.Visible = true;
                LegalAddressLabel.Visible = true;

                IndividualInnTextBox.Visible = false;
                AddressTextBox.Visible = false;
                AgeNumeric.Visible = false;
                NameLabel.Visible = false;
                AddressLabel.Visible = false;
                AgeLabel.Visible = false;
            }
        }

        private bool ValidateData()
        {
            bool innIsEmpty = TypeComboBox.Text == individualType ?
                IndividualInnTextBox.Text.Length != 12 : LegalEntityInnTextBox.Text.Length != 10;
            string phoneText = PhoneTextBox.Text.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (NameTextBox.Text == "" || phoneText.Length != 10 || innIsEmpty)
            {
                Utils.ShowErrorMessage("Не заполнены необходимые поля!");
                return false;
            }
            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            try
            {
                Database.TransactionManager.ExecuteInTransaction(transaction =>
                {
                    string? type = TypeComboBox.SelectedItem!.ToString();
                    if (type == null)
                    {
                        return;
                    }
                    _client = new Client(
                        id: _isEditMode ? _clientId!.Value : -1,
                        type: type,
                        phone: PhoneTextBox.Text,
                        email: EmailTextBox.Text,
                        inn: type == individualType ? IndividualInnTextBox.Text : LegalEntityInnTextBox.Text
                    );
                    if (_isEditMode)
                    {
                        ClientRepository.UpdateClient(_client, transaction);
                    }
                    else
                    {
                        _client.Id = ClientRepository.AddClient(_client, transaction);
                    }
                    if (type == individualType)
                    {
                        _individual = new Individual(
                            clientId: _client.Id,
                            fullName: NameTextBox.Text,
                            address: AddressTextBox.Text,
                            age: Convert.ToInt32(AgeNumeric.Value)
                        );
                        if (_isEditMode)
                        {
                            if (type == _initialClientType)
                            {
                                ClientRepository.UpdateIndividual(_individual, transaction);
                            }
                            else
                            {
                                ClientRepository.DeleteLegalEntity(_clientId!.Value, transaction);
                                ClientRepository.AddIndividual(_individual, transaction);
                            }
                        }
                        else
                        {
                            ClientRepository.AddIndividual(_individual, transaction);
                        }
                    }
                    else
                    {
                        _legalEntity = new LegalEntity(
                            clientId: _client.Id,
                            companyName: NameTextBox.Text,
                            contactPerson: ContactPersonTextBox.Text,
                            legalAddress: LegalAddressTextBox.Text,
                            actualAddress: ActualAddressTextBox.Text
                        );
                        if (_isEditMode)
                        {
                            if (type == _initialClientType)
                            {
                                ClientRepository.UpdateLegalEntity(_legalEntity, transaction);
                            }
                            else
                            {
                                ClientRepository.DeleteIndividual(_clientId!.Value, transaction);
                                ClientRepository.AddLegalEntity(_legalEntity, transaction);
                            }
                        }
                        else
                        {
                            ClientRepository.AddLegalEntity(_legalEntity, transaction);
                        }
                    }
                });
                Utils.ShowInfoMessage("Данные были сохранены успешно");
                Close();
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Ошибка при попытке сохранения данных: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (Utils.ShowQuestionMessage() == DialogResult.Yes)
            {
                Close();
            }
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? type = TypeComboBox.SelectedItem?.ToString();
            if (type != null)
            {
                ChangeControls(type);
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
                        ClientRepository.DeleteClientWithDependencies(_clientId!.Value, transaction);
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