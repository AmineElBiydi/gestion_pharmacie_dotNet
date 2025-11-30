namespace GestionPharmacie.Forms
{
    partial class CommandeSearchForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.searchPanel = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearchClient = new System.Windows.Forms.Button();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.btnSearchDate = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvCommandes = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCommande = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontantTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrint = new System.Windows.Forms.DataGridViewButtonColumn();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).BeginInit();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.btnShowAll);
            this.searchPanel.Controls.Add(this.btnSearchClient);
            this.searchPanel.Controls.Add(this.cboClient);
            this.searchPanel.Controls.Add(this.lblClient);
            this.searchPanel.Controls.Add(this.btnSearchDate);
            this.searchPanel.Controls.Add(this.dtpEndDate);
            this.searchPanel.Controls.Add(this.lblEndDate);
            this.searchPanel.Controls.Add(this.dtpStartDate);
            this.searchPanel.Controls.Add(this.lblStartDate);
            this.searchPanel.Controls.Add(this.lblSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(10);
            this.searchPanel.Size = new System.Drawing.Size(1000, 100);
            this.searchPanel.TabIndex = 0;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(720, 50);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(120, 30);
            this.btnShowAll.TabIndex = 9;
            this.btnShowAll.Text = "Afficher Tout";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.BtnShowAll_Click);
            // 
            // btnSearchClient
            // 
            this.btnSearchClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.btnSearchClient.FlatAppearance.BorderSize = 0;
            this.btnSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchClient.ForeColor = System.Drawing.Color.White;
            this.btnSearchClient.Location = new System.Drawing.Point(390, 65);
            this.btnSearchClient.Name = "btnSearchClient";
            this.btnSearchClient.Size = new System.Drawing.Size(150, 28);
            this.btnSearchClient.TabIndex = 8;
            this.btnSearchClient.Text = "Rechercher par Client";
            this.btnSearchClient.UseVisualStyleBackColor = false;
            this.btnSearchClient.Click += new System.EventHandler(this.BtnSearchClient_Click);
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(120, 67);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(250, 23);
            this.cboClient.TabIndex = 7;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(20, 70);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(41, 15);
            this.lblClient.TabIndex = 6;
            this.lblClient.Text = "Client:";
            // 
            // btnSearchDate
            // 
            this.btnSearchDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.btnSearchDate.FlatAppearance.BorderSize = 0;
            this.btnSearchDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDate.ForeColor = System.Drawing.Color.White;
            this.btnSearchDate.Location = new System.Drawing.Point(550, 35);
            this.btnSearchDate.Name = "btnSearchDate";
            this.btnSearchDate.Size = new System.Drawing.Size(150, 28);
            this.btnSearchDate.TabIndex = 5;
            this.btnSearchDate.Text = "Rechercher par Date";
            this.btnSearchDate.UseVisualStyleBackColor = false;
            this.btnSearchDate.Click += new System.EventHandler(this.BtnSearchDate_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(380, 37);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 23);
            this.dtpEndDate.TabIndex = 4;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(300, 40);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(60, 15);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "Date Fin:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(120, 37);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 23);
            this.dtpStartDate.TabIndex = 2;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(20, 40);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(72, 15);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Date Début:";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(20, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(125, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Rechercher par:";
            // 
            // dgvCommandes
            // 
            this.dgvCommandes.AllowUserToAddRows = false;
            this.dgvCommandes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommandes.BackgroundColor = System.Drawing.Color.White;
            this.dgvCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colDateCommande,
            this.colClientNom,
            this.colMontantTotal,
            this.colStatut,
            this.colPrint});
            this.dgvCommandes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommandes.Location = new System.Drawing.Point(0, 100);
            this.dgvCommandes.MultiSelect = false;
            this.dgvCommandes.Name = "dgvCommandes";
            this.dgvCommandes.ReadOnly = true;
            this.dgvCommandes.RowTemplate.Height = 25;
            this.dgvCommandes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommandes.Size = new System.Drawing.Size(1000, 500);
            this.dgvCommandes.TabIndex = 1;
            this.dgvCommandes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCommandes_CellClick);
            this.dgvCommandes.SelectionChanged += new System.EventHandler(this.DgvCommandes_SelectionChanged);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "N° Cmd";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 80;
            // 
            // colDateCommande
            // 
            this.colDateCommande.DataPropertyName = "DateCommande";
            this.colDateCommande.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            this.colDateCommande.HeaderText = "Date";
            this.colDateCommande.Name = "colDateCommande";
            this.colDateCommande.ReadOnly = true;
            this.colDateCommande.Width = 150;
            // 
            // colClientNom
            // 
            this.colClientNom.DataPropertyName = "ClientNom";
            this.colClientNom.HeaderText = "Client";
            this.colClientNom.Name = "colClientNom";
            this.colClientNom.ReadOnly = true;
            this.colClientNom.Width = 200;
            // 
            // colMontantTotal
            // 
            this.colMontantTotal.DataPropertyName = "MontantTotal";
            this.colMontantTotal.DefaultCellStyle.Format = "N2";
            this.colMontantTotal.HeaderText = "Montant Total (€)";
            this.colMontantTotal.Name = "colMontantTotal";
            this.colMontantTotal.ReadOnly = true;
            this.colMontantTotal.Width = 120;
            // 
            // colStatut
            // 
            this.colStatut.DataPropertyName = "Statut";
            this.colStatut.HeaderText = "Statut";
            this.colStatut.Name = "colStatut";
            this.colStatut.ReadOnly = true;
            this.colStatut.Width = 100;
            // 
            // colPrint
            // 
            this.colPrint.HeaderText = "Action";
            this.colPrint.Name = "colPrint";
            this.colPrint.ReadOnly = true;
            this.colPrint.Text = "Imprimer";
            this.colPrint.UseColumnTextForButtonValue = true;
            this.colPrint.Width = 100;
            // 
            // CommandeSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvCommandes);
            this.Controls.Add(this.searchPanel);
            this.Name = "CommandeSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechercher Commandes";
            this.Load += new System.EventHandler(this.CommandeSearchForm_Load);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnSearchDate;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.Button btnSearchClient;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridView dgvCommandes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateCommande;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontantTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatut;
        private System.Windows.Forms.DataGridViewButtonColumn colPrint;
    }
}
