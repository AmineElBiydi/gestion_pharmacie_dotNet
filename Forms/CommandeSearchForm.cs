using GestionPharmacie.Data;
using GestionPharmacie.Models;
using GestionPharmacie.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Text;
using Rectangle = iTextSharp.text.Rectangle;

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

            if (!DesignMode)
            {
                StyleHelper.ApplyFormTheme(this);
            }
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
            var form = new PaymentManagerForm(commande);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadAllCommandes();
            }
        }

        private void PrintCommande(Commande commande)
        {
            try
            {
                // Choisir où sauvegarder
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "PDF Files|*.pdf";
                saveDlg.FileName = $"Facture_{commande.ID:D6}.pdf";
                if (saveDlg.ShowDialog() != DialogResult.OK)
                    return;
                string filePath = saveDlg.FileName;

                // Création du document PDF avec marges
                Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
                pdfDoc.Open();

                // Définition des couleurs
                BaseColor primaryColor = new BaseColor(41, 128, 185);    // Bleu
                BaseColor secondaryColor = new BaseColor(52, 73, 94);    // Gris foncé
                BaseColor lightGray = new BaseColor(236, 240, 241);      // Gris clair
                BaseColor successColor = new BaseColor(39, 174, 96);     // Vert

                // Styles de police
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, primaryColor);
                var subtitleFont = FontFactory.GetFont(FontFactory.HELVETICA, 14, secondaryColor);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.White);
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, secondaryColor);
                var textFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, secondaryColor);
                var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.Gray);
                var totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, secondaryColor);

                // ========== EN-TÊTE ==========
                PdfPTable headerTable = new PdfPTable(2);
                headerTable.WidthPercentage = 100;
                headerTable.SetWidths(new float[] { 1f, 1f });

                // Colonne gauche - Nom de la pharmacie
                PdfPCell leftCell = new PdfPCell();
                leftCell.Border = Rectangle.NO_BORDER;
                leftCell.AddElement(new Paragraph("🏥 PHARMACIE", titleFont));
                leftCell.AddElement(new Paragraph("Votre santé, notre priorité", subtitleFont));
                leftCell.AddElement(new Paragraph("\n123 Rue de la Santé\n75001 Paris\nTél: 01 23 45 67 89", smallFont));
                headerTable.AddCell(leftCell);

                // Colonne droite - Numéro de facture
                PdfPCell rightCell = new PdfPCell();
                rightCell.Border = Rectangle.NO_BORDER;
                rightCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                var factureFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, primaryColor);
                rightCell.AddElement(new Paragraph("FACTURE", factureFont));
                rightCell.AddElement(new Paragraph($"N° {commande.ID:D6}", boldFont));
                rightCell.AddElement(new Paragraph($"Date: {commande.DateCommande:dd/MM/yyyy}", textFont));
                headerTable.AddCell(rightCell);

                pdfDoc.Add(headerTable);
                pdfDoc.Add(new Paragraph("\n"));

                // Ligne de séparation
                LineSeparator line = new LineSeparator(1f, 100f, primaryColor, Element.ALIGN_CENTER, -2);
                pdfDoc.Add(new Chunk(line));
                pdfDoc.Add(new Paragraph("\n"));

                // ========== INFORMATIONS CLIENT ET COMMANDE ==========
                PdfPTable infoTable = new PdfPTable(2);
                infoTable.WidthPercentage = 100;
                infoTable.SetWidths(new float[] { 1f, 1f });

                // Bloc Client
                PdfPCell clientCell = new PdfPCell();
                clientCell.BackgroundColor = lightGray;
                clientCell.Padding = 10f;
                clientCell.Border = Rectangle.NO_BORDER;
                clientCell.AddElement(new Paragraph("CLIENT", boldFont));
                clientCell.AddElement(new Paragraph(commande.ClientNom, textFont));
                infoTable.AddCell(clientCell);

                // Bloc Détails
                PdfPCell detailsCell = new PdfPCell();
                detailsCell.BackgroundColor = lightGray;
                detailsCell.Padding = 10f;
                detailsCell.Border = Rectangle.NO_BORDER;
                detailsCell.AddElement(new Paragraph("DÉTAILS", boldFont));
                detailsCell.AddElement(new Paragraph($"Statut: {commande.Statut}", textFont));

                Paragraph paiementPara = new Paragraph();
                paiementPara.Add(new Chunk("Paiement: ", textFont));
                paiementPara.Add(new Chunk(
                    commande.EstPaye ? "✓ Payé" : "✗ Non Payé",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, commande.EstPaye ? successColor : BaseColor.Red)
                ));
                detailsCell.AddElement(paiementPara);

                if (!string.IsNullOrEmpty(commande.TypePaiement))
                    detailsCell.AddElement(new Paragraph($"Mode: {commande.TypePaiement}", textFont));

                infoTable.AddCell(detailsCell);

                pdfDoc.Add(infoTable);
                pdfDoc.Add(new Paragraph("\n\n"));

                // ========== TABLEAU DES MÉDICAMENTS ==========
                pdfDoc.Add(new Paragraph("DÉTAIL DE LA COMMANDE", boldFont));
                pdfDoc.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1.5f, 3f, 1f, 1.5f, 1.5f });

                // En-têtes avec fond coloré
                string[] headers = { "Référence", "Médicament", "Qté", "Prix Unit.", "Total" };
                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                    cell.BackgroundColor = primaryColor;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 8f;
                    cell.Border = Rectangle.NO_BORDER;
                    table.AddCell(cell);
                }

                // Lignes de données avec alternance de couleurs
                int rowIndex = 0;
                foreach (var d in commande.Details)
                {
                    BaseColor rowColor = rowIndex % 2 == 0 ? BaseColor.White : lightGray;

                    PdfPCell[] cells = new PdfPCell[]
                    {
                new PdfPCell(new Phrase(d.MedicamentReference, textFont)),
                new PdfPCell(new Phrase(d.MedicamentNom, textFont)),
                new PdfPCell(new Phrase(d.Quantite.ToString(), textFont)) { HorizontalAlignment = Element.ALIGN_CENTER },
                new PdfPCell(new Phrase($"{d.PrixUnitaire:N2} DH", textFont)) { HorizontalAlignment = Element.ALIGN_RIGHT },
                new PdfPCell(new Phrase($"{d.SousTotal:N2} DH", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT }
                    };

                    foreach (var cell in cells)
                    {
                        cell.BackgroundColor = rowColor;
                        cell.Padding = 8f;
                        cell.Border = Rectangle.NO_BORDER;
                        table.AddCell(cell);
                    }
                    rowIndex++;
                }

                pdfDoc.Add(table);
                pdfDoc.Add(new Paragraph("\n"));

                // ========== TOTAL ==========
                PdfPTable totalTable = new PdfPTable(2);
                totalTable.WidthPercentage = 100;
                totalTable.SetWidths(new float[] { 4f, 1f });

                PdfPCell emptyCell = new PdfPCell(new Phrase(""));
                emptyCell.Border = Rectangle.NO_BORDER;
                totalTable.AddCell(emptyCell);

                PdfPCell totalCell = new PdfPCell();
                totalCell.BackgroundColor = primaryColor;
                totalCell.Padding = 12f;
                totalCell.Border = Rectangle.NO_BORDER;
                Paragraph totalPara = new Paragraph();
                totalPara.Add(new Chunk("TOTAL : ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.White)));
                totalPara.Add(new Chunk($"{commande.MontantTotal:N2} DH", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.White)));
                totalPara.Alignment = Element.ALIGN_RIGHT;
                totalCell.AddElement(totalPara);
                totalTable.AddCell(totalCell);

                pdfDoc.Add(totalTable);

                // ========== PIED DE PAGE ==========
                pdfDoc.Add(new Paragraph("\n\n"));
                LineSeparator bottomLine = new LineSeparator(0.5f, 100f, BaseColor.LightGray, Element.ALIGN_CENTER, -2);
                pdfDoc.Add(new Chunk(bottomLine));
                pdfDoc.Add(new Paragraph("\n"));

                Paragraph footer = new Paragraph("Merci de votre confiance !",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, primaryColor));
                footer.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(footer);

                Paragraph generatedDate = new Paragraph($"Document généré le {DateTime.Now:dd/MM/yyyy à HH:mm}", smallFont);
                generatedDate.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(generatedDate);

                pdfDoc.Close();

                // Ouvrir automatiquement le PDF
                Process.Start(new ProcessStartInfo()
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la génération du PDF :\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCommandes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
