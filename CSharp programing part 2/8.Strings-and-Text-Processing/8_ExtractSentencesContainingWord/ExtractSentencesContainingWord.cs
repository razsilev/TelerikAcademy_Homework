using System;
using System.Text;
using System.Collections.Generic;

// 8   Write a program that extracts from a given text all sentences containing given word.
//     Example: The word is "in". The text is:
// 	   Consider that the sentences are separated by "." and the words – by non-letter symbols.


namespace _8_ExtractSentencesContainingWord
{
    class ExtractSentencesContainingWord
    {
        static void Main(string[] args)
        {
            Console.Title = "Extract Sentences Containing Word";

            string sentences = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string word = "are";

            StringBuilder extractedSentences = ExtractSentences(sentences, word);

            Console.WriteLine(extractedSentences);
        }

        private static StringBuilder ExtractSentences(string sentences, string word)
        {
            // if the sentence separators are:  . ? !  uncomment this and comment next
            //string[] sentenceArray = GetSentences(sentences);
            string[] sentenceArray = sentences.Split('.');

            StringBuilder result = new StringBuilder();
            string wordOnly = " " + word + " ";

            foreach (string sentence in sentenceArray)
            {
                if (sentence.Contains(wordOnly))
                {
                    result.Append(sentence.Trim());
                    result.Append('.'); // <- comment this to
                    result.AppendLine();
                }
            }

            return result;
        }

        private static string[] GetSentences(string sentences)
        {
            List<string> sentenceArray = new List<string>();
            StringBuilder sentence = new StringBuilder();

            foreach (char sumbol in sentences)
            {
                if (sumbol != '.' && sumbol != '?' && sumbol != '!')
                {
                    sentence.Append(sumbol);
                }
                else
                {
                    sentence.Append(sumbol);
                    sentenceArray.Add(sentence.ToString());
                    sentence.Clear();
                }
            }

            return sentenceArray.ToArray();
        }
    }
}
