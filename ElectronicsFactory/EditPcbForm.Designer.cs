namespace ElectronicsFactory
{
    partial class EditPcbForm
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
            LayersNumeric = new NumericUpDown();
            WidthNumeric = new NumericUpDown();
            LengthNumeric = new NumericUpDown();
            ManufactureDatePicker = new DateTimePicker();
            TotalQuantity = new NumericUpDown();
            PriceNumeric = new NumericUpDown();
            CommentTextBox = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            DescriptionTextBox = new TextBox();
            label4 = new Label();
            BatchTextBox = new TextBox();
            label3 = new Label();
            SerialNumberTextBox = new TextBox();
            label1 = new Label();
            NameTextBox = new TextBox();
            label2 = new Label();
            SaveButton = new Button();
            CancelButton = new Button();
            PcbImage = new PictureBox();
            AddQuantityButton = new Button();
            groupBox2 = new GroupBox();
            AddQuantityNumeric = new NumericUpDown();
            ComponentsButton = new Button();
            DeleteButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayersNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WidthNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LengthNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TotalQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PriceNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PcbImage).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AddQuantityNumeric).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(LayersNumeric);
            groupBox1.Controls.Add(WidthNumeric);
            groupBox1.Controls.Add(LengthNumeric);
            groupBox1.Controls.Add(ManufactureDatePicker);
            groupBox1.Controls.Add(TotalQuantity);
            groupBox1.Controls.Add(PriceNumeric);
            groupBox1.Controls.Add(CommentTextBox);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(DescriptionTextBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(BatchTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(SerialNumberTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(NameTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(13, 13);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(377, 386);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Данные платы";
            // 
            // LayersNumeric
            // 
            LayersNumeric.Location = new Point(138, 306);
            LayersNumeric.Name = "LayersNumeric";
            LayersNumeric.Size = new Size(232, 25);
            LayersNumeric.TabIndex = 33;
            // 
            // WidthNumeric
            // 
            WidthNumeric.DecimalPlaces = 1;
            WidthNumeric.Location = new Point(138, 275);
            WidthNumeric.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            WidthNumeric.Name = "WidthNumeric";
            WidthNumeric.Size = new Size(232, 25);
            WidthNumeric.TabIndex = 32;
            // 
            // LengthNumeric
            // 
            LengthNumeric.DecimalPlaces = 1;
            LengthNumeric.Location = new Point(138, 243);
            LengthNumeric.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            LengthNumeric.Name = "LengthNumeric";
            LengthNumeric.Size = new Size(232, 25);
            LengthNumeric.TabIndex = 31;
            // 
            // ManufactureDatePicker
            // 
            ManufactureDatePicker.Location = new Point(138, 212);
            ManufactureDatePicker.Name = "ManufactureDatePicker";
            ManufactureDatePicker.Size = new Size(232, 25);
            ManufactureDatePicker.TabIndex = 30;
            // 
            // TotalQuantity
            // 
            TotalQuantity.Location = new Point(138, 181);
            TotalQuantity.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            TotalQuantity.Name = "TotalQuantity";
            TotalQuantity.Size = new Size(232, 25);
            TotalQuantity.TabIndex = 28;
            // 
            // PriceNumeric
            // 
            PriceNumeric.DecimalPlaces = 2;
            PriceNumeric.Location = new Point(138, 149);
            PriceNumeric.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            PriceNumeric.Name = "PriceNumeric";
            PriceNumeric.Size = new Size(232, 25);
            PriceNumeric.TabIndex = 27;
            // 
            // CommentTextBox
            // 
            CommentTextBox.Location = new Point(138, 336);
            CommentTextBox.Name = "CommentTextBox";
            CommentTextBox.Size = new Size(232, 25);
            CommentTextBox.TabIndex = 26;
            // 
            // label9
            // 
            label9.Location = new Point(2, 339);
            label9.MaximumSize = new Size(150, 45);
            label9.Name = "label9";
            label9.Size = new Size(130, 17);
            label9.TabIndex = 25;
            label9.Text = "Комментарий:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.Location = new Point(2, 308);
            label10.MaximumSize = new Size(150, 45);
            label10.Name = "label10";
            label10.Size = new Size(130, 17);
            label10.TabIndex = 23;
            label10.Text = "Количество слоёв:";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.Location = new Point(2, 277);
            label11.MaximumSize = new Size(150, 45);
            label11.Name = "label11";
            label11.Size = new Size(130, 17);
            label11.TabIndex = 21;
            label11.Text = "Ширина:";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.Location = new Point(2, 246);
            label12.MaximumSize = new Size(150, 45);
            label12.Name = "label12";
            label12.Size = new Size(130, 17);
            label12.TabIndex = 19;
            label12.Text = "Длина:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new Point(2, 215);
            label5.MaximumSize = new Size(150, 45);
            label5.Name = "label5";
            label5.Size = new Size(130, 17);
            label5.TabIndex = 17;
            label5.Text = "Дата изготовления:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Location = new Point(2, 183);
            label7.MaximumSize = new Size(150, 45);
            label7.Name = "label7";
            label7.Size = new Size(130, 17);
            label7.TabIndex = 13;
            label7.Text = "Всего на складе:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Location = new Point(2, 152);
            label8.MaximumSize = new Size(150, 45);
            label8.Name = "label8";
            label8.Size = new Size(130, 17);
            label8.TabIndex = 11;
            label8.Text = "Стоимость:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(138, 118);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(232, 25);
            DescriptionTextBox.TabIndex = 10;
            // 
            // label4
            // 
            label4.Location = new Point(2, 121);
            label4.MaximumSize = new Size(150, 45);
            label4.Name = "label4";
            label4.Size = new Size(130, 17);
            label4.TabIndex = 9;
            label4.Text = "Описание:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BatchTextBox
            // 
            BatchTextBox.Location = new Point(138, 87);
            BatchTextBox.Name = "BatchTextBox";
            BatchTextBox.Size = new Size(232, 25);
            BatchTextBox.TabIndex = 8;
            // 
            // label3
            // 
            label3.Location = new Point(2, 90);
            label3.MaximumSize = new Size(150, 45);
            label3.Name = "label3";
            label3.Size = new Size(130, 17);
            label3.TabIndex = 7;
            label3.Text = "Партия:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // SerialNumberTextBox
            // 
            SerialNumberTextBox.Location = new Point(138, 56);
            SerialNumberTextBox.Name = "SerialNumberTextBox";
            SerialNumberTextBox.Size = new Size(232, 25);
            SerialNumberTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.Location = new Point(2, 59);
            label1.MaximumSize = new Size(150, 45);
            label1.Name = "label1";
            label1.Size = new Size(130, 17);
            label1.TabIndex = 5;
            label1.Text = "Серийный номер:";
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
            // SaveButton
            // 
            SaveButton.Location = new Point(214, 429);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(166, 53);
            SaveButton.TabIndex = 16;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(18, 429);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(166, 53);
            CancelButton.TabIndex = 17;
            CancelButton.Text = "Назад";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // PcbImage
            // 
            PcbImage.Image = Properties.Resources.circuit_placeholder;
            PcbImage.Location = new Point(397, 13);
            PcbImage.Name = "PcbImage";
            PcbImage.Size = new Size(200, 200);
            PcbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            PcbImage.TabIndex = 18;
            PcbImage.TabStop = false;
            PcbImage.Click += PcbImage_Click;
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
            groupBox2.Location = new Point(397, 219);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(181, 119);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Добавить платы";
            // 
            // AddQuantityNumeric
            // 
            AddQuantityNumeric.Location = new Point(6, 24);
            AddQuantityNumeric.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            AddQuantityNumeric.Name = "AddQuantityNumeric";
            AddQuantityNumeric.Size = new Size(166, 25);
            AddQuantityNumeric.TabIndex = 29;
            // 
            // ComponentsButton
            // 
            ComponentsButton.Location = new Point(403, 352);
            ComponentsButton.Name = "ComponentsButton";
            ComponentsButton.Size = new Size(166, 53);
            ComponentsButton.TabIndex = 21;
            ComponentsButton.Text = "Компоненты платы";
            ComponentsButton.UseVisualStyleBackColor = true;
            ComponentsButton.Click += ComponentsButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.FlatStyle = FlatStyle.System;
            DeleteButton.Location = new Point(403, 429);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(166, 53);
            DeleteButton.TabIndex = 22;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Visible = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EditPcbForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(609, 498);
            Controls.Add(DeleteButton);
            Controls.Add(ComponentsButton);
            Controls.Add(groupBox2);
            Controls.Add(PcbImage);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "EditPcbForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактирование платы";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LayersNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)WidthNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)LengthNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)TotalQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)PriceNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)PcbImage).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AddQuantityNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox TypeComboBox;
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
        private Label label5;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label7;
        private Label label8;
        private TextBox Description;
        private Label label4;
        private TextBox BatchTextBox;
        private Label label3;
        private TextBox SerialNumberTextBox;
        private Label label1;
        private TextBox DescriptionTextBox;
        private NumericUpDown PriceNumeric;
        private NumericUpDown TotalQuantity;
        private NumericUpDown LayersNumeric;
        private NumericUpDown WidthNumeric;
        private NumericUpDown LengthNumeric;
        private DateTimePicker ManufactureDatePicker;
        private PictureBox PcbImage;
        private Button AddQuantityButton;
        private GroupBox groupBox2;
        private NumericUpDown AddQuantityNumeric;
        private Button ComponentsButton;
        private Label CompanyNameLabel;
        private Label ContactPersonLabel;
        private Label LegalAddressLabel;
        private Button DeleteButton;
    }
}