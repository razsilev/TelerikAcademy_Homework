using System;

class IsPrimeNumberLessThen100
{
    static void Main()
    {
        const int MAX_NUMBER_FOR_CHECK = 100;
        bool isPrime = true;
        int number = 2;

        if (number <= MAX_NUMBER_FOR_CHECK)
        {
            for (int divider = 2; divider < number; divider++)
            {
                if ((number % divider) == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine("Is {0} prime? {1}", number, isPrime);
        }
        else
        {
            Console.WriteLine("Please enter number less then 100");
        }
    }
}