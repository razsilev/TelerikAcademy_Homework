using System;
using System.Collections.Generic;
using System.Xml;

class Program
{
    //Write a program, which extract from the file catalog.xml 
    //the prices for all albums, published 5 years ago or earlier. Use XPath query.

    static void Main()
    {
        string fileLocation = @"..\..\catalogue.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(fileLocation);
        Console.WriteLine("Document Loaded");

        string xPathQuery = "/Catalogue/Artist/Album";

        XmlNodeList artistList = doc.SelectNodes(xPathQuery);
        Dictionary<string, int> albumsDic = new Dictionary<string, int>();

        foreach (XmlNode node  in artistList)
        {
            var albumName = node.Attributes["name"].Value;
            int year = int.Parse(node["Year"].InnerText);
            int currentYear = DateTime.Now.Year;

            if ((currentYear - year) <= 5)
            {
                var price = node["Price"].InnerText;
                Console.WriteLine("The Album: {0} price is {1}",albumName,price);
            }
        }
    }
}