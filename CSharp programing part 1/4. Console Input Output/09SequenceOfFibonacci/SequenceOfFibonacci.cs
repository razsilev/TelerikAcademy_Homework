using System;

class SequenceOfFibonacci
{
    static void Main()
    {
        int NUMBER_OF_MEMBER_OF_SEQUENCE = 100;
        decimal befor = 0M;
        decimal last = 1M;

        // print first two members
        Console.Write("0, 1");

        // print ather start from third
        for (int i = 3; i <= NUMBER_OF_MEMBER_OF_SEQUENCE; i++)
        {
            Console.Write(" ," + (befor + last));
            
            last += befor;
            befor = last - befor;
        }
    }
}