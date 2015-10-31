using System;
using System.Collections.Generic;
using System.Text;

//20.   Write a program that extracts from a given text 
//      all palindromes, e.g. "ABBA", "lamal", "exe".

namespace _20_PalindromesFinder
{
    class PalindromesFinder
    {
        static void Main()
        {
            Console.Title = "Faind palindromes in text";

            string text = "given text all ABBA palindromes, e.g. lamal, exe.";
            Console.WriteLine(text);

            string[] palindroms = FindPalindroms(text);

            Console.WriteLine("\nPalindromes are:\n");
            for (int i = 0; i < palindroms.Length; i++)
            {
                Console.WriteLine(palindroms[i]);
            }

            Console.WriteLine();
        }

        private static string[] FindPalindroms(string text)
        {
            List<string> palindroms = new List<string>();

            string[] words = GetWords(text);

            foreach (string word in words)
            {
                if (IsPalindrome(word))
                {
                    palindroms.Add(word);
                }
            }

            return palindroms.ToArray();
        }

        private static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
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
