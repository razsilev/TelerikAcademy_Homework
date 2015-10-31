using System;
using System.Text;
using System.Collections.Generic;

namespace _8AddTwoPositiveIntegerNumbers
{
    class AddTwoPositiveIntegerNumbers
    {
        static void Main()
        {
            byte[] firstNumber = { 0, 2, 5 };
            byte[] secondNumber = { 0, 9, 9, 1 };

            byte[] result = AddNumbers(firstNumber, secondNumber);

            Console.Write("Sum is: ");
            for (int i = result.Length - 1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }

            Console.WriteLine("\n");
        }

        private static byte[] AddNumbers(byte[] firstNumber, byte[] secondNumber)
        {
            List<byte> sum = new List<byte>();

            int add = 0; // take value 0 or 1 
            int count = 0;
            bool end = false;
            
            while(!end)
            {
                byte digitSum = 0;

                if ((count < firstNumber.Length) && (count < secondNumber.Length))
                {
                    digitSum = (byte)(firstNumber[count] + secondNumber[count] + add);
                }
                else if (count < firstNumber.Length)
                {
                    digitSum += (byte)(add + firstNumber[count]);
                }
                else if (count < secondNumber.Length)
                {
                    digitSum += (byte)(add + secondNumber[count]);
                }
                else
                {
                    end = true;
                    digitSum = (byte)add;
                }

                count++;
                add = 0;

                if (digitSum > 9)
                {
                    int digit = digitSum % 10;
                    sum.Add((byte)digit);
                    add = 1;
                }
                else
                {
                    if (end && digitSum == 0)
                    {

                    }
                    else
                    {
                        sum.Add(digitSum);
                    }
                    
                }
            }

            return sum.ToArray();
        }
    }
}
