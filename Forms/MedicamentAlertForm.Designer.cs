namespace GestionPharmacie.Forms
{
    partial class MedicamentAlertForm
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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvAlerts = new System.Windows.Forms.DataGridView();
            this.colReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatePeremption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantiteStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeuil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.titlePanel.Controls.Add(this.lblTitle);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(900, 60);
            this.titlePanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(100)))), ((int)(((byte)(4)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚠ Médicaments nécessitant une attention (stock faible ou péremption proche)";
            // 
            // dgvAlerts
            // 
            this.dgvAlerts.AllowUserToAddRows = false;
            this.dgvAlerts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlerts.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReference,
            this.colNom,
            this.colDatePeremption,
            this.colQuantiteStock,
            this.colSeuil});
            this.dgvAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlerts.Location = new System.Drawing.Point(0, 60);
            this.dgvAlerts.MultiSelect = false;
            this.dgvAlerts.Name = "dgvAlerts";
            this.dgvAlerts.ReadOnly = true;
            this.dgvAlerts.RowTemplate.Height = 25;
            this.dgvAlerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlerts.Size = new System.Drawing.Size(900, 440);
            this.dgvAlerts.TabIndex = 1;
            this.dgvAlerts.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvAlerts_RowPrePaint);
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
            // colQuantiteStock
            // 
            this.colQuantiteStock.DataPropertyName = "QuantiteStock";
            this.colQuantiteStock.HeaderText = "Stock";
            this.colQuantiteStock.Name = "colQuantiteStock";
            this.colQuantiteStock.ReadOnly = true;
            this.colQuantiteStock.Width = 80;
            // 
            // colSeuil
            // 
            this.colSeuil.DataPropertyName = "Seuil";
            this.colSeuil.HeaderText = "Seuil";
            this.colSeuil.Name = "colSeuil";
            this.colSeuil.ReadOnly = true;
            this.colSeuil.Width = 80;
            // 
            // MedicamentAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgvAlerts);
            this.Controls.Add(this.titlePanel);
            this.Name = "MedicamentAlertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alertes - Médicaments en Alerte";
            this.Load += new System.EventHandler(this.MedicamentAlertForm_Load);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvAlerts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatePeremption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantiteStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeuil;
    }
}
