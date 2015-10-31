namespace _07_NumbersCountsInArray
{
    using System.Collections.Generic;
    using System.Linq;

    public class NumbersCountsInArray
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var numbersOccurs = FindNumbersOccurs(numbers);
            PrintOccurses(numbersOccurs);
        }

        private static void PrintOccurses(Dictionary<int, int> numbersOccurs)
        {
            var sortedOccurs = numbersOccurs.OrderBy(x => x.Key);
            foreach (var item in sortedOccurs)
            {
                System.Console.WriteLine("{0} -> {1} Times", item.Key, item.Value);
            }
        }

        private static Dictionary<int, int> FindNumbersOccurs(List<int> numbers)
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

            return numbersCounts;
        }
    }
}
