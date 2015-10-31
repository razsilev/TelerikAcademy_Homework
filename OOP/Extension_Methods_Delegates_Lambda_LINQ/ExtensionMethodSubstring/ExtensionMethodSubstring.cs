using System;
using System.Text;

// 1. Implement an extension method Substring(int index, int length)
//    for the class StringBuilder that returns new StringBuilder and 
//    has the same functionality as Substring in the class String.


namespace ExtensionMethodSubstring
{
    class ExtensionMethodSubstring
    {
        static void Main()
        {
            StringBuilder text = new StringBuilder("Telerik Akademy. . .");

            Console.WriteLine("text: {0}", text);
            Console.WriteLine("\nGet substring whit start index 8 and length 8");
            Console.WriteLine("by using extension method");
            Console.WriteLine("\nSubstring is: -> {0} <-\n", text.Substring(8, 8));
        }
    }
}
