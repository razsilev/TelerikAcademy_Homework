namespace _06_RemoveOddNumbersCount
{
    using System.Collections.Generic;

    public class RemoveOddNumbersCount
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            List<int> result = RemoveOddNumbersCountFrom(numbers);

            System.Console.WriteLine("initial values: [{0}]", string.Join(", ", numbers));
            System.Console.WriteLine("\nresult values: [{0}]", string.Join(", ", result));
        }

        private static List<int> RemoveOddNumbersCountFrom(List<int> numbers)
        {
            Dictionary<int, int> numbersCounts = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbersCounts.ContainsKey(numbers[i]))
                {
                    numbersCounts[numbers[i]]++;
                }
                else
                {
                    numbersCounts[numbers[i]] = 1;
                }
            }

            var results = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if ((numbersCounts[numbers[i]] % 2) == 0)
                {
                    results.Add(numbers[i]);
                }
            }

            return results;
        }
    }
}