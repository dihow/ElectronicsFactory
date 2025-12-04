namespace ElectronicsFactory
{
    partial class ComponentsListForm
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            PrevButton = new Button();
            NextButton = new Button();
            PageLabel = new Label();
            AddComponentButton = new Button();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            TypeFilterComboBox = new ComboBox();
            FilterButton = new Button();
            label1 = new Label();
            NameFilterTextBox = new TextBox();
            CloseButton = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
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
            // AddComponentButton
            // 
            AddComponentButton.Location = new Point(645, 205);
            AddComponentButton.Name = "AddComponentButton";
            AddComponentButton.Size = new Size(197, 73);
            AddComponentButton.TabIndex = 4;
            AddComponentButton.Text = "Добавить компонент";
            AddComponentButton.UseVisualStyleBackColor = true;
            AddComponentButton.Click += AddComponentButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(PrevButton);
            panel1.Controls.Add(NextButton);
            panel1.Controls.Add(PageLabel);
            panel1.Location = new Point(12, 536);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 80);
            panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(12, 48);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Компоненты";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TypeFilterComboBox);
            groupBox2.Controls.Add(FilterButton);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(NameFilterTextBox);
            groupBox2.Location = new Point(645, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(197, 187);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Фильтрация";
            // 
            // TypeFilterComboBox
            // 
            TypeFilterComboBox.FormattingEnabled = true;
            TypeFilterComboBox.Items.AddRange(new object[] { "Все", "Резистор", "Конденсатор", "Диод" });
            TypeFilterComboBox.Location = new Point(6, 84);
            TypeFilterComboBox.Name = "TypeFilterComboBox";
            TypeFilterComboBox.Size = new Size(185, 25);
            TypeFilterComboBox.TabIndex = 4;
            // 
            // FilterButton
            // 
            FilterButton.Location = new Point(17, 126);
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
            label1.Size = new Size(131, 17);
            label1.TabIndex = 2;
            label1.Text = "Поиск по названию:";
            // 
            // NameFilterTextBox
            // 
            NameFilterTextBox.Location = new Point(6, 53);
            NameFilterTextBox.Name = "NameFilterTextBox";
            NameFilterTextBox.Size = new Size(185, 25);
            NameFilterTextBox.TabIndex = 0;
            NameFilterTextBox.KeyPress += NameFilterTextBox_KeyPress;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(645, 540);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(197, 73);
            CloseButton.TabIndex = 8;
            CloseButton.Text = "На главную";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // ComponentsListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 629);
            Controls.Add(CloseButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(AddComponentButton);
            DoubleBuffered = true;
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "ComponentsListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список компонентов";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button PrevButton;
        private Button NextButton;
        private Label PageLabel;
        private Button AddComponentButton;
        private Panel panel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button FilterButton;
        private Label label1;
        private TextBox NameFilterTextBox;
        private Button CloseButton;
        private ComboBox TypeFilterComboBox;
    }
}