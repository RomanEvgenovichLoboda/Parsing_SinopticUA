using System.Net;
using HtmlAgilityPack;

namespace Parsing_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("https://sinoptik.ua/%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0-%D0%B4%D0%BD%D0%B5%D0%BF%D1%80-303007131", "file.html");
                client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/b/d400.jpg", "d400.jpg");
                client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/n420.gif", "d420.jpg");
            }
            pictureBox_d40.Image = Image.FromFile("d400.jpg");
            pictureBox_term.Image = Image.FromFile("termemetr.png");

            pictureBox1.Image = Image.FromFile("d420.jpg");
            pictureBox2.Image = Image.FromFile("d420.jpg");
            pictureBox3.Image = Image.FromFile("d420.jpg");
            pictureBox4.Image = Image.FromFile("d420.jpg");
            pictureBox5.Image = Image.FromFile("d420.jpg");
            pictureBox6.Image = Image.FromFile("d420.jpg");
            pictureBox7.Image = Image.FromFile("d420.jpg");
            pictureBox8.Image = Image.FromFile("d420.jpg");



            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.Load("file.html");

            HtmlNode htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='today-time']");
            label_today_time.Text = htmlNode.InnerText;

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='today-temp']");
            label_termNow.Text = htmlNode.InnerText;

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='infoDaylight']");
            label_infoDayLight.Text = htmlNode.InnerText;
        }
    }
}
