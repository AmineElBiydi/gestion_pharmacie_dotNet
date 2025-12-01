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
        private TextBox? txtConfirmPassword;
        private TextBox? txtFullName;
        private ComboBox? cboRole;
        private CheckBox? chkShowPasswordCreate;
        private Button? btnCreate;
        private LinkLabel? btnBackToLogin;
        private Label? lblConfirmPassword;
        private Label? lblFullName;
        private Label? lblRole;

        public LoginForm()
        {
            InitializeComponent();
            InitializeCreateAccountControls();
            ShowLoginView();
            // Apply global typography/colors
            StyleHelper.ApplyFormTheme(this);
            // Vibrant blue gradient background behind the main card
            StyleHelper.ApplyGradientBackground(this);
        }

        private void InitializeCreateAccountControls()
        {
            // These will be created dynamically when switching to create account mode
            txtConfirmPassword = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(46, 420),
                Size = new Size(343, 40),
                TabIndex = 2,
                UseSystemPasswordChar = true,
                BackColor = Color.FromArgb(250, 250, 250),
                Visible = false
            };
            txtConfirmPassword.Enter += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.White; };
            txtConfirmPassword.Leave += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.FromArgb(250, 250, 250); };

            txtFullName = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(46, 500),
                Size = new Size(343, 40),
                TabIndex = 3,
                BackColor = Color.FromArgb(250, 250, 250),
                Visible = false
            };
            txtFullName.Enter += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.White; };
            txtFullName.Leave += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.FromArgb(250, 250, 250); };

            cboRole = new ComboBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(46, 560),
                Size = new Size(343, 40),
                DropDownStyle = ComboBoxStyle.DropDownList,
                TabIndex = 4,
                BackColor = Color.FromArgb(250, 250, 250),
                FlatStyle = FlatStyle.Flat,
                Visible = false
            };
            cboRole.Items.AddRange(new string[] { "Pharmacien", "Admin", "User" });
            cboRole.SelectedIndex = 0;
            cboRole.Enter += (s, e) => { if (s is ComboBox cb) cb.BackColor = Color.White; };
            cboRole.Leave += (s, e) => { if (s is ComboBox cb) cb.BackColor = Color.FromArgb(250, 250, 250); };

            chkShowPasswordCreate = new CheckBox
            {
                Text = "Afficher le mot de passe",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(117, 117, 117),
                Location = new Point(46, 470),
                AutoSize = true,
                Visible = false
            };
            chkShowPasswordCreate.CheckedChanged += (s, e) =>
            {
                if (txtPassword != null && txtConfirmPassword != null)
                {
                    txtPassword.UseSystemPasswordChar = !chkShowPasswordCreate.Checked;
                    txtConfirmPassword.UseSystemPasswordChar = !chkShowPasswordCreate.Checked;
                }
            };

            btnCreate = new Button
            {
                Text = "Créer le compte",
                BackColor = StyleHelper.PrimaryBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Location = new Point(103, 620),
                Size = new Size(229, 48),
                Cursor = Cursors.Hand,
                TabIndex = 5,
                Visible = false
            };
            btnCreate.Click += BtnCreate_Click;
            btnCreate.MouseEnter += (s, e) => { if (s is Button btn) btn.BackColor = StyleHelper.DarkBlue; };
            btnCreate.MouseLeave += (s, e) => { if (s is Button btn) btn.BackColor = StyleHelper.PrimaryBlue; };
            btnCreate.Paint += BtnLogin_Paint;

            btnBackToLogin = new LinkLabel
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 9F, FontStyle.Underline),
                ForeColor = Color.FromArgb(66, 133, 244),
                Location = new Point(103, 680),
                Size = new Size(229, 20),
                TabStop = true,
                Text = "Retour à la connexion",
                TextAlign = ContentAlignment.MiddleCenter,
                LinkBehavior = LinkBehavior.HoverUnderline,
                Visible = false
            };
            btnBackToLogin.LinkClicked += (s, e) => ShowLoginView();

            // Create labels for create account view
            lblConfirmPassword = new Label
            {
                Text = "Confirmer le mot de passe *",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(46, 390),
                AutoSize = true,
                Visible = false
            };

            lblFullName = new Label
            {
                Text = "Nom complet *",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(46, 470),
                AutoSize = true,
                Visible = false
            };

            lblRole = new Label
            {
                Text = "Rôle",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(46, 530),
                AutoSize = true,
                Visible = false
            };

            mainPanel.Controls.AddRange(new Control[] { txtConfirmPassword, txtFullName, cboRole, chkShowPasswordCreate, btnCreate, btnBackToLogin, lblConfirmPassword, lblFullName, lblRole });
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

            if (txtConfirmPassword != null) txtConfirmPassword.Visible = false;
            if (txtFullName != null) txtFullName.Visible = false;
            if (cboRole != null) cboRole.Visible = false;
            if (chkShowPasswordCreate != null) chkShowPasswordCreate.Visible = false;
            if (btnCreate != null) btnCreate.Visible = false;
            if (btnBackToLogin != null) btnBackToLogin.Visible = false;
            if (lblConfirmPassword != null) lblConfirmPassword.Visible = false;
            if (lblFullName != null) lblFullName.Visible = false;
            if (lblRole != null) lblRole.Visible = false;

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

            if (lblConfirmPassword != null)
            {
                lblConfirmPassword.Visible = true;
                lblConfirmPassword.Location = new Point(46, 390);
            }
            if (txtConfirmPassword != null)
            {
                txtConfirmPassword.Visible = true;
                txtConfirmPassword.Location = new Point(46, 420);
            }

            if (chkShowPasswordCreate != null)
            {
                chkShowPasswordCreate.Visible = true;
                chkShowPasswordCreate.Location = new Point(46, 470);
            }

            if (lblFullName != null)
            {
                lblFullName.Visible = true;
                lblFullName.Location = new Point(46, 500);
            }
            if (txtFullName != null)
            {
                txtFullName.Visible = true;
                txtFullName.Location = new Point(46, 530);
            }

            if (lblRole != null)
            {
                lblRole.Visible = true;
                lblRole.Location = new Point(46, 570);
            }
            if (cboRole != null)
            {
                cboRole.Visible = true;
                cboRole.Location = new Point(46, 600);
            }

            if (btnCreate != null)
            {
                btnCreate.Visible = true;
                btnCreate.Location = new Point(103, 660);
            }

            if (btnBackToLogin != null)
            {
                btnBackToLogin.Visible = true;
                btnBackToLogin.Location = new Point(103, 720);
            }

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

            if (txtConfirmPassword == null || txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Les mots de passe ne correspondent pas.");
                txtConfirmPassword?.Focus();
                return;
            }

            if (txtFullName == null || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowError("Veuillez entrer le nom complet.");
                txtFullName?.Focus();
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
