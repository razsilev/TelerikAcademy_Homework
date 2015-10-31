using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3BiggestOfThreeIntegers
{
    class BiggestOfThreeIntegers
    {
        static void Main(string[] args)
        {
            double firstNumber = -3.6d;
            double secondNumber = -1.5d;
            double thirdNumber = -0.3d;
            double maxNumber = firstNumber;

            if (secondNumber > maxNumber)
            {
                maxNumber = secondNumber;
            }
            if (thirdNumber > maxNumber)
            {
                maxNumber = thirdNumber;
            }

            Console.WriteLine("Max number is: " + maxNumber);
        }
    }
}
