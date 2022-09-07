using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Parsing_WinForm
{
    public partial class SinopticForm : Form
    {
        public SinopticForm()
        {
            InitializeComponent();
            DataLoad();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
                client.DownloadFile("https://sinoptik.ua/%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0-%D0%B4%D0%BD%D0%B5%D0%BF%D1%80-303007131", "file.html");
        }

        void DataLoad()
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.Load("file.html");

            HtmlNode htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='today-time']");
            label_today_time.Text = htmlNode.InnerText;



            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='today-temp']");
            label_termNow.Text = htmlNode.InnerText.Replace("deg;", "°");

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='infoDaylight']");
            label_infoDayLight.Text = htmlNode.InnerText;

            /////temp

            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//tbody//tr");
            string tempString = htmlNodes[0].InnerText;
            tempString = tempString.Replace("&deg;", "°").Replace(" :", ":").Replace("   ", " ").Replace("  ", " ");
            var matchColl = Regex.Match(tempString, " (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) ");
            label00.Text = matchColl.Groups[1].Value;
            label01.Text = matchColl.Groups[2].Value;
            label02.Text = matchColl.Groups[3].Value;
            label03.Text = matchColl.Groups[4].Value;
            label04.Text = matchColl.Groups[5].Value;
            label05.Text = matchColl.Groups[6].Value;
            label06.Text = matchColl.Groups[7].Value;
            label07.Text = matchColl.Groups[8].Value;
            ////
            htmlNodes = htmlDoc.DocumentNode.SelectNodes("//tbody//tr");
            tempString = htmlNodes[2].InnerText;
            tempString = tempString.Replace("&deg;", "°").Replace(" :", ":").Replace("   ", " ").Replace("  ", " ");
            matchColl = Regex.Match(tempString, " (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) ");
            label20.Text = matchColl.Groups[1].Value;
            label21.Text = matchColl.Groups[2].Value;
            label22.Text = matchColl.Groups[3].Value;
            label23.Text = matchColl.Groups[4].Value;
            label24.Text = matchColl.Groups[5].Value;
            label25.Text = matchColl.Groups[6].Value;
            label26.Text = matchColl.Groups[7].Value;
            label27.Text = matchColl.Groups[8].Value;
            /////
            htmlNodes = htmlDoc.DocumentNode.SelectNodes("//tbody//tr");
            tempString = htmlNodes[3].InnerText;
            tempString = tempString.Replace("&deg;", "°").Replace(" :", ":").Replace("   ", " ").Replace("  ", " ");
            matchColl = Regex.Match(tempString, " (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) ");
            label30.Text = matchColl.Groups[1].Value;
            label31.Text = matchColl.Groups[2].Value;
            label32.Text = matchColl.Groups[3].Value;
            label33.Text = matchColl.Groups[4].Value;
            label34.Text = matchColl.Groups[5].Value;
            label35.Text = matchColl.Groups[6].Value;
            label36.Text = matchColl.Groups[7].Value;
            label37.Text = matchColl.Groups[8].Value;
            ////
            ///
            htmlNodes = htmlDoc.DocumentNode.SelectNodes("//tbody//tr");
            tempString = htmlNodes[4].InnerText;
            tempString = tempString.Replace("&deg;", "°").Replace(" :", ":").Replace("   ", " ").Replace("  ", " ");
            matchColl = Regex.Match(tempString, " (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) ");
            label40.Text = matchColl.Groups[1].Value;
            label41.Text = matchColl.Groups[2].Value;
            label42.Text = matchColl.Groups[3].Value;
            label43.Text = matchColl.Groups[4].Value;
            label44.Text = matchColl.Groups[5].Value;
            label45.Text = matchColl.Groups[6].Value;
            label46.Text = matchColl.Groups[7].Value;
            label47.Text = matchColl.Groups[8].Value;



            using (WebClient client = new WebClient())
            {
                //imegBox
                var Node = htmlDoc.DocumentNode.SelectNodes("//div[@class='imgBlock']//div[@class='img']//img");
                string linc = "https:" + Node[0].GetAttributeValue("src", "");
                client.DownloadFile(linc, "title.jpg");
                pictureBox_Title.Image = Image.FromFile("title.jpg");

                Node = htmlDoc.DocumentNode.SelectNodes("//tr//td//div//img[@class='weatherImg']");
                linc = "https:" + Node[0].GetAttributeValue("src", "");
                client.DownloadFile(linc, "night1.gif");
                pictureBox_night1.Image = Image.FromFile("night1.gif");

                linc = "https:" + Node[1].GetAttributeValue("src", "");
                client.DownloadFile(linc, "night2.gif");
                pictureBox_night2.Image = Image.FromFile("night2.gif");

                linc = "https:" + Node[2].GetAttributeValue("src", "");
                client.DownloadFile(linc, "mon1.gif");
                pictureBoxMon1.Image = Image.FromFile("mon1.gif");

                linc = "https:" + Node[3].GetAttributeValue("src", "");
                client.DownloadFile(linc, "mon2.gif");
                pictureBoxMon2.Image = Image.FromFile("mon2.gif");

                linc = "https:" + Node[4].GetAttributeValue("src", "");
                client.DownloadFile(linc, "day1.gif");
                pictureBoxDay1.Image = Image.FromFile("day1.gif");

                linc = "https:" + Node[5].GetAttributeValue("src", "");
                client.DownloadFile(linc, "day2.gif");
                pictureBoxDay2.Image = Image.FromFile("day2.gif");

                linc = "https:" + Node[6].GetAttributeValue("src", "");
                client.DownloadFile(linc, "evn1.gif");
                pictureBoxEvn1.Image = Image.FromFile("evn1.gif");

                linc = "https:" + Node[7].GetAttributeValue("src", "");
                client.DownloadFile(linc, "evn2.gif");
                pictureBoxEvn2.Image = Image.FromFile("evn2.gif");




                ////
                ///




                client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/n420.gif", "d420.jpg");
            }
            pictureBox_term.Image = Image.FromFile("termemetr.png");
        }
    }
}
