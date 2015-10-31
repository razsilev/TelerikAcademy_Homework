using System;

namespace _2TenRandomValuesInRange
{
    class TenRandomValuesInRange
    {
        static void Main()
        {
            Random rand = new Random();
            int numberOfValues = 10;
            int minValue = 100;
            int maxValue = 201;

            Console.WriteLine("10 random values in the range [100, 200]\n");
            for (int i = 0; i < numberOfValues; i++)
            {
                Console.WriteLine("{0,-2} -> {1}", 
                    (i + 1), rand.Next(minValue, maxValue));
            }

            Console.WriteLine();
        }
    }
}
