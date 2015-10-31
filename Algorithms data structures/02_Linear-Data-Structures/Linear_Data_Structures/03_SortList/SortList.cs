namespace _03_SortList
{
    using System;
    using System.Collections.Generic;

    public class SortList
    {
        private static List<int> numbers = new List<int>();

        public static void Main()
        {
            ReadNumbers();

            numbers.Sort();

            Console.WriteLine("\nNumbrs in increasing order.");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine("sum: {0}", numbers[i]);
            }
        }

        private static void ReadNumbers()
        {
            string input = string.Empty;

            while (true)
            {
                Console.Write("enter number: ");

                input = Console.ReadLine();

                if (input == string.Empty)
                {
                    break;
                }

                try
                {
                    int number = int.Parse(input);
                    numbers.Add(number);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}
