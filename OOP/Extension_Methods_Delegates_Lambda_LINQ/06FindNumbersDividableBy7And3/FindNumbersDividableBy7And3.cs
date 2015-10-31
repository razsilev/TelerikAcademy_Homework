using System;
using System.Linq;

// 6.   Write a program that prints from given array of integers
//      all numbers that are divisible by 7 and 3. Use the built-in
//      extension methods and lambda expressions. 
//      Rewrite the same with LINQ.


namespace _06FindNumbersDividableBy7And3
{
    class FindNumbersDividableBy7And3
    {
        static void Main()
        {
            int[] numbers = { 3, 5, 21, 63, 55, 12 };

            var resultNumbers = numbers.Where(n => (n % 3 == 0 && n % 7 == 0));

            Console.WriteLine("Extension methods and lambda expressions result:");
            foreach (var num in resultNumbers)
            {
                Console.Write("{0} ", num);
            }

            Console.WriteLine("\n");

            var linqResult = from n in numbers
                             where n % 3 == 0 && n % 7 == 0
                             orderby n descending
                             select n;

            Console.WriteLine("LINQ result:");
            foreach (var num in linqResult)
            {
                Console.Write("{0} ", num);
            }

            Console.WriteLine("\n");
        }
    }
}
