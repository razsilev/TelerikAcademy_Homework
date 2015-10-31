using System;
using System.IO;

namespace _7_ReplaseStringInFile
{
    class ReplacesStringInFile
    {
        static void Main()
        {
            Console.Title = "Replase String In File";

            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            try
            {
                Replaces(filePath);
                Console.WriteLine("\nReplase finish successfully...\n");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private static void Replaces(string filePath)
        {
            string tempFilePath = filePath + ".txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string str = reader.ReadLine();

                        string replasedString = str.Replace("start", "finish");

                        writer.WriteLine(replasedString);
                    }
                }
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
            File.Delete(tempFilePath);
        }
    }
}
