namespace _08_FindMajorant
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var majorantCandidate = FindMaxOccurElement(numbers);

            if (majorantCandidate.Value > (numbers.Count / 2))
            {
                Console.WriteLine("Majorant is: {0}", majorantCandidate.Key);
            }
            else
            {
                Console.WriteLine("There is no Majorant!");
            }
        }

        private static KeyValuePair<int, int> FindMaxOccurElement(List<int> numbers)
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

            int maxValue = 0;
            int maxOccurNumber = 0;
            foreach (var item in numbersCounts)
            {
                if (item.Value > maxValue)
                {
                    maxValue = item.Value;
                    maxOccurNumber = item.Key;
                }
            }

            return new KeyValuePair<int,int>(maxOccurNumber, maxValue);
        }
    }
}
