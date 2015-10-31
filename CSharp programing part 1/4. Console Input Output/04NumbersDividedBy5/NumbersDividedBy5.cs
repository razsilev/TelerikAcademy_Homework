using System;

class NumbersDividedBy5
{
    static void Main()
    {
        uint firstNumber = 0;
        uint secondNumber = 0;
        uint oldValue = 0;
        uint numbersDividedBy5 = 0;

        Console.Write("Enter first positive number: ");
        firstNumber = uint.Parse(Console.ReadLine());

        Console.Write("Enter second positive number: ");
        secondNumber = uint.Parse(Console.ReadLine());

        // if first integer is bigger than second, exchange them
        if (firstNumber > secondNumber)
        {
            oldValue = firstNumber;
            firstNumber = secondNumber;
            secondNumber = oldValue;
        }

        // check if first integer can be divided by 5 without remainder
        if ((firstNumber % 5) == 0)
        {
            numbersDividedBy5 = ((secondNumber - firstNumber) / 5) + 1;
        }
        else
        {
            uint firstDidivedNumber = ((firstNumber / 5) + 1) * 5;
            numbersDividedBy5 = ((secondNumber - firstDidivedNumber) / 5) + 1;
        } 

        Console.WriteLine("p({0},{1}) = {2}", firstNumber, secondNumber, numbersDividedBy5);
    }
}