using GestionPharmacie.Models;
using GestionPharmacie.Data;

namespace GestionPharmacie.Forms
{
    public partial class MedicamentAlertForm : Form
    {
        private readonly MedicamentRepository _repository = new();

        public MedicamentAlertForm()
        {
            InitializeComponent();
            LoadAlerts();
        }

        private void MedicamentAlertForm_Load(object? sender, EventArgs e)
        {
            LoadAlerts();
        }

        private void DgvAlerts_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvAlerts.Rows[e.RowIndex].DataBoundItem is Medicament med)
            {
                if (med.DatePeremption <= DateTime.Now)
                {
                    dgvAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                }
                else if (med.DatePeremption <= DateTime.Now.AddMonths(1))
                {
                    dgvAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200);
                }
                else if (med.QuantiteStock <= med.Seuil)
                {
                    dgvAlerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
                }
            }
        }

        private void LoadAlerts()
        {
            try
            {
                var alerts = _repository.GetMedicamentsEnAlerte();
                dgvAlerts.DataSource = alerts;
                
                if (alerts.Count == 0)
                {
                    MessageBox.Show("Aucune alerte pour le moment!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
