using System;

namespace _4AppaersNumberInArray
{
    class AppaersNumberInArray
    {
        static void Main()
        {
            int[] array = { 3, 5, 6, 3, 7, 3, 4, 5, 3, 5 };

            int number = 3;

            int appears = AppearsNumber(array, number);

            Console.WriteLine("number {0}, have {1} appears.", number, appears);
        }

        private static int AppearsNumber(int[] array, int number)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
