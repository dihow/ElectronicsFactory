using System.Drawing;
using System.Windows.Forms;

namespace ElectronicsFactory
{
    public static class SettingsUI
    {
        // --------------------------------------------------------------------
        // ГЛОБАЛЬНАЯ ЦВЕТОВАЯ ПАЛИТРА
        // --------------------------------------------------------------------

        // Основной фон всех форм
        public static Color BackColor = Color.FromArgb(15, 18, 30);

        // Фон карточек, панелей, DataGridView-строк
        public static Color CardBackColor = Color.FromArgb(25, 28, 40);

        // Акцент (кнопки, заголовки)
        public static Color AccentColor = Color.FromArgb(120, 80, 200);
        public static Color AccentHover = Color.FromArgb(150, 100, 230);

        // Дополнительные цвета
        public static Color BorderColor = Color.FromArgb(70, 70, 100);
        public static Color TextColor = Color.FromArgb(210, 210, 230);
        public static Color SecondaryText = Color.FromArgb(160, 160, 200);

        // --------------------------------------------------------------------
        // ШРИФТЫ
        // --------------------------------------------------------------------
        public static Font DefaultFont = new Font("Times New Roman", 11f, FontStyle.Regular);
        public static Font HeaderFont = new Font("Times New Roman", 13f, FontStyle.Bold);
        public static Font SmallFont = new Font("Times New Roman", 10f, FontStyle.Regular);


        // ====================================================================
        //                ПРИМЕНЕНИЕ СТИЛЯ КО ВСЕЙ ФОРМЕ
        // ====================================================================
        public static void ApplyStyle(Form form)
        {
            form.BackColor = BackColor;
            form.Font = DefaultFont;
            form.Icon = Icon.FromHandle(Properties.Resources.circuit_placeholder_old.GetHicon());

            ApplyStyleToControls(form.Controls);
        }


        // Рекурсивная стилизация всех вложенных контролов
        private static void ApplyStyleToControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is Button btn) StyleButton(btn);
                else if (c is TextBox tb) StyleTextBox(tb);
                else if (c is ComboBox cb) StyleComboBox(cb);
                else if (c is Label lbl) StyleLabel(lbl);
                else if (c is NumericUpDown nud) StyleNumeric(nud);
                else if (c is DataGridView dgv) StyleDataGrid(dgv);
                else if (c is DateTimePicker dtp) StyleDate(dtp);
                else if (c is Panel p) p.BackColor = BackColor;

                c.ForeColor = TextColor;
                c.Font = DefaultFont;

                if (c.HasChildren)
                    ApplyStyleToControls(c.Controls);
            }
        }


        // ====================================================================
        //                                BUTTONS
        // ====================================================================
        public static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.BackColor = AccentColor;
            btn.ForeColor = Color.White;
            btn.Font = DefaultFont;

            btn.Cursor = Cursors.Hand;

            // Плавный hover
            btn.MouseEnter += (s, e) => btn.BackColor = AccentHover;
            btn.MouseLeave += (s, e) => btn.BackColor = AccentColor;
        }


        // ====================================================================
        //                                TEXTBOX
        // ====================================================================
        public static void StyleTextBox(TextBox tb)
        {
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.BackColor = CardBackColor;
            tb.ForeColor = TextColor;
        }


        // ====================================================================
        //                                COMBOBOX
        // ====================================================================
        public static void StyleComboBox(ComboBox cb)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.BackColor = AccentColor;
            cb.ForeColor = TextColor;
        }


        // ====================================================================
        //                                LABEL
        // ====================================================================
        public static void StyleLabel(Label lbl)
        {
            lbl.ForeColor = TextColor;
            lbl.BackColor = Color.Transparent;
        }


        // ====================================================================
        //                         NUMERIC UP/DOWN
        // ====================================================================
        public static void StyleNumeric(NumericUpDown nud)
        {
            nud.BorderStyle = BorderStyle.FixedSingle;
            nud.BackColor = CardBackColor;
            nud.ForeColor = TextColor;
        }


        // ====================================================================
        //                         DATETIMEPICKER
        // ====================================================================
        public static void StyleDate(DateTimePicker dtp)
        {
            dtp.BackColor = CardBackColor;
            dtp.ForeColor = TextColor;
        }


        // ====================================================================
        //                            CARD USERCONTROLS
        // ====================================================================
        public static void StyleCard(UserControl uc)
        {
            uc.BackColor = CardBackColor;
            uc.BorderStyle = BorderStyle.FixedSingle;
        }


        // ====================================================================
        //                              DATA GRID VIEW
        // ====================================================================
        public static void StyleDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = BackColor;
            dgv.GridColor = BorderColor;

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = AccentColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = DefaultFont;

            dgv.DefaultCellStyle.BackColor = CardBackColor;
            dgv.DefaultCellStyle.ForeColor = TextColor;
            dgv.DefaultCellStyle.SelectionBackColor = AccentHover;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
        }
    }
}
