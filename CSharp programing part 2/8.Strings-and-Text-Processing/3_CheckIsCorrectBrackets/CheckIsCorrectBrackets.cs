using System;

// 3.   Write a program to check if in a given expression the brackets are put correctly.
//      Example of correct expression: ((a+b)/5-d).
//      Example of incorrect expression: )(a+b)).

namespace _3_CheckIsCorrectBrackets
{
    class CheckIsCorrectBrackets
    {
        static void Main()
        {
            Console.Title = "Check brackeds in expression";

            Console.Write("Enter expression: ");
            string expression = Console.ReadLine();
            int leftBracets = 0;

            foreach (char sumbol in expression)
            {
                if (sumbol == '(')
                {
                    leftBracets++;
                }
                else if (sumbol == ')')
                {
                    leftBracets--;
                }
            }

            if (leftBracets == 0)
            {
                Console.WriteLine("Bracets are correct");
            }
            else
            {
                Console.WriteLine("Brackeds are incorrect!!!");
            }
        }
    }
}
