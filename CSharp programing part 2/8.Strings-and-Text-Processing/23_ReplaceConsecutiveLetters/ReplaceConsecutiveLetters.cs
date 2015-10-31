using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//23. Write a program that reads a string from the console
//    and replaces all series of consecutive identical letters
//    with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".


namespace _23_ReplaceConsecutiveLetters
{
    class ReplaceConsecutiveLetters
    {
        static void Main()
        {
            Console.Title = "Replace Consecutive Letters";

            string text = "I aaaamm tthhhheeee bestt, don't you aaaa?";

            string replacedConsecutive = RemoveConsecutive(text);

            Console.WriteLine(text);
            Console.WriteLine(replacedConsecutive);
            Console.WriteLine();
        }

        private static string RemoveConsecutive(string text)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder word = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetter(c))
                {
                    if (word.Length > 0 && c != word[word.Length - 1])
                    {
                        word.Append(c);
                    }
                    else if (word.Length == 0)
                    {
                        word.Append(c);
                    }
                }
                else
                {
                    if (word.Length > 0)
                    {
                        result.Append(word.ToString());
                    }

                    word.Clear();
                    result.Append(c);
                }
            }

            if (word.Length > 1)
            {
                result.Append(word.ToString());
                word.Clear();
            }

            return result.ToString();
        }
    }
}
