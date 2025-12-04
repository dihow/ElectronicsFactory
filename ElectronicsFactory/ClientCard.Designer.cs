namespace ElectronicsFactory
{
    partial class ClientCard
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            EmailLabel = new Label();
            PhoneLabel = new Label();
            TypeLabel = new Label();
            NameLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(EmailLabel);
            panel1.Controls.Add(PhoneLabel);
            panel1.Controls.Add(TypeLabel);
            panel1.Controls.Add(NameLabel);
            panel1.Location = new Point(5, 5);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(455, 135);
            panel1.TabIndex = 0;
            panel1.Click += Card_Click;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(13, 103);
            EmailLabel.Margin = new Padding(5, 0, 5, 0);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(42, 17);
            EmailLabel.TabIndex = 3;
            EmailLabel.Text = "label4";
            EmailLabel.Click += Card_Click;
            // 
            // PhoneLabel
            // 
            PhoneLabel.AutoSize = true;
            PhoneLabel.Location = new Point(13, 74);
            PhoneLabel.Margin = new Padding(5, 0, 5, 0);
            PhoneLabel.Name = "PhoneLabel";
            PhoneLabel.Size = new Size(42, 17);
            PhoneLabel.TabIndex = 2;
            PhoneLabel.Text = "label3";
            PhoneLabel.Click += Card_Click;
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(13, 46);
            TypeLabel.Margin = new Padding(5, 0, 5, 0);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(42, 17);
            TypeLabel.TabIndex = 1;
            TypeLabel.Text = "label2";
            TypeLabel.Click += Card_Click;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NameLabel.Location = new Point(13, 12);
            NameLabel.Margin = new Padding(5, 0, 5, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(63, 25);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "label1";
            NameLabel.Click += Card_Click;
            // 
            // ClientCard
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "ClientCard";
            Size = new Size(465, 141);
            Load += ClientCard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label EmailLabel;
        private Label PhoneLabel;
        private Label TypeLabel;
        private Label NameLabel;
    }
}
