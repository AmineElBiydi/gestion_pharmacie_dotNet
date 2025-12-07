using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class MedicamentAlertForm : Form
    {
        private readonly MedicamentRepository _repository = new();
        private readonly FournisseurRepository _fournisseurRepo = new();
        private bool _showingSuppliers = false;
        private Medicament? _currentMedicament = null;

        public MedicamentAlertForm()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                StyleHelper.ApplyFormTheme(this);
                AddSupplierButtonColumn();
                CreateBackButton();
            }
            LoadAlerts();
        }

        private Button? _btnBack;

        private void CreateBackButton()
        {
            _btnBack = new Button
            {
                Text = "← Retour aux Médicaments",
                Location = new Point(500, 20),  // Position next to title, top-right area
                Size = new Size(220, 35),
                BackColor = Color.FromArgb(66, 133, 244),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand,
                Visible = false
            };
            _btnBack.FlatAppearance.BorderSize = 0;
            _btnBack.Click += BtnBack_Click;
            this.Controls.Add(_btnBack);
            _btnBack.BringToFront();
        }

        private void BtnBack_Click(object? sender, EventArgs e)
        {
            ShowMedicationsView();
        }

        private void AddSupplierButtonColumn()
        {
            // Check if button column already exists
            if (dgvAlerts.Columns.Contains("btnViewSuppliers"))
                return;

            var btnColumn = new DataGridViewButtonColumn
            {
                Name = "btnViewSuppliers",
                HeaderText = "Fournisseurs",
                Text = "Voir",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvAlerts.Columns.Add(btnColumn);
            
            // Only subscribe once
            dgvAlerts.CellClick -= DgvAlerts_CellClick; // Remove if exists
            dgvAlerts.CellClick += DgvAlerts_CellClick; // Add
        }

        private void DgvAlerts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvAlerts.Columns[e.ColumnIndex].Name == "btnViewSuppliers")
                {
                    var medicament = (Medicament)dgvAlerts.Rows[e.RowIndex].DataBoundItem;
                    ShowSuppliers(medicament);
                }
            }
        }

        private void ShowSuppliers(Medicament medicament)
        {
            var suppliers = _fournisseurRepo.GetSuppliersForMedicament(medicament.ID);
            
            if (suppliers.Count == 0)
            {
                MessageBox.Show(
                    $"Aucun fournisseur enregistré pour {medicament.Nom}.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _currentMedicament = medicament;
            _showingSuppliers = true;

            // Update title
            lblTitle.Text = $"Fournisseurs - {medicament.Nom}";

            // Unsubscribe from events temporarily
            dgvAlerts.CellClick -= DgvAlerts_CellClick;
            dgvAlerts.RowPrePaint -= DgvAlerts_RowPrePaint;

            // Clear and setup for suppliers
            dgvAlerts.DataSource = null;
            dgvAlerts.Columns.Clear();
            dgvAlerts.AutoGenerateColumns = false;

            // Add supplier columns
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FournisseurNom",
                HeaderText = "Fournisseur",
                Name = "colNom",
                Width = 200
            });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FournisseurTelephone",
                HeaderText = "Téléphone",
                Name = "colTelephone",
                Width = 140
            });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FournisseurEmail",
                HeaderText = "Email",
                Name = "colEmail",
                Width = 200
            });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrixInfo",
                HeaderText = "Prix d'Achat",
                Name = "colPrix",
                Width = 120
            });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DelaiLivraison",
                HeaderText = "Délai (jours)",
                Name = "colDelai",
                Width = 100
            });

            // Bind data
            dgvAlerts.DataSource = suppliers;
            
            // Show back button
            if (_btnBack != null)
            {
                _btnBack.Visible = true;
            }
        }

        private void ShowMedicationsView()
        {
            _showingSuppliers = false;
            _currentMedicament = null;
            lblTitle.Text = "Alertes Médicaments";

            // Hide back button
            if (_btnBack != null)
            {
                _btnBack.Visible = false;
            }

            LoadAlerts();
        }

        private void MedicamentAlertForm_Load(object? sender, EventArgs e)
        {
            if (!_showingSuppliers)
            {
                LoadAlerts();
            }
        }

        private void DgvAlerts_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (_showingSuppliers) return; // Don't color supplier rows

            if (dgvAlerts.Rows[e.RowIndex].DataBoundItem is Medicament med)
            {
                if (med.DatePeremption <= DateTime.Now)
                {
                    dgvAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                }
                else if (med.DatePeremption <= DateTime.Now.AddMonths(1))
                {
                    dgvAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200);
                }
                else if (med.QuantiteStock <= med.Seuil)
                {
                    dgvAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
                }
            }
        }

        private void LoadAlerts()
        {
            try
            {
                // Unsubscribe events
                dgvAlerts.CellClick -= DgvAlerts_CellClick;
                dgvAlerts.RowPrePaint -= DgvAlerts_RowPrePaint;

                dgvAlerts.DataSource = null;
                dgvAlerts.Columns.Clear();
                dgvAlerts.AutoGenerateColumns = true;

                var alerts = _repository.GetMedicamentsEnAlerte();
                dgvAlerts.DataSource = alerts;

                // Re-add supplier button column
                AddSupplierButtonColumn();

                // Resubscribe to row painting for color coding
                dgvAlerts.RowPrePaint += DgvAlerts_RowPrePaint;

                if (alerts.Count == 0)
                {
                    MessageBox.Show("Aucune alerte pour le moment!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
