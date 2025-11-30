using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Controls
{
    public partial class ClientControl : UserControl
    {
        private readonly ClientRepository _repository = new();
        private Client? _currentClient;

        private TextBox txtNumero = null!;
        private TextBox txtNom = null!;
        private TextBox txtPrenom = null!;
        private TextBox txtAdresse = null!;
        private TextBox txtTelephone = null!;
        private DataGridView dgvClients = null!;

        public ClientControl()
        {
            InitializeComponent();
            CreateControls();
            LoadClients();
        }

        private void CreateControls()
        {
            this.BackColor = StyleHelper.LightGray;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            // Title
            var lblTitle = new Label
            {
                Text = "Gestion des Clients",
                Font = StyleHelper.HeadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            // Form Panel
            var formPanel = new Panel
            {
                Location = new Point(20, 70),
                Size = new Size(1150, 220),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(formPanel);

            int y = 20;
            int labelX = 20, textX = 180, width = 300;

            // Numero
            var lblNumero = new Label { Text = "Numéro Client:", Location = new Point(labelX, y), AutoSize = true };
            StyleHelper.StyleLabel(lblNumero);
            txtNumero = new TextBox { Location = new Point(textX, y - 3), Width = width, Font = StyleHelper.BodyFont };
            formPanel.Controls.AddRange(new Control[] { lblNumero, txtNumero });
            y += 45;

            // Nom
            var lblNom = new Label { Text = "Nom:", Location = new Point(labelX, y), AutoSize = true };
            StyleHelper.StyleLabel(lblNom);
            txtNom = new TextBox { Location = new Point(textX, y - 3), Width = width, Font = StyleHelper.BodyFont };
            formPanel.Controls.AddRange(new Control[] { lblNom, txtNom });
            y += 45;

            // Prenom
            var lblPrenom = new Label { Text = "Prénom:", Location = new Point(labelX, y), AutoSize = true };
            StyleHelper.StyleLabel(lblPrenom);
            txtPrenom = new TextBox { Location = new Point(textX, y - 3), Width = width, Font = StyleHelper.BodyFont };
            formPanel.Controls.AddRange(new Control[] { lblPrenom, txtPrenom });
            y += 45;

            // Adresse (right column)
            var lblAdresse = new Label { Text = "Adresse:", Location = new Point(550, 20), AutoSize = true };
            StyleHelper.StyleLabel(lblAdresse);
            txtAdresse = new TextBox { Location = new Point(650, 17), Width = 400, Font = StyleHelper.BodyFont };
            formPanel.Controls.AddRange(new Control[] { lblAdresse, txtAdresse });

            // Telephone
            var lblTelephone = new Label { Text = "Téléphone:", Location = new Point(550, 65), AutoSize = true };
            StyleHelper.StyleLabel(lblTelephone);
            txtTelephone = new TextBox { Location = new Point(650, 62), Width = 400, Font = StyleHelper.BodyFont };
            formPanel.Controls.AddRange(new Control[] { lblTelephone, txtTelephone });

            // Buttons
            var btnSave = new Button { Text = "Enregistrer", Location = new Point(550, 140), Size = new Size(120, 40) };
            StyleHelper.StyleButton(btnSave);
            btnSave.Click += BtnSave_Click;

            var btnNew = new Button { Text = "Nouveau", Location = new Point(680, 140), Size = new Size(120, 40) };
            StyleHelper.StyleButton(btnNew, StyleHelper.SecondaryColor);
            btnNew.Click += BtnNew_Click;

            var btnDelete = new Button { Text = "Supprimer", Location = new Point(810, 140), Size = new Size(120, 40) };
            StyleHelper.StyleButton(btnDelete, StyleHelper.DangerColor);
            btnDelete.Click += BtnDelete_Click;

            formPanel.Controls.AddRange(new Control[] { btnSave, btnNew, btnDelete });
            this.Controls.Add(formPanel);

            // DataGridView Panel
            var gridPanel = new Panel
            {
                Location = new Point(20, 310),
                Size = new Size(1150, 350),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(gridPanel);

            dgvClients = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(1130, 330),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Dock = DockStyle.Fill
            };
            StyleHelper.StyleDataGridView(dgvClients);

            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID", Width = 60 });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Numéro", Width = 150 });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nom", HeaderText = "Nom", Width = 200 });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Prenom", HeaderText = "Prénom", Width = 200 });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Adresse", HeaderText = "Adresse", Width = 250 });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telephone", HeaderText = "Téléphone", Width = 150 });

            dgvClients.SelectionChanged += DgvClients_SelectionChanged;

            gridPanel.Controls.Add(dgvClients);
            this.Controls.Add(gridPanel);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "ClientControl";
            this.Size = new Size(1200, 700);
            this.ResumeLayout(false);
        }
    }
}

