namespace _3_WordCounter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class WordCounter
    {
        public static void Main()
        {
            string sourceFilePath = "../../Resources/source.txt";
            string resultFilePath = "../../Resources/result.txt";

            Console.WriteLine("Enter file path or empty string to use default fail");
            Console.Write("Path: ");

            string userPath = Console.ReadLine();

            if (userPath != string.Empty)
            {
                sourceFilePath = userPath;
            }

            Console.WriteLine("\n The results is in the ../../Resources/result.txt  against program exe file!");

            var occurrences = GetWordOccurrences(sourceFilePath);

            WriteToFile(resultFilePath, occurrences);
        }

        private static IOrderedEnumerable<KeyValuePair<string, int>> GetWordOccurrences(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path cannot be null or empty.", "path");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Could not find the file specified.", path);
            }

            Dictionary<string, int> occurrences = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(
                        new char[] { ' ', ',', ';', '.', '?', '!', '"', '\'', ':' },
                        StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        string wordNoCaps = word.ToLower();
                        if (occurrences.ContainsKey(wordNoCaps))
                        {
                            occurrences[wordNoCaps]++;
                        }
                        else
                        {
                            occurrences.Add(wordNoCaps, 1);
                        }
                    }
                }
            }

            var sortedOccurrences = occurrences.OrderBy(entry => entry.Value);
                //from entry in occurrences
                //orderby entry.Value ascending
                //select entry;

            return sortedOccurrences;
        }

        private static void WriteToFile(string resultFilePath, IOrderedEnumerable<KeyValuePair<string, int>> occurrences)
        {
            StringBuilder result = new StringBuilder();
            int index = 0;

            foreach (var occurrence in occurrences)
            {
                index++;
                result.AppendFormat(
                    "{0, 5}. {1} -> {2}{3}",
                    index,
                    occurrence.Key,
                    occurrence.Value,
                    Environment.NewLine);
            }

            File.WriteAllText(resultFilePath, result.ToString());
        }
    }
}