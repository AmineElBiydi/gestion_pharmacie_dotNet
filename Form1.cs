using GestionPharmacie.Forms;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;
using System.Data.SqlClient;
using GestionPharmacie.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionPharmacie;

public partial class Form1 : Form
{
    private System.Windows.Forms.Timer refreshTimer = null!;

    public Form1()
    {
        InitializeComponent();
        StyleHelper.ApplyFormTheme(this);
        this.WindowState = FormWindowState.Maximized;
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        if (Session.CurrentUser != null)
        {
            statusLabel.Text = $"👤 {Session.CurrentUser.FullName} ({Session.CurrentUser.Role})";
        }
        statusDateLabel.Text = "🕒 " + DateTime.Now.ToString("dd MMMM yyyy - HH:mm");
        LoadDashboard();
    }

    private void LoadDashboard()
    {
        ClearContentPanel();
        StyleHelper.ApplyGradientBackground(contentPanel);
        CreateDashboard();
        LoadStatistics();

        refreshTimer?.Stop();
        refreshTimer?.Dispose();
        refreshTimer = new System.Windows.Forms.Timer { Interval = 30000 };
        refreshTimer.Tick += (s, e) => LoadStatistics();
        refreshTimer.Start();
    }

    private void ClearContentPanel()
    {
        refreshTimer?.Stop();
        refreshTimer?.Dispose();

        while (contentPanel.Controls.Count > 0)
        {
            var oldControl = contentPanel.Controls[0];
            contentPanel.Controls.RemoveAt(0);
            oldControl.Dispose();
        }
    }

    private void MenuHome_Click(object? sender, EventArgs e) => LoadDashboard();
    private void MenuMedGerer_Click(object? sender, EventArgs e) => new MedicamentForm().ShowDialog();
    private void MenuMedRechercher_Click(object? sender, EventArgs e) => new MedicamentSearchForm().ShowDialog();
    private void MenuMedAlertes_Click(object? sender, EventArgs e) => new MedicamentAlertForm().ShowDialog();
    private void MenuCmdDashboard_Click(object? sender, EventArgs e) => new CommandeDashboardForm().ShowDialog();
    private void MenuCmdNouvelle_Click(object? sender, EventArgs e) => new CommandeForm().ShowDialog();
    private void MenuCmdRechercher_Click(object? sender, EventArgs e) => new CommandeSearchForm().ShowDialog();
    private void MenuCliGerer_Click(object? sender, EventArgs e) => new ClientForm().ShowDialog();
    private void MenuCliRechercher_Click(object? sender, EventArgs e) => new ClientSearchForm().ShowDialog();
    private void MenuStatTableau_Click(object? sender, EventArgs e) => LoadDashboard();
    private void MenuCompteGérer_Click(object? sender, EventArgs e) => new UserManagementForm().ShowDialog();

