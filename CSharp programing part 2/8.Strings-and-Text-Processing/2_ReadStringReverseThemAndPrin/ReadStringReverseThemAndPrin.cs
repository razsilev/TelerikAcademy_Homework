using System;

// 2.  Write a program that reads a string, reverses it 
//     and prints the result at the console.
//     Example: "sample"  "elpmas".


namespace _2_ReadStringReverseThemAndPrin
{
    class ReadStringReverseThemAndPrin
    {
        static void Main()
        {
            Console.Title = "Revers string";

            Console.Write("Enter string: ");
            string str = Console.ReadLine();
            char[] sumbols = str.ToCharArray();

            Array.Reverse(sumbols);

            Console.WriteLine(sumbols);
        }
    }
}
