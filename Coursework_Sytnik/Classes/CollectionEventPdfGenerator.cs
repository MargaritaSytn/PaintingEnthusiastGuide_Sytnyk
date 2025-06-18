using MigraDocCore.DocumentObjectModel;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.Rendering;
using PdfSharpCore.Pdf;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Coursework_Sytnik.Classes;

namespace Coursework_Sytnik.Classes
{
    public static class CollectionEventPdfGenerator
    {
        public static void GenerateCollectionEventPdf(CollectionEvent collectionEvent)
        {
            if (collectionEvent == null)
            {
                MessageBox.Show("Дані події відсутні.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Document document = new Document();
            document.Info.Title = $"Інформація про подію: {collectionEvent.Name}";
            document.Info.Author = "Застосунок \"Музей\"";

            Section section = document.AddSection();

            Paragraph title = section.AddParagraph();
            title.Format.Font.Size = 18;
            title.Format.Font.Bold = true;
            title.Format.Alignment = ParagraphAlignment.Center;
            title.AddText($"Інформація про подію: {collectionEvent.Name}");

            section.AddParagraph();

            AddEventInfo(section, "Назва події:", collectionEvent.Name);
            AddEventInfo(section, "Тип заходу:", collectionEvent.EventTypeDisplay);

            if (collectionEvent.IsAuction && collectionEvent.EventDate.HasValue)
            {
                AddEventInfo(section, "Дата проведення:", collectionEvent.EventDate.Value.ToShortDateString());
            }
            else
            {
                AddEventInfo(section, "Дата проведення:", "N/A");
            }

            section.AddParagraph();

            if (collectionEvent.PaintingsForSale != null && collectionEvent.PaintingsForSale.Any())
            {
                Paragraph paintingsHeader = section.AddParagraph("Представлені картини:");
                paintingsHeader.Format.Font.Size = 14;
                paintingsHeader.Format.Font.Bold = true;
                paintingsHeader.Format.SpaceAfter = "0.5cm";

                Table table = section.AddTable();
                table.Borders.Width = 0.75;
                table.Borders.Color = MigraDocCore.DocumentObjectModel.Color.FromCmyk(0, 0, 0, 100);
                table.Format.SpaceAfter = "1cm";

                Column column = table.AddColumn(Unit.FromCentimeter(6));
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(4));
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn(Unit.FromCentimeter(5));
                column.Format.Alignment = ParagraphAlignment.Left;

                Row headerRow = table.AddRow();
                headerRow.Shading.Color = MigraDocCore.DocumentObjectModel.Color.FromCmyk(0, 0, 0, 10);
                headerRow.Format.Font.Bold = true;
                headerRow.Cells[0].AddParagraph("Назва картини");
                headerRow.Cells[1].AddParagraph("Ціна");
                headerRow.Cells[2].AddParagraph("Художник");

                foreach (var pfs in collectionEvent.PaintingsForSale)
                {
                    var painting = DataManager.Instance.GetPaintingById(pfs.PaintingId);
                    if (painting != null)
                    {
                        Row row = table.AddRow();
                        row.Cells[0].AddParagraph(painting.Title);
                        row.Cells[1].AddParagraph($"{pfs.Price:C}");

                        Artist artist = null;
                        if (painting.ArtistId.HasValue)
                        {
                            artist = DataManager.Instance.GetArtistById(painting.ArtistId.Value);
                        }
                        row.Cells[2].AddParagraph(artist != null ? artist.FullName : "Невідомий");
                    }
                }
            }
            else
            {
                section.AddParagraph("На цьому заході немає представлених картин.").Format.SpaceAfter = "1cm";
            }

            SaveDocument(document, collectionEvent.Name);
        }

        private static void AddEventInfo(Section section, string label, string value)
        {
            Paragraph p = section.AddParagraph();
            p.Format.Font.Size = 12;
            p.AddFormattedText(label, TextFormat.Bold);
            p.AddText($" {value}");
            p.Format.SpaceAfter = "0.1cm";
        }

        private static void SaveDocument(Document document, string fileName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Подія_{fileName.Replace(" ", "_")}.pdf";
                saveFileDialog.Title = "Зберегти інформацію про подію як PDF";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
                        pdfRenderer.Document = document;
                        pdfRenderer.RenderDocument();
                        pdfRenderer.PdfDocument.Save(filePath);

                        MessageBox.Show($"PDF успішно створено за шляхом: {filePath}", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при створенні PDF: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}