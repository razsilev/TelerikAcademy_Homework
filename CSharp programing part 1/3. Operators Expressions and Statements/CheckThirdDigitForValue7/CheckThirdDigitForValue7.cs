using System;

class CheckThirdDigitForValue7
{
    static void Main()
    {
        const int LOST_LAST_TWO_DIGIT_OF_NUMBER = 100;
        long number = 0;
        long digit = 0;
        bool isThirdDigit7 = false;

        Console.Write("Enter number: ");
        number = Convert.ToInt64(Console.ReadLine());

        number /= LOST_LAST_TWO_DIGIT_OF_NUMBER;
        digit = number % 10;
        
        isThirdDigit7 = ((digit == 7) || (digit == -7)) ? true : false;
        
        Console.WriteLine(isThirdDigit7);
    }
}