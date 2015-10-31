using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _13FaindWordsCount
{
    class FaindWordsCount
    {
        static void Main()
        {
            Console.Title = "Faind Words Count";

            Console.Write("Enter path to file words.txt: ");
            string fileWordsPath = Console.ReadLine();

            Console.Write("Enter path to file test.txt: ");
            string filePath = Console.ReadLine();
            Console.WriteLine();

            string resultPath = GetFilePath(filePath) + "result.txt";

            try
            {
                Engine(fileWordsPath, filePath, resultPath);
                Console.WriteLine(" The operations are completed successfully...\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private static void Engine(string fileWordsPath, string filePath, string resultPath)
        {
            Dictionary<string, uint> wordsAndCountInText = new Dictionary<string, uint>();
            Dictionary<string, uint> resultWordCunt;
            List<string> checkWords = new List<string>();

            checkWords = GetListOfWords(fileWordsPath);
            wordsAndCountInText = GetWordsAndCount(filePath);
            resultWordCunt = CheckContainedWord(wordsAndCountInText, checkWords);

            checkWords.Clear();
            wordsAndCountInText.Clear();

            var sortedWordCount = resultWordCunt.OrderByDescending(r => r.Value);

            SaveResults(sortedWordCount, resultPath);
        }

        private static void SaveResults(IOrderedEnumerable<KeyValuePair<string, uint>> sortedWordCount, string resultPath)
        {
            using (StreamWriter writer = new StreamWriter(resultPath))
            {
                foreach (KeyValuePair<string, uint> item in sortedWordCount)
                {
                    writer.WriteLine("{0,2} -> {1}", item.Value, item.Key);
                }
            }
        }

        private static Dictionary<string, uint> CheckContainedWord(Dictionary<string, uint> wordsAndCountInText,
                                                                        List<string> checkWords)
        {
            Dictionary<string, uint> resultCount = new Dictionary<string, uint>();

            foreach (var word in checkWords)
            {
                if (wordsAndCountInText.ContainsKey(word))
                {
                    resultCount.Add(word, wordsAndCountInText[word]);
                }
                else
                {
                    resultCount.Add(word, 0);
                }
            }

            return resultCount;
        }

        private static List<string> GetListOfWords(string fileWordsPath)
        {
            List<string> words = new List<string>();

            using (StreamReader reader = new StreamReader(fileWordsPath))
            {
                while (!reader.EndOfStream)
                {
                    string word = reader.ReadLine().Trim();
                    words.Add(word);
                }
            }

            return words;
        }

        private static Dictionary<string, uint> GetWordsAndCount(string filePath)
        {
            Dictionary<string, uint> result = new Dictionary<string, uint>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] words = GetWords(line);

                    for (int i = 0; i < words.Length; i++)
                    {
                        if (result.ContainsKey(words[i]))
                        {
                            result[words[i]]++;
                        }
                        else
                        {
                            result.Add(words[i], 1);
                        }
                    }
                }
            }

            return result;
        }

        private static string[] GetWords(string line)
        {
            StringBuilder word = new StringBuilder();
            List<string> words = new List<string>();
            bool isWord = false;

            for (int i = 0; i < line.Length; i++)
            {
                
                // get whole word
                if (line[i] >= 'a' && line[i] <= 'z' || line[i] >= 'A' && line[i] <= 'Z' ||
                    line[i] == '_' || line[i] == '-' || line[i] >= '0' && line[i] <= '9')
                {
                    word.Append(line[i]);
                    isWord = true;
                }
                else if (isWord)
                {
                    words.Add(word.ToString());
                    word.Clear();
                    isWord = false;
                }
            }

            return words.ToArray();
        }

        private static string GetFilePath(string fullFilePath)
        {
            int endIndex = fullFilePath.LastIndexOf('\\');

            string path = fullFilePath.Substring(0, endIndex + 1);

            return path;
        }
    }
}
