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
    public partial class MovementsListForm : Form
    {
        private int _pageSize = 4;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private string _currentTypeFilter = "Все";
        private Label _noResultsLabel;

        public MovementsListForm()
        {
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            InitializeNoResultsLabel();
            LoadTypeFilterComboBox();
            LoadMovementsPage();
            UpdatePaginationButtons();
            DeletionGroupBox.Visible = Settings.IsAdmin;
        }

        private void InitializeNoResultsLabel()
        {
            _noResultsLabel = new Label();
            _noResultsLabel.Text = "Движений нет";
            _noResultsLabel.AutoSize = true;
            _noResultsLabel.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            _noResultsLabel.ForeColor = Color.Gray;
            _noResultsLabel.Visible = false;
            flowLayoutPanel1.Controls.Add(_noResultsLabel);
        }

        private void LoadTypeFilterComboBox()
        {
            TypeComboBox.Items.AddRange(new object[] { "Все", "Поступление", "Списание" });
            TypeComboBox.SelectedItem = "Все";
        }

        private void LoadMovementsPage()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(_noResultsLabel);

            var movements = AdditionalRepository.GetMovementsPage(_pageSize, _currentPage, _currentTypeFilter);
            long totalMovements = AdditionalRepository.GetTotalMovementsCount(_currentTypeFilter);
            _totalPages = (int)Math.Ceiling((double)totalMovements / _pageSize);

            if (_totalPages == 0) _totalPages = 1;

            if (movements.Count == 0)
            {
                _noResultsLabel.Visible = true;
            }
            else
            {
                _noResultsLabel.Visible = false;

                foreach (var info in movements)
                {
                    var card = new MovementCard(info);
                    flowLayoutPanel1.Controls.Add(card);
                }
            }

            UpdatePageInfo();
            UpdatePaginationButtons();
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
                LoadMovementsPage();
            }
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadMovementsPage();
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            _currentTypeFilter = TypeComboBox.SelectedItem?.ToString() ?? "Все";
            _currentPage = 1;
            LoadMovementsPage();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Utils.ShowQuestionMessage($"Вы уверены, что хотите удалить все движения с {StartDatePicker.Value:dd.MM.yyyy} по {EndDatePicker.Value:dd.MM.yyyy}?") == DialogResult.Yes)
            {
                try
                {
                    int deletedCount = AdditionalRepository.DeleteMovementsInPeriod(
                        StartDatePicker.Value,
                        EndDatePicker.Value.AddDays(1).AddSeconds(-1)
                    );

                    LoadMovementsPage();
                    Utils.ShowInfoMessage($"Удалено движений: {deletedCount}");
                }
                catch (Exception ex)
                {
                    Utils.ShowErrorMessage($"Ошибка при удалении движений:\n{ex.Message}");
                }
            }
        }
    }
}