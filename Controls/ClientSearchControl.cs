using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Controls
{
    public partial class ClientSearchControl : UserControl
    {
        private readonly ClientRepository _repository = new();

        public ClientSearchControl()
        {
            InitializeComponent();
            CreateControls();
            SearchClients();
        }

        private void CreateControls()
        {
            this.BackColor = StyleHelper.LightGray;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            // Main container
            var container = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = StyleHelper.LightGray,
                Padding = new Padding(20)
            };

            // Title
            var lblTitle = new Label
            {
                Text = "Rechercher des Clients",
                Font = StyleHelper.HeadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(0, 0),
                AutoSize = true
            };
            container.Controls.Add(lblTitle);

            // Search Panel
            var searchPanel = new Panel
            {
                Location = new Point(0, 50),
                Size = new Size(1100, 90),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(searchPanel);

            var lblCriteria = new Label
            {
                Text = "Critère:",
                Font = StyleHelper.BodyFont,
                Location = new Point(20, 20),
                AutoSize = true
            };
            StyleHelper.StyleLabel(lblCriteria);

            var cboCriteria = new ComboBox
            {
                Name = "cboCriteria",
                Location = new Point(120, 17),
                Size = new Size(150, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = StyleHelper.BodyFont
            };
            cboCriteria.Items.AddRange(new object[] { "Tous", "Numéro", "Nom", "Prénom", "Téléphone" });
            cboCriteria.SelectedIndex = 0;

            var lblSearch = new Label
            {
                Text = "Rechercher:",
                Font = StyleHelper.BodyFont,
                Location = new Point(290, 20),
                AutoSize = true
            };
            StyleHelper.StyleLabel(lblSearch);

            var txtSearch = new TextBox
            {
                Name = "txtSearch",
                Location = new Point(390, 17),
                Size = new Size(400, 30),
                Font = StyleHelper.BodyFont
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            var btnSearch = new Button
            {
                Text = "Rechercher",
                Location = new Point(810, 15),
                Size = new Size(150, 35)
            };
            StyleHelper.StyleButton(btnSearch);
            btnSearch.Click += BtnSearch_Click;

            searchPanel.Controls.AddRange(new Control[] { lblCriteria, cboCriteria, lblSearch, txtSearch, btnSearch });
            container.Controls.Add(searchPanel);

            // Results Grid
            var gridPanel = new Panel
            {
                Location = new Point(0, 160),
                Size = new Size(1100, 480),
                BackColor = StyleHelper.White
            };
            StyleHelper.StylePanel(gridPanel);

            var dgvResults = new DataGridView
            {
                Name = "dgvResults",
                Location = new Point(10, 10),
                Size = new Size(1080, 460),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Dock = DockStyle.Fill
            };
            StyleHelper.StyleDataGridView(dgvResults);

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID", Width = 60 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Numéro", Width = 150 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nom", HeaderText = "Nom", Width = 200 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Prenom", HeaderText = "Prénom", Width = 200 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Adresse", HeaderText = "Adresse", Width = 250 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telephone", HeaderText = "Téléphone", Width = 150 });

            gridPanel.Controls.Add(dgvResults);
            container.Controls.Add(gridPanel);

            this.Controls.Add(container);
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            SearchClients();
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchClients();
        }

        private void SearchClients()
        {
            try
            {
                var txtSearch = this.Controls.Find("txtSearch", true).FirstOrDefault() as TextBox;
                var cboCriteria = this.Controls.Find("cboCriteria", true).FirstOrDefault() as ComboBox;
                var dgvResults = this.Controls.Find("dgvResults", true).FirstOrDefault() as DataGridView;

                if (dgvResults == null) return;

                var searchTerm = txtSearch?.Text ?? "";
                var criteria = cboCriteria?.SelectedItem?.ToString() ?? "Tous";

                List<Client> results;
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    results = _repository.GetAll();
                }
                else
                {
                    results = _repository.SearchByCriteria(searchTerm, criteria);
                }

                dgvResults.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "ClientSearchControl";
            this.Size = new Size(1200, 700);
            this.ResumeLayout(false);
        }
    }
}

