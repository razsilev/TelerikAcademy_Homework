using System;

// 7.   Using delegates write a class Timer that has can execute
//      certain method at each t seconds.

namespace _07UseTimer
{
    class UseTimer
    {
        static void Main()
        {
            int ticksCount = 15;
            int interval = 1000;

            MyTimer timer = new MyTimer(delegate(int ticksLeft) 
                                        {
                                            Console.SetCursorPosition(1, 3);
                                            Console.WriteLine("left: {0, 2} s.", ticksLeft); 
                                        },
                                        interval, ticksCount);

            Console.WriteLine("Start ticksCount: {0}  interval: {1} miliseconds", ticksCount, interval);

            timer.Run();

            Console.WriteLine("It worck. . . Timer work in ather thread.");
        }
    }
}
