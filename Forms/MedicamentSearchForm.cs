using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class MedicamentSearchForm : Form
    {
        private readonly MedicamentRepository _repository = new();
        private ComboBox cboCriteria = null!;

        public MedicamentSearchForm()
        {
            InitializeComponent();
            InitializeCustomControls();
            StyleHelper.ApplyFormTheme(this);
            SearchMedicaments();
        }

        private void InitializeCustomControls()
        {
            // Add Criteria ComboBox
            var lblCriteria = new Label
            {
                Text = "Critère:",
                Font = StyleHelper.BodyFont,
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblCriteria);

            cboCriteria = new ComboBox
            {
                Name = "cboCriteria",
                Location = new Point(120, 17),
                Size = new Size(150, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = StyleHelper.BodyFont
            };
            cboCriteria.Items.AddRange(new object[] { "Tous", "Référence", "Nom" });
            cboCriteria.SelectedIndex = 0;
            this.Controls.Add(cboCriteria);

            // Adjust existing controls positions
            if (txtSearch != null)
            {
                txtSearch.Location = new Point(390, 17);
                txtSearch.Size = new Size(400, 30);
                
                var lblSearch = new Label
                {
                    Text = "Rechercher:",
                    Font = StyleHelper.BodyFont,
                    Location = new Point(290, 20),
                    AutoSize = true
                };
                this.Controls.Add(lblSearch);
            }

            if (btnSearchAll != null)
            {
                btnSearchAll.Location = new Point(810, 15);
            }
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
    }
}
