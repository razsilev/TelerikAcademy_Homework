using System;
using System.IO;

namespace _3ReadFileContent
{
    class ReadFileContent
    {
        static void Main()
        {
            Console.Title = "Read file content";

            Console.Write("Enter full file path whit file name: ");

            string path = Console.ReadLine();

            try
            {
                string content = System.IO.File.ReadAllText(path);

                Console.WriteLine("\nfile have: {0} sumbols", content.Length);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Path is too long!!!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found!!!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!!!");
            }
            catch (IOException)
            {
                Console.WriteLine("Read time exceptin!!!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Unauthorized access!!!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Enter path!!!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid path format!!!");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Not supported file!!!");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("There is security error!!!");
            }

        }
    }
}
