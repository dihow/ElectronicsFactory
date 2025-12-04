namespace ElectronicsFactory
{
    partial class ComponentCard
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
            QuantityLabel = new Label();
            ManufacturerLabel = new Label();
            TypeLabel = new Label();
            NameLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(QuantityLabel);
            panel1.Controls.Add(ManufacturerLabel);
            panel1.Controls.Add(TypeLabel);
            panel1.Controls.Add(NameLabel);
            panel1.Location = new Point(4, 4);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 135);
            panel1.TabIndex = 0;
            panel1.Click += Card_Click;
            // 
            // QuantityLabel
            // 
            QuantityLabel.AutoSize = true;
            QuantityLabel.Location = new Point(13, 103);
            QuantityLabel.Margin = new Padding(4, 0, 4, 0);
            QuantityLabel.Name = "QuantityLabel";
            QuantityLabel.Size = new Size(42, 17);
            QuantityLabel.TabIndex = 3;
            QuantityLabel.Text = "label4";
            QuantityLabel.Click += Card_Click;
            // 
            // ManufacturerLabel
            // 
            ManufacturerLabel.AutoSize = true;
            ManufacturerLabel.Location = new Point(13, 74);
            ManufacturerLabel.Margin = new Padding(4, 0, 4, 0);
            ManufacturerLabel.Name = "ManufacturerLabel";
            ManufacturerLabel.Size = new Size(42, 17);
            ManufacturerLabel.TabIndex = 2;
            ManufacturerLabel.Text = "label3";
            ManufacturerLabel.Click += Card_Click;
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(13, 46);
            TypeLabel.Margin = new Padding(4, 0, 4, 0);
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
            NameLabel.Margin = new Padding(4, 0, 4, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(63, 25);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "label1";
            NameLabel.Click += Card_Click;
            // 
            // ComponentCard
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "ComponentCard";
            Size = new Size(467, 143);
            Paint += ComponentCard_Paint;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label QuantityLabel;
        private Label ManufacturerLabel;
        private Label TypeLabel;
        private Label NameLabel;
    }
}
