using System;

class CalculatesTheGreatestCommonDivisor
{
    static void Main()
    {
        long greatestCommonDivisor = 1;
        long divider = 0;

        Console.WriteLine("     Calculates the Greatest Common Divisor (GCD)\n");
        Console.WriteLine("Enter two numbers to see there GCD.\n");
        
        Console.Write("N1: ");
        long firstNumber = long.Parse(Console.ReadLine());
        Console.Write("N2: ");
        long secondNumber = long.Parse(Console.ReadLine());

        firstNumber = Math.Abs(firstNumber);
        secondNumber = Math.Abs(secondNumber);

        // exchange numbers
        if (firstNumber > secondNumber)
        {
            firstNumber = secondNumber + firstNumber;
            secondNumber = firstNumber - secondNumber;
            firstNumber = firstNumber - secondNumber;
        }

        if (firstNumber == secondNumber)
        {
            greatestCommonDivisor = firstNumber;
        }
        else
        {
            while (true)
            {
                divider = firstNumber / secondNumber;

                if (divider * secondNumber == firstNumber)
                {
                    break;
                }

                greatestCommonDivisor = firstNumber - (divider * secondNumber);

                firstNumber = secondNumber;
                secondNumber = greatestCommonDivisor;
            }
        }

        Console.WriteLine("\nGCD is: {0}\n", greatestCommonDivisor);
    }

    //static void Main()
    //{
    //    Console.WriteLine("Enter first number : ");
    //    int firstNum = int.Parse(Console.ReadLine());

    //    Console.WriteLine("Enter first number : ");
    //    int secondNum = int.Parse(Console.ReadLine());

    //    while (firstNum != secondNum)//do the loop untill firstNum == secondNum
    //    {
    //        if (firstNum < secondNum)
    //        {
    //            secondNum = secondNum - firstNum;//the larger number gets the value of (larger number - smaller number)
    //        }
    //        else
    //        {
    //            firstNum = firstNum - secondNum;
    //        }
    //    }
    //    Console.WriteLine(firstNum);
    //}
}