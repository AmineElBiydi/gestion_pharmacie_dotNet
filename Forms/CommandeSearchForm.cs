using GestionPharmacie.Models;
using GestionPharmacie.Data;
using System.Drawing.Printing;
using System.Text;
using GestionPharmacie.Utils;

namespace GestionPharmacie.Forms
{
    public partial class CommandeSearchForm : Form
    {
        private readonly CommandeRepository _commandeRepo = new();
        private readonly ClientRepository _clientRepo = new();
        private Commande? _selectedCommande;

        public CommandeSearchForm()
        {
            InitializeComponent();
            StyleHelper.ApplyFormTheme(this);
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            
            // Add extra columns if they don't exist (Modify, Payment, Print)
            SetupGridColumns();
        }

        private void SetupGridColumns()
        {
            // Payment status column
            if (!dgvCommandes.Columns.Contains("EstPaye"))
            {
                var colPaye = new DataGridViewCheckBoxColumn
                {
                    Name = "EstPaye",
                    HeaderText = "Payé",
                    DataPropertyName = "EstPaye",
                    Width = 80
                };
                dgvCommandes.Columns.Add(colPaye);
            }
            
            // Payment type column
            if (!dgvCommandes.Columns.Contains("TypePaiement"))
            {
                dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn { Name = "TypePaiement", DataPropertyName = "TypePaiement", HeaderText = "Type Paiement", Width = 120 });
            }

            if (!dgvCommandes.Columns.Contains("colModify"))
            {
                var colModify = new DataGridViewButtonColumn
                {
                    Name = "colModify",
                    HeaderText = "Modifier",
                    Text = "Modifier",
                    UseColumnTextForButtonValue = true,
                    Width = 100
                };
                dgvCommandes.Columns.Add(colModify);
            }

            if (!dgvCommandes.Columns.Contains("colPayment"))
            {
                var colPayment = new DataGridViewButtonColumn
                {
                    Name = "colPayment",
                    HeaderText = "Paiement",
                    Text = "Gérer",
                    UseColumnTextForButtonValue = true,
                    Width = 100
                };
                dgvCommandes.Columns.Add(colPayment);
            }

            if (!dgvCommandes.Columns.Contains("colPrint"))
            {
                var colPrint = new DataGridViewButtonColumn
                {
                    Name = "colPrint",
                    HeaderText = "Imprimer",
                    Text = "Imprimer",
                    UseColumnTextForButtonValue = true,
                    Width = 100
                };
                dgvCommandes.Columns.Add(colPrint);
            }
        }

        private void CommandeSearchForm_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var allClients = new List<Client> { new Client { ID = 0, Nom = "Tous", Prenom = "" } };
                allClients.AddRange(_clientRepo.GetAll());
                
                cboClient.DataSource = allClients;
                cboClient.DisplayMember = "NomComplet";
                cboClient.ValueMember = "ID";

