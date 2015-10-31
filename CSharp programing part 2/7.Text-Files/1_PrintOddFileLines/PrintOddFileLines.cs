using System;
using System.IO;

namespace _1_PrintOddFileLines
{
    class PrintOddFileLines
    {
        static void Main()
        {
            Console.Title = "Print odd file lines";

            Console.Write("Enter full File path: ");

            string path = Console.ReadLine();

            using (StreamReader reader = new StreamReader(path))
            {
                int count = 1;

                while (!reader.EndOfStream)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine("Line: {0,-3} -> {1}", count, reader.ReadLine());
                    }
                    else
                    {
                        reader.ReadLine();
                    }

                    count++;
                }
            }
        }
    }
}
