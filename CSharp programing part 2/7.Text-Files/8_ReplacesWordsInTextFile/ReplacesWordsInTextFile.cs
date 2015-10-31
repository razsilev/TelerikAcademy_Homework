using System;
using System.IO;
using System.Text;

namespace _8_ReplacesWordsInTextFile
{
    class ReplacesWordsInTextFile
    {
        static void Main()
        {
            Console.Title = "Replase Words In File";

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

                        string replasedString = ReplacesWord(str, "start", "finish");

                        writer.WriteLine(replasedString);
                    }
                }
            }

            File.Delete(filePath);
                
            File.Move(tempFilePath, filePath);
        }

        private static string ReplacesWord(string str, string oldValue, string newValue)
        {
            StringBuilder word = new StringBuilder();
            StringBuilder replasedString = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                // get whole word
                if (str[i] >= 'a' && str[i] <= 'z' || str[i] >= 'A' && str[i] <= 'Z')
                {
                    word.Append(str[i]);
                }
                else
                {
                    if (oldValue.Equals(word.ToString()))
                    {
                        replasedString.Append(newValue);
                        replasedString.Append(str[i]);
                    }
                    else
                    {
                        replasedString.Append(word);
                        replasedString.Append(str[i]);
                    }

                    word.Clear();
                }
            }

            if (oldValue.Equals(word.ToString()))
            {
                replasedString.Append(newValue);
            }

            return replasedString.ToString();
        }
    }
}
