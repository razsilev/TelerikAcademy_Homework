using System;

class ReadAgeAndPrintThemPlusTen
{
    static void Main()
    {
        int age = 0;
        string str = "";

        Console.Write("Enter your age: ");
        
        str = Console.ReadLine();
        age = Convert.ToInt32(str);

        Console.WriteLine("Your age after 10 years is: " + (age + 10));
    }
}