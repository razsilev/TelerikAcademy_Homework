using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class Program
{
    //01. Create a XML file representing catalogue. 
    //The catalogue should contain albums of different artists. 
    //For each album you should define: name, artist, year, producer, price and a list of songs. 
    //Each song should be described by title and duration.

    static void Main()
    {
        XmlDocument xml = new XmlDocument();
        XmlNode catalogue = xml.AppendChild(xml.CreateElement("Catalogue"));

        Dictionary<string, double> songList = new Dictionary<string, double>() 
        {
            {"Udriii", 3.0 },
            {"Udriii1", 3.34 },
            {"Udriii2", 3.56 },
            {"Udriii3", 5.32 },
            {"Udriii4", 3 }
        };

        for (int i = 0; i < 3; i++)
        {
            var album = AddAlbum(xml, catalogue, "Tralala", "Prodigy", "1998", "Ba li go", 100.0m);

            AddSongsInAlbum(xml, songList, album["Songs"]);
        }

        xml.Save(@"..\..\catalogue.xml");
    }

    static XmlNode AddAlbum(XmlDocument xml, XmlNode catalogue, string albumName, string artistName, string year, string producerName, decimal price)
    {
        XmlNode artist = catalogue.AppendChild(xml.CreateElement("Artist"));
        XmlAttribute artistAttrName = artist.Attributes.Append(xml.CreateAttribute("name"));
        artistAttrName.InnerText = artistName;

        XmlNode album = AddChild(xml, artist, "Album");
        XmlAttribute albumAttrName = album.Attributes.Append(xml.CreateAttribute("name"));
        albumAttrName.InnerText = albumName;

        XmlNode promYear = AddChild(xml, album, "Year");
        promYear.InnerText = year;

        XmlNode producer = AddChild(xml, album, "Producer");
        producer.InnerText = producerName;

        XmlNode albumPrice = AddChild(xml, album, "Price");
        albumPrice.InnerText = price.ToString();

        XmlNode songs = AddChild(xml, album, "Songs");
        return album;
    }

    static void AddSongsInAlbum(XmlDocument xml, Dictionary<string, double> songsList, XmlNode album)
    {
        foreach (var songName in songsList)
        {
            XmlNode song = album.AppendChild(xml.CreateElement("Song"));
            XmlNode title = song.AppendChild(xml.CreateElement("Title"));
            XmlNode duration = song.AppendChild(xml.CreateElement("Duration"));
            title.InnerText = songName.Key;
            duration.InnerText = songName.Value.ToString();
        }
    }

    static XmlNode AddChild(XmlDocument xml, XmlNode node, string nodeName)
    {
        XmlNode newNode = node.AppendChild(xml.CreateElement(nodeName));
        return newNode;
    }
}

