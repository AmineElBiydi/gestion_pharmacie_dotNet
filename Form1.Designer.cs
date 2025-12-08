namespace GestionPharmacie
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainMenuStrip = new MenuStrip();
            menuHome = new ToolStripMenuItem();
            menuMedicaments = new ToolStripMenuItem();
            menuMedGerer = new ToolStripMenuItem();
            menuMedRechercher = new ToolStripMenuItem();
            menuMedAlertes = new ToolStripMenuItem();
            menuCommandes = new ToolStripMenuItem();
            menuCmdDashboard = new ToolStripMenuItem();
            menuCmdNouvelle = new ToolStripMenuItem();
            menuCmdRechercher = new ToolStripMenuItem();
            menuClients = new ToolStripMenuItem();
            menuCliGerer = new ToolStripMenuItem();
            menuCliRechercher = new ToolStripMenuItem();
            menuCompte = new ToolStripMenuItem();
            menuCompteGérer = new ToolStripMenuItem();
            menuCompteLogout = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            statusSpacer = new ToolStripStatusLabel();
            statusDateLabel = new ToolStripStatusLabel();
            contentPanel = new Panel();
            mainMenuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.BackColor = Color.FromArgb(0, 50, 73);
            mainMenuStrip.ImageScalingSize = new Size(20, 20);
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { menuHome, menuMedicaments, menuCommandes, menuClients, menuCompte });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new Padding(11, 7, 11, 7);
            mainMenuStrip.Size = new Size(1200, 41);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
            mainMenuStrip.ItemClicked += mainMenuStrip_ItemClicked;
            // 
            // menuHome
            // 
            menuHome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            menuHome.ForeColor = Color.FromArgb(128, 206, 215);
            menuHome.Name = "menuHome";
            menuHome.Size = new Size(110, 27);
            menuHome.Text = "🏠 Accueil";
            menuHome.Click += MenuHome_Click;
            // 
            // menuMedicaments
            // 
            menuMedicaments.DropDownItems.AddRange(new ToolStripItem[] { menuMedGerer, menuMedRechercher, menuMedAlertes });
            menuMedicaments.Font = new Font("Segoe UI", 10F);
            menuMedicaments.ForeColor = Color.White;
            menuMedicaments.Name = "menuMedicaments";
            menuMedicaments.Size = new Size(154, 27);
            menuMedicaments.Text = "💊 Médicaments";
            menuMedicaments.Click += menuMedicaments_Click;
            // 
            // menuMedGerer
            // 
            menuMedGerer.Name = "menuMedGerer";
            menuMedGerer.Size = new Size(268, 28);
            menuMedGerer.Text = "Gérer les médicaments";
            menuMedGerer.Click += MenuMedGerer_Click;
            // 
            // menuMedRechercher
            // 
            menuMedRechercher.Name = "menuMedRechercher";
            menuMedRechercher.Size = new Size(268, 28);
            menuMedRechercher.Text = "Rechercher";
            menuMedRechercher.Click += MenuMedRechercher_Click;
            // 
            // menuMedAlertes
            // 
            menuMedAlertes.Name = "menuMedAlertes";
            menuMedAlertes.Size = new Size(268, 28);
            menuMedAlertes.Text = "Alertes de péremption";
            menuMedAlertes.Click += MenuMedAlertes_Click;
            // 
            // menuCommandes
            // 
            menuCommandes.DropDownItems.AddRange(new ToolStripItem[] { menuCmdDashboard, menuCmdNouvelle, menuCmdRechercher });
            menuCommandes.Font = new Font("Segoe UI", 10F);
            menuCommandes.ForeColor = Color.White;
            menuCommandes.Name = "menuCommandes";
            menuCommandes.Size = new Size(148, 27);
            menuCommandes.Text = "📦 Commandes";
            // 
            // menuCmdDashboard
            // 
            menuCmdDashboard.Name = "menuCmdDashboard";
            menuCmdDashboard.Size = new Size(277, 28);
            menuCmdDashboard.Text = "Tableau de bord";
            menuCmdDashboard.Click += MenuCmdDashboard_Click;
            // 
            // menuCmdNouvelle
            // 
            menuCmdNouvelle.Name = "menuCmdNouvelle";
            menuCmdNouvelle.Size = new Size(277, 28);
            menuCmdNouvelle.Text = "Nouvelle commande";
            menuCmdNouvelle.Click += MenuCmdNouvelle_Click;
            // 
            // menuCmdRechercher
            // 
            menuCmdRechercher.Name = "menuCmdRechercher";
            menuCmdRechercher.Size = new Size(277, 28);
            menuCmdRechercher.Text = "Rechercher commandes";
            menuCmdRechercher.Click += MenuCmdRechercher_Click;
            // 
            // menuClients
            // 
            menuClients.DropDownItems.AddRange(new ToolStripItem[] { menuCliGerer, menuCliRechercher });
            menuClients.Font = new Font("Segoe UI", 10F);
            menuClients.ForeColor = Color.White;
            menuClients.Name = "menuClients";
            menuClients.Size = new Size(103, 27);
            menuClients.Text = "👥 Clients";
            // 
            // menuCliGerer
            // 
            menuCliGerer.Name = "menuCliGerer";
            menuCliGerer.Size = new Size(232, 28);
            menuCliGerer.Text = "Gérer les clients";
            menuCliGerer.Click += MenuCliGerer_Click;
            // 
            // menuCliRechercher
            // 
            menuCliRechercher.Name = "menuCliRechercher";
            menuCliRechercher.Size = new Size(232, 28);
            menuCliRechercher.Text = "Rechercher clients";
            menuCliRechercher.Click += MenuCliRechercher_Click;
            // 
            // 
            // menuCompte
            // 
            menuCompte.DropDownItems.AddRange(new ToolStripItem[] { menuCompteGérer, menuCompteLogout });
            menuCompte.Font = new Font("Segoe UI", 10F);
            menuCompte.ForeColor = Color.White;
            menuCompte.Name = "menuCompte";
            menuCompte.Size = new Size(113, 27);
            menuCompte.Text = "⚙️ Compte";
            menuCompte.Click += menuCompte_Click_1;
            // 
            // menuCompteGérer
            // 
            menuCompteGérer.Name = "menuCompteGérer";
            menuCompteGérer.Size = new Size(248, 28);
            menuCompteGérer.Text = "Gérer les utilisateurs";
            menuCompteGérer.Click += MenuCompteGérer_Click;
            // 
            // menuCompteLogout
            // 
            menuCompteLogout.Name = "menuCompteLogout";
            menuCompteLogout.Size = new Size(248, 28);
            menuCompteLogout.Text = "Déconnexion";
            menuCompteLogout.Click += MenuCompteLogout_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(0, 50, 73);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, statusSpacer, statusDateLabel });
            statusStrip.Location = new Point(0, 720);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(6, 7, 6, 7);
            statusStrip.Size = new Size(1200, 40);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Font = new Font("Segoe UI", 9F);
            statusLabel.ForeColor = Color.FromArgb(128, 206, 215);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(101, 20);
            statusLabel.Text = "👤 Utilisateur";
            // 
            // statusSpacer
            // 
            statusSpacer.Name = "statusSpacer";
            statusSpacer.Size = new Size(1087, 20);
            statusSpacer.Spring = true;
            // 
            // statusDateLabel
            // 
            statusDateLabel.ForeColor = Color.FromArgb(154, 209, 212);
            statusDateLabel.Name = "statusDateLabel";
            statusDateLabel.Size = new Size(0, 20);
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(245, 245, 245);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 41);
            contentPanel.Margin = new Padding(0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1200, 679);
            contentPanel.TabIndex = 2;
            contentPanel.Paint += contentPanel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1200, 760);
            Controls.Add(contentPanel);
            Controls.Add(statusStrip);
            Controls.Add(mainMenuStrip);
            MainMenuStrip = mainMenuStrip;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion Pharmacie - Système de Gestion";
            Load += Form1_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuHome;
        private System.Windows.Forms.ToolStripMenuItem menuMedicaments;
        private System.Windows.Forms.ToolStripMenuItem menuMedGerer;
        private System.Windows.Forms.ToolStripMenuItem menuMedRechercher;
        private System.Windows.Forms.ToolStripMenuItem menuMedAlertes;
        private System.Windows.Forms.ToolStripMenuItem menuCommandes;
        private System.Windows.Forms.ToolStripMenuItem menuCmdDashboard;
        private System.Windows.Forms.ToolStripMenuItem menuCmdNouvelle;
        private System.Windows.Forms.ToolStripMenuItem menuCmdRechercher;
        private System.Windows.Forms.ToolStripMenuItem menuClients;
        private System.Windows.Forms.ToolStripMenuItem menuCliGerer;
        private System.Windows.Forms.ToolStripMenuItem menuCliRechercher;
        private System.Windows.Forms.ToolStripMenuItem menuStatistiques;
        private System.Windows.Forms.ToolStripMenuItem menuStatTableau;
        private System.Windows.Forms.ToolStripMenuItem menuCompte;
        private System.Windows.Forms.ToolStripMenuItem menuCompteGérer;
        private System.Windows.Forms.ToolStripMenuItem menuCompteLogout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusSpacer;
        private System.Windows.Forms.ToolStripStatusLabel statusDateLabel;
        private System.Windows.Forms.Panel contentPanel;
    }
}
