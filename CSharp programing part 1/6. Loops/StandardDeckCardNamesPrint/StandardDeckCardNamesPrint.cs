using System;

class StandardDeckCardNamesPrint
{
    static void Main()
    {
        const int NumberOfCardSigns = 4;
        const int NumberOfCardValues = 13;

        for (int cardSigns = 1; cardSigns <= NumberOfCardSigns; cardSigns++)
        {
            for (int cardValues = 1; cardValues <= NumberOfCardValues; cardValues++)
            {
                Console.WriteLine("{0,-5} {1}", GetCardValue(cardValues),
                    GetCardSign(cardSigns));
            }

            Console.WriteLine();
        }
    }

    private static string GetCardSign(int cardSign)
    {
        switch (cardSign)
        {
            case 1: return "Spades";
            case 2: return "Diamonds";
            case 3: return "Hearts";
            case 4: return "Clubs";
            default:
                {
                    Console.WriteLine("Error invalid card!");
                    return "";
                }
        }

    }

    private static string GetCardValue(int cardValues)
    {
        switch (cardValues)
        {
            case 1: return "Two";
            case 2: return "Three";
            case 3: return "Four";
            case 4: return "Five";
            case 5: return "Six";
            case 6: return "Seven";
            case 7: return "Eight";
            case 8: return "Nine";
            case 9: return "Ten";
            case 10: return "Jack";
            case 11: return "Queen";
            case 12: return "King";
            case 13: return "Ace";
            default:
                {
                    Console.WriteLine("Error invalid card value!");
                    return "";
                }
        }
    }
}