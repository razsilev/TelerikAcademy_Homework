using System;
using System.IO;
using System.Text;

namespace _11_DeletePrefixWordInTextFile
{
    class DeletePrefixWordInTextFile
    {
        static void Main()
        {
            Console.Title = "Delete prefix word in text file";

            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            try
            {
                DeleteWord(filePath);
                Console.WriteLine("\nDeleting finish successfully...\n");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DeleteWord(string filePath)
        {
            string tempFilePath = filePath + ".txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string str = reader.ReadLine();

                        string replasedString = DeletePrefixWords(str, "test");

                        writer.WriteLine(replasedString);
                    }
                }
            }

            File.Delete(filePath);

            File.Move(tempFilePath, filePath);
        }

        private static string DeletePrefixWords(string str, string prefix)
        {
            StringBuilder word = new StringBuilder();
            StringBuilder replasedString = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                // get whole word
                if (str[i] >= 'a' && str[i] <= 'z' || str[i] >= 'A' && str[i] <= 'Z'
                    || str[i] == '_' || str[i] >= '0' && str[i] <= '9')
                {
                    word.Append(str[i]);
                }
                else
                {
                    if (!word.ToString().StartsWith(prefix))
                    {
                        replasedString.Append(word);
                        replasedString.Append(str[i]);
                    }

                    word.Clear();
                }
            }

            if (!word.ToString().StartsWith(prefix))
            {
                replasedString.Append(word);
            }

            return replasedString.ToString();
        }
    }
}
