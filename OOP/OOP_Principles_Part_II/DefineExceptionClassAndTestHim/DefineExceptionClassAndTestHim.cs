using System;

namespace DefineExceptionClassAndTestHim
{
    class DefineExceptionClassAndTestHim
    {
        static void Main()
        {
            try
            {
                int min = 1;
                int max = 100;

                throw new InvalidRangeException<int>("InvalidRangeException test whit int.", min, max);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e);
            }

            try
            {
                DateTime start = new  DateTime(1980, 1, 1);
                DateTime end = new DateTime(2013, 12, 31);

                throw new InvalidRangeException<DateTime>("InvalidRangeException test whit DateTime.", start, end);
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
