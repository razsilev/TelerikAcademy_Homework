using System;
using System.Xml;

class Program
{
    //Using the DOM parser write a program to delete from catalog.xml 
    //all albums having price > 20.

    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        string fileLocation = @"..\..\catalogue.xml";
        doc.Load(fileLocation);
        Console.WriteLine("Document Loaded");

        XmlNode rootNode = doc.DocumentElement;
        var count = rootNode.ChildNodes.Count;

        for (int i = 0; i < count; i++)
        {
            XmlNode album = rootNode.ChildNodes[i];
            XmlNode albumNode = album.FirstChild;

            while (albumNode != null)
            {
                XmlNode nextSibling = albumNode.NextSibling;
                double price = double.Parse(albumNode["Price"].InnerText);

                if (price > 20)
                {
                    album.RemoveChild(albumNode);
                }

                albumNode = nextSibling;
            }
        }

        doc.Save(fileLocation);
    }
}