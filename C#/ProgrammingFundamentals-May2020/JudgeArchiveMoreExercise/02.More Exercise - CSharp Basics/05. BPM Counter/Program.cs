using System;

namespace _05._BPM_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int BPM = int.Parse(Console.ReadLine());
            int beats = int.Parse(Console.ReadLine());
            double bar = (double)beats / 4;
            double seconds = beats * 60.0 / BPM;
            int minutes = (int)seconds / 60;
            seconds -= minutes * 60;
            Console.WriteLine($"{Math.Round(bar,1) } bars - {minutes}m {Math.Floor(seconds)}s");
        }
    }
}
