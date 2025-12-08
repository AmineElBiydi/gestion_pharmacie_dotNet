namespace GestionPharmacie.Forms
{
    partial class MedicamentSuppliersDialog
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
            panel = new Panel();
            lblTitle = new Label();
            dgvSuppliers = new DataGridView();
            colNom = new DataGridViewTextBoxColumn();
            colTelephone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPrixAchat = new DataGridViewTextBoxColumn();
            colDelai = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = Color.White;
            panel.Dock = DockStyle.Fill;
            panel.Padding = new Padding(20);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(dgvSuppliers);
            panel.Controls.Add(btnClose);
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(700, 450);
            panel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 126, 167);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(660, 30);
            lblTitle.Text = "Fournisseurs Disponibles";
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.AllowUserToDeleteRows = false;
            dgvSuppliers.BackgroundColor = Color.White;
            dgvSuppliers.BorderStyle = BorderStyle.None;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 126, 167);
            dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvSuppliers.ColumnHeadersHeight = 40;
            dgvSuppliers.Columns.AddRange(new DataGridViewColumn[] {
                colNom, colTelephone, colEmail, colPrixAchat, colDelai });
            dgvSuppliers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgvSuppliers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvSuppliers.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvSuppliers.DefaultCellStyle.Padding = new Padding(5);
            dgvSuppliers.EnableHeadersVisualStyles = false;
            dgvSuppliers.Location = new Point(20, 60);
            dgvSuppliers.MultiSelect = false;
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.ReadOnly = true;
            dgvSuppliers.RowHeadersVisible = false;
            dgvSuppliers.RowTemplate.Height = 35;
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.Size = new Size(660, 320);
            dgvSuppliers.TabIndex = 1;
            // 
            // colNom
            // 
            colNom.DataPropertyName = "FournisseurNom";
            colNom.HeaderText = "Fournisseur";
            colNom.Name = "colNom";
            colNom.ReadOnly = true;
            colNom.Width = 200;
            // 
            // colTelephone
            // 
            colTelephone.DataPropertyName = "FournisseurTelephone";
            colTelephone.HeaderText = "Téléphone";
            colTelephone.Name = "colTelephone";
            colTelephone.ReadOnly = true;
            colTelephone.Width = 140;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "FournisseurEmail";
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 180;
            // 
            // colPrixAchat
            // 
            colPrixAchat.DataPropertyName = "PrixInfo";
            colPrixAchat.HeaderText = "Prix d'Achat";
            colPrixAchat.Name = "colPrixAchat";
            colPrixAchat.ReadOnly = true;
            colPrixAchat.Width = 100;
            // 
            // colDelai
            // 
            colDelai.DataPropertyName = "DelaiLivraison";
            colDelai.HeaderText = "Délai (jours)";
            colDelai.Name = "colDelai";
            colDelai.ReadOnly = true;
            colDelai.Width = 100;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(0, 126, 167);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(280, 390);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "Fermer";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += BtnClose_Click;
            // 
            // MedicamentSuppliersDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MedicamentSuppliersDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Fournisseurs";
            panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Label lblTitle;
        private DataGridView dgvSuppliers;
        private DataGridViewTextBoxColumn colNom;
        private DataGridViewTextBoxColumn colTelephone;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPrixAchat;
        private DataGridViewTextBoxColumn colDelai;
        private Button btnClose;
    }
}
