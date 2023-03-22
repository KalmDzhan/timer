using System;
using System.Threading;

namespace TimerApp
{
    public class Timer1
    {
        public int Minute { get; set; }
        public int Second { get; set; }

        public delegate void TimerTickEventHandler(object sender, TimerTickEventArgs e);
        public event TimerTickEventHandler TimerTick;

        public delegate void TimerCompletedEventHandler(object sender, EventArgs e);
        public event TimerCompletedEventHandler TimerCompleted;

        public Timer1(int minute, int second)
        {
            Minute = minute;
            Second = second;
        }

        public async void Run()
        {
            while (true)
            {
                if (Second != 0 || Minute != 0)
                {
                    TimerTick?.Invoke(this, new TimerTickEventArgs(Minute, Second));
                    Console.WriteLine("Минуты: " + Minute + " Секунды: " + Second);
                    Second--;
                    Thread.Sleep(1000);
                    Console.Clear();

                    if (Second < 0)
                    {
                        Second = 59;
                        Minute--;
                    }
                }
                else
                {
                    TimerCompleted?.Invoke(this, EventArgs.Empty);
                    Console.WriteLine("Время вышло");
                    break;
                }
            }
        }
    }

    public class TimerTickEventArgs : EventArgs
    {
        public int Minute { get; set; }
        public int Second { get; set; }

        public TimerTickEventArgs(int minute, int second)
        {
            Minute = minute;
            Second = second;
        }
    }
}