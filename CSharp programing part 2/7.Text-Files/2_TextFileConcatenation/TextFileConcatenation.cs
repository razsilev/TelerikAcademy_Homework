using System;
using System.IO;

namespace _2_TextFileConcatenation
{
    class TextFileConcatenation
    {
        static void Main()
        {
            Console.Title = "Text File Concatenation";

            Console.Write("Enter full File 1 path: ");
            string firstFilePath = Console.ReadLine();

            Console.Write("Enter full File 2 path: ");
            string secondFilePath = Console.ReadLine();

            string concatenatedFileName = "Concatenated_file.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(concatenatedFileName))
                {
                    using (StreamReader reader = new StreamReader(firstFilePath))
                    {
                        FileCopy(reader, writer);
                    }

                    using (StreamReader reader = new StreamReader(secondFilePath))
                    {
                        FileCopy(reader, writer);
                    }

                    Console.WriteLine("\nConcatenation finish successful\n");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void FileCopy(StreamReader reader, StreamWriter writer)
        {
            while (!reader.EndOfStream)
            {
                writer.WriteLine(reader.ReadLine());
            }
        }
    }
}
