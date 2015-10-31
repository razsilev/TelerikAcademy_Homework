using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace _12_RemoveListOfWordsFromFile
{
    class RemoveListOfWordsFromFile
    {
        static void Main()
        {
            Console.Title = "Remove list of words from file";

            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            Console.Write("Enter path to file whit words for remove: ");
            string fileWordsPath = Console.ReadLine();
            Console.WriteLine();

            try
            {
                string tempExtention = ".txt";

                using (StreamReader reader = new StreamReader(filePath))
                {
                    List<string> listOfWords = GetListOfWords(fileWordsPath);
                    listOfWords = listOfWords.OrderBy(x => x.Length).ToList();

                    using (StreamWriter writer = new StreamWriter(filePath + tempExtention))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            line = DeleteWords(line, listOfWords);

                            writer.WriteLine(line);
                        }
                    }
                }

                File.Delete(filePath);
                File.Move(filePath + tempExtention, filePath);

                Console.WriteLine("The words are deleted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<string> GetListOfWords(string path)
        {
            List<string> words = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string word = reader.ReadLine().Trim();
                    words.Add(word);
                }
            }

            return words;
        }

        private static string DeleteWords(string line, List<string> wordsForDelete)
        {
            StringBuilder word = new StringBuilder();
            StringBuilder replasedString = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                // get whole word
                if (line[i] >= 'a' && line[i] <= 'z' || line[i] >= 'A' && line[i] <= 'Z' ||
                    line[i] == '_' || line[i] == '-' || line[i] >= '0' && line[i] <= '9')
                {
                    word.Append(line[i]);
                }
                else
                {
                    char separator = line[i];
                    DeleteWord(separator, wordsForDelete, word, replasedString);

                    word.Clear();
                }
            }

            DeleteLastWord(wordsForDelete, word, replasedString);

            return replasedString.ToString();
        }

        private static void DeleteWord(char separator, List<string> wordsForDelete, 
                                StringBuilder word, StringBuilder replasedString)
        {
            bool deleteWord = false;
            int wordLength = word.Length;
            // check for enough characters to be searched in given list.
            // List is sorted by word lengt ascending
            if (wordLength >= wordsForDelete[0].Length && 
                    wordLength <= wordsForDelete[wordsForDelete.Count - 1].Length)
            {
                for (int j = 0; j < wordsForDelete.Count; j++)
                {
                    if (wordsForDelete[j].Equals(word.ToString()))
                    {
                        deleteWord = true;
                        break;
                    }
                }
            }

            if (!deleteWord)
            {
                replasedString.Append(word);
                replasedString.Append(separator);
            }
        }

        private static void DeleteLastWord(List<string> wordsForDelete, StringBuilder word,
                                   StringBuilder replasedString)
        {
            bool deleteWord = false;
            int wordLength = word.Length;

            if (wordLength >= wordsForDelete[0].Length &&
                    wordLength <= wordsForDelete[wordsForDelete.Count - 1].Length)
            {
                for (int i = 0; i < wordsForDelete.Count; i++)
                {
                    if (wordsForDelete[i].Equals(word.ToString()))
                    {
                        deleteWord = true;
                        break;
                    }
                }
            }

            if (!deleteWord)
            {
                replasedString.Append(word);
            }
        }
    }
}
