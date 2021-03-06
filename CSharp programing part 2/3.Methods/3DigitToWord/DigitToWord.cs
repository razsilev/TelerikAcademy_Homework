﻿using System;

class DigitToWord
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        string word = LastDigitAsWord(number);

        Console.WriteLine("\nLast digit is -> {0}\n", word);
    }

    private static string LastDigitAsWord(int number)
    {
        int digit = number % 10;
        
        switch (digit)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default: throw new ArgumentException("Invalide value");
        }
    }
}
