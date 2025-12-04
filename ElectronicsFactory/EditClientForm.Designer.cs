namespace ElectronicsFactory
{
    partial class EditClientForm
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
            groupBox1 = new GroupBox();
            LegalAddressLabel = new Label();
            ContactPersonLabel = new Label();
            CompanyNameLabel = new Label();
            ActualAddressLabel = new Label();
            ActualAddressTextBox = new TextBox();
            LegalAddressTextBox = new TextBox();
            LegalEntityInnTextBox = new MaskedTextBox();
            AgeNumeric = new NumericUpDown();
            ContactPersonTextBox = new TextBox();
            AgeLabel = new Label();
            AddressTextBox = new TextBox();
            AddressLabel = new Label();
            NameTextBox = new TextBox();
            NameLabel = new Label();
            IndividualInnTextBox = new MaskedTextBox();
            label3 = new Label();
            EmailTextBox = new TextBox();
            label2 = new Label();
            PhoneTextBox = new MaskedTextBox();
            label1 = new Label();
            TypeComboBox = new ComboBox();
            SaveButton = new Button();
            CancelButton = new Button();
            DeleteButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AgeNumeric).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(LegalAddressLabel);
            groupBox1.Controls.Add(ContactPersonLabel);
            groupBox1.Controls.Add(CompanyNameLabel);
            groupBox1.Controls.Add(ActualAddressLabel);
            groupBox1.Controls.Add(ActualAddressTextBox);
            groupBox1.Controls.Add(LegalAddressTextBox);
            groupBox1.Controls.Add(LegalEntityInnTextBox);
            groupBox1.Controls.Add(AgeNumeric);
            groupBox1.Controls.Add(ContactPersonTextBox);
            groupBox1.Controls.Add(AgeLabel);
            groupBox1.Controls.Add(AddressTextBox);
            groupBox1.Controls.Add(AddressLabel);
            groupBox1.Controls.Add(NameTextBox);
            groupBox1.Controls.Add(NameLabel);
            groupBox1.Controls.Add(IndividualInnTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(EmailTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(PhoneTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(TypeComboBox);
            groupBox1.Location = new Point(13, 13);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(420, 357);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Данные клиента";
            // 
            // LegalAddressLabel
            // 
            LegalAddressLabel.AutoSize = true;
            LegalAddressLabel.Location = new Point(3, 260);
            LegalAddressLabel.MaximumSize = new Size(98, 45);
            LegalAddressLabel.Name = "LegalAddressLabel";
            LegalAddressLabel.Size = new Size(95, 34);
            LegalAddressLabel.TabIndex = 20;
            LegalAddressLabel.Text = "Юридический\r\nадрес:";
            LegalAddressLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ContactPersonLabel
            // 
            ContactPersonLabel.AutoSize = true;
            ContactPersonLabel.Location = new Point(19, 220);
            ContactPersonLabel.MaximumSize = new Size(98, 45);
            ContactPersonLabel.Name = "ContactPersonLabel";
            ContactPersonLabel.Size = new Size(80, 34);
            ContactPersonLabel.TabIndex = 19;
            ContactPersonLabel.Text = "Контактное\r\nлицо:";
            ContactPersonLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CompanyNameLabel
            // 
            CompanyNameLabel.AutoSize = true;
            CompanyNameLabel.Location = new Point(27, 180);
            CompanyNameLabel.MaximumSize = new Size(98, 45);
            CompanyNameLabel.Name = "CompanyNameLabel";
            CompanyNameLabel.Size = new Size(69, 34);
            CompanyNameLabel.TabIndex = 18;
            CompanyNameLabel.Text = "Название\r\nкомпании:";
            CompanyNameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ActualAddressLabel
            // 
            ActualAddressLabel.AutoSize = true;
            ActualAddressLabel.ImageAlign = ContentAlignment.MiddleRight;
            ActualAddressLabel.Location = new Point(9, 301);
            ActualAddressLabel.MaximumSize = new Size(98, 45);
            ActualAddressLabel.Name = "ActualAddressLabel";
            ActualAddressLabel.Size = new Size(90, 34);
            ActualAddressLabel.TabIndex = 17;
            ActualAddressLabel.Text = "Фактический адрес:";
            ActualAddressLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ActualAddressTextBox
            // 
            ActualAddressTextBox.Location = new Point(113, 307);
            ActualAddressTextBox.Name = "ActualAddressTextBox";
            ActualAddressTextBox.Size = new Size(300, 25);
            ActualAddressTextBox.TabIndex = 16;
            // 
            // LegalAddressTextBox
            // 
            LegalAddressTextBox.Location = new Point(113, 267);
            LegalAddressTextBox.Name = "LegalAddressTextBox";
            LegalAddressTextBox.Size = new Size(300, 25);
            LegalAddressTextBox.TabIndex = 15;
            // 
            // LegalEntityInnTextBox
            // 
            LegalEntityInnTextBox.Location = new Point(113, 146);
            LegalEntityInnTextBox.Mask = "0000000000";
            LegalEntityInnTextBox.Name = "LegalEntityInnTextBox";
            LegalEntityInnTextBox.Size = new Size(300, 25);
            LegalEntityInnTextBox.TabIndex = 7;
            LegalEntityInnTextBox.ValidatingType = typeof(int);
            // 
            // AgeNumeric
            // 
            AgeNumeric.Location = new Point(113, 268);
            AgeNumeric.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            AgeNumeric.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            AgeNumeric.Name = "AgeNumeric";
            AgeNumeric.Size = new Size(299, 25);
            AgeNumeric.TabIndex = 13;
            AgeNumeric.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // ContactPersonTextBox
            // 
            ContactPersonTextBox.Location = new Point(113, 226);
            ContactPersonTextBox.Name = "ContactPersonTextBox";
            ContactPersonTextBox.Size = new Size(300, 25);
            ContactPersonTextBox.TabIndex = 14;
            // 
            // AgeLabel
            // 
            AgeLabel.AutoSize = true;
            AgeLabel.Location = new Point(39, 269);
            AgeLabel.MaximumSize = new Size(98, 45);
            AgeLabel.Name = "AgeLabel";
            AgeLabel.Size = new Size(62, 17);
            AgeLabel.TabIndex = 12;
            AgeLabel.Text = "Возраст:";
            AgeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(113, 226);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(300, 25);
            AddressTextBox.TabIndex = 11;
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.Location = new Point(50, 229);
            AddressLabel.MaximumSize = new Size(98, 45);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(51, 17);
            AddressLabel.TabIndex = 10;
            AddressLabel.Text = "Адрес:";
            AddressLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(113, 186);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(300, 25);
            NameTextBox.TabIndex = 9;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(54, 189);
            NameLabel.MaximumSize = new Size(98, 45);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(44, 17);
            NameLabel.TabIndex = 8;
            NameLabel.Text = "ФИО:";
            NameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // IndividualInnTextBox
            // 
            IndividualInnTextBox.Location = new Point(113, 146);
            IndividualInnTextBox.Mask = "000000000000";
            IndividualInnTextBox.Name = "IndividualInnTextBox";
            IndividualInnTextBox.Size = new Size(300, 25);
            IndividualInnTextBox.TabIndex = 6;
            IndividualInnTextBox.ValidatingType = typeof(int);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 149);
            label3.MaximumSize = new Size(98, 45);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 5;
            label3.Text = "ИНН:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(113, 106);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(300, 25);
            EmailTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 108);
            label2.MaximumSize = new Size(98, 45);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 3;
            label2.Text = "Email:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(113, 65);
            PhoneTextBox.Mask = "(999) 000-0000";
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(300, 25);
            PhoneTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 68);
            label1.MaximumSize = new Size(98, 45);
            label1.Name = "label1";
            label1.Size = new Size(63, 17);
            label1.TabIndex = 1;
            label1.Text = "Телефон:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TypeComboBox
            // 
            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Items.AddRange(new object[] { "Физическое лицо", "Юридическое лицо" });
            TypeComboBox.Location = new Point(113, 25);
            TypeComboBox.Name = "TypeComboBox";
            TypeComboBox.Size = new Size(300, 25);
            TypeComboBox.TabIndex = 0;
            TypeComboBox.SelectedIndexChanged += TypeComboBox_SelectedIndexChanged;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(154, 373);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(137, 53);
            SaveButton.TabIndex = 16;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(11, 373);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(137, 53);
            CancelButton.TabIndex = 17;
            CancelButton.Text = "Назад";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.FlatStyle = FlatStyle.System;
            DeleteButton.Location = new Point(297, 373);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(137, 53);
            DeleteButton.TabIndex = 18;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Visible = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EditClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(447, 439);
            Controls.Add(DeleteButton);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "EditClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактирование клиента";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AgeNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox TypeComboBox;
        private MaskedTextBox IndividualInnTextBox;
        private Label label3;
        private TextBox EmailTextBox;
        private Label label2;
        private MaskedTextBox PhoneTextBox;
        private Label label1;
        private NumericUpDown AgeNumeric;
        private Label AgeLabel;
        private TextBox AddressTextBox;
        private Label AddressLabel;
        private TextBox NameTextBox;
        private Label NameLabel;
        private MaskedTextBox LegalEntityInnTextBox;
        private Label ActualAddressLabel;
        private TextBox ActualAddressTextBox;
        private TextBox ContactPersonTextBox;
        private TextBox LegalAddressTextBox;
        private Button SaveButton;
        private Button CancelButton;
        private Label CompanyNameLabel;
        private Label ContactPersonLabel;
        private Label LegalAddressLabel;
        private Button DeleteButton;
    }
}