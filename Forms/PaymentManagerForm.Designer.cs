namespace GestionPharmacie.Forms
{
    partial class PaymentManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel = new Panel();
            lblCommande = new Label();
            lblMontant = new Label();
            chkEstPaye = new CheckBox();
            lblTypePaiement = new Label();
            cboTypePaiement = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Dock = DockStyle.Fill;
            panel.Padding = new Padding(20);
            panel.BackColor = Color.White;
            panel.Controls.Add(lblCommande);
            panel.Controls.Add(lblMontant);
            panel.Controls.Add(chkEstPaye);
            panel.Controls.Add(lblTypePaiement);
            panel.Controls.Add(cboTypePaiement);
            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnCancel);
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(500, 300);
            panel.TabIndex = 0;
            // 
            // lblCommande
            // 
            lblCommande.Text = "";
            lblCommande.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCommande.ForeColor = Color.FromArgb(66, 133, 244);
            lblCommande.Location = new Point(20, 20);
            lblCommande.AutoSize = true;
            lblCommande.Name = "lblCommande";
            lblCommande.TabIndex = 0;
            // 
            // lblMontant
            // 
            lblMontant.Text = "";
            lblMontant.Font = new Font("Segoe UI", 10F);
            lblMontant.Location = new Point(20, 60);
            lblMontant.AutoSize = true;
            lblMontant.Name = "lblMontant";
            lblMontant.TabIndex = 1;
            // 
            // chkEstPaye
            // 
            chkEstPaye.Text = "Facture Payée";
            chkEstPaye.Location = new Point(20, 100);
            chkEstPaye.Font = new Font("Segoe UI", 10F);
            chkEstPaye.Name = "chkEstPaye";
            chkEstPaye.AutoSize = true;
            chkEstPaye.TabIndex = 0;
            // 
            // lblTypePaiement
            // 
            lblTypePaiement.Text = "Type de Paiement:";
            lblTypePaiement.Location = new Point(20, 140);
            lblTypePaiement.AutoSize = true;
            lblTypePaiement.Font = new Font("Segoe UI", 10F);
            lblTypePaiement.Name = "lblTypePaiement";
            lblTypePaiement.TabIndex = 4;
            // 
            // cboTypePaiement
            // 
            cboTypePaiement.Location = new Point(20, 165);
            cboTypePaiement.Size = new Size(400, 30);
            cboTypePaiement.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTypePaiement.Font = new Font("Segoe UI", 10F);
            cboTypePaiement.Name = "cboTypePaiement";
            cboTypePaiement.TabIndex = 1;
            cboTypePaiement.Items.AddRange(new object[] { "", "Espèces", "Carte Bancaire", "Chèque", "Virement", "Autre" });
            // 
            // btnSave
            // 
            btnSave.Text = "Enregistrer";
            btnSave.Location = new Point(200, 220);
            btnSave.Size = new Size(120, 35);
            btnSave.BackColor = Color.FromArgb(66, 133, 244);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Name = "btnSave";
            btnSave.TabIndex = 2;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Text = "Annuler";
            btnCancel.Location = new Point(330, 220);
            btnCancel.Size = new Size(120, 35);
            btnCancel.BackColor = Color.FromArgb(117, 117, 117);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Name = "btnCancel";
            btnCancel.TabIndex = 3;
            btnCancel.Click += BtnCancel_Click;
            // 
            // PaymentManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 300);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentManagerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestion du Paiement";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Label lblCommande;
        private Label lblMontant;
        private CheckBox chkEstPaye;
        private Label lblTypePaiement;
        private ComboBox cboTypePaiement;
        private Button btnSave;
        private Button btnCancel;
    }
}
