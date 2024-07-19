using System;
using System.Text;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace pdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            GeneratePdf(text);
        }

        private void GeneratePdf(string text)
        {
            // Создание документа PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Отчет";
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12);

            // Установка начальной позиции для текста
            XRect rect = new XRect(50, 50, page.Width - 100, page.Height - 100);

            // Разбивка текста на слова
            string[] words = text.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Текущая позиция Y на странице
            double curYPos = rect.Y;

            StringBuilder currentLine = new StringBuilder();

            // Цикл для отрисовки каждого слова текста
            foreach (string word in words)
            {
                string testLine = currentLine.ToString() + word + " ";
                XSize size = gfx.MeasureString(testLine, font);

                if (size.Width < rect.Width)
                {
                    currentLine.Append(word).Append(" ");
                }
                else
                {
                    gfx.DrawString(currentLine.ToString(), font, XBrushes.Black, new XPoint(rect.X, curYPos));
                    curYPos += size.Height;
                    currentLine = new StringBuilder(word + " ");
                }

                if (curYPos + size.Height > page.Height - 100)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    curYPos = 50;
                    currentLine = new StringBuilder();
                }
            }

            //  выполняет отрисовку текста, содержащегося в переменной currentLine, с использованием заданных параметров шрифта, цвета и позиции на странице
            gfx.DrawString(currentLine.ToString(), font, XBrushes.Black, new XPoint(rect.X, curYPos));

            // Сохранить документ
            string filename = "Report.pdf";
            document.Save(filename);
            MessageBox.Show($"PDF файл '{filename}' успешно создан!");
        }


    }
}