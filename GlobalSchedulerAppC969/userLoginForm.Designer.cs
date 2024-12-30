namespace GlobalSchedulerAppC969
{
    partial class userLoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Method required for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.languageLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.pwdTextbox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.locationLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.languageLabel.Location = new System.Drawing.Point(183, 144);
            this.languageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(471, 29);
            this.languageLabel.TabIndex = 0;
            this.languageLabel.Text = "Please enter your username and password";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameLabel.Location = new System.Drawing.Point(122, 216);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(130, 29);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.passwordLabel.Location = new System.Drawing.Point(122, 276);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(126, 29);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameTextbox.Location = new System.Drawing.Point(281, 210);
            this.usernameTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(366, 34);
            this.usernameTextbox.TabIndex = 3;
            // 
            // pwdTextbox
            // 
            this.pwdTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pwdTextbox.Location = new System.Drawing.Point(281, 270);
            this.pwdTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pwdTextbox.Name = "pwdTextbox";
            this.pwdTextbox.Size = new System.Drawing.Size(366, 34);
            this.pwdTextbox.TabIndex = 4;
            this.pwdTextbox.UseSystemPasswordChar = true;
            this.pwdTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pwdTextbox_KeyDown);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(189, 360);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(147, 54);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(379, 360);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(147, 54);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.locationLabel.Location = new System.Drawing.Point(122, 444);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(0, 29);
            this.locationLabel.TabIndex = 7;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(177, 48);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(377, 38);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "Global Scheduler Login";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(775, 493);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.pwdTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.languageLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.loginFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox pwdTextbox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}
