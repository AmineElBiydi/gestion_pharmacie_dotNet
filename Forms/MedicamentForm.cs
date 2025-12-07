using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class MedicamentForm : Form
    {
        private readonly MedicamentRepository _repository = new();
        private Medicament? _currentMedicament;

        public MedicamentForm()
        {
            InitializeComponent();
            StyleHelper.ApplyFormTheme(this);
            LoadMedicaments();
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadMedicaments()
        {
            try
            {
                var medicaments = _repository.GetAll();
                dgvMedicaments.DataSource = medicaments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvMedicaments_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvMedicaments.CurrentRow?.DataBoundItem is Medicament med)
            {
                _currentMedicament = med;
                txtReference.Text = med.Reference;
                txtNom.Text = med.Nom;
                dtpDatePeremption.Value = med.DatePeremption;
                nudPrixUnitaire.Value = med.PrixUnitaire;
                nudQuantiteStock.Value = med.QuantiteStock;
                nudSeuil.Value = med.Seuil;
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtReference.Text) || string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var medicament = new Medicament
                {
                    Reference = txtReference.Text.Trim(),
                    Nom = txtNom.Text.Trim(),
                    DatePeremption = dtpDatePeremption.Value,
                    PrixUnitaire = nudPrixUnitaire.Value,
                    QuantiteStock = (int)nudQuantiteStock.Value,
                    Seuil = (int)nudSeuil.Value
                };

                if (_currentMedicament != null)
                {
                    medicament.ID = _currentMedicament.ID;
                    _repository.Update(medicament);
                    MessageBox.Show("Médicament modifié avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _repository.Insert(medicament);
                    MessageBox.Show("Médicament ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadMedicaments();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_currentMedicament == null)
            {
                MessageBox.Show("Veuillez sélectionner un médicament à supprimer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Voulez-vous vraiment bloquer le médicament '{_currentMedicament.Nom}'?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _repository.Delete(_currentMedicament.ID);
                    MessageBox.Show("Médicament bloquer avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMedicaments();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la bloquage: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            _currentMedicament = null;
            txtReference.Clear();
            txtNom.Clear();
            dtpDatePeremption.Value = DateTime.Now.AddYears(1);
            nudPrixUnitaire.Value = 0;
            nudQuantiteStock.Value = 0;
            nudSeuil.Value = 10;
            dgvMedicaments.ClearSelection();
        }

        private void MedicamentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
