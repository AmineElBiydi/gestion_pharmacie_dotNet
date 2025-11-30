using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Controls
{
    public partial class CommandeControl : UserControl
    {
        private readonly CommandeRepository _commandeRepo = new();
        private readonly ClientRepository _clientRepo = new();
        private readonly MedicamentRepository _medicamentRepo = new();

        private List<DetailsCommande> _details = new();

        private ComboBox cboClient = null!;
        private DateTimePicker dtpDate = null!;
        private ComboBox cboStatut = null!;
        private ComboBox cboMedicament = null!;
        private NumericUpDown nudQuantite = null!;
        private DataGridView dgvDetails = null!;
        private Label lblTotal = null!;
        private CheckBox chkEstPaye = null!;
        private ComboBox cboTypePaiement = null!;

        public CommandeControl()
        {
            InitializeComponent();
            CreateControls();
            LoadData();
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

            // Title
            var lblTitle = new Label
            {
                Text = "Nouvelle Commande",
                Font = StyleHelper.HeadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(0, 0),
                AutoSize = true
            };
            container.Controls.Add(lblTitle);

            // Header Panel
            var headerPanel = new Panel
            {
                Location = new Point(0, 50),
                Size = new Size(1100, 180),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(headerPanel);

            var lblClient = new Label { Text = "Client:", Location = new Point(20, 20), AutoSize = true };
            StyleHelper.StyleLabel(lblClient);
            cboClient = new ComboBox
            {
                Location = new Point(150, 17),
                Size = new Size(400, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = StyleHelper.BodyFont
            };

            var lblDate = new Label { Text = "Date Commande:", Location = new Point(20, 60), AutoSize = true };
            StyleHelper.StyleLabel(lblDate);
            dtpDate = new DateTimePicker
            {
                Location = new Point(150, 57),
                Size = new Size(250, 30),
                Font = StyleHelper.BodyFont
            };

            var lblStatut = new Label { Text = "Statut:", Location = new Point(20, 100), AutoSize = true };
            StyleHelper.StyleLabel(lblStatut);
            cboStatut = new ComboBox
            {
                Location = new Point(150, 97),
                Size = new Size(250, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = StyleHelper.BodyFont
            };
            cboStatut.Items.AddRange(new object[] { "En cours", "Livrée", "Annulée" });
            cboStatut.SelectedIndex = 0;

            // Payment fields
            chkEstPaye = new CheckBox
            {
                Text = "Facture Payée",
                Location = new Point(450, 20),
                Font = StyleHelper.BodyFont
            };

            var lblTypePaiement = new Label { Text = "Type Paiement:", Location = new Point(450, 60), AutoSize = true };
            StyleHelper.StyleLabel(lblTypePaiement);
            cboTypePaiement = new ComboBox
            {
                Location = new Point(450, 85),
                Size = new Size(250, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = StyleHelper.BodyFont
            };
            cboTypePaiement.Items.AddRange(new object[] { "", "Espèces", "Carte Bancaire", "Chèque", "Virement", "Autre" });

            headerPanel.Controls.AddRange(new Control[] { 
                lblClient, cboClient, lblDate, dtpDate, lblStatut, cboStatut,
                chkEstPaye, lblTypePaiement, cboTypePaiement
            });
            container.Controls.Add(headerPanel);

            // Details Panel
            var detailsPanel = new Panel
            {
                Location = new Point(0, 250),
                Size = new Size(1100, 120),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(detailsPanel);

            var lblAddMed = new Label
            {
                Text = "Ajouter Médicament:",
                Font = StyleHelper.SubheadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(20, 20),
                AutoSize = true
            };

            var lblMed = new Label { Text = "Médicament:", Location = new Point(20, 55), AutoSize = true };
            StyleHelper.StyleLabel(lblMed);
            cboMedicament = new ComboBox
            {
                Location = new Point(120, 52),
                Size = new Size(400, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = StyleHelper.BodyFont
            };

            var lblQte = new Label { Text = "Quantité:", Location = new Point(540, 55), AutoSize = true };
            StyleHelper.StyleLabel(lblQte);
            nudQuantite = new NumericUpDown
            {
                Location = new Point(620, 52),
                Size = new Size(120, 30),
                Minimum = 1,
                Maximum = 1000,
                Value = 1,
                Font = StyleHelper.BodyFont
            };

            var btnAdd = new Button
            {
                Text = "Ajouter",
                Location = new Point(760, 50),
                Size = new Size(120, 35)
            };
            StyleHelper.StyleButton(btnAdd, StyleHelper.AccentGreen);
            btnAdd.Click += BtnAddDetail_Click;

            detailsPanel.Controls.AddRange(new Control[] { lblAddMed, lblMed, cboMedicament, lblQte, nudQuantite, btnAdd });
            container.Controls.Add(detailsPanel);

            // Details Grid
            var gridPanel = new Panel
            {
                Location = new Point(0, 390),
                Size = new Size(1100, 300),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(gridPanel);

            dgvDetails = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(1080, 280),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Dock = DockStyle.Fill
            };
            StyleHelper.StyleDataGridView(dgvDetails);

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicamentReference", HeaderText = "Référence", Width = 150 });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicamentNom", HeaderText = "Médicament", Width = 300 });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantite", HeaderText = "Quantité", Width = 120 });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrixUnitaire", HeaderText = "Prix Unit. (€)", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SousTotal", HeaderText = "Sous-Total (€)", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });

            var colDelete = new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true,
                Width = 150
            };
            dgvDetails.Columns.Add(colDelete);

            dgvDetails.CellClick += DgvDetails_CellClick;

            gridPanel.Controls.Add(dgvDetails);
            container.Controls.Add(gridPanel);

            // Footer Panel
            var footerPanel = new Panel
            {
                Location = new Point(0, 710),
                Size = new Size(1100, 80),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(footerPanel);

            lblTotal = new Label
            {
                Text = "Total: 0.00 €",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(20, 25),
                AutoSize = true
            };

            var btnSave = new Button
            {
                Text = "Enregistrer Commande",
                Location = new Point(800, 20),
                Size = new Size(200, 45)
            };
            StyleHelper.StyleButton(btnSave);
            btnSave.Click += BtnSave_Click;

            footerPanel.Controls.AddRange(new Control[] { lblTotal, btnSave });
            container.Controls.Add(footerPanel);

            this.Controls.Add(container);
        }

        private void LoadData()
        {
            try
            {
                var clients = _clientRepo.GetAll();
                cboClient.DataSource = clients;
                cboClient.DisplayMember = "NomComplet";
                cboClient.ValueMember = "ID";

                var medicaments = _medicamentRepo.GetAll();
                cboMedicament.DataSource = medicaments;
                cboMedicament.DisplayMember = "Nom";
                cboMedicament.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddDetail_Click(object? sender, EventArgs e)
        {
            if (cboMedicament.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un médicament.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var medicament = _medicamentRepo.GetById((int)cboMedicament.SelectedValue);
            if (medicament == null) return;

            if (medicament.QuantiteStock < (int)nudQuantite.Value)
            {
                MessageBox.Show($"Stock insuffisant! Disponible: {medicament.QuantiteStock}", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detail = new DetailsCommande
            {
                MedicamentID = medicament.ID,
                MedicamentNom = medicament.Nom,
                MedicamentReference = medicament.Reference,
                Quantite = (int)nudQuantite.Value,
                PrixUnitaire = medicament.PrixUnitaire
            };

            _details.Add(detail);
            RefreshDetails();
        }

        private void DgvDetails_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDetails.Columns.Count - 1)
            {
                _details.RemoveAt(e.RowIndex);
                RefreshDetails();
            }
        }

        private void RefreshDetails()
        {
            dgvDetails.DataSource = null;
            dgvDetails.DataSource = _details.ToList();

            var total = _details.Sum(d => d.SousTotal);
            lblTotal.Text = $"Total: {total:N2} €";
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (cboClient.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_details.Count == 0)
            {
                MessageBox.Show("Veuillez ajouter au moins un médicament.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var commande = new Commande
                {
                    DateCommande = dtpDate.Value,
                    ClientID = (int)cboClient.SelectedValue,
                    MontantTotal = _details.Sum(d => d.SousTotal),
                    Statut = cboStatut.SelectedItem?.ToString() ?? "En cours",
                    EstPaye = chkEstPaye.Checked,
                    TypePaiement = cboTypePaiement.SelectedItem?.ToString(),
                    Details = _details
                };

                _commandeRepo.Insert(commande);
                MessageBox.Show("Commande enregistrée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Clear form after successful save
                _details.Clear();
                RefreshDetails();
                cboClient.SelectedIndex = -1;
                dtpDate.Value = DateTime.Now;
                cboStatut.SelectedIndex = 0;
                chkEstPaye.Checked = false;
                cboTypePaiement.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "CommandeControl";
            this.Size = new Size(1200, 800);
            this.ResumeLayout(false);
        }
    }
}

