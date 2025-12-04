namespace ElectronicsFactory
{
    partial class MovementCard
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
            DateLabel = new Label();
            DescriptionLabel = new Label();
            TypeLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(DateLabel);
            panel1.Controls.Add(DescriptionLabel);
            panel1.Controls.Add(TypeLabel);
            panel1.Location = new Point(4, 4);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 102);
            panel1.TabIndex = 1;
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Location = new Point(13, 74);
            DateLabel.Margin = new Padding(4, 0, 4, 0);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(38, 15);
            DateLabel.TabIndex = 2;
            DateLabel.Text = "label3";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(13, 47);
            DescriptionLabel.Margin = new Padding(4, 0, 4, 0);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(38, 15);
            DescriptionLabel.TabIndex = 1;
            DescriptionLabel.Text = "label2";
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TypeLabel.Location = new Point(13, 12);
            TypeLabel.Margin = new Padding(4, 0, 4, 0);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(63, 25);
            TypeLabel.TabIndex = 0;
            TypeLabel.Text = "label1";
            // 
            // MovementCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "MovementCard";
            Size = new Size(470, 110);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label DateLabel;
        private Label DescriptionLabel;
        private Label TypeLabel;
    }
}
