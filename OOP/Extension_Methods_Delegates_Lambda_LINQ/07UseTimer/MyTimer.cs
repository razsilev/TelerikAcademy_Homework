using System;
using System.Threading;

namespace _07UseTimer
{
    public delegate void MyTimerDelegate(int ticks);

    public class MyTimer
    {
        private MyTimerDelegate method;
        public int Interval { get; private set; }
        public int TicksCount { get; private set; }

        public MyTimer(MyTimerDelegate method, int interval, int ticksCount)
        {
            this.method = method;
            this.Interval = interval;
            this.TicksCount = ticksCount;
        }

        public void Run()
        {
            Thread timerThread = new Thread(StartAction);
            
            timerThread.Start();
        }

        private void StartAction()
        {
            int ticks = this.TicksCount;

            while (ticks > 0)
            {
                Thread.Sleep(this.Interval);
                ticks--;
                this.method(ticks);
            }
        }
    }
}
