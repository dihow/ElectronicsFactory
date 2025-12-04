namespace ElectronicsFactory
{
    partial class EditComponentForm
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
            label13 = new Label();
            TypeComboBox = new ComboBox();
            StockQuantity = new NumericUpDown();
            PriceNumeric = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            ManufacturerTextBox = new TextBox();
            label1 = new Label();
            NameTextBox = new TextBox();
            label2 = new Label();
            SecondSpecificationNumeric = new NumericUpDown();
            SecondSpecificationLabel = new Label();
            FirstSpecificationNumeric = new NumericUpDown();
            FirstSpecificationLabel = new Label();
            ThirdSpecificationNumeric = new NumericUpDown();
            ThirdSpecificationLabel = new Label();
            SaveButton = new Button();
            CancelButton = new Button();
            AddQuantityButton = new Button();
            groupBox2 = new GroupBox();
            AddQuantityNumeric = new NumericUpDown();
            SpecificationsGroupBox = new GroupBox();
            DeleteButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StockQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PriceNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SecondSpecificationNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FirstSpecificationNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThirdSpecificationNumeric).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AddQuantityNumeric).BeginInit();
            SpecificationsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(TypeComboBox);
            groupBox1.Controls.Add(StockQuantity);
            groupBox1.Controls.Add(PriceNumeric);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(ManufacturerTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(NameTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(13, 13);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(377, 199);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Данные компонента";
            // 
            // label13
            // 
            label13.Location = new Point(2, 152);
            label13.MaximumSize = new Size(150, 45);
            label13.Name = "label13";
            label13.Size = new Size(130, 17);
            label13.TabIndex = 30;
            label13.Text = "Тип компонента:";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TypeComboBox
            // 
            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Items.AddRange(new object[] { "Резистор", "Конденсатор", "Диод" });
            TypeComboBox.Location = new Point(138, 149);
            TypeComboBox.Name = "TypeComboBox";
            TypeComboBox.Size = new Size(232, 25);
            TypeComboBox.TabIndex = 29;
            TypeComboBox.SelectedIndexChanged += TypeComboBox_SelectedIndexChanged;
            // 
            // StockQuantity
            // 
            StockQuantity.Location = new Point(138, 118);
            StockQuantity.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            StockQuantity.Name = "StockQuantity";
            StockQuantity.Size = new Size(232, 25);
            StockQuantity.TabIndex = 28;
            // 
            // PriceNumeric
            // 
            PriceNumeric.DecimalPlaces = 2;
            PriceNumeric.Location = new Point(138, 87);
            PriceNumeric.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            PriceNumeric.Name = "PriceNumeric";
            PriceNumeric.Size = new Size(232, 25);
            PriceNumeric.TabIndex = 27;
            // 
            // label7
            // 
            label7.Location = new Point(2, 120);
            label7.MaximumSize = new Size(150, 45);
            label7.Name = "label7";
            label7.Size = new Size(130, 17);
            label7.TabIndex = 13;
            label7.Text = "Всего на складе:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Location = new Point(2, 89);
            label8.MaximumSize = new Size(150, 45);
            label8.Name = "label8";
            label8.Size = new Size(130, 17);
            label8.TabIndex = 11;
            label8.Text = "Стоимость:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ManufacturerTextBox
            // 
            ManufacturerTextBox.Location = new Point(138, 56);
            ManufacturerTextBox.Name = "ManufacturerTextBox";
            ManufacturerTextBox.Size = new Size(232, 25);
            ManufacturerTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.Location = new Point(2, 59);
            label1.MaximumSize = new Size(150, 45);
            label1.Name = "label1";
            label1.Size = new Size(130, 17);
            label1.TabIndex = 5;
            label1.Text = "Производитель:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(138, 25);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(232, 25);
            NameTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.Location = new Point(2, 28);
            label2.MaximumSize = new Size(150, 45);
            label2.Name = "label2";
            label2.Size = new Size(130, 17);
            label2.TabIndex = 3;
            label2.Text = "Название:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // SecondSpecificationNumeric
            // 
            SecondSpecificationNumeric.DecimalPlaces = 2;
            SecondSpecificationNumeric.Location = new Point(55, 105);
            SecondSpecificationNumeric.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            SecondSpecificationNumeric.Name = "SecondSpecificationNumeric";
            SecondSpecificationNumeric.Size = new Size(232, 25);
            SecondSpecificationNumeric.TabIndex = 34;
            // 
            // SecondSpecificationLabel
            // 
            SecondSpecificationLabel.Location = new Point(13, 82);
            SecondSpecificationLabel.Name = "SecondSpecificationLabel";
            SecondSpecificationLabel.Size = new Size(289, 17);
            SecondSpecificationLabel.TabIndex = 33;
            SecondSpecificationLabel.Text = "Стоимость:";
            SecondSpecificationLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FirstSpecificationNumeric
            // 
            FirstSpecificationNumeric.DecimalPlaces = 2;
            FirstSpecificationNumeric.Location = new Point(55, 50);
            FirstSpecificationNumeric.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            FirstSpecificationNumeric.Name = "FirstSpecificationNumeric";
            FirstSpecificationNumeric.Size = new Size(232, 25);
            FirstSpecificationNumeric.TabIndex = 32;
            // 
            // FirstSpecificationLabel
            // 
            FirstSpecificationLabel.Location = new Point(13, 26);
            FirstSpecificationLabel.MaximumSize = new Size(300, 45);
            FirstSpecificationLabel.Name = "FirstSpecificationLabel";
            FirstSpecificationLabel.Size = new Size(289, 17);
            FirstSpecificationLabel.TabIndex = 31;
            FirstSpecificationLabel.Text = "Стоимость:";
            FirstSpecificationLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ThirdSpecificationNumeric
            // 
            ThirdSpecificationNumeric.DecimalPlaces = 2;
            ThirdSpecificationNumeric.Location = new Point(55, 162);
            ThirdSpecificationNumeric.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            ThirdSpecificationNumeric.Name = "ThirdSpecificationNumeric";
            ThirdSpecificationNumeric.Size = new Size(232, 25);
            ThirdSpecificationNumeric.TabIndex = 30;
            // 
            // ThirdSpecificationLabel
            // 
            ThirdSpecificationLabel.Location = new Point(13, 139);
            ThirdSpecificationLabel.Name = "ThirdSpecificationLabel";
            ThirdSpecificationLabel.Size = new Size(289, 17);
            ThirdSpecificationLabel.TabIndex = 29;
            ThirdSpecificationLabel.Text = "Стоимость:";
            ThirdSpecificationLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(208, 436);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(166, 53);
            SaveButton.TabIndex = 16;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(12, 436);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(166, 53);
            CancelButton.TabIndex = 17;
            CancelButton.Text = "Назад";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddQuantityButton
            // 
            AddQuantityButton.Location = new Point(6, 55);
            AddQuantityButton.Name = "AddQuantityButton";
            AddQuantityButton.Size = new Size(166, 53);
            AddQuantityButton.TabIndex = 19;
            AddQuantityButton.Text = "Добавить";
            AddQuantityButton.UseVisualStyleBackColor = true;
            AddQuantityButton.Click += AddQuantityButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(AddQuantityNumeric);
            groupBox2.Controls.Add(AddQuantityButton);
            groupBox2.Location = new Point(397, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(181, 130);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Добавить компоненты";
            // 
            // AddQuantityNumeric
            // 
            AddQuantityNumeric.Location = new Point(6, 24);
            AddQuantityNumeric.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            AddQuantityNumeric.Name = "AddQuantityNumeric";
            AddQuantityNumeric.Size = new Size(166, 25);
            AddQuantityNumeric.TabIndex = 29;
            // 
            // SpecificationsGroupBox
            // 
            SpecificationsGroupBox.AutoSize = true;
            SpecificationsGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SpecificationsGroupBox.Controls.Add(SecondSpecificationNumeric);
            SpecificationsGroupBox.Controls.Add(FirstSpecificationNumeric);
            SpecificationsGroupBox.Controls.Add(SecondSpecificationLabel);
            SpecificationsGroupBox.Controls.Add(ThirdSpecificationLabel);
            SpecificationsGroupBox.Controls.Add(ThirdSpecificationNumeric);
            SpecificationsGroupBox.Controls.Add(FirstSpecificationLabel);
            SpecificationsGroupBox.Location = new Point(15, 219);
            SpecificationsGroupBox.Name = "SpecificationsGroupBox";
            SpecificationsGroupBox.Size = new Size(308, 211);
            SpecificationsGroupBox.TabIndex = 21;
            SpecificationsGroupBox.TabStop = false;
            SpecificationsGroupBox.Text = "groupBox3";
            // 
            // DeleteButton
            // 
            DeleteButton.FlatStyle = FlatStyle.System;
            DeleteButton.Location = new Point(403, 436);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(166, 53);
            DeleteButton.TabIndex = 22;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Visible = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EditComponentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(590, 503);
            Controls.Add(DeleteButton);
            Controls.Add(SpecificationsGroupBox);
            Controls.Add(groupBox2);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "EditComponentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактирование компонента";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)StockQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)PriceNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)SecondSpecificationNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)FirstSpecificationNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThirdSpecificationNumeric).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AddQuantityNumeric).EndInit();
            SpecificationsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private MaskedTextBox IndividualInnTextBox;
        private TextBox NameTextBox;
        private Label label2;
        private MaskedTextBox PhoneTextBox;
        private NumericUpDown AgeNumeric;
        private Label AgeLabel;
        private TextBox AddressTextBox;
        private Label AddressLabel;
        private Label NameLabel;
        private MaskedTextBox LegalEntityInnTextBox;
        private Label ActualAddressLabel;
        private TextBox ActualAddressTextBox;
        private TextBox ContactPersonTextBox;
        private TextBox LegalAddressTextBox;
        private Button SaveButton;
        private Button CancelButton;
        private TextBox CommentTextBox;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
        private Label label7;
        private Label label8;
        private TextBox Description;
        private TextBox BatcTextBox;
        private TextBox ManufacturerTextBox;
        private Label label1;
        private TextBox DescriptionTextBox;
        private NumericUpDown PriceNumeric;
        private NumericUpDown OrderedQuantity;
        private NumericUpDown StockQuantity;
        private NumericUpDown LayersNumeric;
        private NumericUpDown WidthNumeric;
        private NumericUpDown LengthNumeric;
        private DateTimePicker ManufactureDatePicker;
        private Button AddQuantityButton;
        private GroupBox groupBox2;
        private NumericUpDown AddQuantityNumeric;
        private Label CompanyNameLabel;
        private Label ContactPersonLabel;
        private Label LegalAddressLabel;
        private NumericUpDown SecondSpecificationNumeric;
        private Label SecondSpecificationLabel;
        private NumericUpDown FirstSpecificationNumeric;
        private Label FirstSpecificationLabel;
        private NumericUpDown ThirdSpecificationNumeric;
        private Label ThirdSpecificationLabel;
        private Label label13;
        private ComboBox TypeComboBox;
        private GroupBox SpecificationsGroupBox;
        private Button DeleteButton;
    }
}