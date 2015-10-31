using System;

class ExaminesTwoIntegerVariables
{
    static void Main()
    {
        int firstNumber = 7;
        int secondNumber = 5;
        int oldValue = 0;

        // print result before compare
        Console.WriteLine("first: {0}, second: {1}", firstNumber, secondNumber);

        if (firstNumber > secondNumber)
        {
            oldValue = firstNumber;
            firstNumber = secondNumber;
            secondNumber = oldValue;
        }

        // print result after compare
        Console.WriteLine("first: {0}, second: {1}", firstNumber, secondNumber);
    }
}