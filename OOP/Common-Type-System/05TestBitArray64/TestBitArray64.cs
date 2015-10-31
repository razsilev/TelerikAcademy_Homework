using System;

namespace _05TestBitArray64
{
    class TestBitArray64
    {
        static void Main()
        {
            BitArray64 arr = new BitArray64(5);
            BitArray64 arr1 = new BitArray64(5);

            arr1[0] = 6;
            arr[0] = 4;

            Console.WriteLine("Use foreach.");
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.Write("\narr Equals arr1: ");
            Console.WriteLine(arr.Equals(arr1));

            Console.WriteLine("\nThe arr HashCode is {0}", arr.GetHashCode());

            Console.WriteLine("\narr == arr1: {0}", arr == arr1);

            Console.WriteLine("\narr != arr1: {0}", arr != arr1);

            Console.WriteLine("\narr: {0}", arr);
            Console.WriteLine("arr1: {0}", arr1);
        }
    }
}
