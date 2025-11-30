using GestionPharmacie.Models;
using GestionPharmacie.Data;

namespace GestionPharmacie.Forms
{
    public partial class ClientForm : Form
    {
        private readonly ClientRepository _repository = new();
        private Client? _currentClient;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object? sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                var clients = _repository.GetAll();
                dgvClients.DataSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvClients_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvClients.CurrentRow?.DataBoundItem is Client client)
            {
                _currentClient = client;
                txtNumero.Text = client.Numero;
                txtNom.Text = client.Nom;
                txtPrenom.Text = client.Prenom;
                txtAdresse.Text = client.Adresse ?? "";
                txtTelephone.Text = client.Telephone ?? "";
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumero.Text) || string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var client = new Client
                {
                    Numero = txtNumero.Text.Trim(),
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    Adresse = txtAdresse.Text.Trim(),
                    Telephone = txtTelephone.Text.Trim()
                };

                if (_currentClient != null)
                {
                    client.ID = _currentClient.ID;
                    _repository.Update(client);
                    MessageBox.Show("Client modifié avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _repository.Insert(client);
                    MessageBox.Show("Client ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadClients();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_currentClient == null)
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Voulez-vous vraiment supprimer le client '{_currentClient.NomComplet}'?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _repository.Delete(_currentClient.ID);
                    MessageBox.Show("Client supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClients();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            _currentClient = null;
            txtNumero.Clear();
            txtNom.Clear();
            txtPrenom.Clear();
            txtAdresse.Clear();
            txtTelephone.Clear();
            dgvClients.ClearSelection();
        }
    }
}
