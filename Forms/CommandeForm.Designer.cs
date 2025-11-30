namespace GestionPharmacie.Forms
{
    partial class CommandeForm
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.cboStatut = new System.Windows.Forms.ComboBox();
            this.lblStatut = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nudQuantite = new System.Windows.Forms.NumericUpDown();
            this.lblQte = new System.Windows.Forms.Label();
            this.cboMedicament = new System.Windows.Forms.ComboBox();
            this.lblMed = new System.Windows.Forms.Label();
            this.lblAddMed = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrixUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSousTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.detailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerPanel.Controls.Add(this.cboStatut);
            this.headerPanel.Controls.Add(this.lblStatut);
            this.headerPanel.Controls.Add(this.dtpDate);
            this.headerPanel.Controls.Add(this.lblDate);
            this.headerPanel.Controls.Add(this.cboClient);
            this.headerPanel.Controls.Add(this.lblClient);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(10);
            this.headerPanel.Size = new System.Drawing.Size(900, 150);
            this.headerPanel.TabIndex = 0;
            // 
            // cboStatut
            // 
            this.cboStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatut.FormattingEnabled = true;
            this.cboStatut.Items.AddRange(new object[] {
            "En cours",
            "Livrée",
            "Annulée"});
            this.cboStatut.Location = new System.Drawing.Point(150, 87);
            this.cboStatut.Name = "cboStatut";
            this.cboStatut.Size = new System.Drawing.Size(200, 23);
            this.cboStatut.TabIndex = 5;
            // 
            // lblStatut
            // 
            this.lblStatut.AutoSize = true;
            this.lblStatut.Location = new System.Drawing.Point(20, 90);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(42, 15);
            this.lblStatut.TabIndex = 4;
            this.lblStatut.Text = "Statut:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(150, 52);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 55);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(104, 15);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date Commande:";
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(150, 17);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(300, 23);
            this.cboClient.TabIndex = 1;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(20, 20);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(41, 15);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Client:";
            // 
            // detailsPanel
            // 
            this.detailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsPanel.Controls.Add(this.btnAdd);
            this.detailsPanel.Controls.Add(this.nudQuantite);
            this.detailsPanel.Controls.Add(this.lblQte);
            this.detailsPanel.Controls.Add(this.cboMedicament);
            this.detailsPanel.Controls.Add(this.lblMed);
            this.detailsPanel.Controls.Add(this.lblAddMed);
            this.detailsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.detailsPanel.Location = new System.Drawing.Point(0, 150);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Padding = new System.Windows.Forms.Padding(10);
            this.detailsPanel.Size = new System.Drawing.Size(900, 100);
            this.detailsPanel.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(640, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAddDetail_Click);
            // 
            // nudQuantite
            // 
            this.nudQuantite.Location = new System.Drawing.Point(520, 47);
            this.nudQuantite.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudQuantite.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantite.Name = "nudQuantite";
            this.nudQuantite.Size = new System.Drawing.Size(100, 23);
            this.nudQuantite.TabIndex = 4;
            this.nudQuantite.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQte
            // 
            this.lblQte.AutoSize = true;
            this.lblQte.Location = new System.Drawing.Point(440, 50);
            this.lblQte.Name = "lblQte";
            this.lblQte.Size = new System.Drawing.Size(59, 15);
            this.lblQte.TabIndex = 3;
            this.lblQte.Text = "Quantité:";
            // 
            // cboMedicament
            // 
            this.cboMedicament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicament.FormattingEnabled = true;
            this.cboMedicament.Location = new System.Drawing.Point(120, 47);
            this.cboMedicament.Name = "cboMedicament";
            this.cboMedicament.Size = new System.Drawing.Size(300, 23);
            this.cboMedicament.TabIndex = 2;
            // 
            // lblMed
            // 
            this.lblMed.AutoSize = true;
            this.lblMed.Location = new System.Drawing.Point(20, 50);
            this.lblMed.Name = "lblMed";
            this.lblMed.Size = new System.Drawing.Size(77, 15);
            this.lblMed.TabIndex = 1;
            this.lblMed.Text = "Médicament:";
            // 
            // lblAddMed
            // 
            this.lblAddMed.AutoSize = true;
            this.lblAddMed.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAddMed.Location = new System.Drawing.Point(20, 20);
            this.lblAddMed.Name = "lblAddMed";
            this.lblAddMed.Size = new System.Drawing.Size(165, 19);
            this.lblAddMed.TabIndex = 0;
            this.lblAddMed.Text = "Ajouter Médicament:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRef,
            this.colMedicament,
            this.colQuantite,
            this.colPrixUnit,
            this.colSousTotal,
            this.colDelete});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 250);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 25;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(900, 370);
            this.dgvDetails.TabIndex = 2;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetails_CellClick);
            // 
            // colRef
            // 
            this.colRef.DataPropertyName = "MedicamentReference";
            this.colRef.HeaderText = "Référence";
            this.colRef.Name = "colRef";
            this.colRef.ReadOnly = true;
            // 
            // colMedicament
            // 
            this.colMedicament.DataPropertyName = "MedicamentNom";
            this.colMedicament.HeaderText = "Médicament";
            this.colMedicament.Name = "colMedicament";
            this.colMedicament.ReadOnly = true;
            // 
            // colQuantite
            // 
            this.colQuantite.DataPropertyName = "Quantite";
            this.colQuantite.HeaderText = "Quantité";
            this.colQuantite.Name = "colQuantite";
            this.colQuantite.ReadOnly = true;
            // 
            // colPrixUnit
            // 
            this.colPrixUnit.DataPropertyName = "PrixUnitaire";
            this.colPrixUnit.DefaultCellStyle.Format = "N2";
            this.colPrixUnit.HeaderText = "Prix Unit. (€)";
            this.colPrixUnit.Name = "colPrixUnit";
            this.colPrixUnit.ReadOnly = true;
            // 
            // colSousTotal
            // 
            this.colSousTotal.DataPropertyName = "SousTotal";
            this.colSousTotal.DefaultCellStyle.Format = "N2";
            this.colSousTotal.HeaderText = "Sous-Total (€)";
            this.colSousTotal.Name = "colSousTotal";
            this.colSousTotal.ReadOnly = true;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Action";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "Supprimer";
            this.colDelete.UseColumnTextForButtonValue = true;
            // 
            // footerPanel
            // 
            this.footerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.footerPanel.Controls.Add(this.btnSave);
            this.footerPanel.Controls.Add(this.lblTotal);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 620);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(900, 80);
            this.footerPanel.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(600, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Enregistrer Commande";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.lblTotal.Location = new System.Drawing.Point(20, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(138, 30);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total: 0.00 €";
            // 
            // CommandeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.detailsPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "CommandeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nouvelle Commande";
            this.Load += new System.EventHandler(this.CommandeForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.detailsPanel.ResumeLayout(false);
            this.detailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cboStatut;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.Label lblAddMed;
        private System.Windows.Forms.ComboBox cboMedicament;
        private System.Windows.Forms.Label lblMed;
        private System.Windows.Forms.NumericUpDown nudQuantite;
        private System.Windows.Forms.Label lblQte;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicament;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrixUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSousTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}
