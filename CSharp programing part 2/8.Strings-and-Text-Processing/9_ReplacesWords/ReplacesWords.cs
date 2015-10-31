using System;
using System.Collections.Generic;
using System.Text;

// 9.  We are given a string containing a list of forbidden
//     words and a text containing some of these words. 
//     Write a program that replaces the forbidden words with asterisks

namespace _9_ReplacesWords
{
    class ReplacesWords
    {
        static void Main()
        {
            Console.Title = "Replaces Words";

            string str = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            string words = "PHP, CLR, Microsoft";

            string replacedWords = ReplaceWords(str, words);

            Console.WriteLine("\nResult ->  {0}\n", replacedWords);
        }

        private static string ReplaceWords(string text, string words)
        {
            StringBuilder result = new StringBuilder(text.Length);
            StringBuilder word = new StringBuilder();
            string[] wordsArray = words.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);

            foreach (char sumbol in text)
            {
                if (!char.IsSeparator(sumbol) && !char.IsPunctuation(sumbol))
                {
                    word.Append(sumbol);
                }
                else
                {
                    for (int i = 0; i < wordsArray.Length; i++)
                    {
                        string str = word.ToString();
                        if (str.Equals(wordsArray[i].Trim()))
                        {
                            word.Clear();
                            word.Append(new string('*', str.Length));
                            break;
                        }
                    }

                    result.Append(word);
                    result.Append(sumbol);

                    word.Clear();                    
                }
            }

            result.Append(word);

            return result.ToString();
        }
    }
}
