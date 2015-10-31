using System;

class ShowsTheNameOfInputedDigit
{
    static void Main()
    {
        Console.Write("Enter digit (0-9): ");
        string enteredDigit = Console.ReadLine();
        int digit = 0;

        if (int.TryParse(enteredDigit, out digit))
        {
            switch (digit)
            {
                case 0:
                    Console.WriteLine("zero");
                    break;
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                case 4:
                    Console.WriteLine("four");
                    break;
                case 5:
                    Console.WriteLine("five");
                    break;
                case 6:
                    Console.WriteLine("six");
                    break;
                case 7:
                    Console.WriteLine("seven");
                    break;
                case 8:
                    Console.WriteLine("eight");
                    break;
                case 9:
                    Console.WriteLine("nine");
                    break;
                default:
                    Console.WriteLine("The input \"{0}\" is not a digit!", enteredDigit);
                    break;
            }
        }
        else
        {
            Console.WriteLine("The input \"{0}\" is not a digit!", enteredDigit);
        }
    }
}