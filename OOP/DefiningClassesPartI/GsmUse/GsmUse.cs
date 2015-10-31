using System;

namespace GsmUse
{
    class GsmUse
    {
        static void Main()
        {
            GSMTest gsmTest = new GSMTest();
            GSMCallHistoryTest callHistoryTest = new GSMCallHistoryTest();

            gsmTest.Test();
            callHistoryTest.Test();
        }
    }
}
