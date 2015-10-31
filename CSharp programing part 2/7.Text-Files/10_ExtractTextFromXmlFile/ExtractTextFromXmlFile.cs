using System;
using System.IO;

namespace _10_ExtractTextFromXmlFile
{
    class ExtractTextFromXmlFile
    {
        static void Main()
        {
            Console.Title = "Extract text from XML file";

            Console.Write("Enter XML file path: ");
            string filePath = Console.ReadLine();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    PrintTextWithoutTags(line);
                }
            }

            Console.WriteLine();
        }

        private static void PrintTextWithoutTags(string line)
        {
            bool isContinue = false;
            bool isPrint = false;

            for (int i = 0; i < line.Length; i++)
            {
                char charactrer = line[i];
                
                if (charactrer == '<')
                {
                    if (isPrint)
                    {
                        Console.WriteLine();
                        isPrint = false;
                    }
                    isContinue = true;
                }

                if (charactrer != '>' && isContinue)
                {
                    continue;
                }
                else
                {
                    isContinue = false;
                }

                if (charactrer != '>')
                {
                    Console.Write(charactrer);
                    isPrint = true;
                }
                // E:\xml.txt
            }
        }
    }
}
