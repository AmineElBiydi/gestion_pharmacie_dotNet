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

        public CommandeEditForm(Commande commande)
        {
            _commande = commande;
            _details = commande.Details != null ? commande.Details.ToList() : new List<DetailsCommande>();
            InitializeComponent();

            if (!DesignMode)
            {
                StyleHelper.ApplyFormTheme(this);
            }
            LoadData();
            LoadCommandeData();
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
            lblTotal.Text = $"Total: {total:N2} DH";
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
