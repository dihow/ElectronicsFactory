namespace ElectronicsFactory
{
    partial class EditPcbComponentForm
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
            ComponentComboBox = new ComboBox();
            CountNumeric = new NumericUpDown();
            label7 = new Label();
            CoordinatesTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            CancelButton = new Button();
            SaveButton = new Button();
            DeleteButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CountNumeric).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(ComponentComboBox);
            groupBox1.Controls.Add(CountNumeric);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(CoordinatesTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(13, 13);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(401, 199);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Данные компонента";
            // 
            // ComponentComboBox
            // 
            ComponentComboBox.FormattingEnabled = true;
            ComponentComboBox.Location = new Point(26, 53);
            ComponentComboBox.Name = "ComponentComboBox";
            ComponentComboBox.Size = new Size(368, 25);
            ComponentComboBox.TabIndex = 29;
            // 
            // CountNumeric
            // 
            CountNumeric.Location = new Point(26, 101);
            CountNumeric.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            CountNumeric.Name = "CountNumeric";
            CountNumeric.Size = new Size(368, 25);
            CountNumeric.TabIndex = 28;
            // 
            // label7
            // 
            label7.Location = new Point(26, 81);
            label7.MaximumSize = new Size(150, 45);
            label7.Name = "label7";
            label7.Size = new Size(150, 17);
            label7.TabIndex = 13;
            label7.Text = "Количество на плате:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CoordinatesTextBox
            // 
            CoordinatesTextBox.Location = new Point(26, 149);
            CoordinatesTextBox.Name = "CoordinatesTextBox";
            CoordinatesTextBox.Size = new Size(368, 25);
            CoordinatesTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.Location = new Point(26, 129);
            label1.MaximumSize = new Size(150, 45);
            label1.Name = "label1";
            label1.Size = new Size(150, 17);
            label1.TabIndex = 5;
            label1.Text = "Координаты на плате:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(26, 33);
            label2.MaximumSize = new Size(150, 45);
            label2.Name = "label2";
            label2.Size = new Size(130, 17);
            label2.TabIndex = 3;
            label2.Text = "Компонент:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(13, 219);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(129, 53);
            CancelButton.TabIndex = 19;
            CancelButton.Text = "Назад";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(149, 219);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(129, 53);
            SaveButton.TabIndex = 18;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.FlatStyle = FlatStyle.System;
            DeleteButton.Location = new Point(284, 219);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(129, 53);
            DeleteButton.TabIndex = 20;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Visible = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EditPcbComponentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 284);
            Controls.Add(DeleteButton);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "EditPcbComponentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактирование компонента на плате";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CountNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label13;
        private ComboBox ComponentComboBox;
        private NumericUpDown CountNumeric;
        private Label label7;
        private Label label8;
        private TextBox CoordinatesTextBox;
        private Label label1;
        private Label label2;
        private Button CancelButton;
        private Button SaveButton;
        private Button DeleteButton;
    }
}