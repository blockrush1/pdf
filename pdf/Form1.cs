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
            // �������� ��������� PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = "�����";
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12);

            // ��������� ��������� ������� ��� ������
            XRect rect = new XRect(50, 50, page.Width - 100, page.Height - 100);

            // �������� ������ �� �����
            string[] words = text.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // ������� ������� Y �� ��������
            double curYPos = rect.Y;

            StringBuilder currentLine = new StringBuilder();

            // ���� ��� ��������� ������� ����� ������
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

            //  ��������� ��������� ������, ������������� � ���������� currentLine, � �������������� �������� ���������� ������, ����� � ������� �� ��������
            gfx.DrawString(currentLine.ToString(), font, XBrushes.Black, new XPoint(rect.X, curYPos));

            // ��������� ��������
            string filename = "Report.pdf";
            document.Save(filename);
            MessageBox.Show($"PDF ���� '{filename}' ������� ������!");
        }


    }
}