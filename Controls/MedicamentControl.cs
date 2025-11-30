using GestionPharmacie.Models;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Controls
{
    public partial class MedicamentControl : UserControl
    {
        private readonly MedicamentRepository _repository = new();
        private Medicament? _currentMedicament;

        private TextBox txtReference = null!;
        private TextBox txtNom = null!;
        private DateTimePicker dtpDatePeremption = null!;
        private NumericUpDown nudPrixUnitaire = null!;
        private NumericUpDown nudQuantiteStock = null!;
        private NumericUpDown nudSeuil = null!;
        private DataGridView dgvMedicaments = null!;

        public MedicamentControl()
        {
            InitializeComponent();
            CreateControls();
            LoadMedicaments();
        }

        private void CreateControls()
        {
            this.BackColor = StyleHelper.BackgroundColor;
            this.Dock = DockStyle.Fill;

            // Title and Dashboard Button
            var titlePanel = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(950, 40),
                BackColor = Color.Transparent
            };

            var lblTitle = new Label
            {
                Text = "Gestion des Médicaments",
                Font = StyleHelper.HeadingFont,
                ForeColor = StyleHelper.PrimaryColor,
                Location = new Point(0, 0),
                AutoSize = true
            };
            titlePanel.Controls.Add(lblTitle);

            var btnDashboard = new Button
            {
                Text = "📊 Tableau de bord",
                Font = StyleHelper.BodyFont,
                Location = new Point(750, 0),
                Size = new Size(200, 35),
                Cursor = Cursors.Hand
            };
            StyleHelper.StyleButton(btnDashboard, StyleHelper.AccentPurple);
            btnDashboard.Click += (s, e) =>
            {
                if (this.ParentForm is Form1 form1)
                {
                    form1.LoadControl(new DashboardControl());
                }
            };
            titlePanel.Controls.Add(btnDashboard);
            this.Controls.Add(titlePanel);

            // Form Panel
            var formPanel = new Panel
            {
                Location = new Point(20, 80),
                Size = new Size(950, 220),
                BackColor = StyleHelper.SurfaceColor
            };
            StyleHelper.StylePanel(formPanel);

            // Labels and TextBoxes
            int y = 20;
            int labelX = 20, textX = 180, width = 250;

            AddFormField(formPanel, "Référence:", ref txtReference, y);
            y += 45;
            AddFormField(formPanel, "Nom:", ref txtNom, y);
            y += 45;

            // Date Peremption
            var lblDate = new Label { Text = "Date de Péremption:", Location = new Point(labelX, y), AutoSize = true };
            StyleHelper.StyleLabel(lblDate);
            dtpDatePeremption = new DateTimePicker { Location = new Point(textX, y), Width = width, Font = StyleHelper.BodyFont };
            formPanel.Controls.AddRange(new Control[] { lblDate, dtpDatePeremption });
            y += 45;

            // Prix Unitaire
            var lblPrix = new Label { Text = "Prix Unitaire (€):", Location = new Point(labelX, y), AutoSize = true };
            StyleHelper.StyleLabel(lblPrix);
            nudPrixUnitaire = new NumericUpDown
            {
                Location = new Point(textX, y),
                Width = width,
                DecimalPlaces = 2,
                Maximum = 100000,
                Minimum = 0,
                Font = StyleHelper.BodyFont
            };
            formPanel.Controls.AddRange(new Control[] { lblPrix, nudPrixUnitaire });

            // Quantite Stock (right column)
            var lblQte = new Label { Text = "Quantité en Stock:", Location = new Point(500, 20), AutoSize = true };
            StyleHelper.StyleLabel(lblQte);
            nudQuantiteStock = new NumericUpDown
            {
                Location = new Point(660, 20),
                Width = 200,
                Maximum = 100000,
                Minimum = 0,
                Font = StyleHelper.BodyFont
            };
            formPanel.Controls.AddRange(new Control[] { lblQte, nudQuantiteStock });

            // Seuil
            var lblSeuil = new Label { Text = "Seuil d'Alerte:", Location = new Point(500, 65), AutoSize = true };
            StyleHelper.StyleLabel(lblSeuil);
            nudSeuil = new NumericUpDown
            {
                Location = new Point(660, 65),
                Width = 200,
                Maximum = 10000,
                Minimum = 0,
                Value = 10,
                Font = StyleHelper.BodyFont
            };
            formPanel.Controls.AddRange(new Control[] { lblSeuil, nudSeuil });

            // Buttons
            var btnSave = new Button { Text = "Enregistrer", Location = new Point(500, 140), Size = new Size(120, 40) };
            StyleHelper.StyleButton(btnSave);
            btnSave.Click += BtnSave_Click;
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = StyleHelper.PrimaryDark;
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = StyleHelper.PrimaryColor;

            var btnNew = new Button { Text = "Nouveau", Location = new Point(630, 140), Size = new Size(120, 40) };
            StyleHelper.StyleButton(btnNew, StyleHelper.SecondaryColor);
            btnNew.Click += (s, e) => ClearForm();
            btnNew.MouseEnter += (s, e) => btnNew.BackColor = StyleHelper.PrimaryColor;
            btnNew.MouseLeave += (s, e) => btnNew.BackColor = StyleHelper.SecondaryColor;

            var btnDelete = new Button { Text = "Supprimer", Location = new Point(760, 140), Size = new Size(120, 40) };
            StyleHelper.StyleButton(btnDelete, StyleHelper.DangerColor);
            btnDelete.Click += BtnDelete_Click;
            btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = Color.FromArgb(192, 57, 43);
            btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = StyleHelper.DangerColor;

            formPanel.Controls.AddRange(new Control[] { btnSave, btnNew, btnDelete });
            this.Controls.Add(formPanel);

            // DataGridView Panel
            var gridPanel = new Panel
            {
                Location = new Point(20, 310),
                Size = new Size(950, 270),
                BackColor = StyleHelper.SurfaceColor
            };
            StyleHelper.StylePanel(gridPanel);

            dgvMedicaments = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(930, 250),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            StyleHelper.StyleDataGridView(dgvMedicaments);

            dgvMedicaments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID", Width = 50 });
            dgvMedicaments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Reference", HeaderText = "Référence", Width = 100 });
            dgvMedicaments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nom", HeaderText = "Nom", Width = 200 });
            dgvMedicaments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DatePeremption", HeaderText = "Date Péremption", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvMedicaments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrixUnitaire", HeaderText = "Prix (€)", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvMedicaments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QuantiteStock", HeaderText = "Stock", Width = 80 });
            dgvMedicaments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Seuil", HeaderText = "Seuil", Width = 80 });

            dgvMedicaments.SelectionChanged += DgvMedicaments_SelectionChanged;

            gridPanel.Controls.Add(dgvMedicaments);
            this.Controls.Add(gridPanel);
        }

        private void AddFormField(Panel panel, string label, ref TextBox textBox, int y)
        {
            var lbl = new Label { Text = label, Location = new Point(20, y), AutoSize = true };
            StyleHelper.StyleLabel(lbl);
            textBox = new TextBox { Location = new Point(180, y), Width = 250, Font = StyleHelper.BodyFont };
            panel.Controls.AddRange(new Control[] { lbl, textBox });
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

            var result = MessageBox.Show($"Voulez-vous vraiment supprimer le médicament '{_currentMedicament.Nom}'?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _repository.Delete(_currentMedicament.ID);
                    MessageBox.Show("Médicament supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMedicaments();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "MedicamentControl";
            this.Size = new Size(1000, 600);
            this.ResumeLayout(false);
        }
    }
}
