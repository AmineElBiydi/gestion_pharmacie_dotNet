using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Controls
{
    public partial class MedicamentSearchControl : UserControl
    {
        private readonly MedicamentRepository _repository = new();

        public MedicamentSearchControl()
        {
            InitializeComponent();
            CreateControls();
            SearchMedicaments();
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
                Text = "Rechercher des Médicaments",
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
            cboCriteria.Items.AddRange(new object[] { "Tous", "Référence", "Nom" });
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

            var btnSearchAll = new Button
            {
                Text = "Afficher Tous",
                Location = new Point(810, 15),
                Size = new Size(150, 35)
            };
            StyleHelper.StyleButton(btnSearchAll);
            btnSearchAll.Click += BtnSearchAll_Click;

            searchPanel.Controls.AddRange(new Control[] { lblCriteria, cboCriteria, lblSearch, txtSearch, btnSearchAll });
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

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Reference", HeaderText = "Référence", Width = 150 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nom", HeaderText = "Nom", Width = 300 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DatePeremption", HeaderText = "Date Péremption", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrixUnitaire", HeaderText = "Prix (€)", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QuantiteStock", HeaderText = "Stock", Width = 100 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Seuil", HeaderText = "Seuil", Width = 100 });

            gridPanel.Controls.Add(dgvResults);
            container.Controls.Add(gridPanel);

            this.Controls.Add(container);
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            SearchMedicaments();
        }

        private void BtnSearchAll_Click(object? sender, EventArgs e)
        {
            var txtSearch = this.Controls.Find("txtSearch", true).FirstOrDefault() as TextBox;
            if (txtSearch != null)
            {
                txtSearch.Clear();
                SearchMedicaments();
            }
        }

        private void SearchMedicaments()
        {
            try
            {
                var txtSearch = this.Controls.Find("txtSearch", true).FirstOrDefault() as TextBox;
                var cboCriteria = this.Controls.Find("cboCriteria", true).FirstOrDefault() as ComboBox;
                var dgvResults = this.Controls.Find("dgvResults", true).FirstOrDefault() as DataGridView;

                if (dgvResults == null) return;

                var searchTerm = txtSearch?.Text ?? "";
                var criteria = cboCriteria?.SelectedItem?.ToString() ?? "Tous";

                List<Medicament> results;
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
            this.Name = "MedicamentSearchControl";
            this.Size = new Size(1200, 700);
            this.ResumeLayout(false);
        }
    }
}

