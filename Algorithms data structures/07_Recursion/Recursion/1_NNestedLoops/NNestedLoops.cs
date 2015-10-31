namespace _1_NNestedLoops
{
    using System;

    public class NNestedLoops
    {
        private static int[] arr;
        private static int n;

        static void Main()
        {
            int numberOfNestedLoops = 3;
            n = numberOfNestedLoops;
            arr = new int[numberOfNestedLoops];

            GenerateVariations(0);
        }

        static void GenerateVariations(int index)
        {
            if (index >= n)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    arr[index] = i;
                    GenerateVariations(index + 1);
                }
            }
        }

        private static void Print(int[] arr)
        {
            string row = string.Join(" ", arr);

            Console.WriteLine(row);
        }

    }
}
