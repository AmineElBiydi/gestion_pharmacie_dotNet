using GestionPharmacie.Models;
using GestionPharmacie.Data;

namespace GestionPharmacie.Forms
{
    public partial class ClientSearchForm : Form
    {
        private readonly ClientRepository _repository = new();

        public ClientSearchForm()
        {
            InitializeComponent();
            txtSearch.TextChanged += (s, e) => SearchClients();
            SearchClients(); // Load all clients initially
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchClients();
        }

        private void SearchClients()
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
