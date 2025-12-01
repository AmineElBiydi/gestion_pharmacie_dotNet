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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            titlePanel = new Panel();
            lblTitle = new Label();
            dgvAlerts = new DataGridView();
            colReference = new DataGridViewTextBoxColumn();
            colNom = new DataGridViewTextBoxColumn();
            colDatePeremption = new DataGridViewTextBoxColumn();
            colQuantiteStock = new DataGridViewTextBoxColumn();
            colSeuil = new DataGridViewTextBoxColumn();
            titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).BeginInit();
            SuspendLayout();
            // 
            // titlePanel
            // 
            titlePanel.BackColor = Color.FromArgb(255, 243, 205);
            titlePanel.Controls.Add(lblTitle);
            titlePanel.Dock = DockStyle.Top;
            titlePanel.Location = new Point(0, 0);
            titlePanel.Margin = new Padding(3, 4, 3, 4);
            titlePanel.Name = "titlePanel";
            titlePanel.Size = new Size(1029, 80);
            titlePanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(133, 100, 4);
            lblTitle.Location = new Point(122, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(768, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "⚠ Médicaments nécessitant une attention (stock faible ou péremption proche)";
            lblTitle.Click += lblTitle_Click;
            // 
            // dgvAlerts
            // 
            dgvAlerts.AllowUserToAddRows = false;
            dgvAlerts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlerts.BackgroundColor = Color.White;
            dgvAlerts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlerts.Columns.AddRange(new DataGridViewColumn[] { colReference, colNom, colDatePeremption, colQuantiteStock, colSeuil });
            dgvAlerts.Dock = DockStyle.Fill;
            dgvAlerts.Location = new Point(0, 80);
            dgvAlerts.Margin = new Padding(3, 4, 3, 4);
            dgvAlerts.MultiSelect = false;
            dgvAlerts.Name = "dgvAlerts";
            dgvAlerts.ReadOnly = true;
            dgvAlerts.RowHeadersWidth = 51;
            dgvAlerts.RowTemplate.Height = 25;
            dgvAlerts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlerts.Size = new Size(1029, 587);
            dgvAlerts.TabIndex = 1;
            dgvAlerts.RowPrePaint += DgvAlerts_RowPrePaint;
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
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            colDatePeremption.DefaultCellStyle = dataGridViewCellStyle2;
            colDatePeremption.HeaderText = "Date Péremption";
            colDatePeremption.MinimumWidth = 6;
            colDatePeremption.Name = "colDatePeremption";
            colDatePeremption.ReadOnly = true;
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
            // MedicamentAlertForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1029, 667);
            Controls.Add(dgvAlerts);
            Controls.Add(titlePanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MedicamentAlertForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alertes - Médicaments en Alerte";
            Load += MedicamentAlertForm_Load;
            titlePanel.ResumeLayout(false);
            titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).EndInit();
            ResumeLayout(false);

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
