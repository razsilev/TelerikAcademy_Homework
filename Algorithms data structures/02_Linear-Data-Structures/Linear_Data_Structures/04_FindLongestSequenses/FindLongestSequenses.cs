namespace _04_FindLongestSequenses
{
    using System.Collections.Generic;

    public class FindLongestSequenses
    {
        public static void Main()
        {
            // longest in the end
            System.Console.WriteLine("longest in the end");
            List<int> numbers = new List<int>() { 1, 1, 5, 5, 5, 7, 7, 7, 7, 7 };
            List<int> longestSequence = FindLongestSubSequenses(numbers);
            PrintResults(numbers, longestSequence);

            // longest in the middle
            System.Console.WriteLine("\nlongest in the middle");
            numbers = new List<int>() { 1, 5, 5, 5, 7, 7 };
            longestSequence = FindLongestSubSequenses(numbers);
            PrintResults(numbers, longestSequence);


            // longest in the begining
            System.Console.WriteLine("\nlongest in the begining");
            numbers = new List<int>() { 1, 1, 1, 1, 1, 1, 5, 5, 5, 7, 7, 7 };
            longestSequence = FindLongestSubSequenses(numbers);
            PrintResults(numbers, longestSequence);

            // one element
            System.Console.WriteLine("\none element");
            numbers = new List<int>() { 1 };
            longestSequence = FindLongestSubSequenses(numbers);
            PrintResults(numbers, longestSequence);

            // equal elements only
            System.Console.WriteLine("\nequal elements only");
            numbers = new List<int>() { 5, 5, 5 };
            longestSequence = FindLongestSubSequenses(numbers);
            PrintResults(numbers, longestSequence);
        }

        private static void PrintResults(List<int> numbers, List<int> longestSequence)
        {
            System.Console.WriteLine("list content: {0}", string.Join(", ", numbers));

            string longestSequenceAsString = string.Empty;

            longestSequenceAsString = string.Join(", ", longestSequence);

            System.Console.WriteLine("longest sequence is: {0}", longestSequenceAsString);
            System.Console.WriteLine("Elements count: {0}", longestSequence.Count);
        }

        private static List<int> FindLongestSubSequenses(List<int> numbers)
        {
            int maxCount = 1;
            int currentCount = 1;
            int elementValue = numbers[0];
            int currentValue = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if (currentValue == numbers[i])
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        elementValue = numbers[i - 1];
                    }

                    currentValue = numbers[i];
                    currentCount = 1;
                }
            }

            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                elementValue = numbers[numbers.Count - 1];
            }

            var result = new List<int>();

            for (int i = 0; i < maxCount; i++)
            {
                result.Add(elementValue);
            }

            return result;
        }
    }
}
