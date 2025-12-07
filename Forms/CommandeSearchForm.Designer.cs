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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            searchPanel = new Panel();
            btnShowAll = new Button();
            btnSearchClient = new Button();
            cboClient = new ComboBox();
            lblClient = new Label();
            btnSearchDate = new Button();
            dtpEndDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblStartDate = new Label();
            lblSearch = new Label();
            dgvCommandes = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colDateCommande = new DataGridViewTextBoxColumn();
            colClientNom = new DataGridViewTextBoxColumn();
            colMontantTotal = new DataGridViewTextBoxColumn();
            colStatut = new DataGridViewTextBoxColumn();
            colPrint = new DataGridViewButtonColumn();
            searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCommandes).BeginInit();
            SuspendLayout();
            // 
            // searchPanel
            // 
            searchPanel.BorderStyle = BorderStyle.FixedSingle;
            searchPanel.Controls.Add(btnShowAll);
            searchPanel.Controls.Add(btnSearchClient);
            searchPanel.Controls.Add(cboClient);
            searchPanel.Controls.Add(lblClient);
            searchPanel.Controls.Add(btnSearchDate);
            searchPanel.Controls.Add(dtpEndDate);
            searchPanel.Controls.Add(lblEndDate);
            searchPanel.Controls.Add(dtpStartDate);
            searchPanel.Controls.Add(lblStartDate);
            searchPanel.Controls.Add(lblSearch);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(0, 0);
            searchPanel.Margin = new Padding(3, 4, 3, 4);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(11, 13, 11, 13);
            searchPanel.Size = new Size(1068, 133);
            searchPanel.TabIndex = 0;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.FromArgb(66, 133, 244);
            btnShowAll.FlatAppearance.BorderSize = 0;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.ForeColor = Color.White;
            btnShowAll.Location = new Point(895, 38);
            btnShowAll.Margin = new Padding(3, 4, 3, 4);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(137, 40);
            btnShowAll.TabIndex = 9;
            btnShowAll.Text = "Afficher Tout";
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += BtnShowAll_Click;
            // 
            // btnSearchClient
            // 
            btnSearchClient.BackColor = Color.FromArgb(102, 187, 106);
            btnSearchClient.FlatAppearance.BorderSize = 0;
            btnSearchClient.FlatStyle = FlatStyle.Flat;
            btnSearchClient.ForeColor = Color.White;
            btnSearchClient.Location = new Point(691, 84);
            btnSearchClient.Margin = new Padding(3, 4, 3, 4);
            btnSearchClient.Name = "btnSearchClient";
            btnSearchClient.Size = new Size(171, 37);
            btnSearchClient.TabIndex = 8;
            btnSearchClient.Text = "Rechercher par Client";
            btnSearchClient.UseVisualStyleBackColor = false;
            btnSearchClient.Click += BtnSearchClient_Click;
            // 
            // cboClient
            // 
            cboClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClient.FormattingEnabled = true;
            cboClient.Location = new Point(79, 84);
            cboClient.Margin = new Padding(3, 4, 3, 4);
            cboClient.Name = "cboClient";
            cboClient.Size = new Size(585, 28);
            cboClient.TabIndex = 7;
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Location = new Point(23, 88);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(50, 20);
            lblClient.TabIndex = 6;
            lblClient.Text = "Client:";
            // 
            // btnSearchDate
            // 
            btnSearchDate.BackColor = Color.FromArgb(102, 187, 106);
            btnSearchDate.FlatAppearance.BorderSize = 0;
            btnSearchDate.FlatStyle = FlatStyle.Flat;
            btnSearchDate.ForeColor = Color.White;
            btnSearchDate.Location = new Point(691, 40);
            btnSearchDate.Margin = new Padding(3, 4, 3, 4);
            btnSearchDate.Name = "btnSearchDate";
            btnSearchDate.Size = new Size(171, 37);
            btnSearchDate.TabIndex = 5;
            btnSearchDate.Text = "Rechercher par Date";
            btnSearchDate.UseVisualStyleBackColor = false;
            btnSearchDate.Click += BtnSearchDate_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(434, 44);
            dtpEndDate.Margin = new Padding(3, 4, 3, 4);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(230, 27);
            dtpEndDate.TabIndex = 4;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(361, 48);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(67, 20);
            lblEndDate.TabIndex = 3;
            lblEndDate.Text = "Date Fin:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(118, 44);
            dtpStartDate.Margin = new Padding(3, 4, 3, 4);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(219, 27);
            dtpStartDate.TabIndex = 2;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(23, 48);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(89, 20);
            lblStartDate.TabIndex = 1;
            lblStartDate.Text = "Date Début:";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(14, 8);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(136, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Rechercher par:";
            // 
            // dgvCommandes
            // 
            dgvCommandes.AllowUserToAddRows = false;
            dgvCommandes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCommandes.BackgroundColor = Color.White;
            dgvCommandes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCommandes.Columns.AddRange(new DataGridViewColumn[] { colID, colDateCommande, colClientNom, colMontantTotal, colStatut, colPrint });
            dgvCommandes.Dock = DockStyle.Fill;
            dgvCommandes.Location = new Point(0, 133);
            dgvCommandes.Margin = new Padding(3, 4, 3, 4);
            dgvCommandes.MultiSelect = false;
            dgvCommandes.Name = "dgvCommandes";
            dgvCommandes.ReadOnly = true;
            dgvCommandes.RowHeadersWidth = 51;
            dgvCommandes.RowTemplate.Height = 25;
            dgvCommandes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCommandes.Size = new Size(1068, 667);
            dgvCommandes.TabIndex = 1;
            dgvCommandes.CellClick += DgvCommandes_CellClick;
            dgvCommandes.CellContentClick += dgvCommandes_CellContentClick;
            dgvCommandes.SelectionChanged += DgvCommandes_SelectionChanged;
            // 
            // colID
            // 
            colID.DataPropertyName = "ID";
            colID.HeaderText = "N° Cmd";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colDateCommande
            // 
            colDateCommande.DataPropertyName = "DateCommande";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm";
            colDateCommande.DefaultCellStyle = dataGridViewCellStyle3;
            colDateCommande.HeaderText = "Date";
            colDateCommande.MinimumWidth = 6;
            colDateCommande.Name = "colDateCommande";
            colDateCommande.ReadOnly = true;
            // 
            // colClientNom
            // 
            colClientNom.DataPropertyName = "ClientNom";
            colClientNom.HeaderText = "Client";
            colClientNom.MinimumWidth = 6;
            colClientNom.Name = "colClientNom";
            colClientNom.ReadOnly = true;
            // 
            // colMontantTotal
            // 
            colMontantTotal.DataPropertyName = "MontantTotal";
            dataGridViewCellStyle4.Format = "N2";
            colMontantTotal.DefaultCellStyle = dataGridViewCellStyle4;
            colMontantTotal.HeaderText = "Montant Total (€)";
            colMontantTotal.MinimumWidth = 6;
            colMontantTotal.Name = "colMontantTotal";
            colMontantTotal.ReadOnly = true;
            // 
            // colStatut
            // 
            colStatut.DataPropertyName = "Statut";
            colStatut.HeaderText = "Statut";
            colStatut.MinimumWidth = 6;
            colStatut.Name = "colStatut";
            colStatut.ReadOnly = true;
            // 
            // colPrint
            // 
            colPrint.HeaderText = "Action";
            colPrint.MinimumWidth = 6;
            colPrint.Name = "colPrint";
            colPrint.ReadOnly = true;
            colPrint.Text = "Imprimer";
            colPrint.UseColumnTextForButtonValue = true;
            // 
            // CommandeSearchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1068, 800);
            Controls.Add(dgvCommandes);
            Controls.Add(searchPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CommandeSearchForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rechercher Commandes";
            Load += CommandeSearchForm_Load;
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCommandes).EndInit();
            ResumeLayout(false);

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
