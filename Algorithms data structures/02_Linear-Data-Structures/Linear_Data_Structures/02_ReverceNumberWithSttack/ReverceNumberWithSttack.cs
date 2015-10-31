namespace _02_ReverceNumberWithSttack
{
    using System;
    using System.Collections.Generic;

    public class ReverceNumberWithSttack
    {
        private static Stack<int> numbers = new Stack<int>();

        public static void Main()
        {
            ReadNumbers();

            Console.WriteLine("\n Number in reverced order using stack.");
            while (numbers.Count > 0)
            {
                Console.WriteLine("sum: {0}", numbers.Pop());
            }
        }

        private static void ReadNumbers()
        {
            string input = "0";

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
                    numbers.Push(number);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}
