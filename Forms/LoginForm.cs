using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GestionPharmacie.Utils;
using GestionPharmacie.Data;

namespace GestionPharmacie.Forms
{
    public partial class LoginForm : Form
    {
        private bool _isCreateAccountMode = false;

        public LoginForm()
        {
            InitializeComponent();
            ShowLoginView();
            
            if (!DesignMode)
            {
                // Apply global typography/colors
                StyleHelper.ApplyFormTheme(this);
                // Vibrant blue gradient background behind the main card
                StyleHelper.ApplyGradientBackground(this);
            }
        }



        private void ShowLoginView()
        {
            _isCreateAccountMode = false;
            lblTitle.Text = "Gestion Pharmacie";
            lblSubtitle.Text = "Connectez-vous pour continuer";
            btnLogin.Visible = true;
            btnCreateAccount.Visible = true;
            chkShowPassword.Visible = true;
            lblUsername.Visible = true;
            txtUsername.Visible = true;
            lblPassword.Visible = true;
            txtPassword.Visible = true;
            txtPassword.Location = new Point(46, 360);
            chkShowPassword.Location = new Point(46, 420);
            btnLogin.Location = new Point(103, 513);
            btnCreateAccount.Location = new Point(103, 580);
            lblError.Location = new Point(46, 460);

            txtConfirmPassword.Visible = false;
            txtFullName.Visible = false;
            cboRole.Visible = false;
            chkShowPasswordCreate.Visible = false;
            btnCreate.Visible = false;
            btnBackToLogin.Visible = false;
            lblConfirmPassword.Visible = false;
            lblFullName.Visible = false;
            lblRole.Visible = false;

            mainPanel.Size = new Size(434, 620);
            this.ClientSize = new Size(514, 753);
            this.AcceptButton = btnLogin;
        }

        private void ShowCreateAccountView()
        {
            _isCreateAccountMode = true;
            lblTitle.Text = "Créer un compte";
            lblSubtitle.Text = "Remplissez les informations pour créer un nouveau compte";
            btnLogin.Visible = false;
            btnCreateAccount.Visible = false;
            chkShowPassword.Visible = false;
            lblUsername.Text = "Nom d'utilisateur *";
            lblPassword.Text = "Mot de passe *";

            lblConfirmPassword.Visible = true;
            lblConfirmPassword.Location = new Point(46, 390);

            txtConfirmPassword.Visible = true;
            txtConfirmPassword.Location = new Point(46, 420);

            chkShowPasswordCreate.Visible = true;
            chkShowPasswordCreate.Location = new Point(46, 470);

            lblFullName.Visible = true;
            lblFullName.Location = new Point(46, 500);

            txtFullName.Visible = true;
            txtFullName.Location = new Point(46, 530);

            lblRole.Visible = true;
            lblRole.Location = new Point(46, 570);

            cboRole.Visible = true;
            cboRole.Location = new Point(46, 600);

            btnCreate.Visible = true;
            btnCreate.Location = new Point(103, 660);

            btnBackToLogin.Visible = true;
            btnBackToLogin.Location = new Point(103, 720);

            lblError.Location = new Point(46, 640);
            mainPanel.Size = new Size(434, 760);
            this.ClientSize = new Size(514, 893);
            this.AcceptButton = btnCreate;
        }

