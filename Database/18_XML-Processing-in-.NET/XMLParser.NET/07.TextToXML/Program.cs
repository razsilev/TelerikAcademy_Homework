using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

class Program
{
    //7.In a text file we are given the name, address and phone number of given person 
    //(each at a single line). Write a program, which creates new XML document, 
    //which contains these data in structured XML format.

    static void Main()
    {
        string fileLocation = @"..\..\person.xml";
        string[] lines = File.ReadAllLines(@"..\..\Person.txt");
        string name = lines[0];
        string address = lines[1];
        string phoneNumber = lines[2];

        XElement personInfo = new XElement("Person",
                    new XElement("name", name),
                    new XElement("address", address),
                    new XElement("phoneNumber", phoneNumber));

        personInfo.Save(fileLocation);
    }
}