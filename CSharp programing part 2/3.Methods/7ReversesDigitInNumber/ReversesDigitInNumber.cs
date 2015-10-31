using System;
using System.Text;

namespace _7ReversesDigitInNumber
{
    class ReversesDigitInNumber
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            Console.Write("Enter number: ");
            decimal number = decimal.Parse(Console.ReadLine());

            decimal reversedNumber = ReversNumber(number);

            Console.WriteLine("{0} -> {1}", number, reversedNumber);
        }

        private static decimal ReversNumber(decimal number)
        {
            string strNumber = number.ToString();
            StringBuilder reversedString = new StringBuilder();
            int startIndex = 0;

            if (number < 0)
            {
                reversedString.Append(strNumber[0]);
                startIndex = 1;
            }

            for (int i = strNumber.Length - 1; i >= startIndex ; i--)
            {
                reversedString.Append(strNumber[i]);
            }

            return decimal.Parse(reversedString.ToString());
        }
    }
}
