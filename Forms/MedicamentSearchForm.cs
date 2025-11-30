using GestionPharmacie.Models;
using GestionPharmacie.Data;

namespace GestionPharmacie.Forms
{
    public partial class MedicamentSearchForm : Form
    {
        private readonly MedicamentRepository _repository = new();

        public MedicamentSearchForm()
        {
            InitializeComponent();
            SearchMedicaments();
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            SearchMedicaments();
        }

        private void BtnSearchAll_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            SearchMedicaments();
        }

        private void SearchMedicaments()
        {
            try
            {
                var results = string.IsNullOrWhiteSpace(txtSearch.Text)
                    ? _repository.GetAll()
                    : _repository.Search(txtSearch.Text);

                dgvResults.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
