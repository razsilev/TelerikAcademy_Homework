using System;

class AZ_Array
{
    static void Main()
    {
        Console.Write("Enter word: ");
        string word = Console.ReadLine();

        word = word.ToUpper();

        Console.WriteLine("\nIndex of leters are:");
        PrintLeterIndexInWord(word);
    }

    private static void PrintLeterIndexInWord(string word)
    {
        char[] alphabetArray = FillAlphabetArray();

        for (int i = 0; i < word.Length; i++)
        {
            for (int leterIndex = 0; leterIndex < alphabetArray.Length; leterIndex++)
            {
                if (word[i] == alphabetArray[leterIndex])
                {
                    Console.Write(" {0}", leterIndex);
                }
            }
        }

        Console.WriteLine();
    }

    private static char[] FillAlphabetArray()
    {
        char leter = 'A';
        char[] alphabet = new char[26];
        int count = 0;

        while (leter <= 'Z')
        {
            alphabet[count] = leter;
            count++;
            leter = (char)(leter + 1);
        }

        return alphabet;
    }



}