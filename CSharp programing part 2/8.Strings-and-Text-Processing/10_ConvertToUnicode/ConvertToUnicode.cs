using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 10.   Write a program that converts a string to a sequence
//       of C# Unicode character literals. Use format strings. Sample input:

namespace _10_ConvertToUnicode
{
    class ConvertToUnicode
    {
        static void Main()
        {
            Console.Title = "Convert To Unicode";

            Console.Write("Enter text to convert: ");
            string text = Console.ReadLine();

            StringBuilder unicodeString = new StringBuilder();

            foreach (char symbol in text)
            {
                unicodeString.AppendFormat("\\u{0:X4}", (int)symbol);
            }

            Console.WriteLine(unicodeString);
        }
    }
}
