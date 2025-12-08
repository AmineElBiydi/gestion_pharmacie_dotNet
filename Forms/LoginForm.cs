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
        private Panel _activeFocusPanel = null;

        public LoginForm()
        {
            InitializeComponent();
            ShowLoginView();
            cboRole.SelectedIndex = 0;
        }

        private void ShowLoginView()
        {
            _isCreateAccountMode = false;
            lblTitle.Text = "Connexion";
            lblSubtitle.Text = "Entrez vos identifiants ci-dessous";

            // Show login controls
            btnLogin.Visible = true;
            btnCreateAccount.Visible = true;
            forgotPasswordLink.Visible = true;
            lblUsername.Visible = true;
            pnlUsername.Visible = true;
            lblPassword.Visible = true;
            pnlPassword.Visible = true;

            // Reset labels
            lblUsername.Text = "Nom d'utilisateur";
            lblPassword.Text = "Mot de passe";

            // Hide create account controls
            lblConfirmPassword.Visible = false;
            pnlConfirmPassword.Visible = false;
            lblFullName.Visible = false;
            pnlFullName.Visible = false;
            lblRole.Visible = false;
            cboRole.Visible = false;
            btnCreate.Visible = false;
            btnBackToLogin.Visible = false;

            // Reposition controls for login view
            lblTitle.Location = new Point(60, 100);
            lblSubtitle.Location = new Point(60, 165);
            lblUsername.Location = new Point(60, 230);
            pnlUsername.Location = new Point(60, 265);
            lblPassword.Location = new Point(60, 345);
            pnlPassword.Location = new Point(60, 380);
            forgotPasswordLink.Location = new Point(60, 445);
            lblError.Location = new Point(60, 480);
            btnLogin.Location = new Point(60, 520);
            btnCreateAccount.Location = new Point(150, 630);

            mainPanel.Height = 700;
            this.ClientSize = new Size(900, 700);
            this.AcceptButton = btnLogin;

            lblError.Text = "";
            CenterForm();
        }

        private void ShowCreateAccountView()
        {
            _isCreateAccountMode = true;
            lblTitle.Text = "Créer un compte";
            lblSubtitle.Text = "Remplissez les informations ci-dessous";

            // Hide login controls
            btnLogin.Visible = false;
            btnCreateAccount.Visible = false;
            forgotPasswordLink.Visible = false;

            // Update labels
            lblUsername.Text = "Nom d'utilisateur *";
            lblPassword.Text = "Mot de passe *";

            // Show create account controls
            lblConfirmPassword.Visible = true;
            pnlConfirmPassword.Visible = true;
            lblFullName.Visible = true;
            pnlFullName.Visible = true;
            lblRole.Visible = true;
            cboRole.Visible = true;
            btnCreate.Visible = true;
            btnBackToLogin.Visible = true;

            // Reposition controls for create account view
            lblTitle.Location = new Point(60, 80);
            lblSubtitle.Location = new Point(60, 145);
            lblUsername.Location = new Point(60, 210);
            pnlUsername.Location = new Point(60, 245);
            lblPassword.Location = new Point(60, 325);
            pnlPassword.Location = new Point(60, 360);
            lblConfirmPassword.Location = new Point(60, 385);
            pnlConfirmPassword.Location = new Point(60, 420);
            lblFullName.Location = new Point(60, 500);
            pnlFullName.Location = new Point(60, 535);
            lblRole.Location = new Point(60, 600);
            cboRole.Location = new Point(60, 635);
            lblError.Location = new Point(60, 675);
            btnCreate.Location = new Point(60, 690);
            btnBackToLogin.Location = new Point(170, 760);

            mainPanel.Height = 820;
            this.ClientSize = new Size(900, 820);
            this.AcceptButton = btnCreate;

            lblError.Text = "";
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            CenterForm();
        }

        private void CenterForm()
        {
            if (this.Owner != null)
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowError("Veuillez entrer votre nom d'utilisateur");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Veuillez entrer votre mot de passe");
                txtPassword.Focus();
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Connexion...";

            try
            {
                if (!DatabaseConnection.TestConnection())
                {
                    ShowError("Impossible de se connecter à la base de données");
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
                    ShowError("Nom d'utilisateur ou mot de passe incorrect");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    btnLogin.Enabled = true;
                    btnLogin.Text = "Se connecter";
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;

                if (errorMsg.Contains("Cannot open database"))
                {
                    errorMsg = "La base de données n'existe pas. Exécutez le script de création.";
                }
                else if (errorMsg.Contains("server was not found"))
                {
                    errorMsg = "Impossible de contacter le serveur SQL.";
                }

                ShowError(errorMsg);
                btnLogin.Enabled = true;
                btnLogin.Text = "Se connecter";
            }
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            lblError.Text = "";

            // Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowError("Veuillez entrer un nom d'utilisateur");
                txtUsername.Focus();
                return;
            }

            if (txtUsername.Text.Length < 3)
            {
                ShowError("Le nom d'utilisateur doit contenir au moins 3 caractères");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Veuillez entrer un mot de passe");
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                ShowError("Le mot de passe doit contenir au moins 6 caractères");
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Les mots de passe ne correspondent pas");
                txtConfirmPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowError("Veuillez entrer le nom complet");
                txtFullName.Focus();
                return;
            }

            try
            {
                if (!DatabaseConnection.TestConnection())
                {
                    ShowError("Impossible de se connecter à la base de données");
                    return;
                }

                var user = AuthenticationService.CreateUser(
                    txtUsername.Text.Trim(),
                    txtPassword.Text,
                    txtFullName.Text.Trim(),
                    cboRole?.SelectedItem?.ToString() ?? "Pharmacien",
                    true
                );

                ShowSuccess("Compte créé avec succès! Redirection...");
                System.Threading.Thread.Sleep(1500);
                ShowLoginView();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
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
            lblError.ForeColor = Color.FromArgb(40, 167, 69);
        }

        private void ShowError(string message)
        {
            lblError.Text = "✗ " + message;
            lblError.ForeColor = Color.FromArgb(220, 53, 69);
        }

        private void BtnLogin_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(0, 114, 152);
            }
        }

        private void BtnLogin_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(0, 126, 167);
            }
        }

        private void BtnCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowCreateAccountView();
        }

        private void BtnTogglePassword_Click(object? sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnTogglePassword.Text = txtPassword.UseSystemPasswordChar ? "👁" : "🙈";
        }

        private void BtnToggleConfirmPassword_Click(object? sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
            btnToggleConfirmPassword.Text = txtConfirmPassword.UseSystemPasswordChar ? "👁" : "🙈";
        }

        private void Input_Enter(object? sender, EventArgs e)
        {
            Panel parentPanel = null;

            if (sender is TextBox txt)
            {
                parentPanel = txt.Parent as Panel;
                txt.BackColor = Color.White;
            }
            else if (sender is ComboBox cmb)
            {
                parentPanel = cmb.Parent as Panel;
            }

            if (parentPanel != null)
            {
                _activeFocusPanel = parentPanel;
                parentPanel.Invalidate();
            }
        }

        private void Input_Leave(object? sender, EventArgs e)
        {
            Panel parentPanel = null;

            if (sender is TextBox txt)
            {
                parentPanel = txt.Parent as Panel;
                txt.BackColor = Color.FromArgb(248, 249, 250);
            }
            else if (sender is ComboBox cmb)
            {
                parentPanel = cmb.Parent as Panel;
            }

            if (parentPanel != null && parentPanel == _activeFocusPanel)
            {
                _activeFocusPanel = null;
                parentPanel.Invalidate();
            }
        }

        private void LeftPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Create gradient from color palette
                using (var brush = new LinearGradientBrush(
                    panel.ClientRectangle,
                    Color.FromArgb(0, 50, 73),      // Dark blue
                    Color.FromArgb(0, 126, 167),    // Medium blue
                    LinearGradientMode.Vertical))
                {
                    // Add color blend for smooth transition
                    ColorBlend colorBlend = new ColorBlend();
                    colorBlend.Colors = new Color[] {
                        Color.FromArgb(0, 50, 73),
                        Color.FromArgb(0, 126, 167),
                        Color.FromArgb(128, 206, 215)
                    };
                    colorBlend.Positions = new float[] { 0.0f, 0.6f, 1.0f };
                    brush.InterpolationColors = colorBlend;

                    g.FillRectangle(brush, panel.ClientRectangle);
                }

                // Add decorative circles
                using (var circleBrush = new SolidBrush(Color.FromArgb(15, 255, 255, 255)))
                {
                    g.FillEllipse(circleBrush, -100, -100, 300, 300);
                    g.FillEllipse(circleBrush, panel.Width - 150, panel.Height - 150, 280, 280);
                }

                // Add subtle diagonal lines for visual interest
                using (var linePen = new Pen(Color.FromArgb(10, 255, 255, 255), 2))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        g.DrawLine(linePen, -50, 100 + (i * 100), 100, -50 + (i * 100));
                    }
                }
            }
        }

        private void InputPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                int cornerRadius = 8;

                // Determine if this panel is focused
                bool isFocused = panel == _activeFocusPanel;

                // Draw background
                using (var path = GetRoundedRect(rect, cornerRadius))
                using (var brush = new SolidBrush(panel.BackColor))
                {
                    g.FillPath(brush, path);
                }

                // Draw border
                using (var path = GetRoundedRect(rect, cornerRadius))
                using (var pen = new Pen(isFocused ? Color.FromArgb(0, 126, 167) : Color.FromArgb(222, 226, 230), 2))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private void Btn_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

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
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
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
    }
}