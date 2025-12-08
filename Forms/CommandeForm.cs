using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class CommandeForm : Form
    {
        private readonly CommandeRepository _commandeRepo = new();
        private readonly ClientRepository _clientRepo = new();
        private readonly MedicamentRepository _medicamentRepo = new();

        private List<DetailsCommande> _details = new();

        public CommandeForm()
        {
            InitializeComponent();
            StyleHelper.ApplyFormTheme(this);
            LoadData();
            cboStatut.SelectedIndex = 0; // Set default to "En cours"
        }

        private void CommandeForm_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var clients = _clientRepo.GetAll();
                cboClient.DataSource = clients;
                cboClient.DisplayMember = "NomComplet";
                cboClient.ValueMember = "ID";

                var medicaments = _medicamentRepo.GetAll()
                    .Where(m => !m.EstBloque)
                    .ToList();
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

        private void BtnNewClient_Click(object? sender, EventArgs e)
        {
            // Store the currently selected client ID (if any)
            var selectedClientId = cboClient.SelectedValue as int?;

            // Open the ClientForm
            using (var clientForm = new ClientForm())
            {
                clientForm.ShowDialog();
            }

            // Reload the clients dropdown
            var clients = _clientRepo.GetAll();
            cboClient.DataSource = clients;
            cboClient.DisplayMember = "NomComplet";
            cboClient.ValueMember = "ID";

            // Try to restore the previously selected client
            if (selectedClientId.HasValue)
            {
                cboClient.SelectedValue = selectedClientId.Value;
            }
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
                    Details = _details
                };

                _commandeRepo.Insert(commande);
                MessageBox.Show("Commande enregistrée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}