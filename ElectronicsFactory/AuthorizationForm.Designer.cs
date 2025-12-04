namespace ElectronicsFactory
{
    partial class AuthorizationForm
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
            LoginTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            PasswordTextBox = new TextBox();
            AuthorizationButton = new Button();
            SuspendLayout();
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(72, 12);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.Size = new Size(197, 25);
            LoginTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 15);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 1;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 46);
            label2.Name = "label2";
            label2.Size = new Size(57, 17);
            label2.TabIndex = 3;
            label2.Text = "Пароль:";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(72, 43);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(197, 25);
            PasswordTextBox.TabIndex = 2;
            // 
            // AuthorizationButton
            // 
            AuthorizationButton.Location = new Point(72, 74);
            AuthorizationButton.Name = "AuthorizationButton";
            AuthorizationButton.Size = new Size(197, 64);
            AuthorizationButton.TabIndex = 4;
            AuthorizationButton.Text = "Авторизоваться";
            AuthorizationButton.UseVisualStyleBackColor = true;
            AuthorizationButton.Click += AuthorizationButton_Click;
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 155);
            Controls.Add(AuthorizationButton);
            Controls.Add(label2);
            Controls.Add(PasswordTextBox);
            Controls.Add(label1);
            Controls.Add(LoginTextBox);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "AuthorizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginTextBox;
        private Label label1;
        private Label label2;
        private TextBox PasswordTextBox;
        private Button AuthorizationButton;
    }
}