using System;

namespace _1UseTryCatchFinnally
{
    class UseTryCatchFinnally
    {
        static void Main()
        {
            Console.WriteLine("Calculate square root.\n");
            Console.Write("Enter integer number: ");

            string inputString = Console.ReadLine();

            try
            {
                uint number = uint.Parse(inputString);

                double result = Math.Sqrt(number);

                Console.WriteLine("\nsquare root: {0} is: {1}", inputString, result);
            }
            catch (Exception)
            {
                Console.WriteLine("\nInvalid number");
            }
            finally
            {
                Console.WriteLine("\nGood bye.\n");
            }

        }
    }
}
