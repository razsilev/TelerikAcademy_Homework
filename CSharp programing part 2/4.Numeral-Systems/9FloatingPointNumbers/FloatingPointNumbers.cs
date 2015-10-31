using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9FloatingPointNumbers
{
    class IEEE754Standart
    {
        static void Main()
        {
            float floatNumber = -27.25f;

            byte[] bitArray = BitConverter.GetBytes(floatNumber);
            int bits = BitConverter.ToInt32(bitArray, 0);
            
            string binValue = Convert.ToString(bits, 2);
            binValue = binValue.PadLeft(32, '0');

            Console.WriteLine("Binary representation: {0}", binValue);
            Console.WriteLine("Sign: {0}", binValue[0]);
            Console.WriteLine("Exponent: {0}", binValue.Substring(1, 8));
            Console.WriteLine("Mantissa: {0}", binValue.Substring(9));    
        }
    }
}
