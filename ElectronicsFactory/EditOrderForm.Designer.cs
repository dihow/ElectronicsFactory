namespace ElectronicsFactory
{
    partial class EditOrderForm
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
            ShipmentDateCheckBox = new CheckBox();
            StatusComboBox = new ComboBox();
            ClientComboBox = new ComboBox();
            ShipmentDatePicker = new DateTimePicker();
            TransportCompanyTextBox = new TextBox();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            AddButton = new Button();
            QuantityNumeric = new NumericUpDown();
            label6 = new Label();
            PcbComboBox = new ComboBox();
            label4 = new Label();
            CloseButton = new Button();
            SaveButton = new Button();
            TotalAmountLabel = new Label();
            DeleteButton = new Button();
            label5 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label13 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuantityNumeric).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(ShipmentDateCheckBox);
            groupBox1.Controls.Add(StatusComboBox);
            groupBox1.Controls.Add(ClientComboBox);
            groupBox1.Controls.Add(ShipmentDatePicker);
            groupBox1.Controls.Add(TransportCompanyTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(13, 13);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(377, 168);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Данные заказа";
            // 
            // ShipmentDateCheckBox
            // 
            ShipmentDateCheckBox.AutoSize = true;
            ShipmentDateCheckBox.Location = new Point(13, 120);
            ShipmentDateCheckBox.Name = "ShipmentDateCheckBox";
            ShipmentDateCheckBox.Size = new Size(119, 21);
            ShipmentDateCheckBox.TabIndex = 10;
            ShipmentDateCheckBox.Text = "Дата отгрузки:";
            ShipmentDateCheckBox.UseVisualStyleBackColor = true;
            ShipmentDateCheckBox.Click += ShipmentDateCheckBox_CheckedChanged;
            // 
            // StatusComboBox
            // 
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(138, 56);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(232, 25);
            StatusComboBox.TabIndex = 32;
            // 
            // ClientComboBox
            // 
            ClientComboBox.FormattingEnabled = true;
            ClientComboBox.Location = new Point(138, 25);
            ClientComboBox.Name = "ClientComboBox";
            ClientComboBox.Size = new Size(232, 25);
            ClientComboBox.TabIndex = 31;
            // 
            // ShipmentDatePicker
            // 
            ShipmentDatePicker.Location = new Point(138, 118);
            ShipmentDatePicker.Name = "ShipmentDatePicker";
            ShipmentDatePicker.Size = new Size(232, 25);
            ShipmentDatePicker.TabIndex = 30;
            // 
            // TransportCompanyTextBox
            // 
            TransportCompanyTextBox.Location = new Point(138, 87);
            TransportCompanyTextBox.Name = "TransportCompanyTextBox";
            TransportCompanyTextBox.Size = new Size(232, 25);
            TransportCompanyTextBox.TabIndex = 8;
            // 
            // label3
            // 
            label3.Location = new Point(2, 76);
            label3.MaximumSize = new Size(150, 45);
            label3.Name = "label3";
            label3.Size = new Size(130, 45);
            label3.TabIndex = 7;
            label3.Text = "Транспортная компания:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Location = new Point(2, 59);
            label1.MaximumSize = new Size(150, 45);
            label1.Name = "label1";
            label1.Size = new Size(130, 17);
            label1.TabIndex = 5;
            label1.Text = "Статус:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(2, 28);
            label2.MaximumSize = new Size(150, 45);
            label2.Name = "label2";
            label2.Size = new Size(130, 17);
            label2.TabIndex = 3;
            label2.Text = "Клиент:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(559, 293);
            dataGridView1.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(397, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(571, 323);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Корзина заказа";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(AddButton);
            groupBox3.Controls.Add(QuantityNumeric);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(PcbComboBox);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(83, 188);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(308, 148);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Добавить плату";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(145, 86);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(155, 51);
            AddButton.TabIndex = 6;
            AddButton.Text = "Добавить в корзину";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddItemButton_Click;
            // 
            // QuantityNumeric
            // 
            QuantityNumeric.Location = new Point(145, 55);
            QuantityNumeric.Name = "QuantityNumeric";
            QuantityNumeric.Size = new Size(155, 25);
            QuantityNumeric.TabIndex = 36;
            // 
            // label6
            // 
            label6.Location = new Point(9, 57);
            label6.MaximumSize = new Size(150, 45);
            label6.Name = "label6";
            label6.Size = new Size(130, 17);
            label6.TabIndex = 35;
            label6.Text = "Количество:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PcbComboBox
            // 
            PcbComboBox.FormattingEnabled = true;
            PcbComboBox.Location = new Point(145, 24);
            PcbComboBox.Name = "PcbComboBox";
            PcbComboBox.Size = new Size(155, 25);
            PcbComboBox.TabIndex = 34;
            // 
            // label4
            // 
            label4.Location = new Point(9, 27);
            label4.MaximumSize = new Size(150, 45);
            label4.Name = "label4";
            label4.Size = new Size(130, 17);
            label4.TabIndex = 33;
            label4.Text = "Плата:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(13, 376);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(155, 51);
            CloseButton.TabIndex = 7;
            CloseButton.Text = "Назад";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(198, 376);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(155, 51);
            SaveButton.TabIndex = 8;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // TotalAmountLabel
            // 
            TotalAmountLabel.AutoSize = true;
            TotalAmountLabel.Location = new Point(133, 0);
            TotalAmountLabel.Name = "TotalAmountLabel";
            TotalAmountLabel.Size = new Size(49, 17);
            TotalAmountLabel.TabIndex = 9;
            TotalAmountLabel.Text = "label13";
            // 
            // DeleteButton
            // 
            DeleteButton.FlatStyle = FlatStyle.System;
            DeleteButton.Location = new Point(380, 376);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(155, 51);
            DeleteButton.TabIndex = 19;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Visible = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(124, 17);
            label5.TabIndex = 20;
            label5.Text = "Стоимость заказа:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(TotalAmountLabel);
            flowLayoutPanel1.Controls.Add(label13);
            flowLayoutPanel1.Location = new Point(397, 342);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(246, 21);
            flowLayoutPanel1.TabIndex = 21;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(188, 0);
            label13.Name = "label13";
            label13.Size = new Size(34, 17);
            label13.TabIndex = 22;
            label13.Text = "руб.";
            // 
            // EditOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 438);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(CloseButton);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "EditOrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактирование заказа";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)QuantityNumeric).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker ShipmentDatePicker;
        private GroupBox groupBox1;
        private NumericUpDown LayersNumeric;
        private NumericUpDown WidthNumeric;
        private NumericUpDown LengthNumeric;
        private DateTimePicker ManufactureDatePicker;
        private NumericUpDown OrderedQuantity;
        private NumericUpDown TotalQuantity;
        private NumericUpDown PriceNumeric;
        private TextBox CommentTextBox;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label7;
        private Label label8;
        private TextBox DescriptionTextBox;
        private TextBox TransportCompanyTextBox;
        private Label label3;
        private TextBox SerialNumberTextBox;
        private Label label1;
        private TextBox NameTextBox;
        private Label label2;
        private ComboBox StatusComboBox;
        private ComboBox ClientComboBox;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private NumericUpDown QuantityNumeric;
        private Label label6;
        private ComboBox PcbComboBox;
        private Label label4;
        private Button AddButton;
        private Button CloseButton;
        private Button SaveButton;
        private Label TotalAmountLabel;
        private CheckBox ShipmentDateCheckBox;
        private Button DeleteButton;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label13;
    }
}