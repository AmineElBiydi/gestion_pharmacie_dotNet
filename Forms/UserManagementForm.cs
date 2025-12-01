using System.Data.SqlClient;
using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class UserManagementForm : Form
    {
        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private TextBox txtConfirmPassword = null!;
        private TextBox txtFullName = null!;
        private ComboBox cboRole = null!;
        private CheckBox chkIsActive = null!;
        private CheckBox chkShowPassword = null!;
        private DataGridView dgvUsers = null!;
        private Label lblMessage = null!;

        public UserManagementForm()
        {
            InitializeComponent();
            CreateControls();
            StyleHelper.ApplyFormTheme(this);
            LoadUsers();
        }

        private void CreateControls()
        {
            this.BackColor = StyleHelper.LightGray;
            this.AutoScroll = true;

            // Title
            var lblTitle = new Label
            {
                Text = "Gestion des Utilisateurs",
                Font = StyleHelper.HeadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            // Message label
            lblMessage = new Label
            {
                Text = "",
                Font = StyleHelper.BodyFont,
                ForeColor = StyleHelper.AccentGreen,
                Location = new Point(20, 60),
                AutoSize = true
            };
            this.Controls.Add(lblMessage);

            // Form Panel
            var formPanel = new Panel
            {
                Location = new Point(20, 100),
                Size = new Size(1150, 280),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(formPanel);

            int y = 20;
            int labelX = 20, textX = 200, width = 300;

            // Username
            var lblUsername = new Label { Text = "Nom d'utilisateur:", Location = new Point(labelX, y), AutoSize = true };
            StyleHelper.StyleLabel(lblUsername);
            txtUsername = new TextBox { Location = new Point(textX, y - 3), Width = width, Font = StyleHelper.BodyFont };
            formPanel.Controls.AddRange(new Control[] { lblUsername, txtUsername });
            y += 45;

            // Password
            var lblPassword = new Label { Text = "Mot de passe:", Location = new Point(labelX, y), AutoSize = true };
            StyleHelper.StyleLabel(lblPassword);
            txtPassword = new TextBox 
            { 
                Location = new Point(textX, y - 3), 
                Width = width, 
                Font = StyleHelper.BodyFont,
                UseSystemPasswordChar = true
            };
            formPanel.Controls.AddRange(new Control[] { lblPassword, txtPassword });
            y += 45;

            // Confirm Password
            var lblConfirmPassword = new Label { Text = "Confirmer mot de passe:", Location = new Point(labelX, y), AutoSize = true };
            StyleHelper.StyleLabel(lblConfirmPassword);
            txtConfirmPassword = new TextBox 
            { 
                Location = new Point(textX, y - 3), 
                Width = width, 
                Font = StyleHelper.BodyFont,
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
                Font = StyleHelper.BodyFont
            };
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            formPanel.Controls.Add(chkShowPassword);
            y += 50;

            // Full Name (right column)
            var lblFullName = new Label { Text = "Nom complet:", Location = new Point(550, 20), AutoSize = true };
            StyleHelper.StyleLabel(lblFullName);
            txtFullName = new TextBox { Location = new Point(650, 17), Width = 400, Font = StyleHelper.BodyFont };
            formPanel.Controls.AddRange(new Control[] { lblFullName, txtFullName });

            // Role
            var lblRole = new Label { Text = "Rôle:", Location = new Point(550, 65), AutoSize = true };
            StyleHelper.StyleLabel(lblRole);
            cboRole = new ComboBox
            {
                Location = new Point(650, 62),
                Width = 200,
                Font = StyleHelper.BodyFont,
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
                Font = StyleHelper.BodyFont,
                Checked = true
            };
            formPanel.Controls.Add(chkIsActive);

            // Buttons
            var btnCreate = new Button { Text = "Créer le compte", Location = new Point(550, 200), Size = new Size(150, 40) };
            StyleHelper.StyleButton(btnCreate);
            btnCreate.Click += BtnCreate_Click;

            var btnClear = new Button { Text = "Effacer", Location = new Point(710, 200), Size = new Size(120, 40) };
            StyleHelper.StyleButton(btnClear, StyleHelper.SecondaryColor);
            btnClear.Click += BtnClear_Click;

            formPanel.Controls.AddRange(new Control[] { btnCreate, btnClear });
            this.Controls.Add(formPanel);

            // DataGridView Panel
            var gridPanel = new Panel
            {
                Location = new Point(20, 400),
                Size = new Size(1150, 350),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(gridPanel);

            dgvUsers = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(1130, 330),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Dock = DockStyle.Fill
            };
            StyleHelper.StyleDataGridView(dgvUsers);

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UserId", HeaderText = "ID", Width = 60 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Nom d'utilisateur", Width = 200 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Nom complet", Width = 250 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Role", HeaderText = "Rôle", Width = 150 });
            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsActive", HeaderText = "Actif", Width = 80 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CreatedDate", HeaderText = "Date de création", Width = 180 });

            gridPanel.Controls.Add(dgvUsers);
            this.Controls.Add(gridPanel);
        }

        private void ChkShowPassword_CheckedChanged(object? sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = StyleHelper.AccentGreen;

            // Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowError("Veuillez entrer un nom d'utilisateur.");
                txtUsername.Focus();
                return;
            }

            if (txtUsername.Text.Length < 3)
            {
                ShowError("Le nom d'utilisateur doit contenir au moins 3 caractères.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Veuillez entrer un mot de passe.");
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                ShowError("Le mot de passe doit contenir au moins 6 caractères.");
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Les mots de passe ne correspondent pas.");
                txtConfirmPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowError("Veuillez entrer le nom complet.");
                txtFullName.Focus();
                return;
            }

            try
            {
                var user = AuthenticationService.CreateUser(
                    txtUsername.Text.Trim(),
                    txtPassword.Text,
                    txtFullName.Text.Trim(),
                    cboRole.SelectedItem?.ToString() ?? "Pharmacien",
                    chkIsActive.Checked
                );

                ShowSuccess($"Compte créé avec succès! ID: {user.UserId}");
                LoadUsers();
                BtnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtFullName.Clear();
            cboRole.SelectedIndex = 0;
            chkIsActive.Checked = true;
            chkShowPassword.Checked = false;
            lblMessage.Text = "";
            txtUsername.Focus();
        }

        private void LoadUsers()
        {
            try
            {
                var users = GetAllUsers();
                dgvUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                ShowError($"Erreur lors du chargement des utilisateurs: {ex.Message}");
            }
        }

        private List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT UserId, Username, PasswordHash, FullName, Role, IsActive, CreatedDate 
                               FROM Users 
                               ORDER BY CreatedDate DESC";
                
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserId = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                PasswordHash = reader.GetString(2),
                                FullName = reader.GetString(3),
                                Role = reader.GetString(4),
                                IsActive = reader.GetBoolean(5),
                                CreatedDate = reader.GetDateTime(6)
                            });
                        }
                    }
                }
            }
            return users;
        }

        private void ShowSuccess(string message)
        {
            lblMessage.Text = "✓ " + message;
            lblMessage.ForeColor = StyleHelper.AccentGreen;
        }

        private void ShowError(string message)
        {
            lblMessage.Text = "✗ " + message;
            lblMessage.ForeColor = StyleHelper.DangerColor;
        }
    }
}
