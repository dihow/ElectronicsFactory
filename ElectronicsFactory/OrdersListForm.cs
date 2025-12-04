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
    public partial class OrdersListForm : Form
    {
        private int _pageSize = 3;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private string _currentClientFilter = "";
        private string _currentStatusFilter = "Все";
        private string _currentDateFilter = "По умолчанию";
        private Label _noResultsLabel;

        public OrdersListForm()
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            InitializeNoResultsLabel();
            LoadOrdersPage();
            UpdatePaginationButtons();
        }

        private void InitializeNoResultsLabel()
        {
            _noResultsLabel = new Label();
            _noResultsLabel.Text = "Заказы не найдены";
            _noResultsLabel.AutoSize = true;
            _noResultsLabel.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            _noResultsLabel.ForeColor = Color.Gray;
            _noResultsLabel.Visible = false;
            flowLayoutPanel1.Controls.Add(_noResultsLabel);
        }

        private void LoadOrdersPage()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(_noResultsLabel);

            var orders = OrderRepository.GetOrdersPage(_pageSize, _currentPage,
                _currentClientFilter, _currentStatusFilter, _currentDateFilter);
            long totalOrders = OrderRepository.GetTotalOrdersCount(_currentClientFilter, _currentStatusFilter);
            _totalPages = (int)Math.Ceiling((double)totalOrders / _pageSize);

            if (_totalPages == 0) _totalPages = 1;

            if (orders.Count == 0)
            {
                _noResultsLabel.Visible = true;
            }
            else
            {
                _noResultsLabel.Visible = false;

                foreach (var info in orders)
                {
                    var card = new OrderCard(info);
                    card.Click += Card_Click!;
                    flowLayoutPanel1.Controls.Add(card);
                }
            }

            UpdatePageInfo();
            UpdatePaginationButtons();
        }

        private void Card_Click(object sender, EventArgs e)
        {
            var card = (OrderCard)sender;
            new EditOrderForm(card.Id).ShowDialog();
            LoadOrdersPage();
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
                LoadOrdersPage();
            }
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadOrdersPage();
            }
        }

        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            new EditOrderForm().ShowDialog();
            LoadOrdersPage();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            _currentClientFilter = ClientFilterTextBox.Text.Trim();
            _currentStatusFilter = StatusFilterComboBox.Text.Trim();
            _currentDateFilter = DateFilterComboBox.Text.Trim();

            _currentPage = 1;

            LoadOrdersPage();
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
