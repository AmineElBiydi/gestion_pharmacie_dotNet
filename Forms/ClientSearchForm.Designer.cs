namespace GestionPharmacie.Forms
{
    partial class ClientSearchForm
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvResults = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colNumero = new DataGridViewTextBoxColumn();
            colNom = new DataGridViewTextBoxColumn();
            colPrenom = new DataGridViewTextBoxColumn();
            colAdresse = new DataGridViewTextBoxColumn();
            colTelephone = new DataGridViewTextBoxColumn();
            lblSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(187, 37);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(457, 32);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 126, 167);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(656, 34);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(137, 43);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Rechercher";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { colID, colNumero, colNom, colPrenom, colAdresse, colTelephone });
            dgvResults.Location = new Point(23, 93);
            dgvResults.Margin = new Padding(3, 4, 3, 4);
            dgvResults.MultiSelect = false;
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.RowTemplate.Height = 25;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(869, 573);
            dgvResults.TabIndex = 2;
            // 
            // colID
            // 
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colNumero
            // 
            colNumero.DataPropertyName = "Numero";
            colNumero.HeaderText = "Numéro";
            colNumero.MinimumWidth = 6;
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            // 
            // colNom
            // 
            colNom.DataPropertyName = "Nom";
            colNom.HeaderText = "Nom";
            colNom.MinimumWidth = 6;
            colNom.Name = "colNom";
            colNom.ReadOnly = true;
            // 
            // colPrenom
            // 
            colPrenom.DataPropertyName = "Prenom";
            colPrenom.HeaderText = "Prénom";
            colPrenom.MinimumWidth = 6;
            colPrenom.Name = "colPrenom";
            colPrenom.ReadOnly = true;
            // 
            // colAdresse
            // 
            colAdresse.DataPropertyName = "Adresse";
            colAdresse.HeaderText = "Adresse";
            colAdresse.MinimumWidth = 6;
            colAdresse.Name = "colAdresse";
            colAdresse.ReadOnly = true;
            // 
            // colTelephone
            // 
            colTelephone.DataPropertyName = "Telephone";
            colTelephone.HeaderText = "Téléphone";
            colTelephone.MinimumWidth = 6;
            colTelephone.Name = "colTelephone";
            colTelephone.ReadOnly = true;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(73, 41);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(99, 23);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Rechercher:";
            // 
            // ClientSearchForm
            // 
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(914, 693);
            Controls.Add(lblSearch);
            Controls.Add(dgvResults);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ClientSearchForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recherche de Clients";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
    }
}
