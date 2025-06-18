using MigraDocCore.DocumentObjectModel;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.Rendering;
using PdfSharpCore.Pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Coursework_Sytnik.Classes;

namespace Coursework_Sytnik.Classes
{
    public static class MyCollectionReceiptGenerator
    {
        public static void GenerateReceiptPdf(MyCollectionPainting collectionItem)
        {
            if (collectionItem == null)
            {
                MessageBox.Show("Дані предмета колекції відсутні.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var painting = DataManager.Instance.GetPaintingById(collectionItem.PaintingId);
            if (painting == null)
            {
                MessageBox.Show("Не вдалося знайти інформацію про картину.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var artist = DataManager.Instance.GetArtistById(painting.ArtistId ?? 0);

            string receiptCode = GenerateUniqueReceiptCode(collectionItem.Id);

            Document document = new Document();
            document.Info.Title = $"Чек на покупку: {painting.Title}";
            document.Info.Author = "Застосунок \"Музей\" - Моя Колекція";

            Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A5;
            section.PageSetup.Orientation = MigraDocCore.DocumentObjectModel.Orientation.Portrait;
            section.PageSetup.LeftMargin = "1.5cm";
            section.PageSetup.RightMargin = "1.5cm";
            section.PageSetup.TopMargin = "1.5cm";
            section.PageSetup.BottomMargin = "1.5cm";

            Paragraph header = section.AddParagraph("ЧЕК ПОКУПКИ");
            header.Format.Font.Size = 16;
            header.Format.Font.Bold = true;
            header.Format.Alignment = ParagraphAlignment.Center;
            header.Format.SpaceAfter = "0.5cm";

            Paragraph shopInfo = section.AddParagraph("Застосунок 'Музей'");
            shopInfo.Format.Font.Size = 10;
            shopInfo.Format.Alignment = ParagraphAlignment.Center;
            shopInfo.AddLineBreak();
            shopInfo.AddText("Україна, м. Харків");
            shopInfo.AddLineBreak();
            shopInfo.AddText("Дата формування чека: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            shopInfo.Format.SpaceAfter = "1cm";


            Table table = section.AddTable();
            table.Borders.Width = 0.5;
            table.Borders.Color = MigraDocCore.DocumentObjectModel.Color.FromCmyk(0, 0, 0, 80);
            table.Format.SpaceAfter = "1cm";

            Column colLabel = table.AddColumn(Unit.FromCentimeter(5));
            colLabel.Format.Alignment = ParagraphAlignment.Left;
            Column colValue = table.AddColumn(Unit.FromCentimeter(8));
            colValue.Format.Alignment = ParagraphAlignment.Left;

            AddReceiptRow(table, "Назва картини:", painting.Title);
            AddReceiptRow(table, "Художник:", artist != null ? artist.FullName : "Невідомо");
            AddReceiptRow(table, "Рік створення:", painting.CreationYear.ToString());
            AddReceiptRow(table, "Жанр:", painting.Genre);
            AddReceiptRow(table, "Дата покупки:", collectionItem.PurchaseDate.ToShortDateString());
            AddReceiptRow(table, "Джерело покупки:", collectionItem.SourceEventName);
            AddReceiptRow(table, "Ціна покупки:", $"{collectionItem.PurchasePrice:C}");

            section.AddParagraph();

            Paragraph total = section.AddParagraph();
            total.Format.Font.Size = 14;
            total.Format.Font.Bold = true;
            total.Format.Alignment = ParagraphAlignment.Right;
            total.AddText($"РАЗОМ: {collectionItem.PurchasePrice:C}");
            total.Format.SpaceAfter = "1cm";

            Paragraph codeParagraph = section.AddParagraph();
            codeParagraph.Format.Font.Size = 10;
            codeParagraph.Format.Alignment = ParagraphAlignment.Center;
            codeParagraph.AddText($"Унікальний код чека: {receiptCode}");
            codeParagraph.Format.SpaceAfter = "0.5cm";
            SaveDocument(document, painting.Title);
        }

        private static void AddReceiptRow(Table table, string label, string value)
        {
            Row row = table.AddRow();
            row.Cells[0].AddParagraph(label).Format.Font.Bold = true;
            row.Cells[1].AddParagraph(value);
            row.Cells[0].Format.SpaceAfter = "0.05cm";
            row.Cells[1].Format.SpaceAfter = "0.05cm";
            row.Cells[0].Borders.Visible = false;
            row.Cells[1].Borders.Visible = false;
        }

        private static string GenerateUniqueReceiptCode(int itemId)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string randomPart = new Random().Next(1000, 9999).ToString();
            return $"REC-{itemId}-{timestamp}-{randomPart}";
        }

        private static void SaveDocument(Document document, string paintingTitle)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Чек_{paintingTitle.Replace(" ", "_")}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                saveFileDialog.Title = "Зберегти чек покупки як PDF";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
                        pdfRenderer.Document = document;
                        pdfRenderer.RenderDocument();
                        pdfRenderer.PdfDocument.Save(filePath);

                        MessageBox.Show($"Чек успішно створено за шляхом: {filePath}", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

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