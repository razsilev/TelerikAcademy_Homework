using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    //Write a program, which using LINQ and XDocument extracts all song titles from catalog.xml.

    static void Main()
    {
        XDocument doc = XDocument.Load(@"..\..\catalogue.xml");

        var songs =
            from song in doc.Descendants("Song")
            select new
            {
                Title = song.Element("Title").Value
            };

        foreach (var song in songs)
        {
            Console.WriteLine("Song title is {0}", song.Title);
        }
    }
}
