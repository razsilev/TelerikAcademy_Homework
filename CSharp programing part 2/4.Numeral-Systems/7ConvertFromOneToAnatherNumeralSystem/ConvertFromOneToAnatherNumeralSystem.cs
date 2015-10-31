using System;
using System.Text;

namespace _7ConvertFromOneToAnatherNumeralSystem
{
    class ConvertFromOneToAnatherNumeralSystem
    {
        static void Main()
        {
            // read data
            Console.Write("Enter numeral system from 2 to 16 : ");
            int inputNumberNumlSystem = int.Parse(Console.ReadLine());

            Console.Write("Enter number: ");
            string inputNumber = Console.ReadLine();

            Console.Write("\nEnter result numeral system: ");
            int resultNumeralSystem = int.Parse(Console.ReadLine());
            
            // read input end

            if (resultNumeralSystem == inputNumberNumlSystem)
            {
                Console.WriteLine("Result number: {0}", inputNumber);
            }
            else
            {
                long number = ConvertToDecimal(inputNumber, inputNumberNumlSystem);
                string result = ConvertFromDecimal(number, resultNumeralSystem);

                Console.WriteLine("Result number: {0}", result);
            }
        }

        private static string ConvertFromDecimal(long number, int resultNumeralSystem)
        {
            StringBuilder result = new StringBuilder();

            while (true)
            {
                int lastDigit = (int)(number % resultNumeralSystem);
                number /= resultNumeralSystem;

                if (lastDigit > 9)
                {
                    string digit = Convert.ToString(lastDigit, 16);
                    result.Append(digit.ToUpper());
                }
                else
                {
                    result.Append(lastDigit);
                }

                if (number < 1)
                {
                    break;
                }
            }

            string str = result.ToString();
            char[] revers = str.ToCharArray();
            Array.Reverse(revers);

            return new string(revers);
        }

        private static long ConvertToDecimal(string inputNumber, int inputNumberNumlSystem)
        {
            long result = 0;

            for (int i = 0; i < inputNumber.Length; i++)
            {
                int lastElement = inputNumber.Length - 1 - i;

                int digit = Convert.ToInt32(inputNumber[lastElement].ToString(), 16);

                result += digit * (long)Math.Pow(inputNumberNumlSystem, i);
            }

            return result;
        }
    }
}
