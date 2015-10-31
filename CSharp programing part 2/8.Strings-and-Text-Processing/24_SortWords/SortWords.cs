using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//24.  Write a program that reads a list of words,
//     separated by spaces and prints the list in an 
//     alphabetical order.

namespace _24_SortWords
{
    class SortWords
    {
        static void Main()
        {
            Console.Title = "Sort Words";

            string listOfWords = "Write program that reads  list of words";

            string[] words = listOfWords.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            string[] sortedWords = words.OrderBy(word => word).ToArray();

            Console.WriteLine(listOfWords);

            Console.WriteLine("\nSorted wotds:");
            for (int i = 0; i < sortedWords.Length; i++)
            {
                Console.WriteLine(sortedWords[i]);
            }

            Console.WriteLine();
        }
    }
}