        private void ChkShowPassword_CheckedChanged(object? sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblError.Text = "Veuillez entrer votre nom d'utilisateur";
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Veuillez entrer votre mot de passe";
                txtPassword.Focus();
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Connexion...";

            try
            {
                // First, test database connection
                if (!DatabaseConnection.TestConnection())
                {
                    lblError.Text = "Erreur: Impossible de se connecter à la base de données. Vérifiez que la base de données existe et que SQL Server est démarré.";
                    btnLogin.Enabled = true;
                    btnLogin.Text = "Se connecter";
                    return;
                }

                var user = AuthenticationService.ValidateUser(txtUsername.Text, txtPassword.Text);

                if (user != null)
                {
                    Session.Login(user);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblError.Text = "Nom d'utilisateur ou mot de passe incorrect";
                    txtPassword.Clear();
                    txtPassword.Focus();
                    btnLogin.Enabled = true;
                    btnLogin.Text = "Se connecter";
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                
                // Provide more helpful error messages
                if (errorMsg.Contains("Cannot open database") || errorMsg.Contains("Cannot open"))
                {
                    errorMsg = "La base de données 'GestionPharmacie' n'existe pas. Veuillez exécuter le script DatabaseSchema_Clean.sql pour créer la base de données.";
                }
                else if (errorMsg.Contains("server was not found") || errorMsg.Contains("not accessible"))
                {
                    errorMsg = "Impossible de se connecter au serveur SQL. Vérifiez que SQL Server est démarré et que la chaîne de connexion est correcte dans DatabaseConnection.cs";
                }
                else if (errorMsg.Contains("Invalid object name"))
                {
                    errorMsg = "La table n'existe pas. Veuillez exécuter le script DatabaseSchema_Clean.sql pour créer toutes les tables.";
                }
                
                lblError.Text = "Erreur: " + errorMsg;
                btnLogin.Enabled = true;
                btnLogin.Text = "Se connecter";
            }
        }

        private void BtnLogin_MouseEnter(object? sender, EventArgs e)
        {
            btnLogin.BackColor = StyleHelper.DarkBlue;
        }

        private void BtnLogin_MouseLeave(object? sender, EventArgs e)
        {
            btnLogin.BackColor = StyleHelper.PrimaryBlue;
        }

        private void lblIcon_Click(object sender, EventArgs e)
        {

        }

        private void BtnCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowCreateAccountView();
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.ForeColor = StyleHelper.AccentGreen;

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
                if (!DatabaseConnection.TestConnection())
                {
                    ShowError("Erreur: Impossible de se connecter à la base de données.");
                    return;
                }

                var user = AuthenticationService.CreateUser(
                    txtUsername.Text.Trim(),
                    txtPassword.Text,
                    txtFullName.Text.Trim(),
                    cboRole?.SelectedItem?.ToString() ?? "Pharmacien",
                    true
                );

                ShowSuccess("Compte créé avec succès! Vous pouvez maintenant vous connecter.");
                System.Threading.Thread.Sleep(1500);
                ShowLoginView();
                txtPassword.Clear();
                if (txtConfirmPassword != null) txtConfirmPassword.Clear();
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ShowSuccess(string message)
        {
            lblError.Text = "✓ " + message;
            lblError.ForeColor = StyleHelper.AccentGreen;
        }

        private void ShowError(string message)
        {
            lblError.Text = "✗ " + message;
            lblError.ForeColor = StyleHelper.DangerColor;
        }

        private void MainPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                int cornerRadius = 16;

                // Draw shadow layers
                for (int i = 0; i < 4; i++)
                {
                    var shadowRect = new Rectangle(3 + i, 3 + i, panel.Width - 1, panel.Height - 1);
                    using (var shadowPath = GetRoundedRect(shadowRect, cornerRadius))
                    using (var shadowBrush = new SolidBrush(Color.FromArgb(15 - i * 3, 0, 0, 0)))
                    {
                        g.FillPath(shadowBrush, shadowPath);
                    }
                }

                // Draw main panel
                using (var path = GetRoundedRect(rect, cornerRadius))
                using (var brush = new SolidBrush(panel.BackColor))
                {
                    g.FillPath(brush, path);
                }

                // Draw subtle border
                using (var path = GetRoundedRect(rect, cornerRadius))
                using (var pen = new Pen(Color.FromArgb(240, 240, 240), 1))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void BtnLogin_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var rect = new Rectangle(0, 0, btn.Width, btn.Height);
                int cornerRadius = 8;

                // Draw rounded background
                using (var path = GetRoundedRect(rect, cornerRadius))
                using (var brush = new SolidBrush(btn.BackColor))
                {
                    g.FillPath(brush, path);
                }

                // Draw text
                TextRenderer.DrawText(g, btn.Text, btn.Font, rect, btn.ForeColor, 
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }
        }

        private void TxtUsername_Enter(object? sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void TxtUsername_Leave(object? sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.FromArgb(250, 250, 250);
            }
        }

        private void TxtPassword_Enter(object? sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void TxtPassword_Leave(object? sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.FromArgb(250, 250, 250);
            }
        }
    }
}
