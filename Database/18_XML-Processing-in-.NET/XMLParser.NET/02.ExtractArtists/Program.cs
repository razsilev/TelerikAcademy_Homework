using System;
using System.Collections.Generic;
using System.Xml;

class Program
{
    //Write program that extracts all different artists which 
    //are found in the catalog.xml. 
    //For each author you should print the number of albums 
    //in the catalogue. Use the DOM parser and a hash-table

    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"..\..\catalogue.xml");
        Console.WriteLine("Document Loaded");

        XmlNode rootNode = doc.DocumentElement;
        Console.WriteLine("Root node is: {0}", rootNode.Name);

        Dictionary<string, int> dic = new Dictionary<string, int>();

        foreach (XmlNode artist in rootNode.ChildNodes)
        {
            var artistName = artist.Attributes["name"].Value;
            var albumsCount = artist.ChildNodes.Count;

            if (!dic.ContainsKey(artist.Attributes["name"].Value))
            {
                dic.Add(artistName, albumsCount);
            }
        }

        foreach (var artistInfo in dic)
        {
            Console.WriteLine("{0} has {1} albums.", artistInfo.Key, artistInfo.Value);
        }
    }
}