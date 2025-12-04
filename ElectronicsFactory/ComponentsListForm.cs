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
    public partial class ComponentsListForm : Form
    {
        private int _pageSize = 3;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private string _currentNameFilter = "";
        private string _currentTypeFilter = "Все";
        private Label _noResultsLabel;
        private bool _isPcbComponents;
        private int? _pcbId;

        public ComponentsListForm(int? pcbId = null)
        {
            _isPcbComponents = pcbId != null;
            _pcbId = pcbId;
            InitializeComponent();
            SettingsUI.ApplyStyle(this);

            InitializeNoResultsLabel();
            LoadComponentsPage();
            UpdatePaginationButtons();
        }

        private void InitializeNoResultsLabel()
        {
            _noResultsLabel = new Label();
            _noResultsLabel.Text = "Компоненты не найдены";
            _noResultsLabel.AutoSize = true;
            _noResultsLabel.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            _noResultsLabel.ForeColor = Color.Gray;
            _noResultsLabel.Visible = false;
            flowLayoutPanel1.Controls.Add(_noResultsLabel);
        }

        private void LoadComponentsPage()
        {
            // Очищаем панель
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(_noResultsLabel);

            // Получаем данные для текущей страницы с фильтрами
            var components = PcbRepository.GetFilteredComponentsPage(_pageSize, _currentPage, _currentNameFilter, _currentTypeFilter, _pcbId);
            long totalComponents = PcbRepository.GetFilteredComponentsCount(_currentNameFilter, _currentTypeFilter, _pcbId);
            _totalPages = (int)Math.Ceiling((double)totalComponents / _pageSize);

            if (_totalPages == 0) _totalPages = 1;

            // Показываем/скрываем сообщение о пустом результате
            if (components.Count == 0)
            {
                _noResultsLabel.Visible = true;
            }
            else
            {
                _noResultsLabel.Visible = false;

                // Создаем и добавляем карточки
                foreach (var info in components)
                {
                    var card = new ComponentCard(info);
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
            var card = (ComponentCard)sender;
            if (_isPcbComponents && _pcbId.HasValue)
            {
                new EditPcbComponentForm(_pcbId.Value, card.Id, card.ComponentName).ShowDialog();
            }
            else
            {
                new EditComponentForm(card.Id).ShowDialog();
            }
            LoadComponentsPage();
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
                LoadComponentsPage();
            }
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadComponentsPage();
            }
        }

        private void AddComponentButton_Click(object sender, EventArgs e)
        {
            if (_isPcbComponents && _pcbId.HasValue)
            {
                new EditPcbComponentForm(_pcbId.Value).ShowDialog();
            }
            else
            {
                new EditComponentForm().ShowDialog();
            }
            LoadComponentsPage();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            _currentNameFilter = NameFilterTextBox.Text.Trim();
            _currentTypeFilter = TypeFilterComboBox.SelectedItem?.ToString() ?? "Все";

            _currentPage = 1;

            LoadComponentsPage();
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