namespace _5_VariationsOfKElementsWithRepeat
{
    using System;

    class VariationsOfKElementsWithRepeat
    {
        private static string[] arr;
        private static string[] elementsArr;
        private static int k;
        private static int n;

        static void Main()
        {
            int numberOfTakedElements = 2;
            int nuberOfElements = 3;

            k = numberOfTakedElements;
            n = nuberOfElements;
            arr = new string[numberOfTakedElements];
            elementsArr = new string[] { "hi", "a", "b" };

            CombReps(0);
        }

        static void CombReps(int index)
        {
            if (index >= k)
                Print();
            else
                for (int i = 0; i < n; i++)
                {
                    arr[index] = elementsArr[i];
                    CombReps(index + 1);
                }
        }

        private static void Print()
        {
            string row = string.Join(" ", arr);

            Console.WriteLine("({0})", row);
        }
    }
}
