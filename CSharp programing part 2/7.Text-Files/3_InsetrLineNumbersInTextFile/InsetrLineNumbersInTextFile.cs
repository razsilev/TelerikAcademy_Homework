using System;
using System.IO;

namespace _3_InsetrLineNumbersInTextFile
{
    class InsetrLineNumbersInTextFile
    {
        static void Main()
        {
            Console.Title = "Insetr line numbers in text file";

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter full file name: ");
            string fileName = Console.ReadLine();

            string resultFileName = "\nwhit_Line_Numbers_\n" + fileName;

            try
            {
                using (StreamWriter writer = new StreamWriter(path + resultFileName))
                {
                    using (StreamReader reader = new StreamReader(path + fileName))
                    {
                        int count = 0;

                        while (!reader.EndOfStream)
                        {
                            count++;

                            writer.WriteLine("{0}. {1}", count, reader.ReadLine());
                        }
                    }
                }

                Console.WriteLine("Line numbers are inserted successfully...");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
