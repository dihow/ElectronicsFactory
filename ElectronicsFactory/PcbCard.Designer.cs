namespace ElectronicsFactory
{
    partial class PcbCard
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
            PcbImage = new PictureBox();
            QuantityLabel = new Label();
            PriceLabel = new Label();
            DescriptionLabel = new Label();
            NameLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PcbImage).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(PcbImage);
            panel1.Controls.Add(QuantityLabel);
            panel1.Controls.Add(PriceLabel);
            panel1.Controls.Add(DescriptionLabel);
            panel1.Controls.Add(NameLabel);
            panel1.Location = new Point(5, 5);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(527, 137);
            panel1.TabIndex = 1;
            panel1.Click += Card_Click;
            // 
            // PcbImage
            // 
            PcbImage.BackgroundImageLayout = ImageLayout.None;
            PcbImage.ErrorImage = null;
            PcbImage.Location = new Point(16, 14);
            PcbImage.Name = "PcbImage";
            PcbImage.Size = new Size(114, 105);
            PcbImage.SizeMode = PictureBoxSizeMode.Zoom;
            PcbImage.TabIndex = 4;
            PcbImage.TabStop = false;
            PcbImage.Click += Card_Click;
            // 
            // QuantityLabel
            // 
            QuantityLabel.AutoSize = true;
            QuantityLabel.Location = new Point(148, 109);
            QuantityLabel.Margin = new Padding(5, 0, 5, 0);
            QuantityLabel.Name = "QuantityLabel";
            QuantityLabel.Size = new Size(42, 17);
            QuantityLabel.TabIndex = 3;
            QuantityLabel.Text = "label4";
            QuantityLabel.Click += Card_Click;
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(148, 77);
            PriceLabel.Margin = new Padding(5, 0, 5, 0);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(42, 17);
            PriceLabel.TabIndex = 2;
            PriceLabel.Text = "label3";
            PriceLabel.Click += Card_Click;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(148, 47);
            DescriptionLabel.Margin = new Padding(5, 0, 5, 0);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(42, 17);
            DescriptionLabel.TabIndex = 1;
            DescriptionLabel.Text = "label2";
            DescriptionLabel.Click += Card_Click;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NameLabel.Location = new Point(148, 10);
            NameLabel.Margin = new Padding(5, 0, 5, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(63, 25);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "label1";
            NameLabel.Click += Card_Click;
            // 
            // PcbCard
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "PcbCard";
            Size = new Size(536, 147);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PcbImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox PcbImage;
        private Label QuantityLabel;
        private Label PriceLabel;
        private Label DescriptionLabel;
        private Label NameLabel;
    }
}
