using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Controls
{
    public partial class MedicamentAlertControl : UserControl
    {
        private readonly MedicamentRepository _repository = new();
        private System.Windows.Forms.Timer refreshTimer = null!;

        public MedicamentAlertControl()
        {
            InitializeComponent();
            CreateControls();
            LoadAlerts();
            
            // Auto-refresh every 60 seconds
            refreshTimer = new System.Windows.Forms.Timer { Interval = 60000 };
            refreshTimer.Tick += (s, e) => LoadAlerts();
            refreshTimer.Start();
        }

        private void CreateControls()
        {
            this.BackColor = StyleHelper.LightGray;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            // Main container
            var container = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = StyleHelper.LightGray,
                Padding = new Padding(20)
            };

            // Title Panel with warning icon
            var titlePanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1100, 80),
                BackColor = Color.FromArgb(255, 243, 205),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblTitle = new Label
            {
                Text = "⚠ Alertes - Médicaments nécessitant une attention",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(133, 100, 4),
                Location = new Point(20, 25),
                AutoSize = true
            };
            titlePanel.Controls.Add(lblTitle);

            var lblSubtitle = new Label
            {
                Text = "Stock faible ou péremption proche",
                Font = StyleHelper.BodyFont,
                ForeColor = Color.FromArgb(133, 100, 4),
                Location = new Point(20, 50),
                AutoSize = true
            };
            titlePanel.Controls.Add(lblSubtitle);

            var btnRefresh = new Button
            {
                Text = "🔄 Actualiser",
                Location = new Point(950, 20),
                Size = new Size(120, 40)
            };
            StyleHelper.StyleButton(btnRefresh);
            btnRefresh.Click += (s, e) => LoadAlerts();
            titlePanel.Controls.Add(btnRefresh);

            container.Controls.Add(titlePanel);

            // Alerts Grid
            var gridPanel = new Panel
            {
                Location = new Point(0, 100),
                Size = new Size(1100, 550),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(gridPanel);

            var dgvAlerts = new DataGridView
            {
                Name = "dgvAlerts",
                Location = new Point(10, 10),
                Size = new Size(1080, 530),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Dock = DockStyle.Fill
            };
            StyleHelper.StyleDataGridView(dgvAlerts);

            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Reference", HeaderText = "Référence", Width = 150 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nom", HeaderText = "Nom", Width = 300 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DatePeremption", HeaderText = "Date Péremption", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QuantiteStock", HeaderText = "Stock", Width = 120 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Seuil", HeaderText = "Seuil", Width = 120 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrixUnitaire", HeaderText = "Prix (€)", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });

            dgvAlerts.RowPrePaint += DgvAlerts_RowPrePaint;

            gridPanel.Controls.Add(dgvAlerts);
            container.Controls.Add(gridPanel);

            this.Controls.Add(container);
        }

        private void DgvAlerts_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.Rows[e.RowIndex].DataBoundItem is not Medicament med) return;

            if (med.QuantiteStock == 0)
            {
                // Out of stock - red
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(139, 0, 0);
            }
            else if (med.DatePeremption <= DateTime.Now)
            {
                // Expired - dark red
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 150, 150);
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(139, 0, 0);
            }
            else if (med.DatePeremption <= DateTime.Now.AddMonths(1))
            {
                // Expiring soon - orange
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200);
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(184, 134, 11);
            }
            else if (med.QuantiteStock <= med.Seuil)
            {
                // Low stock - yellow
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(133, 100, 4);
            }
        }

        private void LoadAlerts()
        {
            try
            {
                var dgvAlerts = this.Controls.Find("dgvAlerts", true).FirstOrDefault() as DataGridView;
                if (dgvAlerts == null) return;

                var alerts = _repository.GetMedicamentsEnAlerte();
                dgvAlerts.DataSource = alerts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                refreshTimer?.Stop();
                refreshTimer?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "MedicamentAlertControl";
            this.Size = new Size(1200, 700);
            this.ResumeLayout(false);
        }
    }
}

