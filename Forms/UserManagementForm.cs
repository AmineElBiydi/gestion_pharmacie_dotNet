using System.Data.SqlClient;
using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class UserManagementForm : Form
    {
        public UserManagementForm()
        {
            InitializeComponent();
            
            if (!DesignMode)
            {
                StyleHelper.ApplyFormTheme(this);
                LoadUsers();
            }
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
