using MigraDocCore.DocumentObjectModel;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.Rendering;
using PdfSharpCore.Pdf;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Coursework_Sytnik.Classes;
using System.Linq;

namespace Coursework_Sytnik.Classes
{
    public static class PaintingPdfGenerator
    {
        public static void GeneratePaintingPdf(Painting painting)
        {
            if (painting == null)
            {
                MessageBox.Show("Дані картини відсутні.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Artist artist = null;
            if (painting.ArtistId.HasValue)
            {
                artist = DataManager.Instance.GetArtistById(painting.ArtistId.Value);
            }

            Museum museum = null;
            if (painting.MuseumId.HasValue)
            {
                museum = DataManager.Instance.GetMuseumById(painting.MuseumId.Value);
            }

            Document document = new Document();
            document.Info.Title = $"Інформація про картину: {painting.Title}";
            document.Info.Author = "Застосунок \"Музей\"";

            Section section = document.AddSection();

            Paragraph title = section.AddParagraph();
            title.Format.Font.Size = 18;
            title.Format.Font.Bold = true;
            title.Format.Alignment = ParagraphAlignment.Center;
            title.AddText($"Інформація про картину: {painting.Title}");

            section.AddParagraph();

            AddPaintingInfo(section, "Назва:", painting.Title);
            AddPaintingInfo(section, "Рік створення:", painting.CreationYear.ToString());
            AddPaintingInfo(section, "Жанр:", painting.Genre);
            AddPaintingInfo(section, "Художник:", artist != null ? artist.FullName : "Невідомий");
            AddPaintingInfo(section, "Музей:", museum != null ? museum.Name : "Немає в музеї");

            if (artist != null && artist.Styles.Any())
            {
                AddPaintingInfo(section, "Стилі художника:", string.Join(", ", artist.Styles));
            }

            SaveDocument(document, painting.Title);
        }

        private static void AddPaintingInfo(Section section, string label, string value)
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
                saveFileDialog.FileName = $"Картина_{fileName.Replace(" ", "_")}.pdf";
                saveFileDialog.Title = "Зберегти інформацію про картину як PDF";

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