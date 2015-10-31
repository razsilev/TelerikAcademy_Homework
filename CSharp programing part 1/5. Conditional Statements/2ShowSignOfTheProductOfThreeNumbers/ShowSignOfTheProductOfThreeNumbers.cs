using System;

class ShowSignOfTheProductOfThreeNumbers
{
    static void Main()
    {
        double firstNumber = -3.6d;
        double secondNumber = -5.5d;
        double thirdNumber = -6.3d;

        if ((firstNumber == 0) || (secondNumber == 0) || (thirdNumber == 0))
        {
            Console.WriteLine("The product is 0 and there is no sign!");
        }
        else if ((firstNumber < 0) ^ (secondNumber < 0) ^ (thirdNumber < 0))
        {
            Console.WriteLine("-");
        }
        else
        {
            Console.WriteLine("+");
        }
    }
}