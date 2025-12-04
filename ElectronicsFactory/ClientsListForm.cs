using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicsFactory
{
    public partial class ClientsListForm : Form
    {
        private int _pageSize = 3;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private string _currentNameFilter = "";
        private string _currentTypeFilter = "Все";
        private Label _noResultsLabel;

        public ClientsListForm()
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            InitializeNoResultsLabel();
            LoadClientsPage();
            UpdatePaginationButtons();
            TypeFilterComboBox.SelectedItem = "Все";
        }

        private void InitializeNoResultsLabel()
        {
            _noResultsLabel = new Label();
            _noResultsLabel.Text = "Клиенты не найдены";
            _noResultsLabel.AutoSize = true;
            _noResultsLabel.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            _noResultsLabel.ForeColor = Color.Gray;
            _noResultsLabel.Visible = false;
            flowLayoutPanel1.Controls.Add(_noResultsLabel);
        }

        private void LoadClientsPage()
        {
            // Очищаем панель
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(_noResultsLabel);

            // Получаем данные для текущей страницы с фильтрами
            var clients = ClientRepository.GetFilteredClientsPage(_pageSize, _currentPage, _currentNameFilter, _currentTypeFilter);
            long totalClients = ClientRepository.GetFilteredClientsCount(_currentNameFilter, _currentTypeFilter);
            _totalPages = (int)Math.Ceiling((double)totalClients / _pageSize);

            if (_totalPages == 0) _totalPages = 1;

            // Показываем/скрываем сообщение о пустом результате
            if (clients.Count == 0)
            {
                _noResultsLabel.Visible = true;
            }
            else
            {
                _noResultsLabel.Visible = false;

                // Создаем и добавляем карточки
                foreach (var info in clients)
                {
                    var card = new ClientCard(info);
                    card.Click += Card_Click!;
                    flowLayoutPanel1.Controls.Add(card);
                }
            }

            // Обновляем информацию о странице
            UpdatePageInfo();
            UpdatePaginationButtons();
        }

        private void Card_Click(object sender, EventArgs e)
        {
            var card = (ClientCard)sender;
            new EditClientForm(card.Id).ShowDialog();
            LoadClientsPage(); // Перезагружаем с текущими фильтрами
        }

        private void UpdatePageInfo()
        {
            PageLabel.Text = $"Страница {_currentPage} из {_totalPages}";
        }

        private void UpdatePaginationButtons()
        {
            PrevButton.Enabled = _currentPage > 1;
            NextButton.Enabled = _currentPage < _totalPages;
        }

        private void PrevPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadClientsPage();
            }
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadClientsPage();
            }
        }

        private void AddClientButton_Click(object sender, EventArgs e)
        {
            new EditClientForm().ShowDialog();
            LoadClientsPage(); // Перезагружаем с текущими фильтрами
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            // Применяем фильтры
            _currentNameFilter = NameFilterTextBox.Text.Trim();
            _currentTypeFilter = TypeFilterComboBox.SelectedItem?.ToString() ?? "Все";

            // Сбрасываем на первую страницу при применении новых фильтров
            _currentPage = 1;

            LoadClientsPage();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NameFilterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FilterButton_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}