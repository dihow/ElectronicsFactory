namespace ElectronicsFactory
{
    partial class OrdersListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CloseButton = new Button();
            groupBox2 = new GroupBox();
            DateFilterComboBox = new ComboBox();
            label3 = new Label();
            StatusFilterComboBox = new ComboBox();
            label2 = new Label();
            FilterButton = new Button();
            label1 = new Label();
            ClientFilterTextBox = new TextBox();
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            PrevButton = new Button();
            NextButton = new Button();
            PageLabel = new Label();
            AddOrderButton = new Button();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(648, 575);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(197, 73);
            CloseButton.TabIndex = 13;
            CloseButton.Text = "На главную";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DateFilterComboBox);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(StatusFilterComboBox);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(FilterButton);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(ClientFilterTextBox);
            groupBox2.Location = new Point(648, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(197, 253);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Фильтрация";
            // 
            // DateFilterComboBox
            // 
            DateFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DateFilterComboBox.FormattingEnabled = true;
            DateFilterComboBox.Items.AddRange(new object[] { "По умолчанию", "По дате регистрации", "По дате отгрузки" });
            DateFilterComboBox.Location = new Point(6, 149);
            DateFilterComboBox.Name = "DateFilterComboBox";
            DateFilterComboBox.Size = new Size(185, 25);
            DateFilterComboBox.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 129);
            label3.Name = "label3";
            label3.Size = new Size(84, 17);
            label3.TabIndex = 7;
            label3.Text = "Сортировка:";
            // 
            // StatusFilterComboBox
            // 
            StatusFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusFilterComboBox.FormattingEnabled = true;
            StatusFilterComboBox.Items.AddRange(new object[] { "Все", "Не подтверждён", "Готов", "Отправлен" });
            StatusFilterComboBox.Location = new Point(6, 101);
            StatusFilterComboBox.Name = "StatusFilterComboBox";
            StatusFilterComboBox.Size = new Size(185, 25);
            StatusFilterComboBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 81);
            label2.Name = "label2";
            label2.Size = new Size(155, 17);
            label2.TabIndex = 5;
            label2.Text = "Фильтрация по статусу:";
            // 
            // FilterButton
            // 
            FilterButton.Location = new Point(18, 190);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(162, 55);
            FilterButton.TabIndex = 3;
            FilterButton.Text = "Применить";
            FilterButton.UseVisualStyleBackColor = true;
            FilterButton.Click += FilterButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(121, 17);
            label1.TabIndex = 2;
            label1.Text = "Поиск по клиенту:";
            // 
            // ClientFilterTextBox
            // 
            ClientFilterTextBox.Location = new Point(6, 53);
            ClientFilterTextBox.Name = "ClientFilterTextBox";
            ClientFilterTextBox.Size = new Size(185, 25);
            ClientFilterTextBox.TabIndex = 0;
            ClientFilterTextBox.KeyPress += NameFilterTextBox_KeyPress;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Location = new Point(15, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(12, 48);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Заказы";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(6, 24);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(0, 0);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(PrevButton);
            panel1.Controls.Add(NextButton);
            panel1.Controls.Add(PageLabel);
            panel1.Location = new Point(15, 571);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 80);
            panel1.TabIndex = 10;
            // 
            // PrevButton
            // 
            PrevButton.Location = new Point(3, 3);
            PrevButton.Name = "PrevButton";
            PrevButton.Size = new Size(197, 73);
            PrevButton.TabIndex = 1;
            PrevButton.Text = "Назад";
            PrevButton.UseVisualStyleBackColor = true;
            PrevButton.Click += PrevPageButton_Click;
            // 
            // NextButton
            // 
            NextButton.Location = new Point(397, 4);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(197, 73);
            NextButton.TabIndex = 2;
            NextButton.Text = "Далее";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextPageButton_Click;
            // 
            // PageLabel
            // 
            PageLabel.AutoSize = true;
            PageLabel.Location = new Point(253, 32);
            PageLabel.Name = "PageLabel";
            PageLabel.Size = new Size(42, 17);
            PageLabel.TabIndex = 3;
            PageLabel.Text = "label1";
            // 
            // AddOrderButton
            // 
            AddOrderButton.Location = new Point(648, 271);
            AddOrderButton.Name = "AddOrderButton";
            AddOrderButton.Size = new Size(197, 73);
            AddOrderButton.TabIndex = 9;
            AddOrderButton.Text = "Добавить заказ";
            AddOrderButton.UseVisualStyleBackColor = true;
            AddOrderButton.Click += AddOrderButton_Click;
            // 
            // OrdersListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 660);
            Controls.Add(CloseButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(AddOrderButton);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "OrdersListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список заказов";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CloseButton;
        private GroupBox groupBox2;
        private Button FilterButton;
        private Label label1;
        private TextBox ClientFilterTextBox;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Button PrevButton;
        private Button NextButton;
        private Label PageLabel;
        private Button AddOrderButton;
        private ComboBox DateFilterComboBox;
        private Label label3;
        private ComboBox StatusFilterComboBox;
        private Label label2;
    }
}