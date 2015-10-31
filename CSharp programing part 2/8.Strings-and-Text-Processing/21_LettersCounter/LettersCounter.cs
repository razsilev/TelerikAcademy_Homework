using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//21. Write a program that reads a string from the console
//    and prints all different letters in the string along 
//    with information how many times each letter is found.

namespace _21_LettersCounter
{
    class LettersCounter
    {
        static void Main(string[] args)
        {
            Console.Title = "Letters Counter";

            string text = "Write a program.";
            
            Dictionary<char, int> lettersCount = GetLettersCount(text);

            var sortedLetersByCount = lettersCount.OrderByDescending( c => c.Value);

            foreach (var character in sortedLetersByCount)
            {
                Console.WriteLine("{0} -> {1}", character.Value, character.Key);
            }

        }

        private static Dictionary<char, int> GetLettersCount(string text)
        {
            Dictionary<char, int> lettersCount = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    if (lettersCount.ContainsKey(c))
                    {
                        lettersCount[c]++;
                    }
                    else
                    {
                        lettersCount.Add(c, 1);
                    }
                }
            }

            return lettersCount;
        }
    }
}