    private void MenuCompteLogout_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("Voulez-vous vraiment vous déconnecter?",
            "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            Session.Logout();
            this.Close();
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }
    }

    private void menuCompte_Click(object sender, EventArgs e) { }
    private void menuStatistiques_Click(object sender, EventArgs e) { }

    #region Dashboard Methods

    private FlowLayoutPanel topStatsPanel;
    private Panel lowStockPanel;
    private Panel recentActivityPanel;
    private Panel quickActionsPanel;
    private Panel chartPanel;

    private void CreateDashboard()
    {
        contentPanel.Controls.Clear();
        contentPanel.BackColor = Color.FromArgb(245, 247, 250);

        var dashboardFlowPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            AutoScroll = true,
            WrapContents = false,
            Padding = new Padding(20)
        };

        // Header
        var headerPanel = new Panel { Size = new Size(1100, 80), Margin = new Padding(0, 0, 0, 20) };
        var lblTitle = new Label
        {
            Text = "Tableau de Bord",
            Font = StyleHelper.HeadingFont,
            ForeColor = StyleHelper.PrimaryBlue,
            Location = new Point(0, 10),
            AutoSize = true
        };
        var lblUpdate = new Label
        {
            Text = $"Dernière mise à jour: {DateTime.Now:HH:mm}",
            Font = StyleHelper.SmallFont,
            ForeColor = StyleHelper.TextLight,
            Location = new Point(0, 50),
            AutoSize = true,
            Name = "lblUpdate"
        };
        headerPanel.Controls.Add(lblTitle);
        headerPanel.Controls.Add(lblUpdate);
        dashboardFlowPanel.Controls.Add(headerPanel);

        // Quick Actions
        CreateQuickActionsSection();
        dashboardFlowPanel.Controls.Add(quickActionsPanel);

        // Top stats panel - FIXED: Added proper sizing
        // Top stats panel - FIXED: Added proper sizing
        topStatsPanel = new FlowLayoutPanel
        {
            Width = 1100,
            Height = 320,
            AutoSize = false,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            Padding = new Padding(0),
            Margin = new Padding(0, 0, 0, 20),
            BackColor = Color.Transparent
        };
        dashboardFlowPanel.Controls.Add(topStatsPanel);

        // Chart Section
        CreateChartSection();
        dashboardFlowPanel.Controls.Add(chartPanel);

        // Low stock panel
        lowStockPanel = new Panel
        {
            Size = new Size(1100, 300),
            BackColor = Color.White,
            Margin = new Padding(0, 0, 0, 20)
        };
        dashboardFlowPanel.Controls.Add(lowStockPanel);

        // Recent activity panel
        recentActivityPanel = new Panel
        {
            Size = new Size(1100, 300),
            BackColor = Color.White,
            Margin = new Padding(0, 0, 0, 20)
        };
        dashboardFlowPanel.Controls.Add(recentActivityPanel);

        contentPanel.Controls.Add(dashboardFlowPanel);
    }

    private void CreateQuickActionsSection()
    {
        quickActionsPanel = new Panel
        {
            Size = new Size(1100, 80),
            Margin = new Padding(0, 0, 0, 20),
            BackColor = Color.Transparent
        };

        var btnNewCmd = CreateQuickActionButton("Nouvelle Commande", StyleHelper.PrimaryBlue, (s, e) => MenuCmdNouvelle_Click(s, e));
        btnNewCmd.Location = new Point(0, 0);

        var btnNewClient = CreateQuickActionButton("Nouveau Client", StyleHelper.AccentGreen, (s, e) => MenuCliGerer_Click(s, e));
        btnNewClient.Location = new Point(220, 0);

        var btnNewMed = CreateQuickActionButton("Nouveau Médicament", StyleHelper.AccentPurple, (s, e) => MenuMedGerer_Click(s, e));
        btnNewMed.Location = new Point(440, 0);

        quickActionsPanel.Controls.Add(btnNewCmd);
        quickActionsPanel.Controls.Add(btnNewClient);
        quickActionsPanel.Controls.Add(btnNewMed);
    }

    private Button CreateQuickActionButton(string text, Color color, EventHandler onClick)
    {
        var btn = new Button
        {
            Text = text,
            Size = new Size(200, 50),
            BackColor = color,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btn.FlatAppearance.BorderSize = 0;
        btn.Click += onClick;

        btn.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, btn.Width, btn.Height);
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int radius = 20;
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                btn.Region = new Region(path);
            }
        };

        return btn;
    }

    private void CreateChartSection()
    {
        chartPanel = new Panel
        {
            Size = new Size(1100, 350),
            BackColor = Color.White,
            Margin = new Padding(0, 0, 0, 20)
        };
        StyleHelper.StyleCardPanel(chartPanel);

        var lblChartTitle = new Label
        {
            Text = "Chiffre d'Affaires (7 derniers jours)",
            Font = StyleHelper.SubheadingFont,
            ForeColor = StyleHelper.PrimaryBlue,
            Location = new Point(20, 15),
            AutoSize = true
        };
        chartPanel.Controls.Add(lblChartTitle);

        var chart = new Chart
        {
            Name = "revenueChart",
            Location = new Point(20, 50),
            Size = new Size(1060, 280),
            BackColor = Color.White,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
        };

        var area = new ChartArea("MainArea");
        area.BackColor = Color.White;
        area.AxisX.MajorGrid.LineColor = Color.LightGray;
        area.AxisY.MajorGrid.LineColor = Color.LightGray;
        area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
        area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
        area.AxisX.LineColor = Color.Gray;
        area.AxisY.LineColor = Color.Gray;
        chart.ChartAreas.Add(area);

        var series = new Series("Revenue");
        series.ChartType = SeriesChartType.SplineArea;
        series.Color = Color.FromArgb(100, StyleHelper.PrimaryBlue);
        series.BorderColor = StyleHelper.PrimaryBlue;
        series.BorderWidth = 3;
        series.IsValueShownAsLabel = false;
        chart.Series.Add(series);

        // Add legend
        var legend = new Legend("Legend");
        legend.Enabled = false;
        chart.Legends.Add(legend);

        chartPanel.Controls.Add(chart);
    }

    private void LoadStatistics()
    {
        try
        {
            topStatsPanel.Controls.Clear();

            var totalMedicaments = GetTotalMedicaments();
            var lowStock = GetLowStockCount();
            var expirationProche = GetExpirationProcheCount();
            var totalClients = GetTotalClients();
            var totalOrders = GetTotalOrders();
            var totalRevenue = GetTotalRevenue();
            var avgOrder = totalOrders > 0 ? totalRevenue / totalOrders : 0;
            var stockValue = GetStockValue();

            // FIXED: Create metric cards with proper sizing
            topStatsPanel.Controls.Add(CreateMetricCard(totalMedicaments.ToString(), "Médicaments", Color.FromArgb(0, 123, 255)));
            topStatsPanel.Controls.Add(CreateMetricCard(lowStock.ToString(), "Stock Faible", Color.FromArgb(255, 193, 7)));
            topStatsPanel.Controls.Add(CreateMetricCard(expirationProche.ToString(), "Péremption Proche", Color.FromArgb(255, 105, 180)));
            topStatsPanel.Controls.Add(CreateMetricCard(totalClients.ToString(), "Clients", Color.FromArgb(32, 201, 151)));

            topStatsPanel.Controls.Add(CreateMetricCard(totalOrders.ToString(), "Commandes Total", Color.FromArgb(156, 39, 176)));
            topStatsPanel.Controls.Add(CreateMetricCard($"{totalRevenue:N0} DH", "Chiffre d'Affaires", Color.FromArgb(0, 123, 255)));
            topStatsPanel.Controls.Add(CreateMetricCard($"{avgOrder:N2} DH", "Prix Moyen", Color.FromArgb(255, 193, 7)));
            topStatsPanel.Controls.Add(CreateMetricCard($"{stockValue:N0} DH", "Valeur Stock", Color.FromArgb(32, 201, 151)));

            var lblUpdate = contentPanel.Controls.Find("lblUpdate", true).FirstOrDefault() as Label;
            if (lblUpdate != null)
                lblUpdate.Text = $"Dernière mise à jour: {DateTime.Now:HH:mm}";

            LoadLowStockMedicines();
            LoadRecentActivity();
            LoadChartData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadChartData()
    {
        try
        {
            var chart = chartPanel.Controls.Find("revenueChart", true).FirstOrDefault() as Chart;
            if (chart == null) return;

            var series = chart.Series["Revenue"];
            series.Points.Clear();

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var query = @"
                    SELECT CAST(DateCommande AS DATE) as Date, SUM(MontantTotal) as Total
                    FROM Commandes
                    WHERE DateCommande >= DATEADD(day, -6, CAST(GETDATE() AS DATE))
                    GROUP BY CAST(DateCommande AS DATE)
                    ORDER BY Date";

                var dataPoints = new Dictionary<DateTime, decimal>();
                
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var date = (DateTime)reader["Date"];
                        var total = (decimal)reader["Total"];
                        dataPoints[date] = total;
                    }
                }

                // Generate points for all 7 days (including today)
                for (int i = 6; i >= 0; i--)
                {
                    var date = DateTime.Now.Date.AddDays(-i);
                    var value = dataPoints.ContainsKey(date) ? (double)dataPoints[date] : 0;
                    series.Points.AddXY(date.ToString("dd/MM"), value);
                }

                // Format Y-axis
                chart.ChartAreas[0].AxisY.LabelStyle.Format = "0 DH";
                chart.ChartAreas[0].AxisY.Minimum = 0;
                
                // If we have data, set a nice max value
                if (dataPoints.Any())
                {
                    var maxValue = dataPoints.Values.Max();
                    chart.ChartAreas[0].AxisY.Maximum = (double)(maxValue * 1.2m); // 20% padding
                }

                chart.Invalidate();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Chart Error: {ex.Message}");
        }
    }

    private Panel CreateMetricCard(string value, string label, Color color)
    {
        var card = new Panel
        {
            Width = 260,
            Height = 160,
            MinimumSize = new Size(260, 140),
            MaximumSize = new Size(260, 140),
            Margin = new Padding(0, 0, 15, 15),
            BackColor = Color.White,
            Cursor = Cursors.Hand
        };

        StyleHelper.StyleCardPanel(card, 12);

        // Left accent border
        var accentBar = new Panel
        {
            Size = new Size(6, 100),
            BackColor = color,
            Location = new Point(0, 20)
        };
        
        accentBar.Paint += (s, e) =>
        {
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int r = 3;
                path.AddArc(0, 0, r * 2, r * 2, 180, 90);
                path.AddLine(r, 0, accentBar.Width - r, 0);
                path.AddArc(accentBar.Width - r * 2, 0, r * 2, r * 2, 270, 90);
                path.AddLine(accentBar.Width, r, accentBar.Width, accentBar.Height - r);
                path.AddArc(accentBar.Width - r * 2, accentBar.Height - r * 2, r * 2, r * 2, 0, 90);
                path.AddLine(accentBar.Width - r, accentBar.Height, r, accentBar.Height);
                path.AddArc(0, accentBar.Height - r * 2, r * 2, r * 2, 90, 90);
                path.CloseFigure();
                accentBar.Region = new Region(path);
            }
        };

        var valueLabel = new Label
        {
            Text = value,
            Font = new Font("Segoe UI", 22, FontStyle.Bold),
            ForeColor = StyleHelper.TextDark,
            Location = new Point(25, 30),
            Size = new Size(220, 45),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var titleLabel = new Label
        {
            Text = label.ToUpper(),
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            ForeColor = StyleHelper.TextLight,
            Location = new Point(28, 90),
            AutoSize = true
        };

        // Icon circle
        var iconCircle = new Panel
        {
            Size = new Size(50, 50),
            Location = new Point(190, 20),
            BackColor = Color.Transparent
        };

        iconCircle.Paint += (s, e) =>
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(Color.FromArgb(20, color)))
            {
                e.Graphics.FillEllipse(brush, 0, 0, 48, 48);
            }
        };

        card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(252, 252, 252);
        card.MouseLeave += (s, e) => card.BackColor = Color.White;

        card.Controls.Add(accentBar);
        card.Controls.Add(valueLabel);
        card.Controls.Add(titleLabel);
        card.Controls.Add(iconCircle);

        return card;
    }

    private void LoadLowStockMedicines()
    {
        lowStockPanel.Controls.Clear();
        lowStockPanel.BackColor = Color.White;
        lowStockPanel.Padding = new Padding(0);

        lowStockPanel.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var shadowBrush = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
            {
                g.FillRectangle(shadowBrush, 2, 2, lowStockPanel.Width - 2, lowStockPanel.Height - 2);
            }
            using (var borderPen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, lowStockPanel.Width - 1, lowStockPanel.Height - 1);
            }
        };

        var titlePanel = new Panel
        {
            Size = new Size(1100, 50),
            BackColor = Color.FromArgb(255, 243, 205),
            Dock = DockStyle.Top,
            Padding = new Padding(20, 0, 20, 0)
        };

        var iconLabel = new Label
        {
            Text = "⚠",
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            ForeColor = Color.FromArgb(255, 193, 7),
            Location = new Point(20, 10),
            AutoSize = true
        };

        var titleLabel = new Label
        {
            Text = "Médicaments en Rupture de Stock (Top 5)",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.FromArgb(102, 60, 0),
            Location = new Point(55, 13),
            AutoSize = true
        };

        titlePanel.Controls.Add(iconLabel);
        titlePanel.Controls.Add(titleLabel);
        lowStockPanel.Controls.Add(titlePanel);

        var grid = new DataGridView
        {
            Location = new Point(0, 50),
            Size = new Size(1100, 250),
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            RowHeadersVisible = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            RowTemplate = { Height = 35 },
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
            GridColor = Color.FromArgb(240, 240, 240)
        };

        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
        grid.ColumnHeadersHeight = 40;
        grid.EnableHeadersVisualStyles = false;

        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 235, 238);
        grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(52, 58, 64);
        grid.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
        grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);

        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 252, 252);

        grid.Columns.Add("Reference", "Référence");
        grid.Columns.Add("Nom", "Nom");
        grid.Columns.Add("DatePeremption", "Date Péremption");
        grid.Columns.Add("Seuil", "Seuil");

        grid.Columns[0].Width = 150;
        grid.Columns[2].Width = 180;
        grid.Columns[3].Width = 100;

        LoadLowStockData(grid);
        lowStockPanel.Controls.Add(grid);
    }

    private void LoadLowStockData(DataGridView grid)
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            var cmd = new SqlCommand(
                @"SELECT TOP 5 Reference, Nom, DatePeremption, Seuil 
                  FROM Medicaments 
                  WHERE QuantiteStock = 0
                  ORDER BY DatePeremption", conn);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var datePeremption = reader["DatePeremption"] != DBNull.Value
                        ? Convert.ToDateTime(reader["DatePeremption"]).ToString("dd/MM/yyyy")
                        : "";

                    grid.Rows.Add(
                        reader["Reference"],
                        reader["Nom"],
                        datePeremption,
                        reader["Seuil"]
                    );
                }
            }
        }
    }

    private void LoadRecentActivity()
    {
        recentActivityPanel.Controls.Clear();
        recentActivityPanel.BackColor = Color.White;
        recentActivityPanel.Padding = new Padding(0);

        recentActivityPanel.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var shadowBrush = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
            {
                g.FillRectangle(shadowBrush, 2, 2, recentActivityPanel.Width - 2, recentActivityPanel.Height - 2);
            }
            using (var borderPen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, recentActivityPanel.Width - 1, recentActivityPanel.Height - 1);
            }
        };

        var titlePanel = new Panel
        {
            Size = new Size(1100, 50),
            BackColor = Color.FromArgb(232, 244, 253),
            Dock = DockStyle.Top,
            Padding = new Padding(20, 0, 20, 0)
        };

        var iconLabel = new Label
        {
            Text = "📊",
            Font = new Font("Segoe UI", 16, FontStyle.Regular),
            Location = new Point(20, 12),
            AutoSize = true
        };

        var titleLabel = new Label
        {
            Text = "Activité Récente",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.FromArgb(13, 71, 161),
            Location = new Point(55, 14),
            AutoSize = true
        };

        titlePanel.Controls.Add(iconLabel);
        titlePanel.Controls.Add(titleLabel);
        recentActivityPanel.Controls.Add(titlePanel);

        var grid = new DataGridView
        {
            Location = new Point(0, 50),
            Size = new Size(1100, 250),
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            RowHeadersVisible = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            RowTemplate = { Height = 35 },
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
            GridColor = Color.FromArgb(240, 240, 240)
        };

        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
        grid.ColumnHeadersHeight = 40;
        grid.EnableHeadersVisualStyles = false;

        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(227, 242, 253);
        grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(52, 58, 64);
        grid.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
        grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);

        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 252, 252);

        grid.Columns.Add("Type", "Type");
        grid.Columns.Add("Description", "Description");
        grid.Columns.Add("Date", "Date");
        grid.Columns.Add("Montant", "Montant");

        grid.Columns[0].Width = 120;
        grid.Columns[2].Width = 150;
        grid.Columns[3].Width = 120;

        LoadRecentActivityData(grid);
        recentActivityPanel.Controls.Add(grid);
    }

    private void LoadRecentActivityData(DataGridView grid)
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            var cmd = new SqlCommand(
                @"SELECT TOP 10 
                    'Commande' as Type,
                    'Commande #' + CAST(c.ID as VARCHAR) + ' - ' + cl.Nom as Description,
                    c.DateCommande as Date,
                    c.MontantTotal as Montant
                  FROM Commandes c
                  INNER JOIN Clients cl ON c.ClientID = cl.ID
                  ORDER BY c.DateCommande DESC", conn);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    grid.Rows.Add(
                        reader["Type"],
                        reader["Description"],
                        Convert.ToDateTime(reader["Date"]).ToString("dd/MM/yyyy"),
                        $"{Convert.ToDecimal(reader["Montant"]):N2} DH"
                    );
                }
            }
        }
    }

    // Statistics methods
    private int GetTotalMedicaments()
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Medicaments", conn);
            return (int)cmd.ExecuteScalar();
        }
    }

    private int GetLowStockCount()
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Medicaments WHERE QuantiteStock <= Seuil", conn);
            return (int)cmd.ExecuteScalar();
        }
    }

    private int GetExpirationProcheCount()
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Medicaments WHERE DatePeremption <= DATEADD(MONTH, 3, GETDATE())", conn);
            return (int)cmd.ExecuteScalar();
        }
    }

    private int GetTotalClients()
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Clients", conn);
            return (int)cmd.ExecuteScalar();
        }
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

    private decimal GetStockValue()
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT ISNULL(SUM(QuantiteStock * PrixUnitaire), 0) FROM Medicaments", conn);
            return (decimal)cmd.ExecuteScalar();
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

    #endregion

    private void contentPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void mainMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void menuCompte_Click_1(object sender, EventArgs e)
    {

    }

    private void menuMedicaments_Click(object sender, EventArgs e)
    {

    }
}
