using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//22.  Write a program that reads a string from the console
//     and lists all different words in the string along with
//     information how many times each word is found.


namespace _22_CountWords
{
    class CountWords
    {
        static void Main()
        {
            Console.Title = "Count Words";

            string inputString = "string word in the string the many times the word is found.";

            Dictionary<string, int> wordCount = GetWordsCount(inputString);

            var sortedByCount = wordCount.OrderByDescending( w => w.Value);

            Console.WriteLine("count -> word");
            foreach (var item in sortedByCount)
            {
                Console.WriteLine("{0} -> {1}", item.Value, item.Key);
            }

            Console.WriteLine();
        }

        private static Dictionary<string, int> GetWordsCount(string text)
        {
            string[] words = GetWords(text);

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordsCount.ContainsKey(word))
                    {
                        wordsCount[word]++;
                    }
                    else
                    {
                        wordsCount.Add(word, 1);
                    }
            }

            return wordsCount;

        }

        private static string[] GetWords(string text)
        {
            List<string> words = new List<string>();
            StringBuilder word = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetter(c))
                {
                    word.Append(c);
                }
                else
                {
                    if (word.Length > 1)
                    {
                        words.Add(word.ToString());
                    }

                    word.Clear();
                }
            }

            if (word.Length > 1)
            {
                words.Add(word.ToString());
                word.Clear();
            }

            return words.ToArray();
        }
    }
}
