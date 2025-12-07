using GestionPharmacie.Data;
using GestionPharmacie.Models;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class PaymentManagerForm : Form
    {
        private readonly CommandeRepository _commandeRepo = new();
        private Commande _commande;

        public PaymentManagerForm(Commande commande)
        {
            _commande = commande;
            InitializeComponent();

            if (!DesignMode)
            {
                StyleHelper.ApplyFormTheme(this);
                LoadPaymentData();
            }
        }

        private void LoadPaymentData()
        {
            lblCommande.Text = $"Commande #{_commande.ID} - {_commande.ClientNom}";
            lblMontant.Text = $"Montant: {_commande.MontantTotal:N2} DH";
            chkEstPaye.Checked = _commande.EstPaye;

            if (!string.IsNullOrEmpty(_commande.TypePaiement))
            {
                var index = cboTypePaiement.Items.IndexOf(_commande.TypePaiement);
                if (index >= 0)
                {
                    cboTypePaiement.SelectedIndex = index;
                }
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                _commande.EstPaye = chkEstPaye.Checked;
                _commande.TypePaiement = cboTypePaiement.SelectedItem?.ToString();
                _commandeRepo.Update(_commande);

                MessageBox.Show("Paiement mis à jour avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
