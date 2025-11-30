namespace GestionPharmacie.Forms
{
    partial class MedicamentForm
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
            this.formPanel = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.nudSeuil = new System.Windows.Forms.NumericUpDown();
            this.lblSeuil = new System.Windows.Forms.Label();
            this.nudQuantiteStock = new System.Windows.Forms.NumericUpDown();
            this.lblQte = new System.Windows.Forms.Label();
            this.nudPrixUnitaire = new System.Windows.Forms.NumericUpDown();
            this.lblPrix = new System.Windows.Forms.Label();
            this.dtpDatePeremption = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.dgvMedicaments = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatePeremption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrixUnitaire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantiteStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeuil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeuil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantiteStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrixUnitaire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicaments)).BeginInit();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formPanel.Controls.Add(this.btnDelete);
            this.formPanel.Controls.Add(this.btnNew);
            this.formPanel.Controls.Add(this.btnSave);
            this.formPanel.Controls.Add(this.nudSeuil);
            this.formPanel.Controls.Add(this.lblSeuil);
            this.formPanel.Controls.Add(this.nudQuantiteStock);
            this.formPanel.Controls.Add(this.lblQte);
            this.formPanel.Controls.Add(this.nudPrixUnitaire);
            this.formPanel.Controls.Add(this.lblPrix);
            this.formPanel.Controls.Add(this.dtpDatePeremption);
            this.formPanel.Controls.Add(this.lblDate);
            this.formPanel.Controls.Add(this.txtNom);
            this.formPanel.Controls.Add(this.lblNom);
            this.formPanel.Controls.Add(this.txtReference);
            this.formPanel.Controls.Add(this.lblReference);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formPanel.Location = new System.Drawing.Point(0, 0);
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(10);
            this.formPanel.Size = new System.Drawing.Size(1000, 250);
            this.formPanel.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(83)))), ((int)(((byte)(80)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(720, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(610, 180);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 30);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "Nouveau";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(500, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // nudSeuil
            // 
            this.nudSeuil.Location = new System.Drawing.Point(660, 140);
            this.nudSeuil.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSeuil.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSeuil.Name = "nudSeuil";
            this.nudSeuil.Size = new System.Drawing.Size(150, 23);
            this.nudSeuil.TabIndex = 11;
            this.nudSeuil.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblSeuil
            // 
            this.lblSeuil.AutoSize = true;
            this.lblSeuil.Location = new System.Drawing.Point(500, 143);
            this.lblSeuil.Name = "lblSeuil";
            this.lblSeuil.Size = new System.Drawing.Size(75, 15);
            this.lblSeuil.TabIndex = 10;
            this.lblSeuil.Text = "Seuil d\'Alerte:";
            // 
            // nudQuantiteStock
            // 
            this.nudQuantiteStock.Location = new System.Drawing.Point(660, 100);
            this.nudQuantiteStock.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudQuantiteStock.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudQuantiteStock.Name = "nudQuantiteStock";
            this.nudQuantiteStock.Size = new System.Drawing.Size(150, 23);
            this.nudQuantiteStock.TabIndex = 9;
            // 
            // lblQte
            // 
            this.lblQte.AutoSize = true;
            this.lblQte.Location = new System.Drawing.Point(500, 103);
            this.lblQte.Name = "lblQte";
            this.lblQte.Size = new System.Drawing.Size(108, 15);
            this.lblQte.TabIndex = 8;
            this.lblQte.Text = "Quantité en Stock:";
            // 
            // nudPrixUnitaire
            // 
            this.nudPrixUnitaire.DecimalPlaces = 2;
            this.nudPrixUnitaire.Location = new System.Drawing.Point(180, 140);
            this.nudPrixUnitaire.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrixUnitaire.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPrixUnitaire.Name = "nudPrixUnitaire";
            this.nudPrixUnitaire.Size = new System.Drawing.Size(250, 23);
            this.nudPrixUnitaire.TabIndex = 7;
            // 
            // lblPrix
            // 
            this.lblPrix.AutoSize = true;
            this.lblPrix.Location = new System.Drawing.Point(20, 143);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(87, 15);
            this.lblPrix.TabIndex = 6;
            this.lblPrix.Text = "Prix Unitaire (€):";
            // 
            // dtpDatePeremption
            // 
            this.dtpDatePeremption.Location = new System.Drawing.Point(180, 100);
            this.dtpDatePeremption.Name = "dtpDatePeremption";
            this.dtpDatePeremption.Size = new System.Drawing.Size(250, 23);
            this.dtpDatePeremption.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 103);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(115, 15);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date de Péremption:";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(180, 60);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(250, 23);
            this.txtNom.TabIndex = 3;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(20, 63);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(37, 15);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom:";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(180, 20);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(250, 23);
            this.txtReference.TabIndex = 1;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(20, 23);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(65, 15);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "Référence:";
            // 
            // dgvMedicaments
            // 
            this.dgvMedicaments.AllowUserToAddRows = false;
            this.dgvMedicaments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicaments.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicaments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colReference,
            this.colNom,
            this.colDatePeremption,
            this.colPrixUnitaire,
            this.colQuantiteStock,
            this.colSeuil});
            this.dgvMedicaments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicaments.Location = new System.Drawing.Point(0, 250);
            this.dgvMedicaments.MultiSelect = false;
            this.dgvMedicaments.Name = "dgvMedicaments";
            this.dgvMedicaments.ReadOnly = true;
            this.dgvMedicaments.RowTemplate.Height = 25;
            this.dgvMedicaments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicaments.Size = new System.Drawing.Size(1000, 350);
            this.dgvMedicaments.TabIndex = 1;
            this.dgvMedicaments.SelectionChanged += new System.EventHandler(this.DgvMedicaments_SelectionChanged);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 50;
            // 
            // colReference
            // 
            this.colReference.DataPropertyName = "Reference";
            this.colReference.HeaderText = "Référence";
            this.colReference.Name = "colReference";
            this.colReference.ReadOnly = true;
            // 
            // colNom
            // 
            this.colNom.DataPropertyName = "Nom";
            this.colNom.HeaderText = "Nom";
            this.colNom.Name = "colNom";
            this.colNom.ReadOnly = true;
            // 
            // colDatePeremption
            // 
            this.colDatePeremption.DataPropertyName = "DatePeremption";
            this.colDatePeremption.HeaderText = "Date Péremption";
            this.colDatePeremption.Name = "colDatePeremption";
            this.colDatePeremption.ReadOnly = true;
            // 
            // colPrixUnitaire
            // 
            this.colPrixUnitaire.DataPropertyName = "PrixUnitaire";
            this.colPrixUnitaire.DefaultCellStyle.Format = "N2";
            this.colPrixUnitaire.HeaderText = "Prix (€)";
            this.colPrixUnitaire.Name = "colPrixUnitaire";
            this.colPrixUnitaire.ReadOnly = true;
            // 
            // colQuantiteStock
            // 
            this.colQuantiteStock.DataPropertyName = "QuantiteStock";
            this.colQuantiteStock.HeaderText = "Stock";
            this.colQuantiteStock.Name = "colQuantiteStock";
            this.colQuantiteStock.ReadOnly = true;
            // 
            // colSeuil
            // 
            this.colSeuil.DataPropertyName = "Seuil";
            this.colSeuil.HeaderText = "Seuil";
            this.colSeuil.Name = "colSeuil";
            this.colSeuil.ReadOnly = true;
            // 
            // MedicamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvMedicaments);
            this.Controls.Add(this.formPanel);
            this.Name = "MedicamentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Médicaments";
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeuil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantiteStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrixUnitaire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicaments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDatePeremption;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.NumericUpDown nudPrixUnitaire;
        private System.Windows.Forms.Label lblQte;
        private System.Windows.Forms.NumericUpDown nudQuantiteStock;
        private System.Windows.Forms.Label lblSeuil;
        private System.Windows.Forms.NumericUpDown nudSeuil;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvMedicaments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatePeremption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrixUnitaire;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantiteStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeuil;
    }
}
