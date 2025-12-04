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
    public partial class PcbsListForm : Form
    {
        private int _pageSize = 3;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private string _currentNameFilter = "";
        private Label _noResultsLabel;

        public PcbsListForm()
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            InitializeNoResultsLabel();
            LoadPcbsPage();
            UpdatePaginationButtons();
        }

        private void InitializeNoResultsLabel()
        {
            _noResultsLabel = new Label();
            _noResultsLabel.Text = "Платы не найдены";
            _noResultsLabel.AutoSize = true;
            _noResultsLabel.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            _noResultsLabel.ForeColor = Color.Gray;
            _noResultsLabel.Visible = false;
            flowLayoutPanel1.Controls.Add(_noResultsLabel);
        }

        private void LoadPcbsPage()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(_noResultsLabel);

            var pcbs = PcbRepository.GetPcbsPage(_pageSize, _currentPage, _currentNameFilter);
            long totalPcbs = PcbRepository.GetTotalPcbsCount(_currentNameFilter);
            _totalPages = (int)Math.Ceiling((double)totalPcbs / _pageSize);

            if (_totalPages == 0) _totalPages = 1;

            if (pcbs.Count == 0)
            {
                _noResultsLabel.Visible = true;
            }
            else
            {
                _noResultsLabel.Visible = false;

                foreach (var info in pcbs)
                {
                    var card = new PcbCard(info);
                    card.Click += Card_Click!;
                    flowLayoutPanel1.Controls.Add(card);
                }
            }

            UpdatePageInfo();
            UpdatePaginationButtons();
        }

        private void Card_Click(object sender, EventArgs e)
        {
            var card = (PcbCard)sender;
            new EditPcbForm(card.Id).ShowDialog();
            LoadPcbsPage();
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
                LoadPcbsPage();
            }
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadPcbsPage();
            }
        }

        private void AddPcbButton_Click(object sender, EventArgs e)
        {
            new EditPcbForm().ShowDialog();
            LoadPcbsPage();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            _currentNameFilter = NameFilterTextBox.Text.Trim();

            _currentPage = 1;

            LoadPcbsPage();
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