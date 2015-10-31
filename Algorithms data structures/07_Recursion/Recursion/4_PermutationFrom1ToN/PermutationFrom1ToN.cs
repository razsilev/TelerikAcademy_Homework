namespace _4_PermutationFrom1ToN
{
    using System;
    public class PermutationFrom1ToN
    {
        private static int[] arr;

        static void Main()
        {
            int nuberOfElements = 3;

            arr = new int[nuberOfElements];

            // fill arr whit values from 1 to n
            for (int i = 0; i < nuberOfElements; i++)
            {
                arr[i] = i + 1;
            }

            // to work corectly numbers mas be sorted.
            Array.Sort(arr);
            PermuteRep(arr, 0, arr.Length);
        }

        private static void PermuteRep(int[] arr, int start, int n)
        {
            Print(arr);
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n);
                    }
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                    arr[i] = arr[i + 1];
                arr[n - 1] = firstElement;
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            int oldValue = first;
            first = second;
            second = oldValue;
        }


        private static void Print(int[] arr)
        {
            string row = string.Join(" ", arr);

            Console.WriteLine(row);
        }
    }
}
