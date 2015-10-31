namespace _3_CombinationsWithOutDuplicates
{
    using System;

    public class CombinationsWithOutDuplicates
    {
        private static int[] arr;
        private static int k;
        private static int n;

        static void Main()
        {
            int numberOfTakedElements = 2;
            int nuberOfElements = 4;

            k = numberOfTakedElements;
            n = nuberOfElements;
            arr = new int[numberOfTakedElements];

            CombWithOutReps(0, 1);
        }

        private static void CombWithOutReps(int index, int start)
        {
            if (index >= k)
                Print();
            else
                for (int i = start; i <= n; i++)
                {
                    arr[index] = i;
                    CombWithOutReps(index + 1, i + 1);
                }
        }

        private static void Print()
        {
            string row = string.Join(" ", arr);

            Console.WriteLine(row);
        }
    }
}
