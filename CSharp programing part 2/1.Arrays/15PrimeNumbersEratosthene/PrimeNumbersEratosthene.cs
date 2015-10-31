using System;

class PrimeNumbersEratosthene
{
    static void Main()
    {
        int[] array = new int[200];

        // fill array
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 2;
        }
        
        SieveOfEratosthenes(array);
        PrintArray(array);
    }

    private static void SieveOfEratosthenes(int[] array)
    {
        // algoritm marks not prime numbers whit negative value
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                continue;
            }

            for (int j = i; j < array.Length; j++)
            {
                long removeNumber = (long)array[i] * (long)array[j];
                int lastElementValue = Math.Abs(array[array.Length - 1]);

                if (removeNumber < 0)
                {
                    removeNumber = removeNumber * (-1);
                }

                if (removeNumber > lastElementValue)
                {
                    break;
                }

                // marks not prime numbers like negative
                if (array[removeNumber - 2] > 0)
                {
                    array[removeNumber - 2] = - array[removeNumber - 2];
                }

            }
            
        }
    }

    public static void PrintArray(int[] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > 0)
            {
                Console.Write(" {0}", array[i]);
                count++;
            }
        }
        Console.WriteLine();
        Console.WriteLine("prime count: {0:###,###}", count);
    }
}