using System;

// 4.   Write a program that finds how many times a substring 
//      is contained in a given text (perform case insensitive search).
//		Example: The target substring is "in". The text is as follows:


namespace _4_RepeatedSubstringCount
{
    class RepeatedSubstringCount
    {
        static void Main()
        {
            Console.Title = "Repeated substring count";

            string str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

            string substring = "in";

            int count = CalculateCount(str, substring);

            Console.WriteLine("The result is: {0}", count);
        }

        private static int CalculateCount(string str, string substring)
        {
            int startIndex = 0;
            int count = -1;
            str = str.ToLower();
            substring = substring.ToLower();

            while (startIndex >= 0)
            {
                count++;

                if (startIndex != 0)
                {
                    startIndex += substring.Length;
                }

                startIndex = str.IndexOf(substring, startIndex);

            }

            return count;
        }
    }
}
