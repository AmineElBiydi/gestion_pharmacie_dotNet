using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    partial class CommandeEditForm
    {
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private Panel container;
        private Label lblTitle;
        private Panel headerPanel;
        private Label lblClient;
        private ComboBox cboClient;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblStatut;
        private ComboBox cboStatut;
        private CheckBox chkEstPaye;
        private Label lblTypePaiement;
        private ComboBox cboTypePaiement;
        private Panel detailsPanel;
        private Label lblAddMed;
        private Label lblMed;
        private ComboBox cboMedicament;
        private Label lblQte;
        private NumericUpDown nudQuantite;
        private Button btnAdd;
        private Panel gridPanel;
        private DataGridView dgvDetails;
        private Panel footerPanel;
        private Label lblTotal;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            container = new Panel();
            lblTitle = new Label();
            headerPanel = new Panel();
            lblClient = new Label();
            cboClient = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblStatut = new Label();
            cboStatut = new ComboBox();
            chkEstPaye = new CheckBox();
            lblTypePaiement = new Label();
            cboTypePaiement = new ComboBox();
            detailsPanel = new Panel();
            lblAddMed = new Label();
            lblMed = new Label();
            cboMedicament = new ComboBox();
            lblQte = new Label();
            nudQuantite = new NumericUpDown();
            btnAdd = new Button();
            gridPanel = new Panel();
            dgvDetails = new DataGridView();
            colDelete = new DataGridViewButtonColumn();
            footerPanel = new Panel();
            lblTotal = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            container.SuspendLayout();
            headerPanel.SuspendLayout();
            detailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantite).BeginInit();
            gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            footerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // container
            // 
            container.Controls.Add(lblTitle);
            container.Controls.Add(headerPanel);
            container.Controls.Add(detailsPanel);
            container.Controls.Add(gridPanel);
            container.Controls.Add(footerPanel);
            container.Location = new Point(0, 0);
            container.Name = "container";
            container.Size = new Size(200, 100);
            container.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(lblClient);
            headerPanel.Controls.Add(cboClient);
            headerPanel.Controls.Add(lblDate);
            headerPanel.Controls.Add(dtpDate);
            headerPanel.Controls.Add(lblStatut);
            headerPanel.Controls.Add(cboStatut);
            headerPanel.Controls.Add(chkEstPaye);
            headerPanel.Controls.Add(lblTypePaiement);
            headerPanel.Controls.Add(cboTypePaiement);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(200, 100);
            headerPanel.TabIndex = 1;
            // 
            // lblClient
            // 
            lblClient.Location = new Point(0, 0);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(100, 23);
            lblClient.TabIndex = 0;
            // 
            // cboClient
            // 
            cboClient.Location = new Point(0, 0);
            cboClient.Name = "cboClient";
            cboClient.Size = new Size(121, 28);
            cboClient.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.Location = new Point(0, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 23);
            lblDate.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 27);
            dtpDate.TabIndex = 3;
            // 
            // lblStatut
            // 
            lblStatut.Location = new Point(0, 0);
            lblStatut.Name = "lblStatut";
            lblStatut.Size = new Size(100, 23);
            lblStatut.TabIndex = 4;
            // 
            // cboStatut
            // 
            cboStatut.Items.AddRange(new object[] { "En cours", "Livrée", "Annulée" });
            cboStatut.Location = new Point(0, 0);
            cboStatut.Name = "cboStatut";
            cboStatut.Size = new Size(121, 28);
            cboStatut.TabIndex = 5;
            // 
            // chkEstPaye
            // 
            chkEstPaye.Location = new Point(0, 0);
            chkEstPaye.Name = "chkEstPaye";
            chkEstPaye.Size = new Size(104, 24);
            chkEstPaye.TabIndex = 6;
            // 
            // lblTypePaiement
            // 
            lblTypePaiement.Location = new Point(0, 0);
            lblTypePaiement.Name = "lblTypePaiement";
            lblTypePaiement.Size = new Size(100, 23);
            lblTypePaiement.TabIndex = 7;
            // 
            // cboTypePaiement
            // 
            cboTypePaiement.Items.AddRange(new object[] { "", "Espèces", "Carte Bancaire", "Chèque", "Virement", "Autre" });
            cboTypePaiement.Location = new Point(0, 0);
            cboTypePaiement.Name = "cboTypePaiement";
            cboTypePaiement.Size = new Size(121, 28);
            cboTypePaiement.TabIndex = 8;
            // 
            // detailsPanel
            // 
            detailsPanel.Controls.Add(lblAddMed);
            detailsPanel.Controls.Add(lblMed);
            detailsPanel.Controls.Add(cboMedicament);
            detailsPanel.Controls.Add(lblQte);
            detailsPanel.Controls.Add(nudQuantite);
            detailsPanel.Controls.Add(btnAdd);
            detailsPanel.Location = new Point(0, 0);
            detailsPanel.Name = "detailsPanel";
            detailsPanel.Size = new Size(200, 100);
            detailsPanel.TabIndex = 2;
            // 
            // lblAddMed
            // 
            lblAddMed.Location = new Point(0, 0);
            lblAddMed.Name = "lblAddMed";
            lblAddMed.Size = new Size(100, 23);
            lblAddMed.TabIndex = 0;
            // 
            // lblMed
            // 
            lblMed.Location = new Point(0, 0);
            lblMed.Name = "lblMed";
            lblMed.Size = new Size(100, 23);
            lblMed.TabIndex = 1;
            // 
            // cboMedicament
            // 
            cboMedicament.Location = new Point(0, 0);
            cboMedicament.Name = "cboMedicament";
            cboMedicament.Size = new Size(121, 28);
            cboMedicament.TabIndex = 2;
            // 
            // lblQte
            // 
            lblQte.Location = new Point(0, 0);
            lblQte.Name = "lblQte";
            lblQte.Size = new Size(100, 23);
            lblQte.TabIndex = 3;
            // 
            // nudQuantite
            // 
            nudQuantite.Location = new Point(0, 0);
            nudQuantite.Name = "nudQuantite";
            nudQuantite.Size = new Size(120, 27);
            nudQuantite.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Click += BtnAddDetail_Click;
            // 
            // gridPanel
            // 
            gridPanel.Controls.Add(dgvDetails);
            gridPanel.Location = new Point(0, 0);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(200, 100);
            gridPanel.TabIndex = 3;
            // 
            // dgvDetails
            // 
            dgvDetails.ColumnHeadersHeight = 29;
            dgvDetails.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, colDelete });
            dgvDetails.Location = new Point(0, 0);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.Size = new Size(240, 150);
            dgvDetails.TabIndex = 0;
            dgvDetails.CellClick += DgvDetails_CellClick;
            // 
            // colDelete
            // 
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.Width = 125;
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(lblTotal);
            footerPanel.Controls.Add(btnSave);
            footerPanel.Controls.Add(btnCancel);
            footerPanel.Location = new Point(0, 0);
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(200, 100);
            footerPanel.TabIndex = 4;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(0, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 23);
            lblTotal.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Click += BtnCancel_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // CommandeEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1200, 800);
            Controls.Add(container);
            Name = "CommandeEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modifier Commande";
            container.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            detailsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudQuantite).EndInit();
            gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            footerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewButtonColumn colDelete;
    }
}
