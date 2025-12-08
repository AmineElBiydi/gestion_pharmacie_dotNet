using System.Data.SqlClient;
using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class CommandeDashboardForm : Form
    {
        private readonly CommandeRepository _commandeRepo = new();
        private System.Windows.Forms.Timer refreshTimer = null!;

        public CommandeDashboardForm()
        {
            InitializeComponent();
            CreateDashboard();
            StyleHelper.ApplyFormTheme(this);
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

            // Main container
            var container = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1200, 900),
                BackColor = StyleHelper.LightGray,
                AutoScroll = false,
                Dock = DockStyle.Fill
            };

            // Header
            var lblTitle = new Label
            {
                Text = "Tableau de Bord - Commandes",
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

            // Navigation Buttons
            var navPanel = new Panel
            {
                Location = new Point(25, 90),
                Size = new Size(1150, 60),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(navPanel);

            var btnNew = new Button
            {
                Text = "➕ Nouvelle Commande",
                Location = new Point(20, 15),
                Size = new Size(200, 35)
            };
            StyleHelper.StyleButton(btnNew, StyleHelper.AccentGreen);
            btnNew.Click += BtnNew_Click;

            var btnSearch = new Button
            {
                Text = "🔍 Rechercher",
                Location = new Point(240, 15),
                Size = new Size(200, 35)
            };
            StyleHelper.StyleButton(btnSearch);
            btnSearch.Click += BtnSearch_Click;

            var btnModify = new Button
            {
                Text = "✏️ Modifier",
                Location = new Point(460, 15),
                Size = new Size(200, 35)
            };
            StyleHelper.StyleButton(btnModify, StyleHelper.AccentOrange);
            btnModify.Click += BtnModify_Click;

            navPanel.Controls.AddRange(new Control[] { btnNew, btnSearch, btnModify });
            container.Controls.Add(navPanel);

            // Statistics Cards Row 1
            CreateStatCard("cardTotalCmd", "Total Commandes", "0", StyleHelper.PrimaryBlue, 25, 170, container);
            CreateStatCard("cardCmdToday", "Commandes Aujourd'hui", "0", StyleHelper.AccentGreen, 270, 170, container);
            CreateStatCard("cardCmdMonth", "Commandes ce Mois", "0", StyleHelper.AccentPurple, 515, 170, container);
            CreateStatCard("cardRevenue", "Chiffre d'Affaires", "0 €", StyleHelper.DarkBlue, 760, 170, container);

            // Statistics Cards Row 2
            CreateStatCard("cardPending", "En Attente", "0", StyleHelper.AccentOrange, 25, 310, container);
            CreateStatCard("cardDelivered", "Livrées", "0", StyleHelper.AccentGreen, 270, 310, container);
            CreateStatCard("cardCancelled", "Annulées", "0", StyleHelper.AccentRed, 515, 310, container);
            CreateStatCard("cardUnpaid", "Non Payées", "0", StyleHelper.AccentRed, 760, 310, container);

            // Recent Commandes
            CreateRecentCommandesSection(container);

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

        private void CreateRecentCommandesSection(Panel parent)
        {
            var recentCard = new Panel
            {
                Location = new Point(25, 450),
                Size = new Size(1150, 400),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(recentCard);

            var lblRecentTitle = new Label
            {
                Text = "Commandes Récentes",
                Font = StyleHelper.SubheadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(15, 15),
                AutoSize = true
            };
            recentCard.Controls.Add(lblRecentTitle);

            var dgv = new DataGridView
            {
                Name = "dgvRecent",
                Location = new Point(15, 50),
                Size = new Size(1120, 330),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            StyleHelper.StyleDataGridView(dgv);

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "N°", DataPropertyName = "ID", Width = 80 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "DateCommande", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Client", DataPropertyName = "ClientNom", Width = 250 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Montant (€)", DataPropertyName = "MontantTotal", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Statut", DataPropertyName = "Statut", Width = 100 });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Payé", DataPropertyName = "EstPaye", Width = 80 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Type Paiement", DataPropertyName = "TypePaiement", Width = 150 });

            recentCard.Controls.Add(dgv);
            parent.Controls.Add(recentCard);
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
                    UpdateCardValue("cardRevenue", $"{revenue:N0} €");

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
    }
}