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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            searchPanel = new Panel();
            btnSearchAll = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            dgvResults = new DataGridView();
            colReference = new DataGridViewTextBoxColumn();
            colNom = new DataGridViewTextBoxColumn();
            colDatePeremption = new DataGridViewTextBoxColumn();
            colPrixUnitaire = new DataGridViewTextBoxColumn();
            colQuantiteStock = new DataGridViewTextBoxColumn();
            searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(btnSearchAll);
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(lblSearch);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(0, 0);
            searchPanel.Margin = new Padding(3, 4, 3, 4);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(11, 13, 11, 13);
            searchPanel.Size = new Size(1029, 80);
            searchPanel.TabIndex = 0;
            // 
            // btnSearchAll
            // 
            btnSearchAll.BackColor = Color.FromArgb(66, 133, 244);
            btnSearchAll.FlatAppearance.BorderSize = 0;
            btnSearchAll.FlatStyle = FlatStyle.Flat;
            btnSearchAll.ForeColor = Color.White;
            btnSearchAll.Location = new Point(665, 16);
            btnSearchAll.Margin = new Padding(3, 4, 3, 4);
            btnSearchAll.Name = "btnSearchAll";
            btnSearchAll.Size = new Size(137, 43);
            btnSearchAll.TabIndex = 2;
            btnSearchAll.Text = "Afficher Tous";
            btnSearchAll.UseVisualStyleBackColor = false;
            btnSearchAll.Click += BtnSearchAll_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(179, 23);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(457, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(65, 27);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(85, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Rechercher:";
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { colReference, colNom, colDatePeremption, colPrixUnitaire, colQuantiteStock });
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.Location = new Point(0, 80);
            dgvResults.Margin = new Padding(3, 4, 3, 4);
            dgvResults.MultiSelect = false;
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.RowTemplate.Height = 25;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(1029, 587);
            dgvResults.TabIndex = 1;
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
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            colDatePeremption.DefaultCellStyle = dataGridViewCellStyle1;
            colDatePeremption.HeaderText = "Date Péremption";
            colDatePeremption.MinimumWidth = 6;
            colDatePeremption.Name = "colDatePeremption";
            colDatePeremption.ReadOnly = true;
            // 
            // colPrixUnitaire
            // 
            colPrixUnitaire.DataPropertyName = "PrixUnitaire";
            dataGridViewCellStyle2.Format = "N2";
            colPrixUnitaire.DefaultCellStyle = dataGridViewCellStyle2;
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
            // MedicamentSearchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1029, 667);
            Controls.Add(dgvResults);
            Controls.Add(searchPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MedicamentSearchForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rechercher Médicaments";
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);

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
