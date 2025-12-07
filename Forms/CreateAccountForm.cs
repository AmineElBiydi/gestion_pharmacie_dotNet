using System;
using System.Drawing;
using System.Windows.Forms;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();
            
            if (!DesignMode)
            {
                StyleHelper.ApplyFormTheme(this);
                StyleHelper.ApplyGradientBackground(this);
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
                // Test database connection first
                if (!DatabaseConnection.TestConnection())
                {
                    ShowError("Erreur: Impossible de se connecter à la base de données.");
                    return;
                }

                var user = AuthenticationService.CreateUser(
                    txtUsername.Text.Trim(),
                    txtPassword.Text,
                    txtFullName.Text.Trim(),
                    cboRole.SelectedItem?.ToString() ?? "Pharmacien",
                    true
                );

                ShowSuccess($"Compte créé avec succès! Vous pouvez maintenant vous connecter.");
                
                // Wait a bit to show the success message
                System.Threading.Thread.Sleep(1500);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
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
