using System;
using System.Xml;

class Program
{
    //Write a program, which using XmlReader extracts all song titles from catalog.xml

    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"..\..\catalogue.xml");
        Console.WriteLine("Document loaded");

        XmlNode rootNode = doc.DocumentElement;

        using (XmlReader reader = XmlReader.Create(@"..\..\catalogue.xml"))
        {
            while (reader.Read())
            {
                
            }
        }
    }
}