namespace _4_HashTable
{
    using System;

    public class HashTableAndHashedSetSampleTests
    {
        public static void Main()
        {
            var hashTable = new HashTable<int, int>();

            hashTable.Add(3, 4);

            Console.WriteLine("value from hashTable");
            Console.WriteLine(hashTable[3]);

            // test hashedSet
            var hashedSet = new HashedSet<int>();

            hashedSet.Add(5);

            Console.WriteLine("value from hashedSet");
            Console.WriteLine(hashedSet.ToArray()[0]);
        }
    }
}
