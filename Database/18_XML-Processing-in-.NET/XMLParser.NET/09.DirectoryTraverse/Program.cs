using System;
using System.IO;

class Program
{
    //Write a program to traverse given directory and write to a 
    //XML file its contents together with all subdirectories and files. 
    //Use tags <file> and <dir> with appropriate attributes. 
    //For the generation of the XML document use the class XmlWriter.

    static void Main()
    {
        string directoryLocation = @"..\..\..\09.DirectoryTraverse";
        string[] fileEntries = Directory.GetFiles(directoryLocation);

        string[] directiories = Directory.GetDirectories(directoryLocation);

    }
}
