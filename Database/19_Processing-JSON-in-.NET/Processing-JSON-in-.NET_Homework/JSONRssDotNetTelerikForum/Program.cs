namespace JSONRssDotNetTelerikForum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;
    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class Program
    {
        private static string RSSFeed = @"http://forums.academy.telerik.com/feed/qa.rss";
        private static string xmlFilePath = @"../../../htmlAndXmlFiles";
        private static string xmlFileName = @"/TARss.xml";
        private static string HTMLfileName = @"/HTMLTARSS.html";
        
        static void Main()
        {
            // 1. Find RSS feed
            // 2. Download RSS as XML
            GetRSSFile(RSSFeed);
            
            // 3. Parse XML to JSON
            string jsonRSS = GetJSONfromXML(xmlFilePath + xmlFileName);
            
            // 4. Print all titels
            var titles = GetTitles(jsonRSS);
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
            
            // 5. JSON to POCO
            TARSS tarss = GetPOCO(jsonRSS);
            
            // 6. Create HTML
            StringBuilder HTMLasSB = new StringBuilder();
            CreateHTMLHEAD(HTMLasSB);
            CreateHTMLBODY(tarss, HTMLasSB);
            CreateHTMLFile(HTMLasSB);
        }
        
        private static void GetRSSFile(string RSSFeed)
        {
            System.IO.Directory.CreateDirectory(xmlFilePath);
            WebClient webClient = new WebClient();
            webClient.DownloadFile(RSSFeed, xmlFilePath + xmlFileName);
        }
        
        private static string GetJSONfromXML(string xmlFilePath)
        {
            XNode xmlRSS = XDocument.Load(xmlFilePath);
            string jsonRSS = JsonConvert.SerializeXNode(xmlRSS, Formatting.Indented);
            
            return jsonRSS;
        }
        
        private static List<string> GetTitles(string jsonRSS)
        {
            var jsonRSSobject = JObject.Parse(jsonRSS);
            var titlesArray = (JArray)jsonRSSobject["rss"]["channel"]["item"];
            var titles = titlesArray.Select(t => (string)t["title"]).ToList();
            
            return titles;
        }
        
        private static TARSS GetPOCO(string jsonRSS)
        {
            var jsonRSSobject = JObject.Parse(jsonRSS);
            var channeJason = jsonRSSobject["rss"]["channel"].ToString();
            TARSS tarss = JsonConvert.DeserializeObject<TARSS>(channeJason);
            
            return tarss;
        }
        
        private static void CreateHTMLHEAD(StringBuilder HTMLasSB)
        {
            HTMLasSB.AppendLine(@"<!DOCTYPE html>");
            HTMLasSB.AppendLine(@"<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">");
            HTMLasSB.AppendLine(@"<head>");
            HTMLasSB.AppendLine(@" <meta charset=""utf-8"" />");
            HTMLasSB.AppendLine(@"<title>");
            HTMLasSB.AppendLine("Telerik Academy RSS");
            HTMLasSB.AppendLine(@"</title>");
            HTMLasSB.AppendLine(@"</head>");
        }
        
        private static void CreateHTMLBODY(TARSS tarss, StringBuilder HTMLasSB)
        {
            HTMLasSB.AppendLine(@"<body>");
            HTMLasSB.AppendLine(string.Format("<h1><a href = \"{1}\">{0}</a></h1>", tarss.Title, tarss.Link));
            HTMLasSB.AppendLine(@"<ul>");
            
            foreach (var item in tarss.Item)
            {
                HTMLasSB.AppendLine(@"<li>");
                HTMLasSB.AppendLine(string.Format("<h4><a href = \"{1}\">{0}</a></h4>", item.Title, item.Link));
                HTMLasSB.AppendLine(string.Format("<p>{0}</p>", item.Category));
                HTMLasSB.AppendLine(@"</li>");
            
            }
            HTMLasSB.AppendLine(@"<ul>");
            HTMLasSB.AppendLine(@"</body>");
        }
        
        private static void CreateHTMLFile(StringBuilder HTMLasSB)
        {
            StreamWriter writer = new StreamWriter(xmlFilePath + HTMLfileName, false, Encoding.UTF8);
            using (writer)
            {
                writer.Write(HTMLasSB.ToString());
            }
        }
    }
}
