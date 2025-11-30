using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using GestionPharmacie.Utils;
using GestionPharmacie.Data;
using GestionPharmacie.Models;

namespace GestionPharmacie.Controls
{
    public partial class DashboardControl : UserControl
    {
        private System.Windows.Forms.Timer refreshTimer = null!;
        
        public DashboardControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill; // IMPORTANT: Must dock to fill
            CreateDashboard();
            LoadStatistics();
            
            // Auto-refresh every 30 seconds
            refreshTimer = new System.Windows.Forms.Timer { Interval = 30000 };
            refreshTimer.Tick += (s, e) => LoadStatistics();
            refreshTimer.Start();
        }

        private void CreateDashboard()
        {
            this.BackColor = StyleHelper.LightGray;
            this.AutoScroll = true;
            this.Padding = new Padding(0);

            // Main container
            var container = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1050, 1050),
                BackColor = StyleHelper.LightGray,
                AutoScroll = true
            };

            // Header
            var lblTitle = new Label
            {
                Text = "Tableau de Bord",
                Font = StyleHelper.HeadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(25, 20),
                AutoSize = true
            };
            container.Controls.Add(lblTitle);

            var lblUpdate = new Label
            {
                Text = $"Dernière mise à jour: {DateTime.Now:HH:mm}",
                Font = StyleHelper.SmallFont,
                ForeColor = StyleHelper.TextLight,
                Location = new Point(25, 50),
                AutoSize = true,
                Name = "lblUpdate"
            };
            container.Controls.Add(lblUpdate);

            // Row 1 - Statistics Cards
            CreateStatCard("cardTotalMed", "Médicaments", "0", StyleHelper.PrimaryBlue, 25, 90, container);
            CreateStatCard("cardLowStock", "Stock Faible", "0", StyleHelper.AccentOrange, 270, 90, container);
            CreateStatCard("cardExpiring", "Péremption Proche", "0", StyleHelper.AccentRed, 515, 90, container);
            CreateStatCard("cardClients", "Clients", "0", StyleHelper.AccentGreen, 760, 90, container);

            // Row 2
            CreateStatCard("cardOrders", "Commandes Total", "0", StyleHelper.AccentPurple, 25, 230, container);
            CreateStatCard("cardRevenue", "Chiffre d'Affaires", "0 €", StyleHelper.DarkBlue, 270, 230, container);
            CreateStatCard("cardAvgPrice", "Prix Moyen", "0 €", StyleHelper.LightBlue, 515, 230, container);
            CreateStatCard("cardStockValue", "Valeur Stock", "0 €", StyleHelper.AccentGreen, 760, 230, container);

            // Out of Stock Section
            CreateOutOfStockSection(container);

            // Alerts Section
            CreateAlertsSection(container);

            // Recent Activity
            CreateActivitySection(container);

            this.Controls.Add(container);
        }

        private void CreateStatCard(string name, string title, string value, Color color, int x, int y, Panel parent)
        {
            var card = new Panel
            {
                Name = name,
                Location = new Point(x, y),
                Size = new Size(225, 120),
                BackColor = StyleHelper.White
            };

            // Top color bar
            var colorBar = new Panel
            {
                Size = new Size(225, 4),
                Location = new Point(0, 0),
                BackColor = color
            };
            card.Controls.Add(colorBar);

            // Value
            var lblValue = new Label
            {
                Name = "lblValue",
                Text = value,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = true,
                Location = new Point(15, 25)
            };
            card.Controls.Add(lblValue);

            // Title
            var lblTitle = new Label
            {
                Text = title,
                Font = StyleHelper.BodyFont,
                ForeColor = StyleHelper.TextLight,
                AutoSize = true,
                Location = new Point(15, 75)
            };
            card.Controls.Add(lblTitle);

            parent.Controls.Add(card);
        }

        private void CreateOutOfStockSection(Panel parent)
        {
            var outOfStockCard = new Panel
            {
                Location = new Point(25, 370),
                Size = new Size(990, 180),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(outOfStockCard);

            var lblOutOfStockTitle = new Label
            {
                Text = "🔴 Médicaments en Rupture de Stock (Stock = 0)",
                Font = StyleHelper.SubheadingFont,
                ForeColor = Color.FromArgb(139, 0, 0),
                Location = new Point(15, 15),
                AutoSize = true
            };
            outOfStockCard.Controls.Add(lblOutOfStockTitle);

            var dgvOutOfStock = new DataGridView
            {
                Name = "dgvOutOfStock",
                Location = new Point(15, 50),
                Size = new Size(960, 115),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            StyleHelper.StyleDataGridView(dgvOutOfStock);

            dgvOutOfStock.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Référence", DataPropertyName = "Reference", Width = 150 });
            dgvOutOfStock.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nom", DataPropertyName = "Nom", Width = 350 });
            dgvOutOfStock.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date Péremption", DataPropertyName = "DatePeremption", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvOutOfStock.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Prix (€)", DataPropertyName = "PrixUnitaire", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvOutOfStock.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Seuil", DataPropertyName = "Seuil", Width = 100 });

            dgvOutOfStock.RowPrePaint += DgvOutOfStock_RowPrePaint;

            outOfStockCard.Controls.Add(dgvOutOfStock);
            parent.Controls.Add(outOfStockCard);
        }

        private void DgvOutOfStock_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.Rows[e.RowIndex].DataBoundItem is not Medicament med) return;

            // Always red for out of stock
            dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
            dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(139, 0, 0);
        }

        private void CreateAlertsSection(Panel parent)
        {
            var alertsCard = new Panel
            {
                Location = new Point(25, 570),
                Size = new Size(990, 200),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(alertsCard);

            var lblAlertsTitle = new Label
            {
                Text = "⚠ Alertes - Médicaments en Stock Faible",
                Font = StyleHelper.SubheadingFont,
                ForeColor = StyleHelper.AccentOrange,
                Location = new Point(15, 15),
                AutoSize = true
            };
            alertsCard.Controls.Add(lblAlertsTitle);

            var dgvAlerts = new DataGridView
            {
                Name = "dgvAlerts",
                Location = new Point(15, 50),
                Size = new Size(960, 135),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            StyleHelper.StyleDataGridView(dgvAlerts);

            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Référence", DataPropertyName = "Reference", Width = 120 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nom", DataPropertyName = "Nom", Width = 300 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Stock", DataPropertyName = "QuantiteStock", Width = 100 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Seuil", DataPropertyName = "Seuil", Width = 100 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date Péremption", DataPropertyName = "DatePeremption", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Prix (€)", DataPropertyName = "PrixUnitaire", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });

            dgvAlerts.RowPrePaint += DgvAlerts_RowPrePaint;

            alertsCard.Controls.Add(dgvAlerts);
            parent.Controls.Add(alertsCard);
        }

        private void DgvAlerts_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.Rows[e.RowIndex].DataBoundItem is not Medicament med) return;

            // Low stock - yellow (this section only shows low stock, not out of stock)
            if (med.QuantiteStock <= med.Seuil && med.QuantiteStock > 0)
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(133, 100, 4);
            }
        }

        private void CreateActivitySection(Panel parent)
        {
            var activityCard = new Panel
            {
                Location = new Point(25, 790),
                Size = new Size(990, 240),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(activityCard);

            var lblActivityTitle = new Label
            {
                Text = "Activité Récente",
                Font = StyleHelper.SubheadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(15, 15),
                AutoSize = true
            };
            activityCard.Controls.Add(lblActivityTitle);

            var dgv = new DataGridView
            {
                Name = "dgvActivity",
                Location = new Point(15, 50),
                Size = new Size(960, 175),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            StyleHelper.StyleDataGridView(dgv);

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Type", DataPropertyName = "Type", Width = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Description", DataPropertyName = "Description", Width = 450 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "Date", Width = 180 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Montant", DataPropertyName = "Amount", Width = 150 });

            activityCard.Controls.Add(dgv);
            parent.Controls.Add(activityCard);
        }

        private void LoadStatistics()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    UpdateCardValue("cardTotalMed", GetCount(conn, "SELECT COUNT(*) FROM Medicaments"));
                    UpdateCardValue("cardLowStock", GetCount(conn, "SELECT COUNT(*) FROM Medicaments WHERE QuantiteStock <= Seuil"));
                    UpdateCardValue("cardExpiring", GetCount(conn, "SELECT COUNT(*) FROM Medicaments WHERE DatePeremption <= DATEADD(day, 30, GETDATE())"));
                    UpdateCardValue("cardClients", GetCount(conn, "SELECT COUNT(*) FROM Clients"));
                    UpdateCardValue("cardOrders", GetCount(conn, "SELECT COUNT(*) FROM Commandes"));

                    var revenue = GetDecimal(conn, "SELECT ISNULL(SUM(dc.Quantite * m.PrixUnitaire), 0) FROM DetailsCommande dc JOIN Medicaments m ON dc.MedicamentID = m.ID");
                    UpdateCardValue("cardRevenue", $"{revenue:N0} €");

                    var avgPrice = GetDecimal(conn, "SELECT ISNULL(AVG(PrixUnitaire), 0) FROM Medicaments");
                    UpdateCardValue("cardAvgPrice", $"{avgPrice:N2} €");

                    var stockValue = GetDecimal(conn, "SELECT ISNULL(SUM(QuantiteStock * PrixUnitaire), 0) FROM Medicaments");
                    UpdateCardValue("cardStockValue", $"{stockValue:N0} €");

                    var lblUpdate = this.Controls.Find("lblUpdate", true).FirstOrDefault() as Label;
                    if (lblUpdate != null)
                        lblUpdate.Text = $"Dernière mise à jour: {DateTime.Now:HH:mm}";

                    LoadOutOfStock(conn);
                    LoadAlerts(conn);
                    LoadRecentActivity(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOutOfStock(SqlConnection conn)
        {
            try
            {
                var dgvOutOfStock = this.Controls.Find("dgvOutOfStock", true).FirstOrDefault() as DataGridView;
                if (dgvOutOfStock == null) return;

                var query = @"SELECT TOP 5 ID, Reference, Nom, QuantiteStock, Seuil, DatePeremption, PrixUnitaire
                              FROM Medicaments 
                              WHERE QuantiteStock = 0
                              ORDER BY DatePeremption ASC";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var outOfStock = new List<Medicament>();
                    while (reader.Read())
                    {
                        outOfStock.Add(new Medicament
                        {
                            ID = (int)reader["ID"],
                            Reference = reader["Reference"].ToString() ?? "",
                            Nom = reader["Nom"].ToString() ?? "",
                            QuantiteStock = (int)reader["QuantiteStock"],
                            Seuil = (int)reader["Seuil"],
                            DatePeremption = (DateTime)reader["DatePeremption"],
                            PrixUnitaire = (decimal)reader["PrixUnitaire"]
                        });
                    }
                    dgvOutOfStock.DataSource = outOfStock;
                }
            }
            catch { }
        }

        private void LoadAlerts(SqlConnection conn)
        {
            try
            {
                var dgvAlerts = this.Controls.Find("dgvAlerts", true).FirstOrDefault() as DataGridView;
                if (dgvAlerts == null) return;

                var query = @"SELECT TOP 5 ID, Reference, Nom, QuantiteStock, Seuil, DatePeremption, PrixUnitaire
                              FROM Medicaments 
                              WHERE QuantiteStock > 0 AND QuantiteStock <= Seuil
                              ORDER BY QuantiteStock ASC, DatePeremption ASC";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var alerts = new List<Medicament>();
                    while (reader.Read())
                    {
                        alerts.Add(new Medicament
                        {
                            ID = (int)reader["ID"],
                            Reference = reader["Reference"].ToString() ?? "",
                            Nom = reader["Nom"].ToString() ?? "",
                            QuantiteStock = (int)reader["QuantiteStock"],
                            Seuil = (int)reader["Seuil"],
                            DatePeremption = (DateTime)reader["DatePeremption"],
                            PrixUnitaire = (decimal)reader["PrixUnitaire"]
                        });
                    }
                    dgvAlerts.DataSource = alerts;
                }
            }
            catch { }
        }

        private void LoadRecentActivity(SqlConnection conn)
        {
            try
            {
                var query = @"SELECT TOP 5 'Commande' as Type,
                    'Commande #' + CAST(c.ID as VARCHAR) + ' - ' + ISNULL(cl.Nom, 'N/A') as Description,
                    CONVERT(VARCHAR, c.DateCommande, 103) as Date,
                    CAST(ISNULL(SUM(dc.Quantite * m.PrixUnitaire), 0) as DECIMAL(10,2)) as Amount
                    FROM Commandes c
                    LEFT JOIN Clients cl ON c.ClientID = cl.ID
                    LEFT JOIN DetailsCommande dc ON c.ID = dc.CommandeID
                    LEFT JOIN Medicaments m ON dc.MedicamentID = m.ID
                    GROUP BY c.ID, c.DateCommande, cl.Nom
                    ORDER BY c.DateCommande DESC";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var dt = new System.Data.DataTable();
                    dt.Load(reader);

                    var dgv = this.Controls.Find("dgvActivity", true).FirstOrDefault() as DataGridView;
                    if (dgv != null)
                    {
                        dgv.DataSource = dt;
                        if (dgv.Columns["Amount"] != null)
                        {
                            dgv.Columns["Amount"].DefaultCellStyle.Format = "N2";
                            dgv.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
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
            this.Name = "DashboardControl";
            this.Size = new Size(1050, 800);
            this.ResumeLayout(false);
        }
    }
}
