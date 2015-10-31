namespace TaskTwoStatistics
{
    using System;

    public class TaskTwoStatistics
    {
        public static void Main()
        {
            double[] numbers = {4, 3, 8, 5, 3};
            int elementsCount = 4;

            PrintStatistics(numbers, elementsCount);
        }

        /// <summary>
        /// Print on Console max, average and min value from
        /// given array in given number of elements.
        /// </summary>
        /// <param name="numbers">array of numbers</param>
        /// <param name="elementsCount">number of elements</param>
        public static void PrintStatistics(double[] numbers, int elementsCount)
        {
            if (elementsCount > numbers.Length)
            {
                elementsCount = numbers.Length;
            }

            double max = FindMax(numbers, elementsCount);
            double average = FindAverage(numbers, elementsCount);
            double min = FindMin(numbers, elementsCount);

            Print("max value = " + max);
            Print("average value = " + average);
            Print("min value = " + min);
        }

        private static double FindMax(double[] numbers, int elementsCount)
        {
            double max = numbers[0];
            for (int i = 1; i < elementsCount; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        private static double FindAverage(double[] numbers, int elementsCount)
        {
            double sum = 0;
            for (int i = 0; i < elementsCount; i++)
            {
                sum += numbers[i];
            }
            
            double avarage = sum / elementsCount;

            return avarage;
        }

        private static double FindMin(double[] numbers, int elementsCount)
        {
            double min = numbers[0];
            for (int i = 1; i < elementsCount; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        private static void Print(Object str)
        {
            Console.WriteLine(str);
        }
    }
}
