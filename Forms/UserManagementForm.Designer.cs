using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    partial class UserManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private Label lblTitle;
        private Label lblMessage;
        private Panel formPanel;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private CheckBox chkShowPassword;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblRole;
        private ComboBox cboRole;
        private CheckBox chkIsActive;
        private Button btnCreate;
        private Button btnClear;
        private Panel gridPanel;
        private DataGridView dgvUsers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // Form properties
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Text = "Gestion des Utilisateurs";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.AutoScroll = true;

            // Title
            lblTitle = new Label
            {
                Text = "Gestion des Utilisateurs",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(66, 133, 244),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            // Message label
            lblMessage = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(52, 168, 83),
                Location = new Point(20, 60),
                AutoSize = true
            };
            this.Controls.Add(lblMessage);

            // Form Panel
            formPanel = new Panel
            {
                Location = new Point(20, 100),
                Size = new Size(1150, 280),
                BackColor = Color.White
            };

            int y = 20;
            int labelX = 20, textX = 200, width = 300;

            // Username
            lblUsername = new Label 
            { 
                Text = "Nom d'utilisateur:", 
                Location = new Point(labelX, y), 
                AutoSize = true,
                Font = new Font("Segoe UI", 10F)
            };
            txtUsername = new TextBox 
            { 
                Location = new Point(textX, y - 3), 
                Width = width, 
                Font = new Font("Segoe UI", 10F) 
            };
            formPanel.Controls.AddRange(new Control[] { lblUsername, txtUsername });
            y += 45;

            // Password
            lblPassword = new Label 
            { 
                Text = "Mot de passe:", 
                Location = new Point(labelX, y), 
                AutoSize = true,
                Font = new Font("Segoe UI", 10F)
            };
            txtPassword = new TextBox 
            { 
                Location = new Point(textX, y - 3), 
                Width = width, 
                Font = new Font("Segoe UI", 10F),
                UseSystemPasswordChar = true
            };
            formPanel.Controls.AddRange(new Control[] { lblPassword, txtPassword });
            y += 45;

            // Confirm Password
            lblConfirmPassword = new Label 
            { 
                Text = "Confirmer mot de passe:", 
                Location = new Point(labelX, y), 
                AutoSize = true,
                Font = new Font("Segoe UI", 10F)
            };
            txtConfirmPassword = new TextBox 
            { 
                Location = new Point(textX, y - 3), 
                Width = width, 
                Font = new Font("Segoe UI", 10F),
                UseSystemPasswordChar = true
            };
            formPanel.Controls.AddRange(new Control[] { lblConfirmPassword, txtConfirmPassword });
            y += 45;

            // Show Password Checkbox
            chkShowPassword = new CheckBox
            {
                Text = "Afficher le mot de passe",
                Location = new Point(textX, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F)
            };
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            formPanel.Controls.Add(chkShowPassword);
            y += 50;

            // Full Name (right column)
            lblFullName = new Label 
            { 
                Text = "Nom complet:", 
                Location = new Point(550, 20), 
                AutoSize = true,
                Font = new Font("Segoe UI", 10F)
            };
            txtFullName = new TextBox 
            { 
                Location = new Point(650, 17), 
                Width = 400, 
                Font = new Font("Segoe UI", 10F) 
            };
            formPanel.Controls.AddRange(new Control[] { lblFullName, txtFullName });

            // Role
            lblRole = new Label 
            { 
                Text = "Rôle:", 
                Location = new Point(550, 65), 
                AutoSize = true,
                Font = new Font("Segoe UI", 10F)
            };
            cboRole = new ComboBox
            {
                Location = new Point(650, 62),
                Width = 200,
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboRole.Items.AddRange(new string[] { "Pharmacien", "Admin", "User" });
            cboRole.SelectedIndex = 0;
            formPanel.Controls.AddRange(new Control[] { lblRole, cboRole });

            // Is Active
            chkIsActive = new CheckBox
            {
                Text = "Compte actif",
                Location = new Point(550, 110),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Checked = true
            };
            formPanel.Controls.Add(chkIsActive);

            // Buttons
            btnCreate = new Button 
            { 
                Text = "Créer le compte", 
                Location = new Point(550, 200), 
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(66, 133, 244),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10F)
            };
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.Click += BtnCreate_Click;

            btnClear = new Button 
            { 
                Text = "Effacer", 
                Location = new Point(710, 200), 
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(100, 181, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10F)
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += BtnClear_Click;

            formPanel.Controls.AddRange(new Control[] { btnCreate, btnClear });
            this.Controls.Add(formPanel);

            // DataGridView Panel
            gridPanel = new Panel
            {
                Location = new Point(20, 400),
                Size = new Size(1150, 350),
                BackColor = Color.White
            };

            dgvUsers = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(1130, 330),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                EnableHeadersVisualStyles = false
            };

            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 133, 244);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UserId", HeaderText = "ID", Width = 60 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Nom d'utilisateur", Width = 200 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Nom complet", Width = 250 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Role", HeaderText = "Rôle", Width = 150 });
            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsActive", HeaderText = "Actif", Width = 80 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CreatedDate", HeaderText = "Date de création", Width = 180 });

            gridPanel.Controls.Add(dgvUsers);
            this.Controls.Add(gridPanel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
