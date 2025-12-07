using System.Data.SqlClient;
using GestionPharmacie.Models;
using GestionPharmacie.Data;

namespace GestionPharmacie.Forms
{
    public partial class CommandeDashboardForm : Form
    {
        private readonly CommandeRepository _commandeRepo = new();
        private System.Windows.Forms.Timer refreshTimer = null!;

        public CommandeDashboardForm()
        {
            InitializeComponent();
            LoadStatistics();

            // Auto-refresh every 30 seconds
            refreshTimer = new System.Windows.Forms.Timer { Interval = 30000 };
            refreshTimer.Tick += (s, e) => LoadStatistics();
            refreshTimer.Start();
        }

        private void LoadStatistics()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    UpdateCardValue("cardTotalCmd", GetCount(conn, "SELECT COUNT(*) FROM Commandes"));
                    UpdateCardValue("cardCmdToday", GetCount(conn, "SELECT COUNT(*) FROM Commandes WHERE CAST(DateCommande AS DATE) = CAST(GETDATE() AS DATE)"));
                    UpdateCardValue("cardCmdMonth", GetCount(conn, "SELECT COUNT(*) FROM Commandes WHERE MONTH(DateCommande) = MONTH(GETDATE()) AND YEAR(DateCommande) = YEAR(GETDATE())"));

                    var revenue = GetDecimal(conn, "SELECT ISNULL(SUM(MontantTotal), 0) FROM Commandes");
                    UpdateCardValue("cardRevenue", $"{revenue:N0} DH");

                    UpdateCardValue("cardPending", GetCount(conn, "SELECT COUNT(*) FROM Commandes WHERE Statut = 'En cours'"));
                    UpdateCardValue("cardDelivered", GetCount(conn, "SELECT COUNT(*) FROM Commandes WHERE Statut = 'Livrée'"));
                    UpdateCardValue("cardCancelled", GetCount(conn, "SELECT COUNT(*) FROM Commandes WHERE Statut = 'Annulée'"));
                    UpdateCardValue("cardUnpaid", GetCount(conn, "SELECT COUNT(*) FROM Commandes WHERE ISNULL(EstPaye, 0) = 0"));

                    var lblUpdate = this.Controls.Find("lblUpdate", true).FirstOrDefault() as Label;
                    if (lblUpdate != null)
                        lblUpdate.Text = $"Dernière mise à jour: {DateTime.Now:HH:mm}";

                    LoadRecentCommandes(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentCommandes(SqlConnection conn)
        {
            try
            {
                var query = @"SELECT TOP 10 c.*, cl.Nom + ' ' + cl.Prenom AS ClientNom,
                              ISNULL(c.EstPaye, 0) AS EstPaye,
                              c.TypePaiement
                              FROM Commandes c
                              INNER JOIN Clients cl ON c.ClientID = cl.ID
                              ORDER BY c.DateCommande DESC";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var commandes = new List<Commande>();
                    while (reader.Read())
                    {
                        commandes.Add(new Commande
                        {
                            ID = (int)reader["ID"],
                            DateCommande = (DateTime)reader["DateCommande"],
                            ClientID = (int)reader["ClientID"],
                            MontantTotal = (decimal)reader["MontantTotal"],
                            Statut = reader["Statut"].ToString() ?? "En cours",
                            EstPaye = reader["EstPaye"] != DBNull.Value && (bool)reader["EstPaye"],
                            TypePaiement = reader["TypePaiement"] == DBNull.Value ? null : reader["TypePaiement"].ToString(),
                            ClientNom = reader["ClientNom"].ToString()
                        });
                    }

                    var dgv = this.Controls.Find("dgvRecent", true).FirstOrDefault() as DataGridView;
                    if (dgv != null)
                    {
                        dgv.DataSource = commandes;
                    }
                }
            }
            catch { }
        }

        private int GetCount(SqlConnection conn, string query)
        {
            using (var cmd = new SqlCommand(query, conn))
            {
                var result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        private decimal GetDecimal(SqlConnection conn, string query)
        {
            using (var cmd = new SqlCommand(query, conn))
            {
                var result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            }
        }

        private void UpdateCardValue(string cardName, string value)
        {
            var card = this.Controls.Find(cardName, true).FirstOrDefault() as Panel;
            if (card != null)
            {
                var lblValue = card.Controls.Find("lblValue", false).FirstOrDefault() as Label;
                if (lblValue != null)
                    lblValue.Text = value;
            }
        }

        private void UpdateCardValue(string cardName, int value)
        {
            UpdateCardValue(cardName, value.ToString());
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            var form = new CommandeForm();
            form.ShowDialog();
            LoadStatistics(); // Refresh after closing
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            var form = new CommandeSearchForm();
            form.ShowDialog();
        }

        private void BtnModify_Click(object? sender, EventArgs e)
        {
            var dgv = this.Controls.Find("dgvRecent", true).FirstOrDefault() as DataGridView;
            if (dgv?.CurrentRow?.DataBoundItem is Commande cmd)
            {
                var fullCommande = _commandeRepo.GetById(cmd.ID);
                if (fullCommande != null)
                {
                    var form = new CommandeEditForm(fullCommande);
                    form.ShowDialog();
                    LoadStatistics();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une commande à modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void navPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
