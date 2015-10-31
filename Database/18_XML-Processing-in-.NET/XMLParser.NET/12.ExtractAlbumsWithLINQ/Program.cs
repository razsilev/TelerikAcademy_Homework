using System;
using System.Xml.Linq;
using System.Linq;

class Program
{
    //Write a program, which extract from the file catalog.xml 
    //the prices for all albums, published 5 years ago or earlier. Use LINQ query.

    static void Main()
    {
        string fileLocation = @"..\..\catalogue.xml";
        XDocument xmlDoc = XDocument.Load(fileLocation);
        XName albumTitle = "name";
        int currentYear = DateTime.Now.Year;

        var albums =
           from album in xmlDoc.Descendants("Album")
           where ((currentYear - int.Parse(album.Element("Year").Value)) <= 5)
           select new
           {
               Title = album.Attribute(albumTitle).Value,
               Year = int.Parse(album.Element("Year").Value)
           };

        foreach (var album in albums)
        {
            Console.WriteLine("{0},{1}", album.Title, album.Year);
        }
    }
}