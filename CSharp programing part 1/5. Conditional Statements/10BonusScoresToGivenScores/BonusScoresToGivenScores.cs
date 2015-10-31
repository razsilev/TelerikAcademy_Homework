using System;

class BonusScoresToGivenScores
{
    static void Main()
    {
        int givenScores = ReadScores();

        switch (givenScores)
        {
            case 1:
            case 2:
            case 3:
                givenScores *= 10;
                break;
            case 4:
            case 5:
            case 6:
                givenScores *= 100;
                break;
            case 7:
            case 8:
            case 9:
                givenScores *= 1000;
                break;
            default:
                {
                    Console.WriteLine("!!! Error given scores are NOT in the range [1..9] !!!");
                    break;
                }
        }

        Console.WriteLine("scores whit bonus are: {0}", givenScores);
        
    }

    private static int ReadScores()
    {
        int scores = 0;
        string inputstring = "";
        bool validNumber = false;

        while (validNumber == false)
        {
            Console.Write("Enter given scores in the range [1..9]: ");
            inputstring = Console.ReadLine();
            validNumber = int.TryParse(inputstring, out scores);

            if (!validNumber)
            {
                Console.WriteLine("! Error <{0}> is NOT a number !", inputstring);
                scores = 1;
            }
            
            if ((scores < 1) || (scores > 9))
            {
                validNumber = false;
                Console.WriteLine("! Error <{0}> is NOT in range [1..9] !", inputstring);
            }
        }

        return scores;
    }
}