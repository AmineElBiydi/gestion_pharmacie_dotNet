namespace GestionPharmacie.Forms
{
    partial class ClientForm
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
            formPanel = new Panel();
            btnDelete = new Button();
            btnNew = new Button();
            btnSave = new Button();
            txtTelephone = new TextBox();
            lblTelephone = new Label();
            txtAdresse = new TextBox();
            lblAdresse = new Label();
            txtPrenom = new TextBox();
            lblPrenom = new Label();
            txtNom = new TextBox();
            lblNom = new Label();
            dgvClients = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colNumero = new DataGridViewTextBoxColumn();
            colNom = new DataGridViewTextBoxColumn();
            colPrenom = new DataGridViewTextBoxColumn();
            colAdresse = new DataGridViewTextBoxColumn();
            colTelephone = new DataGridViewTextBoxColumn();
            lblNumero = new Label();
            txtNumero = new TextBox();
            formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // formPanel
            // 
            formPanel.BorderStyle = BorderStyle.FixedSingle;
            formPanel.Controls.Add(btnDelete);
            formPanel.Controls.Add(btnNew);
            formPanel.Controls.Add(btnSave);
            formPanel.Controls.Add(txtTelephone);
            formPanel.Controls.Add(lblTelephone);
            formPanel.Controls.Add(txtAdresse);
            formPanel.Controls.Add(lblAdresse);
            formPanel.Controls.Add(txtPrenom);
            formPanel.Controls.Add(lblPrenom);
            formPanel.Controls.Add(txtNom);
            formPanel.Controls.Add(lblNom);
            formPanel.Controls.Add(txtNumero);
            formPanel.Controls.Add(lblNumero);
            formPanel.Dock = DockStyle.Top;
            formPanel.Location = new Point(0, 0);
            formPanel.Margin = new Padding(3, 4, 3, 4);
            formPanel.Name = "formPanel";
            formPanel.Padding = new Padding(11, 13, 11, 13);
            formPanel.Size = new Size(1029, 293);
            formPanel.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 83, 80);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(826, 129);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 40);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Supprimer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(100, 181, 246);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(700, 129);
            btnNew.Margin = new Padding(3, 4, 3, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(114, 40);
            btnNew.TabIndex = 6;
            btnNew.Text = "Nouveau";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += BtnNew_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(66, 133, 244);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(574, 129);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 40);
            btnSave.TabIndex = 5;
            btnSave.Text = "Enregistrer";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new Point(171, 240);
            txtTelephone.Margin = new Padding(3, 4, 3, 4);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(342, 27);
            txtTelephone.TabIndex = 4;
            // 
            // lblTelephone
            // 
            lblTelephone.AutoSize = true;
            lblTelephone.Location = new Point(23, 244);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(81, 20);
            lblTelephone.TabIndex = 9;
            lblTelephone.Text = "Téléphone:";
            // 
            // txtAdresse
            // 
            txtAdresse.Location = new Point(171, 187);
            txtAdresse.Margin = new Padding(3, 4, 3, 4);
            txtAdresse.Name = "txtAdresse";
            txtAdresse.Size = new Size(342, 27);
            txtAdresse.TabIndex = 3;
            // 
            // lblAdresse
            // 
            lblAdresse.AutoSize = true;
            lblAdresse.Location = new Point(23, 191);
            lblAdresse.Name = "lblAdresse";
            lblAdresse.Size = new Size(64, 20);
            lblAdresse.TabIndex = 7;
            lblAdresse.Text = "Adresse:";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(171, 133);
            txtPrenom.Margin = new Padding(3, 4, 3, 4);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(342, 27);
            txtPrenom.TabIndex = 2;
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Location = new Point(23, 137);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(63, 20);
            lblPrenom.TabIndex = 5;
            lblPrenom.Text = "Prénom:";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(171, 80);
            txtNom.Margin = new Padding(3, 4, 3, 4);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(342, 27);
            txtNom.TabIndex = 1;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(23, 84);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(45, 20);
            lblNom.TabIndex = 3;
            lblNom.Text = "Nom:";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(23, 31);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(108, 20);
            lblNumero.TabIndex = 1;
            lblNumero.Text = "Numéro Client:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(171, 27);
            txtNumero.Margin = new Padding(3, 4, 3, 4);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(342, 27);
            txtNumero.TabIndex = 0;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.BackgroundColor = Color.White;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Columns.AddRange(new DataGridViewColumn[] { colID, colNumero, colNom, colPrenom, colAdresse, colTelephone });
            dgvClients.Dock = DockStyle.Fill;
            dgvClients.Location = new Point(0, 293);
            dgvClients.Margin = new Padding(3, 4, 3, 4);
            dgvClients.MultiSelect = false;
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.RowTemplate.Height = 25;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(1029, 507);
            dgvClients.TabIndex = 1;
            dgvClients.SelectionChanged += DgvClients_SelectionChanged;
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
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 800);
            Controls.Add(dgvClients);
            Controls.Add(formPanel);
            Name = "ClientForm";
            Text = "Gestion des Clients";
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Label lblAdresse;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNumero;
    }
}
