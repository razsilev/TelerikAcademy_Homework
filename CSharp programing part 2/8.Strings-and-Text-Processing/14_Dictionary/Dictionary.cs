using System;
using System.Collections.Generic;

//14   A dictionary is stored as a sequence of text lines
//     containing words and their explanations. Write a program
//     that enters a word and translates it by using the dictionary.
//     Sample dictionary:

namespace _14_Dictionary
{
    class Dictionary
    {
        static void Main()
        {
            Console.Title = "Dictionary";

            string[] dictionaryLines = {
            ".NET - platform for applications from Microsoft",
            "CLR - managed execution environment for .NET",
            "namespace - hierarchical - organization of classes"
            };

            string word = ".NET";

            Dictionary<string, string> dictionary = FillDictionary(dictionaryLines);

            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine("\n{0} - {1}\n", word, dictionary[word]);
            }
            else
            {
                Console.WriteLine("\nIn dictionary \"{0}\" is missing!\n", word);
            }
        }

        private static Dictionary<string, string> FillDictionary(string[] dictionaryLines)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (string line in dictionaryLines)
            {
                string[] splitedLine = line.Split(new string[] {" - "},
                                                StringSplitOptions.RemoveEmptyEntries);

                dictionary.Add(splitedLine[0], splitedLine[1]);
            }

            return dictionary;
        }
    }
}
