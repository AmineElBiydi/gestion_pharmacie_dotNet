using GestionPharmacie.Data;
using System.Data.SqlClient;

namespace GestionPharmacie.Forms
{
    public partial class StatistiquesForm : Form
    {
        private readonly CommandeRepository _commandeRepo = new();

        public StatistiquesForm()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void StatistiquesForm_Load(object? sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try { 

                this.statsPanel.Controls.Clear();

                // Total Orders
                var totalOrders = GetTotalOrders();
                this.statsPanel.Controls.Add(CreateStatCard("Nombre Total de Commandes", totalOrders.ToString(), Color.FromArgb(0, 123, 255)));

                // Total Revenue
                var totalRevenue = GetTotalRevenue();
                this.statsPanel.Controls.Add(CreateStatCard("Revenus Total", $"{totalRevenue:N2} €", Color.FromArgb(40, 167, 69)));

                // Orders This Month
                var ordersThisMonth = GetOrdersThisMonth();
                this.statsPanel.Controls.Add(CreateStatCard("Commandes ce Mois", ordersThisMonth.ToString(), Color.FromArgb(255, 193, 7)));

                // Top Medicine
                var topMed = GetTopMedicine();
                this.statsPanel.Controls.Add(CreateStatCard("Médicament le Plus Vendu", topMed, Color.FromArgb(220, 53, 69)));

                // Average Order Value
                var avgOrder = totalOrders > 0 ? totalRevenue / totalOrders : 0;
                this.statsPanel.Controls.Add(CreateStatCard("Valeur Moyenne Commande", $"{avgOrder:N2} €", Color.FromArgb(111, 66, 193)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateStatCard(string title, string value, Color color)
        {
            var card = new Panel
            {
                Size = new Size(820, 70),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 10)
            };

            var colorBar = new Panel
            {
                Size = new Size(5, 70),
                BackColor = color,
                Dock = DockStyle.Left
            };

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.Gray,
                Location = new Point(15, 15),
                AutoSize = true
            };

            var valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(15, 35),
                AutoSize = true
            };

            card.Controls.Add(colorBar);
            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);

            return card;
        }

        private int GetTotalOrders()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM Commandes", conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        private decimal GetTotalRevenue()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT ISNULL(SUM(MontantTotal), 0) FROM Commandes", conn);
                return (decimal)cmd.ExecuteScalar();
            }
        }

        private int GetOrdersThisMonth()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT COUNT(*) FROM Commandes 
                      WHERE MONTH(DateCommande) = MONTH(GETDATE()) 
                      AND YEAR(DateCommande) = YEAR(GETDATE())", conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        private string GetTopMedicine()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT TOP 1 m.Nom, SUM(dc.Quantite) as Total
                      FROM DetailsCommande dc
                      INNER JOIN Medicaments m ON dc.MedicamentID = m.ID
                      GROUP BY m.Nom
                      ORDER BY Total DESC", conn);
                
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return $"{reader["Nom"]} ({reader["Total"]} unités)";
                    }
                }
            }
            return "Aucune donnée";
        }
    }
}
