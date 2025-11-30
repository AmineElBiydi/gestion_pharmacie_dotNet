using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class CreateAccountForm : Form
    {
        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private TextBox txtConfirmPassword = null!;
        private TextBox txtFullName = null!;
        private ComboBox cboRole = null!;
        private CheckBox chkShowPassword = null!;
        private Label lblMessage = null!;

        public CreateAccountForm()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {
            this.Text = "Créer un compte";
            this.Size = new Size(500, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(40)
            };
            mainPanel.Paint += MainPanel_Paint;

            // Title
            var lblTitle = new Label
            {
                Text = "Créer un compte",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(0, 0),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblTitle);

            // Subtitle
            var lblSubtitle = new Label
            {
                Text = "Remplissez les informations pour créer un nouveau compte",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(117, 117, 117),
                Location = new Point(0, 50),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblSubtitle);

            int y = 100;

            // Username
            var lblUsername = new Label
            {
                Text = "Nom d'utilisateur *",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(0, y),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblUsername);
            y += 30;
            txtUsername = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(0, y),
                Size = new Size(420, 40),
                TabIndex = 0,
                BackColor = Color.FromArgb(250, 250, 250)
            };
            txtUsername.Enter += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.White; };
            txtUsername.Leave += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.FromArgb(250, 250, 250); };
            mainPanel.Controls.Add(txtUsername);
            y += 50;

            // Password
            var lblPassword = new Label
            {
                Text = "Mot de passe *",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(0, y),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblPassword);
            y += 30;
            txtPassword = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(0, y),
                Size = new Size(420, 40),
                TabIndex = 1,
                UseSystemPasswordChar = true,
                BackColor = Color.FromArgb(250, 250, 250)
            };
            txtPassword.Enter += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.White; };
            txtPassword.Leave += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.FromArgb(250, 250, 250); };
            mainPanel.Controls.Add(txtPassword);
            y += 50;

            // Confirm Password
            var lblConfirmPassword = new Label
            {
                Text = "Confirmer le mot de passe *",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(0, y),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblConfirmPassword);
            y += 30;
            txtConfirmPassword = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(0, y),
                Size = new Size(420, 40),
                TabIndex = 2,
                UseSystemPasswordChar = true,
                BackColor = Color.FromArgb(250, 250, 250)
            };
            txtConfirmPassword.Enter += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.White; };
            txtConfirmPassword.Leave += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.FromArgb(250, 250, 250); };
            mainPanel.Controls.Add(txtConfirmPassword);
            y += 40;

            // Show Password
            chkShowPassword = new CheckBox
            {
                Text = "Afficher le mot de passe",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(117, 117, 117),
                Location = new Point(0, y),
                AutoSize = true
            };
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            mainPanel.Controls.Add(chkShowPassword);
            y += 50;

            // Full Name
            var lblFullName = new Label
            {
                Text = "Nom complet *",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(0, y),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblFullName);
            y += 30;
            txtFullName = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(0, y),
                Size = new Size(420, 40),
                TabIndex = 3,
                BackColor = Color.FromArgb(250, 250, 250)
            };
            txtFullName.Enter += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.White; };
            txtFullName.Leave += (s, e) => { if (s is TextBox tb) tb.BackColor = Color.FromArgb(250, 250, 250); };
            mainPanel.Controls.Add(txtFullName);
            y += 50;

            // Role
            var lblRole = new Label
            {
                Text = "Rôle",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(0, y),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblRole);
            y += 30;
            cboRole = new ComboBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(0, y),
                Size = new Size(420, 40),
                DropDownStyle = ComboBoxStyle.DropDownList,
                TabIndex = 4,
                BackColor = Color.FromArgb(250, 250, 250),
                FlatStyle = FlatStyle.Flat
            };
            cboRole.Items.AddRange(new string[] { "Pharmacien", "Admin", "User" });
            cboRole.SelectedIndex = 0;
            cboRole.Enter += (s, e) => { if (s is ComboBox cb) cb.BackColor = Color.White; };
            cboRole.Leave += (s, e) => { if (s is ComboBox cb) cb.BackColor = Color.FromArgb(250, 250, 250); };
            mainPanel.Controls.Add(cboRole);
            y += 60;

            // Message label
            lblMessage = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(0, y),
                Size = new Size(420, 30),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft
            };
            mainPanel.Controls.Add(lblMessage);
            y += 40;

            // Buttons
            var btnCreate = new Button
            {
                Text = "Créer le compte",
                BackColor = StyleHelper.PrimaryBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Location = new Point(0, y),
                Size = new Size(200, 48),
                Cursor = Cursors.Hand,
                TabIndex = 5
            };
            btnCreate.Click += BtnCreate_Click;
            btnCreate.MouseEnter += (s, e) => btnCreate.BackColor = StyleHelper.DarkBlue;
            btnCreate.MouseLeave += (s, e) => btnCreate.BackColor = StyleHelper.PrimaryBlue;
            btnCreate.Paint += (s, e) => PaintRoundedButton(s, e, 8);
            mainPanel.Controls.Add(btnCreate);

            var btnCancel = new Button
            {
                Text = "Annuler",
                BackColor = Color.FromArgb(224, 224, 224),
                ForeColor = Color.FromArgb(33, 33, 33),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Location = new Point(220, y),
                Size = new Size(200, 48),
                Cursor = Cursors.Hand,
                TabIndex = 6
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            btnCancel.MouseEnter += (s, e) => { if (s is Button btn) btn.BackColor = Color.FromArgb(200, 200, 200); };
            btnCancel.MouseLeave += (s, e) => { if (s is Button btn) btn.BackColor = Color.FromArgb(224, 224, 224); };
            btnCancel.Paint += (s, e) => PaintRoundedButton(s, e, 8);
            mainPanel.Controls.Add(btnCancel);

            this.Controls.Add(mainPanel);
            this.AcceptButton = btnCreate;
            this.CancelButton = btnCancel;
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

        private void PaintRoundedButton(object? sender, PaintEventArgs e)
        {
            PaintRoundedButton(sender, e, 8);
        }

        private void PaintRoundedButton(object? sender, PaintEventArgs e, int cornerRadius)
        {
            if (sender is Button btn)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var rect = new Rectangle(0, 0, btn.Width, btn.Height);

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
    }
}

