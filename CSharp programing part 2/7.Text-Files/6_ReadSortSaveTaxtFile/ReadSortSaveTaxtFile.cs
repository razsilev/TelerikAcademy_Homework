using System;
using System.Collections.Generic;
using System.IO;

namespace _6_ReadSortSaveTaxtFile
{
    class ReadSortSaveTaxtFile
    {
        static void Main()
        {
            Console.Title = "Read, sort and save taxt file";

            Console.Write("Enter full file path: ");
            string filePath = Console.ReadLine();
            string resultFileName = "Sorted_Strings.txt";
            string resultPath = GetFilePath(filePath) + resultFileName;

            try
            {
                List<string> strings = GetStringList(filePath);

                strings.Sort();

                SaveToFail(strings, resultPath);

                Console.WriteLine("Operation complete successfully.");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }

        private static void SaveToFail(List<string> strings, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int row = 0; row < strings.Count; row++)
                {
                    writer.WriteLine(strings[row]);
                }
            }
        }

        private static List<string> GetStringList(string filePath)
        {
            List<string> strings = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    strings.Add(reader.ReadLine());
                }                
            }

            return strings;
        }

        private static string GetFilePath(string fullFilePath)
        {
            int endIndex = fullFilePath.LastIndexOf('\\');

            string path = fullFilePath.Substring(0, endIndex + 1);

            return path;
        }
    }
}
