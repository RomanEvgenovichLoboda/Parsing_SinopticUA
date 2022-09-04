using HtmlAgilityPack;
using System.Net;

using (WebClient client = new WebClient())
    client.DownloadFile("https://sinoptik.ua/%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0-%D0%B4%D0%BD%D0%B5%D0%BF%D1%80-303007131", "file.html");

HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
htmlDoc.Load("file.html");

HtmlNode htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='infoDaylight']");
Console.WriteLine(htmlNode.InnerText);

