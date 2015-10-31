using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

class Program
{
    //Write program that extracts all different artists which 
    //are found in the catalog.xml. For each author you 
    //should print the number of albums in the catalogue.
    //Implement the previous using XPath.

    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"..\..\catalogue.xml");
        Console.WriteLine("Document Loaded");

        string xPathQuery = "/Catalogue/Artist";

        XmlNodeList artistList = doc.SelectNodes(xPathQuery);
        Dictionary<string, int> dic = new Dictionary<string, int>();

        foreach (XmlNode artist in artistList)
        {
            var artistName = artist.Attributes["name"].Value;
            var albumsCount = artist.ChildNodes.Count;

            if (!dic.ContainsKey(artistName))
            {
                dic.Add(artistName, albumsCount);
            }
        }

        foreach (var artist in dic)
        {
            Console.WriteLine(artist.Key + " " + artist.Value);
        }
    }
}