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
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);
        }

        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdditionalRepository.TryLoggingIn(LoginTextBox.Text.Trim(), PasswordTextBox.Text.Trim()))
                {
                    var employeeInfo = AdditionalRepository.GetEmployeeInfo(LoginTextBox.Text.Trim());
                    if (employeeInfo != null)
                    {
                        Settings.IsAdmin = employeeInfo.IsAdmin;
                        Settings.CurrentEmployeeId = employeeInfo.Id;
                        Settings.CurrentEmployeeName = employeeInfo.FullName;

                        Hide();
                        new MainForm().Show();
                    }
                }
                else
                {
                    Utils.ShowErrorMessage("Не удалось войти в систему: неправильный логин или пароль", "Ошибка авторизации");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage($"Ошибка авторизации:\n{ex.Message}");
            }
        }
    }
}
