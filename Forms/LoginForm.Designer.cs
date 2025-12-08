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
            leftPanel = new Panel();
            logoLabel = new Label();
            welcomeLabel = new Label();
            descriptionLabel = new Label();
            mainPanel = new Panel();
            btnCreateAccount = new LinkLabel();
            btnLogin = new Button();
            lblError = new Label();
            forgotPasswordLink = new LinkLabel();
            pnlPassword = new Panel();
            txtPassword = new TextBox();
            lblPasswordIcon = new Label();
            btnTogglePassword = new Button();
            pnlUsername = new Panel();
            txtUsername = new TextBox();
            lblUsernameIcon = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            // Create account controls
            txtConfirmPassword = new TextBox();
            txtFullName = new TextBox();
            cboRole = new ComboBox();
            btnCreate = new Button();
            btnBackToLogin = new LinkLabel();
            pnlConfirmPassword = new Panel();
            lblConfirmPasswordIcon = new Label();
            btnToggleConfirmPassword = new Button();
            pnlFullName = new Panel();
            lblFullNameIcon = new Label();
            lblConfirmPassword = new Label();
            lblFullName = new Label();
            lblRole = new Label();
            leftPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            pnlPassword.SuspendLayout();
            pnlUsername.SuspendLayout();
            pnlConfirmPassword.SuspendLayout();
            pnlFullName.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(0, 50, 73);
            leftPanel.Controls.Add(logoLabel);
            leftPanel.Controls.Add(welcomeLabel);
            leftPanel.Controls.Add(descriptionLabel);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(380, 700);
            leftPanel.TabIndex = 0;
            leftPanel.Paint += LeftPanel_Paint;
            // 
            // logoLabel
            // 
            //logoLabel.AutoSize = true;
            //logoLabel.Font = new Font("Segoe UI", 72F, FontStyle.Regular);
            //logoLabel.Location = new Point(130, 220);
            //logoLabel.Name = "logoLabel";
            //logoLabel.Size = new Size(140, 159);
            //logoLabel.TabIndex = 0;
            //logoLabel.Text = "💊";
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.White;
            welcomeLabel.Location = new Point(50, 420);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(280, 62);
            welcomeLabel.TabIndex = 1;
            welcomeLabel.Text = "Bienvenue";
            welcomeLabel.BackColor = Color.Transparent;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Font = new Font("Segoe UI", 11F);
            descriptionLabel.ForeColor = Color.White;
            descriptionLabel.Location = new Point(50, 490);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(280, 80);
            descriptionLabel.TabIndex = 2;
            descriptionLabel.BackColor = Color.Transparent; 
            descriptionLabel.Text = "Système de gestion de pharmacie moderne et efficace";

            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(btnCreateAccount);
            mainPanel.Controls.Add(btnLogin);
            mainPanel.Controls.Add(lblError);
            mainPanel.Controls.Add(forgotPasswordLink);
            mainPanel.Controls.Add(pnlPassword);
            mainPanel.Controls.Add(pnlUsername);
            mainPanel.Controls.Add(lblPassword);
            mainPanel.Controls.Add(lblUsername);
            mainPanel.Controls.Add(lblSubtitle);
            mainPanel.Controls.Add(lblTitle);
            // Create account controls
            mainPanel.Controls.Add(pnlConfirmPassword);
            mainPanel.Controls.Add(pnlFullName);
            mainPanel.Controls.Add(cboRole);
            mainPanel.Controls.Add(btnCreate);
            mainPanel.Controls.Add(btnBackToLogin);
            mainPanel.Controls.Add(lblConfirmPassword);
            mainPanel.Controls.Add(lblFullName);
            mainPanel.Controls.Add(lblRole);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(380, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(60, 80, 60, 40);
            mainPanel.Size = new Size(520, 700);
            mainPanel.TabIndex = 1;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.AutoSize = true;
            btnCreateAccount.Font = new Font("Segoe UI", 9.5F);
            btnCreateAccount.LinkColor = Color.FromArgb(0, 126, 167);
            btnCreateAccount.Location = new Point(150, 630);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(120, 21);
            btnCreateAccount.TabIndex = 5;
            btnCreateAccount.TabStop = true;
            btnCreateAccount.Text = "Créer un compte";
            btnCreateAccount.LinkBehavior = LinkBehavior.HoverUnderline;
            btnCreateAccount.LinkClicked += BtnCreateAccount_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 126, 167);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(60, 520);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 52);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Se connecter";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;
            btnLogin.Paint += Btn_Paint;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9.5F);
            lblError.ForeColor = Color.FromArgb(220, 53, 69);
            lblError.Location = new Point(60, 480);
            lblError.Name = "lblError";
            lblError.Size = new Size(400, 30);
            lblError.TabIndex = 9;
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // forgotPasswordLink
            // 
            forgotPasswordLink.AutoSize = true;
            forgotPasswordLink.Font = new Font("Segoe UI", 9F);
            forgotPasswordLink.LinkColor = Color.FromArgb(0, 126, 167);
            forgotPasswordLink.Location = new Point(60, 445);
            forgotPasswordLink.Name = "forgotPasswordLink";
            forgotPasswordLink.Size = new Size(150, 20);
            forgotPasswordLink.TabIndex = 4;
            forgotPasswordLink.TabStop = true;
            forgotPasswordLink.Text = "Mot de passe oublié?";
            forgotPasswordLink.LinkBehavior = LinkBehavior.HoverUnderline;
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.FromArgb(248, 249, 250);
            pnlPassword.Controls.Add(txtPassword);
            pnlPassword.Controls.Add(lblPasswordIcon);
            pnlPassword.Controls.Add(btnTogglePassword);
            pnlPassword.Location = new Point(60, 380);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(400, 52);
            pnlPassword.TabIndex = 2;
            pnlPassword.Paint += InputPanel_Paint;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(248, 249, 250);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(45, 14);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(310, 25);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Enter += Input_Enter;
            txtPassword.Leave += Input_Leave;
            // 
            // lblPasswordIcon
            // 
            lblPasswordIcon.Font = new Font("Segoe UI", 14F);
            lblPasswordIcon.ForeColor = Color.FromArgb(108, 117, 125);
            lblPasswordIcon.Location = new Point(12, 11);
            lblPasswordIcon.Name = "lblPasswordIcon";
            lblPasswordIcon.Size = new Size(30, 30);
            lblPasswordIcon.TabIndex = 1;
            lblPasswordIcon.Text = "🔒";
            lblPasswordIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Font = new Font("Segoe UI", 10F);
            btnTogglePassword.ForeColor = Color.FromArgb(108, 117, 125);
            btnTogglePassword.Location = new Point(360, 11);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(30, 30);
            btnTogglePassword.TabIndex = 2;
            btnTogglePassword.Text = "👁";
            btnTogglePassword.UseVisualStyleBackColor = true;
            btnTogglePassword.Click += BtnTogglePassword_Click;
            // 
            // pnlUsername
            // 
            pnlUsername.BackColor = Color.FromArgb(248, 249, 250);
            pnlUsername.Controls.Add(txtUsername);
            pnlUsername.Controls.Add(lblUsernameIcon);
            pnlUsername.Location = new Point(60, 265);
            pnlUsername.Name = "pnlUsername";
            pnlUsername.Size = new Size(400, 52);
            pnlUsername.TabIndex = 1;
            pnlUsername.Paint += InputPanel_Paint;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(248, 249, 250);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(45, 14);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(340, 25);
            txtUsername.TabIndex = 0;
            txtUsername.Enter += Input_Enter;
            txtUsername.Leave += Input_Leave;
            // 
            // lblUsernameIcon
            // 
            lblUsernameIcon.Font = new Font("Segoe UI", 14F);
            lblUsernameIcon.ForeColor = Color.FromArgb(108, 117, 125);
            lblUsernameIcon.Location = new Point(12, 11);
            lblUsernameIcon.Name = "lblUsernameIcon";
            lblUsernameIcon.Size = new Size(30, 30);
            lblUsernameIcon.TabIndex = 1;
            lblUsernameIcon.Text = "👤";
            lblUsernameIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblPassword.ForeColor = Color.FromArgb(73, 80, 87);
            lblPassword.Location = new Point(60, 345);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(98, 23);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Mot de passe";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblUsername.ForeColor = Color.FromArgb(73, 80, 87);
            lblUsername.Location = new Point(60, 230);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(128, 23);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Nom d'utilisateur";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblSubtitle.Location = new Point(60, 165);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(269, 23);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Entrez vos identifiants ci-dessous";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 50, 73);
            lblTitle.Location = new Point(60, 100);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(284, 60);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Connexion";
            // 
            // pnlConfirmPassword
            // 
            pnlConfirmPassword.BackColor = Color.FromArgb(248, 249, 250);
            pnlConfirmPassword.Controls.Add(txtConfirmPassword);
            pnlConfirmPassword.Controls.Add(lblConfirmPasswordIcon);
            pnlConfirmPassword.Controls.Add(btnToggleConfirmPassword);
            pnlConfirmPassword.Location = new Point(60, 420);
            pnlConfirmPassword.Name = "pnlConfirmPassword";
            pnlConfirmPassword.Size = new Size(400, 52);
            pnlConfirmPassword.TabIndex = 3;
            pnlConfirmPassword.Visible = false;
            pnlConfirmPassword.Paint += InputPanel_Paint;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(248, 249, 250);
            txtConfirmPassword.BorderStyle = BorderStyle.None;
            txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            txtConfirmPassword.Location = new Point(45, 14);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(310, 25);
            txtConfirmPassword.TabIndex = 0;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.Enter += Input_Enter;
            txtConfirmPassword.Leave += Input_Leave;
            // 
            // lblConfirmPasswordIcon
            // 
            lblConfirmPasswordIcon.Font = new Font("Segoe UI", 14F);
            lblConfirmPasswordIcon.ForeColor = Color.FromArgb(108, 117, 125);
            lblConfirmPasswordIcon.Location = new Point(12, 11);
            lblConfirmPasswordIcon.Name = "lblConfirmPasswordIcon";
            lblConfirmPasswordIcon.Size = new Size(30, 30);
            lblConfirmPasswordIcon.TabIndex = 1;
            lblConfirmPasswordIcon.Text = "🔒";
            lblConfirmPasswordIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnToggleConfirmPassword
            // 
            btnToggleConfirmPassword.FlatAppearance.BorderSize = 0;
            btnToggleConfirmPassword.FlatStyle = FlatStyle.Flat;
            btnToggleConfirmPassword.Font = new Font("Segoe UI", 10F);
            btnToggleConfirmPassword.ForeColor = Color.FromArgb(108, 117, 125);
            btnToggleConfirmPassword.Location = new Point(360, 11);
            btnToggleConfirmPassword.Name = "btnToggleConfirmPassword";
            btnToggleConfirmPassword.Size = new Size(30, 30);
            btnToggleConfirmPassword.TabIndex = 2;
            btnToggleConfirmPassword.Text = "👁";
            btnToggleConfirmPassword.UseVisualStyleBackColor = true;
            btnToggleConfirmPassword.Click += BtnToggleConfirmPassword_Click;
            // 
            // pnlFullName
            // 
            pnlFullName.BackColor = Color.FromArgb(248, 249, 250);
            pnlFullName.Controls.Add(txtFullName);
            pnlFullName.Controls.Add(lblFullNameIcon);
            pnlFullName.Location = new Point(60, 535);
            pnlFullName.Name = "pnlFullName";
            pnlFullName.Size = new Size(400, 52);
            pnlFullName.TabIndex = 4;
            pnlFullName.Visible = false;
            pnlFullName.Paint += InputPanel_Paint;
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.FromArgb(248, 249, 250);
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Font = new Font("Segoe UI", 11F);
            txtFullName.Location = new Point(45, 14);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(340, 25);
            txtFullName.TabIndex = 0;
            txtFullName.Enter += Input_Enter;
            txtFullName.Leave += Input_Leave;
            // 
            // lblFullNameIcon
            // 
            lblFullNameIcon.Font = new Font("Segoe UI", 14F);
            lblFullNameIcon.ForeColor = Color.FromArgb(108, 117, 125);
            lblFullNameIcon.Location = new Point(12, 11);
            lblFullNameIcon.Name = "lblFullNameIcon";
            lblFullNameIcon.Size = new Size(30, 30);
            lblFullNameIcon.TabIndex = 1;
            lblFullNameIcon.Text = "👤";
            lblFullNameIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboRole
            // 
            cboRole.BackColor = Color.FromArgb(248, 249, 250);
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FlatStyle = FlatStyle.Flat;
            cboRole.Font = new Font("Segoe UI", 11F);
            cboRole.ForeColor = Color.FromArgb(73, 80, 87);
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "Pharmacien", "Admin", "User" });
            cboRole.Location = new Point(60, 635);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(400, 33);
            cboRole.TabIndex = 5;
            cboRole.Visible = false;
            cboRole.Enter += Input_Enter;
            cboRole.Leave += Input_Leave;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(0, 126, 167);
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(60, 690);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(400, 52);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Créer le compte";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Visible = false;
            btnCreate.Click += BtnCreate_Click;
            btnCreate.MouseEnter += BtnLogin_MouseEnter;
            btnCreate.MouseLeave += BtnLogin_MouseLeave;
            btnCreate.Paint += Btn_Paint;
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.AutoSize = true;
            btnBackToLogin.Font = new Font("Segoe UI", 9.5F);
            btnBackToLogin.LinkColor = Color.FromArgb(0, 126, 167);
            btnBackToLogin.Location = new Point(170, 760);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(170, 21);
            btnBackToLogin.TabIndex = 7;
            btnBackToLogin.TabStop = true;
            btnBackToLogin.Text = "Retour à la connexion";
            btnBackToLogin.LinkBehavior = LinkBehavior.HoverUnderline;
            btnBackToLogin.Visible = false;
            btnBackToLogin.LinkClicked += (s, e) => ShowLoginView();
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F);
            lblConfirmPassword.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPassword.Location = new Point(60, 385);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(216, 23);
            lblConfirmPassword.TabIndex = 7;
            lblConfirmPassword.Text = "Confirmer le mot de passe *";
            lblConfirmPassword.Visible = false;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F);
            lblFullName.ForeColor = Color.FromArgb(73, 80, 87);
            lblFullName.Location = new Point(60, 500);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(127, 23);
            lblFullName.TabIndex = 8;
            lblFullName.Text = "Nom complet *";
            lblFullName.Visible = false;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.ForeColor = Color.FromArgb(73, 80, 87);
            lblRole.Location = new Point(60, 600);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(44, 23);
            lblRole.TabIndex = 9;
            lblRole.Text = "Rôle";
            lblRole.Visible = false;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 700);
            Controls.Add(mainPanel);
            Controls.Add(leftPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion Pharmacie - Connexion";
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            pnlUsername.ResumeLayout(false);
            pnlUsername.PerformLayout();
            pnlConfirmPassword.ResumeLayout(false);
            pnlConfirmPassword.PerformLayout();
            pnlFullName.ResumeLayout(false);
            pnlFullName.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsernameIcon;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPasswordIcon;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.LinkLabel forgotPasswordLink;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel btnCreateAccount;
        // Create account controls
        private System.Windows.Forms.Panel pnlConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPasswordIcon;
        private System.Windows.Forms.Button btnToggleConfirmPassword;
        private System.Windows.Forms.Panel pnlFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullNameIcon;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.LinkLabel btnBackToLogin;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblRole;
    }
}