using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 13   Write a program that reverses the words in given sentence.
//  	Example: "C# is not C++, not PHP and not Delphi!" 
//       "Delphi not and PHP, not C++ not is C#!".


namespace _13_ReverceWord
{
    class ReverceWord
    {
        static void Main()
        {
            Console.Title = "Reverce Word";

            string text = "C# is not C++, not PHP and not Delphi!";
            
            string revercedWotds = Reverce(text);

            Console.WriteLine("original text: {0}\n", text);
            Console.WriteLine("reverced text: {0}\n", revercedWotds);
        }

        private static string Reverce(string text)
        {
            string[] words = GetWords(text);
            string[] separators = GetSeparators(text);

            StringBuilder result = new StringBuilder(text.Length);
            int separatorCount = 0;

            for (int i = words.Length - 1; i >= 0; i--)
            {
                string separator;

                if (separatorCount < separators.Length)
                {
                    separator = separators[separatorCount];
                    separatorCount++;
                }
                else
                {
                    separator = "";
                }

                result.AppendFormat("{0}{1}", words[i], separator);
            }

            return result.ToString();
        }

        private static string[] GetSeparators(string text)
        {
            List<string> separators = new List<string>();
            StringBuilder separator = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ' || text[i] == '.' || text[i] == ',' ||
                     text[i] == '!' || text[i] == '?')
                {
                    separator.Append(text[i]);
                }
                else if(separator.Length > 0)
                {
                    separators.Add(separator.ToString());
                    separator.Clear();
                }
            }

            if (separator.Length > 0)
            {
                separators.Add(separator.ToString());
                separator.Clear();
            }

            return separators.ToArray();
        }

        private static string[] GetWords(string text)
        {
            string[] words;

            char[] separators = new char[] { ' ', ',', '.', '?', '!' };

            words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
    }
}
