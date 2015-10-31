using System;

class DividBy7And5
{
    static void Main()
    {
        int number = 105;
        bool dividBy7and5;

        dividBy7and5 = (number % 7 == 0) && (number % 5 == 0);

        Console.WriteLine(dividBy7and5);
    }
}