using System.Data.SqlClient;
using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class CommandeEditForm : Form
    {
        private readonly CommandeRepository _commandeRepo = new();
        private readonly ClientRepository _clientRepo = new();
        private readonly MedicamentRepository _medicamentRepo = new();

        private Commande _commande;
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

        public CommandeEditForm(Commande commande)
        {
            _commande = commande;
            _details = commande.Details != null ? commande.Details.ToList() : new List<DetailsCommande>();
            InitializeComponent();
            CreateControls();
            StyleHelper.ApplyFormTheme(this);
            LoadData();
            LoadCommandeData();
        }

        private void CreateControls()
        {
            this.BackColor = StyleHelper.LightGray;
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
                Text = $"Modifier Commande #{_commande.ID}",
                Font = StyleHelper.HeadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(20, 20),
                AutoSize = true
            };
            container.Controls.Add(lblTitle);

            // Header Panel
            var headerPanel = new Panel
            {
                Location = new Point(20, 70),
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
                Location = new Point(20, 270),
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
                Location = new Point(20, 410),
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
                Location = new Point(20, 730),
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
                Text = "Enregistrer Modifications",
                Location = new Point(800, 20),
                Size = new Size(200, 45)
            };
            StyleHelper.StyleButton(btnSave);
            btnSave.Click += BtnSave_Click;

            var btnCancel = new Button
            {
                Text = "Annuler",
                Location = new Point(600, 20),
                Size = new Size(150, 45)
            };
            StyleHelper.StyleButton(btnCancel, StyleHelper.TextLight);
            btnCancel.Click += BtnCancel_Click;

            footerPanel.Controls.AddRange(new Control[] { lblTotal, btnSave, btnCancel });
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

        private void LoadCommandeData()
        {
            cboClient.SelectedValue = _commande.ClientID;
            dtpDate.Value = _commande.DateCommande;
            cboStatut.SelectedItem = _commande.Statut;
            chkEstPaye.Checked = _commande.EstPaye;
            if (!string.IsNullOrEmpty(_commande.TypePaiement))
            {
                var index = cboTypePaiement.Items.IndexOf(_commande.TypePaiement);
                if (index >= 0) cboTypePaiement.SelectedIndex = index;
            }
            
            // Load details if not already loaded
            if (_commande.Details != null && _commande.Details.Count > 0)
            {
                _details = _commande.Details.ToList();
            }
            
            RefreshDetails();
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
                _commande.DateCommande = dtpDate.Value;
                _commande.ClientID = (int)cboClient.SelectedValue;
                _commande.MontantTotal = _details.Sum(d => d.SousTotal);
                _commande.Statut = cboStatut.SelectedItem?.ToString() ?? "En cours";
                _commande.EstPaye = chkEstPaye.Checked;
                _commande.TypePaiement = cboTypePaiement.SelectedItem?.ToString();
                _commande.Details = _details;

                _commandeRepo.Update(_commande);
                MessageBox.Show("Commande modifiée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
