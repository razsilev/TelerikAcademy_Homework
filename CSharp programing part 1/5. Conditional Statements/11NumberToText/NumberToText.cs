using System;
using System.Text;

class NumberToText
{
    static void Main()
    {
        int number = ReadNumber();
        int units = number % 10;
        int tens = (number % 100) / 10;
        int hundreds = (number % 1000) / 100;

        StringBuilder text = new StringBuilder();

        if (hundreds > 0)
        {
            text.Append(HundredsToText(hundreds));

            // check if number range is [1...19]
            if ((number % 100 < 20) && (number % 100 != 0))
            {
                text.Append("and ");
            }
            else if ((tens > 0) && (units == 0)) // check if number range is [10, 20, 30, ..., 90]
            {
                text.Append("and ");
            }
        }

        if (tens > 1)
        {
            text.Append(TensToText(tens));
        }

        if (tens == 1)
        {
             text.Append(NumberFrom10To19ToText(units));
        }
        else
        {
            text.Append(UnitsToText(units));
        }

        if (number == 0)
        {
            Console.WriteLine("Zero");
        }
        else
        {
            char UpperLetter = (char)(text[0] + ('A' - 'a'));
            text.Replace(text[0], UpperLetter, 0, 1);

            Console.WriteLine("{0} -> \"{1}\"", number, text);
        }
    }

    private static int ReadNumber()
    {
        int number = 0;
        string inputstring = "";
        bool validNumber = false;

        while (validNumber == false)
        {
            Console.Write("Enter number in the range [0..999]: ");
            inputstring = Console.ReadLine();
            validNumber = int.TryParse(inputstring, out number);

            if (!validNumber)
            {
                Console.WriteLine("! Error <{0}> is NOT a number !", inputstring);
            }

            if ((number < 0) || (number > 999))
            {
                validNumber = false;
                Console.WriteLine("! Error <{0}> is NOT in range [0..999] !", inputstring);
            }
        }

        return number;
    }

    private static string UnitsToText(int units)
    {
        string text = "";

        switch (units)
        {
            case 1:
                text = "one";
                break;
            case 2:
                text = "two";
                break;
            case 3:
                text = "three";
                break;
            case 4:
                text = "four";
                break;
            case 5:
                text = "five";
                break;
            case 6:
                text = "six";
                break;
            case 7:
                text = "seven";
                break;
            case 8:
                text = "eight";
                break;
            case 9:
                text = "nine";
                break;
        }

        return text;
    }

    private static string NumberFrom10To19ToText(int units)
    {
        string text = "";

        switch (units)
        {
            case 0:
                text = "ten ";
                break;
            case 1:
                text = "eleven ";
                break;
            case 2:
                text = "twelve ";
                break;
            case 3:
                text = "thirteen ";
                break;
            case 4:
                text = "fourteen ";
                break;
            case 5:
                text = "fifteen ";
                break;
            case 6:
                text = "sixteen ";
                break;
            case 7:
                text = "seventeen ";
                break;
            case 8:
                text = "eighteen ";
                break;
            case 9:
                text = "nineteen ";
                break;
        }

        return text;
    }

    private static string TensToText(int tens)
    {
        string text = "";

        switch (tens)
        {
            case 2:
                text = "twenty ";
                break;
            case 3:
                text = "thirty ";
                break;
            case 4:
                text = "forty ";
                break;
            case 5:
                text = "fifty ";
                break;
            case 6:
                text = "sixty ";
                break;
            case 7:
                text = "seventy ";
                break;
            case 8:
                text = "eighty ";
                break;
            case 9:
                text = "ninety ";
                break;
        }

        return text;
    }

    private static string HundredsToText(int hundreds)
    {
        string text = "";

        switch (hundreds)
        {
            case 1:
                text = "one hundred ";
                break;
            case 2:
                text = "two hundred ";
                break;
            case 3:
                text = "three hundred ";
                break;
            case 4:
                text = "four hundred ";
                break;
            case 5:
                text = "five hundred ";
                break;
            case 6:
                text = "six hundred ";
                break;
            case 7:
                text = "seven hundred ";
                break;
            case 8:
                text = "eight hundred ";
                break;
            case 9:
                text = "nine hundred ";
                break;
        }

        return text;
    }
}