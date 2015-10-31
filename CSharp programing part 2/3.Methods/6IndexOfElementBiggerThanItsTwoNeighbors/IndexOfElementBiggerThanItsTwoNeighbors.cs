using System;

namespace _6IndexOfElementBiggerThanItsTwoNeighbors
{
    class IndexOfElementBiggerThanItsTwoNeighbors
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 5, 6, 6, 7, 8, 8, 9, 13, 15 };

            int index = IndexOfElementBiggerThanHisNeighbors(array);

            Console.WriteLine("Index of element bigger than its neighbors is: {0}", index);
        }

        public static int IndexOfElementBiggerThanHisNeighbors(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                bool isBigger = IsBigger(array, i);

                if (isBigger)
                {
                    return i;
                }
            }

            return -1;
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
