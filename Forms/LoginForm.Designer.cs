namespace GestionPharmacie.Forms
{
    partial class LoginForm
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
            mainPanel = new Panel();
            btnCreateAccount = new LinkLabel();
            btnLogin = new Button();
            lblError = new Label();
            chkShowPassword = new CheckBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            lblIcon = new Label();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(btnCreateAccount);
            mainPanel.Controls.Add(btnLogin);
            mainPanel.Controls.Add(lblError);
            mainPanel.Controls.Add(chkShowPassword);
            mainPanel.Controls.Add(txtPassword);
            mainPanel.Controls.Add(lblPassword);
            mainPanel.Controls.Add(txtUsername);
            mainPanel.Controls.Add(lblUsername);
            mainPanel.Controls.Add(lblSubtitle);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(lblIcon);
            mainPanel.Location = new Point(40, 67);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(434, 620);
            mainPanel.TabIndex = 0;
            mainPanel.Paint += MainPanel_Paint;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.AutoSize = false;
            btnCreateAccount.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            btnCreateAccount.ForeColor = Color.FromArgb(66, 133, 244);
            btnCreateAccount.Location = new Point(103, 580);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(229, 20);
            btnCreateAccount.TabIndex = 4;
            btnCreateAccount.TabStop = true;
            btnCreateAccount.Text = "Créer un compte";
            btnCreateAccount.TextAlign = ContentAlignment.MiddleCenter;
            btnCreateAccount.LinkBehavior = LinkBehavior.HoverUnderline;
            btnCreateAccount.LinkClicked += BtnCreateAccount_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(66, 133, 244);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(103, 513);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(229, 48);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Se connecter";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;
            btnLogin.Paint += BtnLogin_Paint;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.FromArgb(239, 83, 80);
            lblError.Location = new Point(46, 460);
            lblError.Name = "lblError";
            lblError.Size = new Size(343, 33);
            lblError.TabIndex = 9;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(117, 117, 117);
            chkShowPassword.Location = new Point(46, 420);
            chkShowPassword.Margin = new Padding(3, 4, 3, 4);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(192, 24);
            chkShowPassword.TabIndex = 2;
            chkShowPassword.Text = "Afficher le mot de passe";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(46, 360);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(343, 40);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.BackColor = Color.FromArgb(250, 250, 250);
            txtPassword.Enter += TxtPassword_Enter;
            txtPassword.Leave += TxtPassword_Leave;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.ForeColor = Color.FromArgb(33, 33, 33);
            lblPassword.Location = new Point(46, 327);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(112, 23);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Mot de passe";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(46, 267);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(343, 40);
            txtUsername.TabIndex = 0;
            txtUsername.BackColor = Color.FromArgb(250, 250, 250);
            txtUsername.Enter += TxtUsername_Enter;
            txtUsername.Leave += TxtUsername_Leave;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.ForeColor = Color.FromArgb(33, 33, 33);
            lblUsername.Location = new Point(46, 233);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(142, 23);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Nom d'utilisateur";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(117, 117, 117);
            lblSubtitle.Location = new Point(117, 179);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(215, 20);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Connectez-vous pour continuer";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(66, 133, 244);
            lblTitle.Location = new Point(72, 133);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(317, 46);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Gestion Pharmacie";
            // 
            // lblIcon
            // 
            lblIcon.AutoSize = true;
            lblIcon.Font = new Font("Segoe UI", 48F);
            lblIcon.Location = new Point(159, 27);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(155, 106);
            lblIcon.TabIndex = 0;
            lblIcon.Text = "💊";
            lblIcon.Click += lblIcon_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(514, 753);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion Pharmacie - Connexion";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel btnCreateAccount;
    }
}
