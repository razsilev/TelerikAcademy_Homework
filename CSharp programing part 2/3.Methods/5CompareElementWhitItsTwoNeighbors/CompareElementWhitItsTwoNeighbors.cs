using System;

namespace _5CompareElementWhitItsTwoNeighbors
{
    class CompareElementWhitItsTwoNeighbors
    {
        static void Main()
        {
            int[] array = { 3, 5, 6, 3, 7, 3, 4, 5, 3, 5 };

            int index = 0;

            bool isBigger = IsBigger(array, index);

            Console.WriteLine("Is element whit index {1} bigger than its two neighbors: {0}",
                                                    isBigger, index);
        }

        private static bool IsBigger(int[] array, int index)
        {
            bool isBigger = false;

            if ((index > 0) && (index < array.Length - 1))
            {
                int beforeElement = array[index - 1];
                int element = array[index];
                int nextElement = array[index + 1];

                if ((element > beforeElement) && (element > nextElement))
                {
                    isBigger = true;
                }
            }

            return isBigger;
        }
    }
}
