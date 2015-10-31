using System;

namespace _8Show16BitNumber
{
    class Show16BitNumber
    {
        static void Main()
        {
            Console.Write("Enter 16 bit number: ");
            short number = short.Parse(Console.ReadLine());
            string result = "";

            if (number < 0)
            {
                number *= -1;
                string str = Convert.ToString(number, 2).PadLeft(15, '0');
                result = String.Format("1{0}", str);
            }
            else
            {
                result = Convert.ToString(number, 2).PadLeft(16, '0');
            }
            

            Console.WriteLine("\nbinary value {0}\n", result);
        }
    }
}
