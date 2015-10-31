using System;
using System.IO;

namespace _5_FindAreaWhitMaximalSum
{
    class FindAreaWhitMaximalSum
    {
        static void Main()
        {
            Console.Title = "Find area whit maximal sum";

            Console.Write("Enter full file path whit full file name: ");
            string fullFilePath = Console.ReadLine();
            string ResultFileName = "Max_area_sum.txt";
            string path = GetFilePath(fullFilePath);
            path += ResultFileName;

            double maxSum = 0;

            try
            {
                maxSum = FindMaxAreaSum(fullFilePath);
                WriteResult(maxSum, path);
                Console.WriteLine("max sum is successfully write and it is: {0}", maxSum);
            }
            catch (IOException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }

        private static string GetFilePath(string fullFilePath)
        {
            int endIndex = fullFilePath.LastIndexOf('\\');

            string path = fullFilePath.Substring(0, endIndex + 1);

            return path;
        }

        private static void WriteResult(double maxSum, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(maxSum);
            }
        }

        private static double FindMaxAreaSum(string path)
        {
            double maxSum = 0;

            using (StreamReader reader = new StreamReader(path))
            {
                int matrixSize = int.Parse(reader.ReadLine());

                string oldRowStr = reader.ReadLine();

                for (int i = 1; i < matrixSize; i++)
                {
                    string currentRowStr = reader.ReadLine();

                    double currentSum = GetMaxRowsAreaSum(oldRowStr, currentRowStr);

                    oldRowStr = currentRowStr;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            return maxSum;
        }

        private static double GetMaxRowsAreaSum(string oldRowStr, string currentRowStr)
        {
            string[] firstElements = oldRowStr.Split();
            string[] secondElements = currentRowStr.Split();
            double maxSum = double.MinValue;

            for (int col = 0; col < firstElements.Length - 1; col++)
            {
                double a = double.Parse(firstElements[col]);
                double b = double.Parse(firstElements[col + 1]);
                double c = double.Parse(secondElements[col]);
                double d = double.Parse(secondElements[col + 1]);

                double currentSum = a + b + c + d;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

            return maxSum;
        }
    }
}
