using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Chronometer___Asynchronous_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();


            string command;
            while ((command = Console.ReadLine().ToLower()) != "exit")
            {
                switch (command)
                {
                    case "start":
                        Task.Run(() =>
                        {
                            chronometer.Start();
                        });
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        var laps = chronometer.Laps;

                        if (laps.Count > 0)
                        {
                            for (int i = 0; i < laps.Count; i++)
                            {
                                Console.WriteLine($"{i}. {laps[i]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Laps: no laps");
                        }
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                }
            }
            Console.WriteLine(chronometer.GetTime);
            chronometer.Stop();
        }
    }
}
