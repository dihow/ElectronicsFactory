namespace ElectronicsFactory
{
    partial class MovementsListForm
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
            TypeComboBox = new ComboBox();
            FilterButton = new Button();
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            PrevButton = new Button();
            NextButton = new Button();
            PageLabel = new Label();
            StartDatePicker = new DateTimePicker();
            label1 = new Label();
            DeletionGroupBox = new GroupBox();
            DeleteButton = new Button();
            EndDatePicker = new DateTimePicker();
            label2 = new Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            DeletionGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(633, 537);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(197, 73);
            CloseButton.TabIndex = 13;
            CloseButton.Text = "На главную";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TypeComboBox);
            groupBox2.Controls.Add(FilterButton);
            groupBox2.Location = new Point(625, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(217, 124);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Фильтрация";
            // 
            // TypeComboBox
            // 
            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Items.AddRange(new object[] { "Все", "Поступление", "Списание" });
            TypeComboBox.Location = new Point(39, 24);
            TypeComboBox.Name = "TypeComboBox";
            TypeComboBox.Size = new Size(169, 25);
            TypeComboBox.TabIndex = 4;
            // 
            // FilterButton
            // 
            FilterButton.Location = new Point(39, 54);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(169, 55);
            FilterButton.TabIndex = 3;
            FilterButton.Text = "Применить";
            FilterButton.UseVisualStyleBackColor = true;
            FilterButton.Click += FilterButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(12, 48);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Движения";
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
            panel1.Location = new Point(9, 533);
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
            // StartDatePicker
            // 
            StartDatePicker.Location = new Point(39, 24);
            StartDatePicker.Name = "StartDatePicker";
            StartDatePicker.Size = new Size(169, 25);
            StartDatePicker.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 27);
            label1.Name = "label1";
            label1.Size = new Size(21, 17);
            label1.TabIndex = 15;
            label1.Text = "С:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // DeletionGroupBox
            // 
            DeletionGroupBox.Controls.Add(DeleteButton);
            DeletionGroupBox.Controls.Add(EndDatePicker);
            DeletionGroupBox.Controls.Add(label2);
            DeletionGroupBox.Controls.Add(StartDatePicker);
            DeletionGroupBox.Controls.Add(label1);
            DeletionGroupBox.Location = new Point(625, 142);
            DeletionGroupBox.Name = "DeletionGroupBox";
            DeletionGroupBox.Size = new Size(217, 152);
            DeletionGroupBox.TabIndex = 16;
            DeletionGroupBox.TabStop = false;
            DeletionGroupBox.Text = "Удалить движения";
            DeletionGroupBox.Visible = false;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(39, 86);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(169, 55);
            DeleteButton.TabIndex = 18;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EndDatePicker
            // 
            EndDatePicker.Location = new Point(39, 55);
            EndDatePicker.Name = "EndDatePicker";
            EndDatePicker.Size = new Size(169, 25);
            EndDatePicker.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 58);
            label2.Name = "label2";
            label2.Size = new Size(29, 17);
            label2.TabIndex = 17;
            label2.Text = "По:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MovementsListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 622);
            Controls.Add(DeletionGroupBox);
            Controls.Add(CloseButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "MovementsListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список движений";
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            DeletionGroupBox.ResumeLayout(false);
            DeletionGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CloseButton;
        private GroupBox groupBox2;
        private Button FilterButton;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Button PrevButton;
        private Button NextButton;
        private Label PageLabel;
        private ComboBox TypeComboBox;
        private DateTimePicker StartDatePicker;
        private Label label1;
        private GroupBox DeletionGroupBox;
        private DateTimePicker EndDatePicker;
        private Label label2;
        private Button DeleteButton;
    }
}