                LoadAllCommandes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllCommandes()
        {
            try
            {
                var commandes = _commandeRepo.GetAll();
                dgvCommandes.DataSource = commandes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearchDate_Click(object? sender, EventArgs e)
        {
            SearchByDate();
        }

        private void BtnSearchClient_Click(object? sender, EventArgs e)
        {
            SearchByClient();
        }

        private void BtnShowAll_Click(object? sender, EventArgs e)
        {
            LoadAllCommandes();
        }

        private void SearchByDate()
        {
            try
            {
                var commandes = _commandeRepo.SearchByDate(dtpStartDate.Value.Date, dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1));
                dgvCommandes.DataSource = commandes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchByClient()
        {
            if (cboClient.SelectedValue == null || (int)cboClient.SelectedValue == 0)
            {
                LoadAllCommandes();
                return;
            }

            try
            {
                var commandes = _commandeRepo.SearchByClient((int)cboClient.SelectedValue);
                dgvCommandes.DataSource = commandes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCommandes_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCommandes.CurrentRow?.DataBoundItem is Commande cmd)
            {
                _selectedCommande = _commandeRepo.GetById(cmd.ID);
            }
        }

        private void DgvCommandes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedCommande = dgvCommandes.Rows[e.RowIndex].DataBoundItem as Commande;
            if (selectedCommande == null) return;

            // Get full commande details
            var fullCommande = _commandeRepo.GetById(selectedCommande.ID);
            if (fullCommande == null) return;

            var columnName = dgvCommandes.Columns[e.ColumnIndex].Name;

            if (columnName == "colModify" || dgvCommandes.Columns[e.ColumnIndex].HeaderText == "Modifier")
            {
                // Modify commande
                ModifyCommande(fullCommande);
            }
            else if (columnName == "colPayment" || dgvCommandes.Columns[e.ColumnIndex].HeaderText == "Paiement")
            {
                // Manage payment
                ManagePayment(fullCommande);
            }
            else if (columnName == "colPrint" || dgvCommandes.Columns[e.ColumnIndex].HeaderText == "Imprimer")
            {
                // Print invoice
                PrintCommande(fullCommande);
            }
        }

        private void ModifyCommande(Commande commande)
        {
            var form = new CommandeEditForm(commande);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadAllCommandes();
            }
        }

        private void ManagePayment(Commande commande)
        {
            var paymentForm = new Form
            {
                Text = "Gestion du Paiement - Commande #" + commande.ID,
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = StyleHelper.White
            };

            var lblCommande = new Label
            {
                Text = $"Commande #{commande.ID} - {commande.ClientNom}",
                Font = StyleHelper.SubheadingFont,
                ForeColor = StyleHelper.PrimaryBlue,
                Location = new Point(20, 20),
                AutoSize = true
            };

            var lblMontant = new Label
            {
                Text = $"Montant: {commande.MontantTotal:N2} €",
                Font = StyleHelper.BodyFont,
                Location = new Point(20, 60),
                AutoSize = true
            };

            var chkEstPaye = new CheckBox
            {
                Text = "Facture Payée",
                Location = new Point(20, 100),
                Checked = commande.EstPaye,
                Font = StyleHelper.BodyFont
            };

            var lblTypePaiement = new Label
            {
                Text = "Type de Paiement:",
                Location = new Point(20, 140),
                AutoSize = true
            };
            StyleHelper.StyleLabel(lblTypePaiement);

            var cboTypePaiement = new ComboBox
            {
                Location = new Point(20, 165),
                Size = new Size(400, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = StyleHelper.BodyFont
            };
            cboTypePaiement.Items.AddRange(new object[] { "", "Espèces", "Carte Bancaire", "Chèque", "Virement", "Autre" });
            if (!string.IsNullOrEmpty(commande.TypePaiement))
            {
                var index = cboTypePaiement.Items.IndexOf(commande.TypePaiement);
                if (index >= 0) cboTypePaiement.SelectedIndex = index;
            }

            var btnSave = new Button
            {
                Text = "Enregistrer",
                Location = new Point(200, 220),
                Size = new Size(120, 35)
            };
            StyleHelper.StyleButton(btnSave);
            btnSave.Click += (s, e) =>
            {
                try
                {
                    commande.EstPaye = chkEstPaye.Checked;
                    commande.TypePaiement = cboTypePaiement.SelectedItem?.ToString();
                    _commandeRepo.Update(commande);
                    MessageBox.Show("Paiement mis à jour avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    paymentForm.Close();
                    LoadAllCommandes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            var btnCancel = new Button
            {
                Text = "Annuler",
                Location = new Point(330, 220),
                Size = new Size(120, 35)
            };
            StyleHelper.StyleButton(btnCancel, StyleHelper.TextLight);
            btnCancel.Click += (s, e) => paymentForm.Close();

            panel.Controls.AddRange(new Control[] { lblCommande, lblMontant, chkEstPaye, lblTypePaiement, cboTypePaiement, btnSave, btnCancel });
            paymentForm.Controls.Add(panel);
            paymentForm.ShowDialog(this);
        }

        private void PrintCommande(Commande commande)
        {
            try
            {
                var printDoc = new PrintDocument();
                printDoc.PrintPage += (s, e) =>
                {
                    if (e.Graphics == null) return;

                    var titleFont = new Font("Arial", 16, FontStyle.Bold);
                    var headerFont = new Font("Arial", 11, FontStyle.Bold);
                    var font = new Font("Arial", 10);
                    var smallFont = new Font("Arial", 9);
                    var y = 50f;
                    var lineHeight = font.GetHeight(e.Graphics);
                    var margin = 100f;
                    var width = 400f;

                    // Header
                    e.Graphics.DrawString("PHARMACIE", titleFont, Brushes.Black, margin, y);
                    y += lineHeight * 1.5f;
                    e.Graphics.DrawString("FACTURE", headerFont, Brushes.Black, margin, y);
                    y += lineHeight * 2;

                    // Separator
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), margin, y, margin + width, y);
                    y += lineHeight * 1.5f;

                    // Commande Info
                    e.Graphics.DrawString($"N° Facture: {commande.ID:D6}", headerFont, Brushes.Black, margin, y);
                    y += lineHeight;
                    e.Graphics.DrawString($"Date: {commande.DateCommande:dd/MM/yyyy HH:mm}", font, Brushes.Black, margin, y);
                    y += lineHeight;
                    e.Graphics.DrawString($"Client: {commande.ClientNom}", font, Brushes.Black, margin, y);
                    y += lineHeight;
                    e.Graphics.DrawString($"Statut: {commande.Statut}", font, Brushes.Black, margin, y);
                    y += lineHeight;
                    e.Graphics.DrawString($"Paiement: {(commande.EstPaye ? "Payé" : "Non Payé")}", font, commande.EstPaye ? Brushes.Green : Brushes.Red, margin, y);
                    if (!string.IsNullOrEmpty(commande.TypePaiement))
                    {
                        y += lineHeight;
                        e.Graphics.DrawString($"Type: {commande.TypePaiement}", font, Brushes.Black, margin, y);
                    }
                    y += lineHeight * 1.5f;

                    // Separator
                    e.Graphics.DrawLine(new Pen(Color.Black, 1), margin, y, margin + width, y);
                    y += lineHeight;

                    // Details Header
                    e.Graphics.DrawString("DÉTAILS DE LA COMMANDE", headerFont, Brushes.Black, margin, y);
                    y += lineHeight * 1.5f;
                    e.Graphics.DrawLine(new Pen(Color.Black, 1), margin, y, margin + width, y);
                    y += lineHeight;

                    // Table Header
                    e.Graphics.DrawString("Référence", smallFont, Brushes.Black, margin, y);
                    e.Graphics.DrawString("Médicament", smallFont, Brushes.Black, margin + 100, y);
                    e.Graphics.DrawString("Qté", smallFont, Brushes.Black, margin + 280, y);
                    e.Graphics.DrawString("Prix", smallFont, Brushes.Black, margin + 320, y);
                    e.Graphics.DrawString("Total", smallFont, Brushes.Black, margin + 380, y);
                    y += lineHeight;
                    e.Graphics.DrawLine(new Pen(Color.Black, 1), margin, y, margin + width, y);
                    y += lineHeight;

                    // Details
                    foreach (var detail in commande.Details)
                    {
                        e.Graphics.DrawString(detail.MedicamentReference, smallFont, Brushes.Black, margin, y);
                        e.Graphics.DrawString(detail.MedicamentNom, smallFont, Brushes.Black, margin + 100, y);
                        e.Graphics.DrawString(detail.Quantite.ToString(), smallFont, Brushes.Black, margin + 280, y);
                        e.Graphics.DrawString($"{detail.PrixUnitaire:N2}€", smallFont, Brushes.Black, margin + 320, y);
                        e.Graphics.DrawString($"{detail.SousTotal:N2}€", smallFont, Brushes.Black, margin + 380, y);
                        y += lineHeight;
                    }

                    y += lineHeight;
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), margin, y, margin + width, y);
                    y += lineHeight;

                    // Total
                    e.Graphics.DrawString($"TOTAL: {commande.MontantTotal:N2} €", headerFont, Brushes.Black, margin + 300, y);
                    y += lineHeight * 2;

                    // Footer
                    e.Graphics.DrawString("Merci de votre confiance!", smallFont, Brushes.Black, margin, y);
                    y += lineHeight;
                    e.Graphics.DrawString($"Facture générée le {DateTime.Now:dd/MM/yyyy HH:mm}", smallFont, Brushes.Gray, margin, y);
                };

                var printDialog = new PrintDialog { Document = printDoc };
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur d'impression: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
