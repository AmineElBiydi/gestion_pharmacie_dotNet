using GestionPharmacie.Models;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class MedicamentSuppliersDialog : Form
    {
        public MedicamentSuppliersDialog(string medicamentNom, List<MedicamentFournisseur> suppliers)
        {
            InitializeComponent();

            if (!DesignMode)
            {
                StyleHelper.ApplyFormTheme(this);
            }

            lblTitle.Text = $"Fournisseurs - {medicamentNom}";
            dgvSuppliers.DataSource = suppliers;

            // Apply alternating row colors for better readability
            dgvSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
