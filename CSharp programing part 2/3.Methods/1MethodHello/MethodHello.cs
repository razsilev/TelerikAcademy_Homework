using System;

class MethodHello
{
    static void Main()
    {
        Hello();
    }

    static void Hello()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.WriteLine("\nHello, {0}.\n", name);
    }
}
