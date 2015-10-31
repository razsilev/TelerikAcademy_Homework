using System;
using System.IO;

namespace _9_DeleteOddLineInTextFile
{
    class DeleteOddLineInTextFile
    {
        static void Main(string[] args)
        {
            Console.Title = "Delete odd lines in text file";

            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            try
            {
                DeleteOddLines(filePath);
                Console.WriteLine("\nDeleting finish successfully...\n");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DeleteOddLines(string filePath)
        {
            string tempFilePath = filePath + ".txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    bool forDelete = true;
                    while (!reader.EndOfStream)
                    {
                        if (forDelete)
                        {
                            forDelete = false;
                            reader.ReadLine();
                        }
                        else
                        {
                            writer.WriteLine(reader.ReadLine());
                            forDelete = true;
                        }
                        
                    }
                }
            }

            File.Delete(filePath);
            // rename file.
            File.Move(tempFilePath, filePath);
        }
    }
}
