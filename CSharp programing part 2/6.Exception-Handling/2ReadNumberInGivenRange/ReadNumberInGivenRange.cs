using System;

namespace _2ReadNumberInGivenRange
{
    class ReadNumberInGivenRange
    {
        static void Main()
        {
            Console.Title = "Read 10 numbers in given range.";

            Console.WriteLine("Enter range.");
            Console.Write("min value: ");
            int min = int.Parse(Console.ReadLine());
            
            Console.Write("max value: ");
            int max = int.Parse(Console.ReadLine());
            
            int numbers = 10;
            EnterNumbers(numbers, min, max);
        }

        private static void EnterNumbers(int numbers, int min, int max)
        {
            for (int number = 0; number < numbers; number++)
            {
                int currentNumber = 0;
                try
                {
                    Console.Write("{0}. ", number + 1);
                    currentNumber = ReadNumber(min, max);

                    Console.WriteLine("You enter: {0}", currentNumber);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The number is out of given range!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }

                Console.WriteLine();
            }
        }

        public static int ReadNumber(int min, int max)
        {
            Console.Write("Enter integer number in given range: ");

            string input = Console.ReadLine();
            int number = int.Parse(input);

            if (number < min || number > max)
            {
                throw new ArgumentOutOfRangeException("The number is out of range!");
            }

            return number;
        }
    }
}
