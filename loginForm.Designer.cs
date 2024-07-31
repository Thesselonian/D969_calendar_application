namespace calendarApp
{
    partial class loginForm
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
            this.loginUsername = new System.Windows.Forms.TextBox();
            this.loginUsernameLabel = new System.Windows.Forms.Label();
            this.loginFormLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginPassword = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginUsername
            // 
            this.loginUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginUsername.ForeColor = System.Drawing.SystemColors.WindowText;
            this.loginUsername.Location = new System.Drawing.Point(83, 110);
            this.loginUsername.Multiline = true;
            this.loginUsername.Name = "loginUsername";
            this.loginUsername.Size = new System.Drawing.Size(241, 40);
            this.loginUsername.TabIndex = 0;
            // 
            // loginUsernameLabel
            // 
            this.loginUsernameLabel.AutoSize = true;
            this.loginUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginUsernameLabel.Location = new System.Drawing.Point(89, 82);
            this.loginUsernameLabel.Name = "loginUsernameLabel";
            this.loginUsernameLabel.Size = new System.Drawing.Size(102, 25);
            this.loginUsernameLabel.TabIndex = 1;
            this.loginUsernameLabel.Text = "Username";
            // 
            // loginFormLabel
            // 
            this.loginFormLabel.AutoSize = true;
            this.loginFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.loginFormLabel.Location = new System.Drawing.Point(80, 20);
            this.loginFormLabel.Name = "loginFormLabel";
            this.loginFormLabel.Size = new System.Drawing.Size(370, 39);
            this.loginFormLabel.TabIndex = 2;
            this.loginFormLabel.Text = "Enter Login Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(82, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Password";
            // 
            // loginPassword
            // 
            this.loginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginPassword.Location = new System.Drawing.Point(83, 181);
            this.loginPassword.Multiline = true;
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.Size = new System.Drawing.Size(367, 39);
            this.loginPassword.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginButton.Location = new System.Drawing.Point(83, 226);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(140, 39);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginStatus
            // 
            this.loginStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginStatus.Location = new System.Drawing.Point(501, 80);
            this.loginStatus.Multiline = true;
            this.loginStatus.Name = "loginStatus";
            this.loginStatus.ReadOnly = true;
            this.loginStatus.Size = new System.Drawing.Size(580, 175);
            this.loginStatus.TabIndex = 8;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 535);
            this.Controls.Add(this.loginStatus);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginPassword);
            this.Controls.Add(this.loginFormLabel);
            this.Controls.Add(this.loginUsernameLabel);
            this.Controls.Add(this.loginUsername);
            this.Name = "loginForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginUsername;
        private System.Windows.Forms.Label loginUsernameLabel;
        private System.Windows.Forms.Label loginFormLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loginPassword;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox loginStatus;
    }
}

