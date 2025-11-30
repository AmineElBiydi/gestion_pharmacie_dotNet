namespace GestionPharmacie.Forms
{
    partial class MedicamentSearchForm
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
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatePeremption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrixUnitaire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantiteStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.btnSearchAll);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.lblSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(10);
            this.searchPanel.Size = new System.Drawing.Size(900, 60);
            this.searchPanel.TabIndex = 0;
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnSearchAll.FlatAppearance.BorderSize = 0;
            this.btnSearchAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAll.ForeColor = System.Drawing.Color.White;
            this.btnSearchAll.Location = new System.Drawing.Point(540, 10);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(120, 32);
            this.btnSearchAll.TabIndex = 2;
            this.btnSearchAll.Text = "Afficher Tous";
            this.btnSearchAll.UseVisualStyleBackColor = false;
            this.btnSearchAll.Click += new System.EventHandler(this.BtnSearchAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(120, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(70, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Rechercher:";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReference,
            this.colNom,
            this.colDatePeremption,
            this.colPrixUnitaire,
            this.colQuantiteStock});
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 60);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowTemplate.Height = 25;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(900, 440);
            this.dgvResults.TabIndex = 1;
            // 
            // colReference
            // 
            this.colReference.DataPropertyName = "Reference";
            this.colReference.HeaderText = "Référence";
            this.colReference.Name = "colReference";
            this.colReference.ReadOnly = true;
            this.colReference.Width = 120;
            // 
            // colNom
            // 
            this.colNom.DataPropertyName = "Nom";
            this.colNom.HeaderText = "Nom";
            this.colNom.Name = "colNom";
            this.colNom.ReadOnly = true;
            this.colNom.Width = 250;
            // 
            // colDatePeremption
            // 
            this.colDatePeremption.DataPropertyName = "DatePeremption";
            this.colDatePeremption.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.colDatePeremption.HeaderText = "Date Péremption";
            this.colDatePeremption.Name = "colDatePeremption";
            this.colDatePeremption.ReadOnly = true;
            this.colDatePeremption.Width = 120;
            // 
            // colPrixUnitaire
            // 
            this.colPrixUnitaire.DataPropertyName = "PrixUnitaire";
            this.colPrixUnitaire.DefaultCellStyle.Format = "N2";
            this.colPrixUnitaire.HeaderText = "Prix (€)";
            this.colPrixUnitaire.Name = "colPrixUnitaire";
            this.colPrixUnitaire.ReadOnly = true;
            this.colPrixUnitaire.Width = 100;
            // 
            // colQuantiteStock
            // 
            this.colQuantiteStock.DataPropertyName = "QuantiteStock";
            this.colQuantiteStock.HeaderText = "Stock";
            this.colQuantiteStock.Name = "colQuantiteStock";
            this.colQuantiteStock.ReadOnly = true;
            this.colQuantiteStock.Width = 80;
            // 
            // MedicamentSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.searchPanel);
            this.Name = "MedicamentSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechercher Médicaments";
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatePeremption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrixUnitaire;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantiteStock;
    }
}
