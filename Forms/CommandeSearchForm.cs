using GestionPharmacie.Models;
using GestionPharmacie.Data;
using System.Drawing.Printing;
using System.Text;

namespace GestionPharmacie.Forms
{
    public partial class CommandeSearchForm : Form
    {
        private readonly CommandeRepository _commandeRepo = new();
        private readonly ClientRepository _clientRepo = new();
        private Commande? _selectedCommande;

        public CommandeSearchForm()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
        }

        private void CommandeSearchForm_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var allClients = new List<Client> { new Client { ID = 0, Nom = "Tous", Prenom = "" } };
                allClients.AddRange(_clientRepo.GetAll());
                
                cboClient.DataSource = allClients;
                cboClient.DisplayMember = "NomComplet";
                cboClient.ValueMember = "ID";

                LoadAllCommandes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllCommandes()
        {
            try
            {
                var commandes = _commandeRepo.GetAll();
                dgvCommandes.DataSource = commandes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearchDate_Click(object? sender, EventArgs e)
        {
            SearchByDate();
        }

        private void BtnSearchClient_Click(object? sender, EventArgs e)
        {
            SearchByClient();
        }

        private void BtnShowAll_Click(object? sender, EventArgs e)
        {
            LoadAllCommandes();
        }

        private void SearchByDate()
        {
            try
            {
                var commandes = _commandeRepo.SearchByDate(dtpStartDate.Value.Date, dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1));
                dgvCommandes.DataSource = commandes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchByClient()
        {
            if (cboClient.SelectedValue == null || (int)cboClient.SelectedValue == 0)
            {
                LoadAllCommandes();
                return;
            }

            try
            {
                var commandes = _commandeRepo.SearchByClient((int)cboClient.SelectedValue);
                dgvCommandes.DataSource = commandes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCommandes_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCommandes.CurrentRow?.DataBoundItem is Commande cmd)
            {
                _selectedCommande = _commandeRepo.GetById(cmd.ID);
            }
        }

        private void DgvCommandes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCommandes.Columns.Count - 1)
            {
                if (_selectedCommande != null)
                {
                    PrintCommande(_selectedCommande);
                }
            }
        }

        private void PrintCommande(Commande commande)
        {
            try
            {
                var printDoc = new PrintDocument();
                printDoc.PrintPage += (s, e) =>
                {
                    if (e.Graphics == null) return;

                    var font = new Font("Courier New", 10);
                    var y = 50f;
                    var lineHeight = font.GetHeight(e.Graphics);

                    e.Graphics.DrawString("========== FACTURE ==========", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, 100, y);
                    y += lineHeight * 2;

                    e.Graphics.DrawString($"N° Commande: {commande.ID}", font, Brushes.Black, 100, y);
                    y += lineHeight;
                    e.Graphics.DrawString($"Date: {commande.DateCommande:dd/MM/yyyy HH:mm}", font, Brushes.Black, 100, y);
                    y += lineHeight;
                    e.Graphics.DrawString($"Client: {commande.ClientNom}", font, Brushes.Black, 100, y);
                    y += lineHeight;
                    e.Graphics.DrawString($"Statut: {commande.Statut}", font, Brushes.Black, 100, y);
                    y += lineHeight * 2;

                    e.Graphics.DrawString("Détails:", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, 100, y);
                    y += lineHeight;
                    e.Graphics.DrawString("----------------------------------------", font, Brushes.Black, 100, y);
                    y += lineHeight;

                    foreach (var detail in commande.Details)
                    {
                        e.Graphics.DrawString($"{detail.MedicamentNom} ({detail.MedicamentReference})", font, Brushes.Black, 100, y);
                        y += lineHeight;
                        e.Graphics.DrawString($"  Qté: {detail.Quantite} x {detail.PrixUnitaire:N2}€ = {detail.SousTotal:N2}€", font, Brushes.Black, 100, y);
                        y += lineHeight;
                    }

                    y += lineHeight;
                    e.Graphics.DrawString("========================================", font, Brushes.Black, 100, y);
                    y += lineHeight;
                    e.Graphics.DrawString($"TOTAL: {commande.MontantTotal:N2} €", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, 100, y);
                };

                var printDialog = new PrintDialog { Document = printDoc };
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur d'impression: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
