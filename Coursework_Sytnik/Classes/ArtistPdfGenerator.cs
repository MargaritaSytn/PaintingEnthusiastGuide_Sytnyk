using MigraDocCore.DocumentObjectModel;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.DocumentObjectModel.Shapes;
using MigraDocCore.Rendering;
using PdfSharpCore.Pdf;
using System.Diagnostics;
using System.IO;
using Coursework_Sytnik.Classes;
using System.Windows.Forms;

namespace Coursework_Sytnik.Classes
{
    public static class ArtistPdfGenerator
    {
        public static void GenerateArtistPdf(Artist artist)
        {
            if (artist == null)
            {
                MessageBox.Show("Дані художника відсутні.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Document document = new Document();
            document.Info.Title = $"Інформація про художника: {artist.FullName}";
            document.Info.Author = "Застосунок \"Музей\"";

            Section section = document.AddSection();

            Paragraph title = section.AddParagraph();
            title.Format.Font.Size = 18;
            title.Format.Font.Bold = true;
            title.Format.Alignment = ParagraphAlignment.Center;
            title.AddText($"Інформація про художника: {artist.FullName}");

            section.AddParagraph();

            AddArtistInfo(section, "Ім'я:", artist.FirstName);
            AddArtistInfo(section, "Прізвище:", artist.LastName);
            AddArtistInfo(section, "Роки життя:", artist.YearsOfLife);
            AddArtistInfo(section, "Країна:", artist.Country);
            AddArtistInfo(section, "Стилі:", artist.StylesDisplay);

            section.AddParagraph();

            Paragraph bioHeader = section.AddParagraph("Біографія:");
            bioHeader.Format.Font.Size = 12;
            bioHeader.Format.Font.Bold = true;
            bioHeader.Format.SpaceAfter = "0.5cm";

            Paragraph biography = section.AddParagraph(artist.Biography);
            biography.Format.Alignment = ParagraphAlignment.Justify;
            biography.Format.Font.Size = 12;
            biography.Format.LineSpacing = 1.2;
            biography.Format.SpaceAfter = "1cm";

            SaveDocument(document, artist.FullName);
        }

        private static void AddArtistInfo(Section section, string label, string value)
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
                saveFileDialog.FileName = $"Художник_{fileName.Replace(" ", "_")}.pdf";
                saveFileDialog.Title = "Зберегти інформацію про художника як PDF";

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