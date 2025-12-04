namespace ElectronicsFactory
{
    partial class MainForm
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
            PcbsButton = new Button();
            ClientsButton = new Button();
            ComponentsButton = new Button();
            OrdersButton = new Button();
            MovementsButton = new Button();
            ExitButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PcbsButton
            // 
            PcbsButton.Location = new Point(23, 35);
            PcbsButton.Name = "PcbsButton";
            PcbsButton.Size = new Size(229, 69);
            PcbsButton.TabIndex = 0;
            PcbsButton.Text = "Платы на складе";
            PcbsButton.UseVisualStyleBackColor = true;
            PcbsButton.Click += PcbsButton_Click;
            // 
            // ClientsButton
            // 
            ClientsButton.Location = new Point(258, 35);
            ClientsButton.Name = "ClientsButton";
            ClientsButton.Size = new Size(229, 69);
            ClientsButton.TabIndex = 1;
            ClientsButton.Text = "Клиенты";
            ClientsButton.UseVisualStyleBackColor = true;
            ClientsButton.Click += ClientsButton_Click;
            // 
            // ComponentsButton
            // 
            ComponentsButton.Location = new Point(23, 110);
            ComponentsButton.Name = "ComponentsButton";
            ComponentsButton.Size = new Size(229, 69);
            ComponentsButton.TabIndex = 2;
            ComponentsButton.Text = "Компоненты";
            ComponentsButton.UseVisualStyleBackColor = true;
            ComponentsButton.Click += ComponentsButton_Click;
            // 
            // OrdersButton
            // 
            OrdersButton.Location = new Point(258, 110);
            OrdersButton.Name = "OrdersButton";
            OrdersButton.Size = new Size(229, 69);
            OrdersButton.TabIndex = 3;
            OrdersButton.Text = "Заказы";
            OrdersButton.UseVisualStyleBackColor = true;
            OrdersButton.Click += OrdersButton_Click;
            // 
            // MovementsButton
            // 
            MovementsButton.Location = new Point(493, 35);
            MovementsButton.Name = "MovementsButton";
            MovementsButton.Size = new Size(229, 69);
            MovementsButton.TabIndex = 4;
            MovementsButton.Text = "Движения";
            MovementsButton.UseVisualStyleBackColor = true;
            MovementsButton.Click += MovementsButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(258, 185);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(229, 69);
            ExitButton.TabIndex = 5;
            ExitButton.Text = "Выход";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cpu1;
            pictureBox1.Location = new Point(23, 270);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(699, 243);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 525);
            Controls.Add(pictureBox1);
            Controls.Add(ExitButton);
            Controls.Add(MovementsButton);
            Controls.Add(OrdersButton);
            Controls.Add(ComponentsButton);
            Controls.Add(ClientsButton);
            Controls.Add(PcbsButton);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главная форма";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button PcbsButton;
        private Button ClientsButton;
        private Button ComponentsButton;
        private Button OrdersButton;
        private Button MovementsButton;
        private Button ExitButton;
        private PictureBox pictureBox1;
    }
}