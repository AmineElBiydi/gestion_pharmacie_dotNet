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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            formPanel = new Panel();
            btnDelete = new Button();
            btnNew = new Button();
            btnSave = new Button();
            nudSeuil = new NumericUpDown();
            lblSeuil = new Label();
            nudQuantiteStock = new NumericUpDown();
            lblQte = new Label();
            nudPrixUnitaire = new NumericUpDown();
            lblPrix = new Label();
            dtpDatePeremption = new DateTimePicker();
            lblDate = new Label();
            txtNom = new TextBox();
            lblNom = new Label();
            txtReference = new TextBox();
            lblReference = new Label();
            dgvMedicaments = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colReference = new DataGridViewTextBoxColumn();
            colNom = new DataGridViewTextBoxColumn();
            colDatePeremption = new DataGridViewTextBoxColumn();
            colPrixUnitaire = new DataGridViewTextBoxColumn();
            colQuantiteStock = new DataGridViewTextBoxColumn();
            colSeuil = new DataGridViewTextBoxColumn();
            formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeuil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantiteStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrixUnitaire).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicaments).BeginInit();
            SuspendLayout();
            // 
            // formPanel
            // 
            formPanel.BorderStyle = BorderStyle.FixedSingle;
            formPanel.Controls.Add(btnDelete);
            formPanel.Controls.Add(btnNew);
            formPanel.Controls.Add(btnSave);
            formPanel.Controls.Add(nudSeuil);
            formPanel.Controls.Add(lblSeuil);
            formPanel.Controls.Add(nudQuantiteStock);
            formPanel.Controls.Add(lblQte);
            formPanel.Controls.Add(nudPrixUnitaire);
            formPanel.Controls.Add(lblPrix);
            formPanel.Controls.Add(dtpDatePeremption);
            formPanel.Controls.Add(lblDate);
            formPanel.Controls.Add(txtNom);
            formPanel.Controls.Add(lblNom);
            formPanel.Controls.Add(txtReference);
            formPanel.Controls.Add(lblReference);
            formPanel.Dock = DockStyle.Top;
            formPanel.Location = new Point(0, 0);
            formPanel.Margin = new Padding(3, 4, 3, 4);
            formPanel.Name = "formPanel";
            formPanel.Padding = new Padding(11, 13, 11, 13);
            formPanel.Size = new Size(1143, 333);
            formPanel.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 83, 80);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(767, 262);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(157, 40);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "bloquer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(100, 181, 246);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(604, 262);
            btnNew.Margin = new Padding(3, 4, 3, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(157, 40);
            btnNew.TabIndex = 13;
            btnNew.Text = "Nouveau";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += BtnNew_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(66, 133, 244);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(441, 262);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(157, 40);
            btnSave.TabIndex = 12;
            btnSave.Text = "Enregistrer";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // nudSeuil
            // 
            nudSeuil.Location = new Point(754, 187);
            nudSeuil.Margin = new Padding(3, 4, 3, 4);
            nudSeuil.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudSeuil.Name = "nudSeuil";
            nudSeuil.Size = new Size(171, 27);
            nudSeuil.TabIndex = 11;
            nudSeuil.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblSeuil
            // 
            lblSeuil.AutoSize = true;
            lblSeuil.Location = new Point(571, 191);
            lblSeuil.Name = "lblSeuil";
            lblSeuil.Size = new Size(100, 20);
            lblSeuil.TabIndex = 10;
            lblSeuil.Text = "Seuil d'Alerte:";
            // 
            // nudQuantiteStock
            // 
            nudQuantiteStock.Location = new Point(754, 133);
            nudQuantiteStock.Margin = new Padding(3, 4, 3, 4);
            nudQuantiteStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudQuantiteStock.Name = "nudQuantiteStock";
            nudQuantiteStock.Size = new Size(171, 27);
            nudQuantiteStock.TabIndex = 9;
            // 
            // lblQte
            // 
            lblQte.AutoSize = true;
            lblQte.Location = new Point(571, 137);
            lblQte.Name = "lblQte";
            lblQte.Size = new Size(129, 20);
            lblQte.TabIndex = 8;
            lblQte.Text = "Quantité en Stock:";
            // 
            // nudPrixUnitaire
            // 
            nudPrixUnitaire.DecimalPlaces = 2;
            nudPrixUnitaire.Location = new Point(206, 187);
            nudPrixUnitaire.Margin = new Padding(3, 4, 3, 4);
            nudPrixUnitaire.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPrixUnitaire.Name = "nudPrixUnitaire";
            nudPrixUnitaire.Size = new Size(286, 27);
            nudPrixUnitaire.TabIndex = 7;
            // 
            // lblPrix
            // 
            lblPrix.AutoSize = true;
            lblPrix.Location = new Point(23, 191);
            lblPrix.Name = "lblPrix";
            lblPrix.Size = new Size(114, 20);
            lblPrix.TabIndex = 6;
            lblPrix.Text = "Prix Unitaire (€):";
            // 
            // dtpDatePeremption
            // 
            dtpDatePeremption.Location = new Point(206, 133);
            dtpDatePeremption.Margin = new Padding(3, 4, 3, 4);
            dtpDatePeremption.Name = "dtpDatePeremption";
            dtpDatePeremption.Size = new Size(285, 27);
            dtpDatePeremption.TabIndex = 5;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(23, 137);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(145, 20);
            lblDate.TabIndex = 4;
            lblDate.Text = "Date de Péremption:";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(206, 80);
            txtNom.Margin = new Padding(3, 4, 3, 4);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(285, 27);
            txtNom.TabIndex = 3;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(23, 84);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(45, 20);
            lblNom.TabIndex = 2;
            lblNom.Text = "Nom:";
            // 
            // txtReference
            // 
            txtReference.Location = new Point(206, 27);
            txtReference.Margin = new Padding(3, 4, 3, 4);
            txtReference.Name = "txtReference";
            txtReference.Size = new Size(285, 27);
            txtReference.TabIndex = 1;
            // 
            // lblReference
            // 
            lblReference.AutoSize = true;
            lblReference.Location = new Point(23, 31);
            lblReference.Name = "lblReference";
            lblReference.Size = new Size(78, 20);
            lblReference.TabIndex = 0;
            lblReference.Text = "Référence:";
            // 
            // dgvMedicaments
            // 
            dgvMedicaments.AllowUserToAddRows = false;
            dgvMedicaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicaments.BackgroundColor = Color.White;
            dgvMedicaments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicaments.Columns.AddRange(new DataGridViewColumn[] { colID, colReference, colNom, colDatePeremption, colPrixUnitaire, colQuantiteStock, colSeuil });
            dgvMedicaments.Dock = DockStyle.Fill;
            dgvMedicaments.Location = new Point(0, 333);
            dgvMedicaments.Margin = new Padding(3, 4, 3, 4);
            dgvMedicaments.MultiSelect = false;
            dgvMedicaments.Name = "dgvMedicaments";
            dgvMedicaments.ReadOnly = true;
            dgvMedicaments.RowHeadersWidth = 51;
            dgvMedicaments.RowTemplate.Height = 25;
            dgvMedicaments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicaments.Size = new Size(1143, 467);
            dgvMedicaments.TabIndex = 1;
            dgvMedicaments.SelectionChanged += DgvMedicaments_SelectionChanged;
            // 
            // colID
            // 
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colReference
            // 
            colReference.DataPropertyName = "Reference";
            colReference.HeaderText = "Référence";
            colReference.MinimumWidth = 6;
            colReference.Name = "colReference";
            colReference.ReadOnly = true;
            // 
            // colNom
            // 
            colNom.DataPropertyName = "Nom";
            colNom.HeaderText = "Nom";
            colNom.MinimumWidth = 6;
            colNom.Name = "colNom";
            colNom.ReadOnly = true;
            // 
            // colDatePeremption
            // 
            colDatePeremption.DataPropertyName = "DatePeremption";
            colDatePeremption.HeaderText = "Date Péremption";
            colDatePeremption.MinimumWidth = 6;
            colDatePeremption.Name = "colDatePeremption";
            colDatePeremption.ReadOnly = true;
            // 
            // colPrixUnitaire
            // 
            colPrixUnitaire.DataPropertyName = "PrixUnitaire";
            dataGridViewCellStyle1.Format = "N2";
            colPrixUnitaire.DefaultCellStyle = dataGridViewCellStyle1;
            colPrixUnitaire.HeaderText = "Prix (€)";
            colPrixUnitaire.MinimumWidth = 6;
            colPrixUnitaire.Name = "colPrixUnitaire";
            colPrixUnitaire.ReadOnly = true;
            // 
            // colQuantiteStock
            // 
            colQuantiteStock.DataPropertyName = "QuantiteStock";
            colQuantiteStock.HeaderText = "Stock";
            colQuantiteStock.MinimumWidth = 6;
            colQuantiteStock.Name = "colQuantiteStock";
            colQuantiteStock.ReadOnly = true;
            // 
            // colSeuil
            // 
            colSeuil.DataPropertyName = "Seuil";
            colSeuil.HeaderText = "Seuil";
            colSeuil.MinimumWidth = 6;
            colSeuil.Name = "colSeuil";
            colSeuil.ReadOnly = true;
            // 
            // MedicamentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1143, 800);
            Controls.Add(dgvMedicaments);
            Controls.Add(formPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MedicamentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des Médicaments";
            Load += MedicamentForm_Load;
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeuil).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantiteStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrixUnitaire).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicaments).EndInit();
            ResumeLayout(false);

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
