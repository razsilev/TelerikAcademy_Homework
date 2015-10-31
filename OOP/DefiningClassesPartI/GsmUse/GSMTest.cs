using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GsmUse
{
    public class GSMTest
    {
        public void Test()
        {
            //Create an array of few instances of the GSM class.
            const int numberOfGSMs = 2;
            Gsm[] gsmArr = new Gsm[numberOfGSMs];

            gsmArr[0] = new Gsm("101", "Nokia", 4.30f, "Gencho",
                new Batterys("nokia", 540.5, 13.8, BatteryType.NiCd), new Displays(2.0f, 32000));

            gsmArr[1] = new Gsm("GalaxyS4", "Samsung", 254.30f,
                new Batterys("Sony", BatteryType.NiMH), new Displays(4.00f, 65000));

            // Display the information about the GSMs in the array.
            Console.WriteLine("Gsm Information:\n");

            for (int i = 0; i < gsmArr.Length; i++)
            {
                Console.WriteLine(gsmArr[i]);
                Console.WriteLine();
            }

            // Display the information about the static property IPhone4S.
            Console.WriteLine("\nIphone4s information:\n");
            Console.WriteLine(Gsm.Iphone4S);
        }

    }
}
