using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CombinationsWithDuplicates
{
    class CombinationsWithDuplicates
    {
        private static int[] arr;
        private static int k;
        private static int n;

        static void Main()
        {
            int numberOfTakedElements = 2;
            int nuberOfElements = 3;

            k = numberOfTakedElements; 
            n = nuberOfElements;
            arr = new int[numberOfTakedElements];

            CombReps(0, 1);
        }

        static void CombReps(int index, int start)
        {
            if (index >= k)
                Print();
            else
                for (int i = start; i <= n; i++)
                {
                    arr[index] = i;
                    CombReps(index + 1, i);
                }
        }

        private static void Print()
        {
            string row = string.Join(" ", arr);

            Console.WriteLine(row);
        }
    }
}
