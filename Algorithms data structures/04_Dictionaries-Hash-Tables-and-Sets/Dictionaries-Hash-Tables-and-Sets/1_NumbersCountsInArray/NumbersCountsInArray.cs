namespace _1_NumbersCountsInArray
{
    using System.Collections.Generic;
    using System.Linq;

    public class NumbersCountsInArray
    {
        public static void Main()
        {
            List<double> numbers = new List<double>() { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var numbersOccurs = FindNumbersOccurs(numbers);
            PrintOccurses(numbersOccurs);
        }

        private static void PrintOccurses(Dictionary<double, int> numbersOccurs)
        {
            var sortedOccurs = numbersOccurs.OrderBy(x => x.Key);
            foreach (var item in sortedOccurs)
            {
                System.Console.WriteLine("{0} -> {1} Times", item.Key, item.Value);
            }
        }

        private static Dictionary<double, int> FindNumbersOccurs(List<double> numbers)
        {
            Dictionary<double, int> numbersCounts = new Dictionary<double, int>();

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
