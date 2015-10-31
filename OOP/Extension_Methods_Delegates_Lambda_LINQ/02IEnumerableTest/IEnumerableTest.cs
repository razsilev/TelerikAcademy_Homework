using System;
using System.Collections.Generic;

namespace _02IEnumerableTest
{
    public class IEnumerableTest
    {
        static void Main()
        {
            int[] intArray = { 3, 5, 8, 12, 17, 6, 4, 7};
            List<double> doubleList = new List<double>(new double[] { 2.5, 3.44, 88.0, 33,3 });
            string[] stringArray = { "AA", "BB", "Cd" };

            Console.WriteLine("Test on int array:");
            PrintTestResults(intArray);

            Console.WriteLine("\nTest on string array:");
            PrintTestResults(stringArray);
            
            Console.WriteLine("\nTest on double list:");
            PrintTestResults(doubleList);
        }

        private static void PrintTestResults<T>(IEnumerable<T> array)
            where T : IComparable
        {
            try
            {
                Console.WriteLine("sum: {0}", array.Sum());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("product: {0}", array.Product());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("min: {0}", array.Min());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("max: {0}", array.Max());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("average: {0}", array.Average());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
