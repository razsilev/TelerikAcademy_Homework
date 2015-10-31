using System;

namespace _13SolveSeveralTasks
{
    class SolveSeveralTasks
    {
        static void Main()
        {
            Menu();
        }

        private static void Menu()
        {
            PrintMenu();

            while (true)
            {
                Console.Write("\nEnter choice leter:> ");
                string inputChoice = Console.ReadLine();

                switch (inputChoice)
                {
                    case "r": ReversesDigit();
                        break;
                    case "c": CalculateEverage();
                        break;
                    case "s": SolveEquation();
                        break;
                    case "m": Menu(); 
                        return;
                    case "e": return;
                    default:
                        Console.WriteLine("Error! Invalid choice.");
                        Console.WriteLine("To see menu enter -> m");
                        break;
                }
            }
        }

        private static void SolveEquation()
        {
            Console.WriteLine("\na * x + b = 0");
            Console.Write("Enter a: ");
            string input = Console.ReadLine();
            decimal a = 0;

            bool isNumber = decimal.TryParse(input, out a);

            if (!isNumber || (a == 0))
            {
                Console.WriteLine("{0} <- Invalid value for a!", input);
                Console.WriteLine("Exit to menu.");
                return;
            }

            Console.Write("\nEnter b: ");
            input = Console.ReadLine();
            decimal b = 0;

            isNumber = decimal.TryParse(input, out b);

            if (!isNumber)
            {
                Console.WriteLine("{0} <- Invalid value for b!", input);
                Console.WriteLine("Exit to menu.");
                return;
            }

            Console.WriteLine("x = {0}\n", (-b / a));
        }

        private static void CalculateEverage()
        {
            Console.Write("\nEnter sequence length: ");
            string input = Console.ReadLine();
            int length = 0;

            bool isNumber = int.TryParse(input, out length);

            if (!isNumber || (length <= 0))
            {
                Console.WriteLine("Invalid sequence length!");
                Console.WriteLine("Exit to menu.");
                return;
            }

            decimal sum = 0m;
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0}:> ", i + 1);
                input = Console.ReadLine();
                decimal nextNumber = 0m;
                isNumber = decimal.TryParse(input, out nextNumber);

                if (!isNumber)
                {
                    Console.WriteLine("{0} <- Invalid number!", input);
                    Console.WriteLine("Exit to menu.");
                    return;
                }

                sum += nextNumber;
            }

            Console.WriteLine("Average is: {0}", (sum / length));
        }

        private static void ReversesDigit()
        {
            decimal number = GetNumber();

            if (number < 0)
            {
                Console.WriteLine("Exit to menu.");
                return;
            }

            if (number == 0)
            {
                Console.WriteLine("0 -> 0");
                return;
            }

            string strNumber = number.ToString();

            Console.Write("{0} -> ", number);
            for (int i = strNumber.Length - 1; i >= 0; i--)
            {
                Console.Write(strNumber[i]);
            }

            Console.WriteLine();
        }

        private static decimal GetNumber()
        {
            const int maxInput = 3;
            int count = 0;
            while (true)
            {
                Console.Write("\nEnter positive decimal number: ");

                string str = Console.ReadLine();
                decimal number = 0;
                bool isNumber = decimal.TryParse(str, out number);

                if (isNumber && (number >= 0))
                {
                    return number;
                }

                Console.WriteLine("\nError Invalid input!!!");

                count++;

                if (count >= maxInput)
                {
                    break;
                }
            }

            return -1m;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("[r] Reverses the digits of a number.");
            Console.WriteLine("[c] Calculates the average of a sequence of integers.");
            Console.WriteLine("[s] Solves a linear equation a * x + b = 0");
            Console.WriteLine("[m] Menu.");
            Console.WriteLine("[e] Exit");
        }
    }
}
