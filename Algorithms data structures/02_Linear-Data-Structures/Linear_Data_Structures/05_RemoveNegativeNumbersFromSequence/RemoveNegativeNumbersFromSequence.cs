namespace _05_RemoveNegativeNumbersFromSequence
{
    using System.Collections.Generic;

    public class RemoveNegativeNumbersFromSequence
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { -1, 1, 5, -5, -5, 7, -7, 7, -7, 7 };
            var positiveNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= 0)
                {
                    positiveNumbers.Add(numbers[i]);
                }
            }

            System.Console.WriteLine("All numbers are:");
            System.Console.WriteLine(string.Join(", ", numbers));

            System.Console.WriteLine("\nPositive numbers are:");
            System.Console.WriteLine(string.Join(", ", positiveNumbers));
        }
    }
}
