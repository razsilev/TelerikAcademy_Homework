namespace _2_ExtractOddNumbersCountStrings
{
    using System.Collections.Generic;

    public class ExtractOddNumbersCountStrings
    {
        public static void Main()
        {
            var strings = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            List<string> result = RemoveOddNumbersCountFrom(strings);

            System.Console.WriteLine("initial values: [{0}]", string.Join(", ", strings));
            System.Console.WriteLine("\nresult values: [{0}]", string.Join(", ", result));
        }

        private static List<string> RemoveOddNumbersCountFrom(List<string> strings)
        {
            Dictionary<string, int> numbersCounts = new Dictionary<string, int>();
            var stringsInResult = new HashSet<string>();

            for (int i = 0; i < strings.Count; i++)
            {
                if (numbersCounts.ContainsKey(strings[i]))
                {
                    numbersCounts[strings[i]]++;
                }
                else
                {
                    numbersCounts[strings[i]] = 1;
                }
            }

            var results = new List<string>();
            for (int i = 0; i < strings.Count; i++)
            {
                if ((numbersCounts[strings[i]] % 2) != 0 && !stringsInResult.Contains(strings[i]))
                {
                    results.Add(strings[i]);
                    stringsInResult.Add(strings[i]);
                }
            }

            return results;
        }
    }
}
