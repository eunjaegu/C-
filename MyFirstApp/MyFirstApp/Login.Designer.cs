namespace MyFirstApp
{
    partial class Login
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
            loginButton = new Button();
            button1 = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            labelId = new Label();
            labelPassword = new Label();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = SystemColors.ButtonShadow;
            loginButton.Location = new Point(12, 61);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(197, 28);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(525, 128);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(75, 6);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(134, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(75, 32);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(134, 23);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(12, 9);
            labelId.Name = "labelId";
            labelId.Size = new Size(19, 15);
            labelId.TabIndex = 4;
            labelId.Text = "ID";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(12, 35);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(57, 15);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Password";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(218, 101);
            Controls.Add(labelPassword);
            Controls.Add(labelId);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(button1);
            Controls.Add(loginButton);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private Button button1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label labelId;
        private Label labelPassword;
    }
}