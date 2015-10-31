using System;

class PrintAllAsciiSumbols
{
    static void Main()
    {
        char sumbol;

        for (int i = 0; i < 128; i++)
        {
            sumbol = (char) i;

            Console.WriteLine(i + "  " + sumbol);
        }
    }
}