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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            cboStatut = new ComboBox();
            lblStatut = new Label();
            dtpDate = new DateTimePicker();
            lblDate = new Label();
            cboClient = new ComboBox();
            lblClient = new Label();
            detailsPanel = new Panel();
            btnAdd = new Button();
            nudQuantite = new NumericUpDown();
            lblQte = new Label();
            cboMedicament = new ComboBox();
            lblMed = new Label();
            lblAddMed = new Label();
            dgvDetails = new DataGridView();
            colRef = new DataGridViewTextBoxColumn();
            colMedicament = new DataGridViewTextBoxColumn();
            colQuantite = new DataGridViewTextBoxColumn();
            colPrixUnit = new DataGridViewTextBoxColumn();
            colSousTotal = new DataGridViewTextBoxColumn();
            colDelete = new DataGridViewButtonColumn();
            footerPanel = new Panel();
            btnSave = new Button();
            lblTotal = new Label();
            headerPanel.SuspendLayout();
            detailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            footerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BorderStyle = BorderStyle.FixedSingle;
            headerPanel.Controls.Add(cboStatut);
            headerPanel.Controls.Add(lblStatut);
            headerPanel.Controls.Add(dtpDate);
            headerPanel.Controls.Add(lblDate);
            headerPanel.Controls.Add(cboClient);
            headerPanel.Controls.Add(lblClient);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(11, 13, 11, 13);
            headerPanel.Size = new Size(1029, 199);
            headerPanel.TabIndex = 0;
            // 
            // cboStatut
            // 
            cboStatut.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatut.FormattingEnabled = true;
            cboStatut.Items.AddRange(new object[] { "En cours", "Livrée", "Annulée" });
            cboStatut.Location = new Point(171, 116);
            cboStatut.Margin = new Padding(3, 4, 3, 4);
            cboStatut.Name = "cboStatut";
            cboStatut.Size = new Size(245, 28);
            cboStatut.TabIndex = 5;
            // 
            // lblStatut
            // 
            lblStatut.AutoSize = true;
            lblStatut.Location = new Point(23, 120);
            lblStatut.Name = "lblStatut";
            lblStatut.Size = new Size(51, 20);
            lblStatut.TabIndex = 4;
            lblStatut.Text = "Statut:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(171, 69);
            dtpDate.Margin = new Padding(3, 4, 3, 4);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(245, 27);
            dtpDate.TabIndex = 3;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(23, 73);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(125, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date Commande:";
            // 
            // cboClient
            // 
            cboClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClient.FormattingEnabled = true;
            cboClient.Location = new Point(171, 23);
            cboClient.Margin = new Padding(3, 4, 3, 4);
            cboClient.Name = "cboClient";
            cboClient.Size = new Size(342, 28);
            cboClient.TabIndex = 1;
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Location = new Point(23, 27);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(50, 20);
            lblClient.TabIndex = 0;
            lblClient.Text = "Client:";
            // 
            // detailsPanel
            // 
            detailsPanel.BorderStyle = BorderStyle.FixedSingle;
            detailsPanel.Controls.Add(btnAdd);
            detailsPanel.Controls.Add(nudQuantite);
            detailsPanel.Controls.Add(lblQte);
            detailsPanel.Controls.Add(cboMedicament);
            detailsPanel.Controls.Add(lblMed);
            detailsPanel.Controls.Add(lblAddMed);
            detailsPanel.Dock = DockStyle.Top;
            detailsPanel.Location = new Point(0, 199);
            detailsPanel.Margin = new Padding(3, 4, 3, 4);
            detailsPanel.Name = "detailsPanel";
            detailsPanel.Padding = new Padding(11, 13, 11, 13);
            detailsPanel.Size = new Size(1029, 133);
            detailsPanel.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 126, 167);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(769, 66);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 37);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Ajouter";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAddDetail_Click;
            // 
            // nudQuantite
            // 
            nudQuantite.Location = new Point(628, 72);
            nudQuantite.Margin = new Padding(3, 4, 3, 4);
            nudQuantite.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQuantite.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantite.Name = "nudQuantite";
            nudQuantite.Size = new Size(114, 27);
            nudQuantite.TabIndex = 4;
            nudQuantite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQte
            // 
            lblQte.AutoSize = true;
            lblQte.Location = new Point(537, 76);
            lblQte.Name = "lblQte";
            lblQte.Size = new Size(69, 20);
            lblQte.TabIndex = 3;
            lblQte.Text = "Quantité:";
            // 
            // cboMedicament
            // 
            cboMedicament.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMedicament.FormattingEnabled = true;
            cboMedicament.Location = new Point(171, 72);
            cboMedicament.Margin = new Padding(3, 4, 3, 4);
            cboMedicament.Name = "cboMedicament";
            cboMedicament.Size = new Size(342, 28);
            cboMedicament.TabIndex = 2;
            // 
            // lblMed
            // 
            lblMed.AutoSize = true;
            lblMed.Location = new Point(57, 76);
            lblMed.Name = "lblMed";
            lblMed.Size = new Size(95, 20);
            lblMed.TabIndex = 1;
            lblMed.Text = "Médicament:";
            // 
            // lblAddMed
            // 
            lblAddMed.AutoSize = true;
            lblAddMed.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAddMed.Location = new Point(23, 27);
            lblAddMed.Name = "lblAddMed";
            lblAddMed.Size = new Size(180, 23);
            lblAddMed.TabIndex = 0;
            lblAddMed.Text = "Ajouter Médicament:";
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Columns.AddRange(new DataGridViewColumn[] { colRef, colMedicament, colQuantite, colPrixUnit, colSousTotal, colDelete });
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.Location = new Point(0, 332);
            dgvDetails.Margin = new Padding(3, 4, 3, 4);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.RowTemplate.Height = 25;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(1029, 495);
            dgvDetails.TabIndex = 2;
            dgvDetails.CellClick += DgvDetails_CellClick;
            // 
            // colRef
            // 
            colRef.DataPropertyName = "MedicamentReference";
            colRef.HeaderText = "Référence";
            colRef.MinimumWidth = 6;
            colRef.Name = "colRef";
            colRef.ReadOnly = true;
            // 
            // colMedicament
            // 
            colMedicament.DataPropertyName = "MedicamentNom";
            colMedicament.HeaderText = "Médicament";
            colMedicament.MinimumWidth = 6;
            colMedicament.Name = "colMedicament";
            colMedicament.ReadOnly = true;
            // 
            // colQuantite
            // 
            colQuantite.DataPropertyName = "Quantite";
            colQuantite.HeaderText = "Quantité";
            colQuantite.MinimumWidth = 6;
            colQuantite.Name = "colQuantite";
            colQuantite.ReadOnly = true;
            // 
            // colPrixUnit
            // 
            colPrixUnit.DataPropertyName = "PrixUnitaire";
            dataGridViewCellStyle1.Format = "N2";
            colPrixUnit.DefaultCellStyle = dataGridViewCellStyle1;
            colPrixUnit.HeaderText = "Prix Unit. (DH)";
            colPrixUnit.MinimumWidth = 6;
            colPrixUnit.Name = "colPrixUnit";
            colPrixUnit.ReadOnly = true;
            // 
            // colSousTotal
            // 
            colSousTotal.DataPropertyName = "SousTotal";
            dataGridViewCellStyle2.Format = "N2";
            colSousTotal.DefaultCellStyle = dataGridViewCellStyle2;
            colSousTotal.HeaderText = "Sous-Total (DH)";
            colSousTotal.MinimumWidth = 6;
            colSousTotal.Name = "colSousTotal";
            colSousTotal.ReadOnly = true;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Action";
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Supprimer";
            colDelete.UseColumnTextForButtonValue = true;
            // 
            // footerPanel
            // 
            footerPanel.BorderStyle = BorderStyle.FixedSingle;
            footerPanel.Controls.Add(btnSave);
            footerPanel.Controls.Add(lblTotal);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(0, 827);
            footerPanel.Margin = new Padding(3, 4, 3, 4);
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(1029, 106);
            footerPanel.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 126, 167);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(686, 27);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(206, 53);
            btnSave.TabIndex = 1;
            btnSave.Text = "Enregistrer Commande";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(0, 50, 73);
            lblTotal.Location = new Point(23, 33);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(174, 37);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total: 0.00 DH";
            // 
            // CommandeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1029, 933);
            Controls.Add(dgvDetails);
            Controls.Add(footerPanel);
            Controls.Add(detailsPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CommandeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nouvelle Commande";
            Load += CommandeForm_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            detailsPanel.ResumeLayout(false);
            detailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantite).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);

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
