using System;

class Sort3RealValues
{
    static void Main()
    {
        double firstNumber = 3.4d;
        double secondNumber = 5.5d;
        double thirdNumber = 4.7d;
        double maxNumber = firstNumber;

        if ((secondNumber > maxNumber) && (secondNumber > thirdNumber))
        {
            maxNumber = secondNumber;
            secondNumber = firstNumber;
            firstNumber = maxNumber;
        }
        else if (thirdNumber > maxNumber)
        {
            maxNumber = thirdNumber;
            thirdNumber = firstNumber;
            firstNumber = maxNumber;
        }

        if (secondNumber < thirdNumber)
        {
            maxNumber = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = maxNumber;
        }

        Console.WriteLine(firstNumber + "\n" + secondNumber + "\n" + thirdNumber);
    }
}