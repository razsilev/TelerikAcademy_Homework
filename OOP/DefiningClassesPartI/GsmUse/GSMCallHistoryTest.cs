using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GsmUse
{
    public class GSMCallHistoryTest
    {
        public void Test()
        {
            // Create an instance of the GSM class.
            Gsm gsm = Gsm.Iphone4S;

            // Add few calls.
            gsm.AddCall(new Call(DateTime.Now, "0888 333 555", 343u));

            gsm.AddCall(new Call(DateTime.Now.AddMinutes(13.12d), "0888 333 888", 5436u));

            gsm.AddCall(new Call(DateTime.Now.AddHours(3.5d), "0898 454 888", 4893u));

            // Display the information about the calls.
            Console.WriteLine("\nCalls information:");

            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                Console.WriteLine(gsm.CallHistory[i]);
            }

            // print the total price of the calls in the history.
            Console.WriteLine("\nTotal call price in the history: {0:C}.", 
                        gsm.CalculateCallsPrice(0.37m));

            // Remove the longest call from the history and calculate the total price again.
            Call longestCall = GetLongestCall(gsm.CallHistory);
              
            gsm.RemoveCall(longestCall);

            Console.WriteLine("\nTotal call price in the history whitout longest call: {0:C}.",
                        gsm.CalculateCallsPrice(0.37m));

            // Finally clear the call history and print it.
            gsm.ClearCallsHistory();

            Console.WriteLine("\nNumber of calls in call history: {0}\n", gsm.CallHistory.Count);
        }

        private Call GetLongestCall(List<Call> calls)
        {
            Call longestCall = calls[0];

            for (int i = 1; i < calls.Count; i++)
            {
                if (calls[i].Duration > longestCall.Duration)
                {
                    longestCall = calls[i];
                }
            }

            return longestCall;
        }

    }
}
