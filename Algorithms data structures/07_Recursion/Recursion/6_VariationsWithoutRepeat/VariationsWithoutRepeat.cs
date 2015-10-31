using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_VariationsWithoutRepeat
{
    class VariationsWithoutRepeat
    {
        private static string[] arr;
        private static string[] elementsArr;
        private static int k;
        private static int n;

        static void Main()
        {
            int numberOfTakedElements = 2;

            elementsArr = new string[] { "test", "rock", "fun" };
            int nuberOfElements = elementsArr.Length;

            k = numberOfTakedElements;
            n = nuberOfElements;
            arr = new string[numberOfTakedElements];

            Comb(0, 0);
        }

        static void Comb(int index, int start)
        {
            if (index >= k)
                Print();
            else
                for (int i = start; i < n; i++)
                {
                    arr[index] = elementsArr[i];
                    Comb(index + 1, i + 1);
                }
        }

        private static void Print()
        {
            string row = string.Join(" ", arr);

            Console.WriteLine("({0})", row);
        }
    }
}
