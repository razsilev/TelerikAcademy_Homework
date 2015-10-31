using System;

class Program
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        Console.WriteLine(" Enter:\n i -> for int\n d -> for double\n s -> for string");
        Console.Write("\n>");

        string enter = Console.ReadLine();
        char choise = enter[0];
        int intInput = 0;
        double doubleInput = 0;
        string stringInput;

        switch (choise)
        {
            case 'i':
                {
                    Console.Write("int variable: ");
                    intInput = Convert.ToInt32(Console.ReadLine());
                    intInput++;
                    Console.WriteLine("new value: {0}", intInput);
                    break;
                }
            case 'd':
                {
                    Console.Write("double variable: ");
                    doubleInput = Convert.ToDouble(Console.ReadLine());
                    doubleInput++;
                    Console.WriteLine("new value: {0}", doubleInput);
                    break;
                }
            case 's':
                {
                    Console.Write("string variable: ");
                    stringInput = Console.ReadLine() + "*";
                    Console.WriteLine("new value: {0}", stringInput);
                    break;
                }
            default:
                {
                    Console.WriteLine("Invalid choice!");
                    break;
                }
                    
        }
    }
}