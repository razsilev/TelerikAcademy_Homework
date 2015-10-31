namespace SumAndAverageInSequence
{
    using System;
    using System.Collections.Generic;

    public class SumAndAverageInSequence
    {
        private static List<uint> numbers = new List<uint>();

        public static void Main()
        {
            ReadNumbers();
            long sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine("sum: {0}", sum);
            Console.WriteLine("Average: {0}", (double)sum / numbers.Count);
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
                    uint number = uint.Parse(input);
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
