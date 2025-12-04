namespace ElectronicsFactory
{
    partial class OrderCard
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
            ShipmentDateLabel = new Label();
            RegistrationDateLabel = new Label();
            TotalAmountLabel = new Label();
            StatusLabel = new Label();
            ClientLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(ShipmentDateLabel);
            panel1.Controls.Add(RegistrationDateLabel);
            panel1.Controls.Add(TotalAmountLabel);
            panel1.Controls.Add(StatusLabel);
            panel1.Controls.Add(ClientLabel);
            panel1.Location = new Point(4, 4);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(461, 151);
            panel1.TabIndex = 1;
            panel1.Click += Card_Click;
            // 
            // ShipmentDateLabel
            // 
            ShipmentDateLabel.AutoSize = true;
            ShipmentDateLabel.Location = new Point(13, 121);
            ShipmentDateLabel.Margin = new Padding(4, 0, 4, 0);
            ShipmentDateLabel.Name = "ShipmentDateLabel";
            ShipmentDateLabel.Size = new Size(38, 15);
            ShipmentDateLabel.TabIndex = 4;
            ShipmentDateLabel.Text = "label4";
            ShipmentDateLabel.Click += Card_Click;
            // 
            // RegistrationDateLabel
            // 
            RegistrationDateLabel.AutoSize = true;
            RegistrationDateLabel.Location = new Point(13, 95);
            RegistrationDateLabel.Margin = new Padding(4, 0, 4, 0);
            RegistrationDateLabel.Name = "RegistrationDateLabel";
            RegistrationDateLabel.Size = new Size(38, 15);
            RegistrationDateLabel.TabIndex = 3;
            RegistrationDateLabel.Text = "label4";
            RegistrationDateLabel.Click += Card_Click;
            // 
            // TotalAmountLabel
            // 
            TotalAmountLabel.AutoSize = true;
            TotalAmountLabel.Location = new Point(13, 70);
            TotalAmountLabel.Margin = new Padding(4, 0, 4, 0);
            TotalAmountLabel.Name = "TotalAmountLabel";
            TotalAmountLabel.Size = new Size(38, 15);
            TotalAmountLabel.TabIndex = 2;
            TotalAmountLabel.Text = "label3";
            TotalAmountLabel.Click += Card_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(13, 44);
            StatusLabel.Margin = new Padding(4, 0, 4, 0);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(38, 15);
            StatusLabel.TabIndex = 1;
            StatusLabel.Text = "label2";
            StatusLabel.Click += Card_Click;
            // 
            // ClientLabel
            // 
            ClientLabel.AutoSize = true;
            ClientLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ClientLabel.Location = new Point(13, 12);
            ClientLabel.Margin = new Padding(4, 0, 4, 0);
            ClientLabel.Name = "ClientLabel";
            ClientLabel.Size = new Size(63, 25);
            ClientLabel.TabIndex = 0;
            ClientLabel.Text = "label1";
            ClientLabel.Click += Card_Click;
            // 
            // OrderCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "OrderCard";
            Size = new Size(469, 159);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label RegistrationDateLabel;
        private Label TotalAmountLabel;
        private Label StatusLabel;
        private Label ClientLabel;
        private Label ShipmentDateLabel;
    }
}
