
using System;
using System.IO;

namespace _4_ComparesTextFilesByLines
{
    class ComparesTextFilesByLines
    {
        static void Main()
        {
            Console.Title = "Compares two text files line by line";

            Console.Write("Enter full File 1 path: ");
            string firstFilePath = Console.ReadLine();

            Console.Write("Enter full File 2 path: ");
            string secondFilePath = Console.ReadLine();

            ComparesFiles(firstFilePath, secondFilePath);
        }

        private static void ComparesFiles(string firstFilePath, string secondFilePath)
        {
            using (StreamReader firstReader = new StreamReader(firstFilePath))
            {
                using (StreamReader secondReader = new StreamReader(secondFilePath))
                {
                    int lineCount = 0;
                    while (!firstReader.EndOfStream)
                    {
                        lineCount++;
                        string firstStr = firstReader.ReadLine();
                        string secondStr = secondReader.ReadLine();

                        bool isEqual = firstStr.Equals(secondStr);

                        PrintResults(lineCount, isEqual);
                    }
                }
            }
        }

        private static void PrintResults(int lineCount, bool isEqual)
        {
            if (isEqual)
            {
                Console.WriteLine("Line {0} is same", lineCount);
            }
            else
            {
                Console.WriteLine("Line {0} is different", lineCount);
            }
        } 
    }
}
