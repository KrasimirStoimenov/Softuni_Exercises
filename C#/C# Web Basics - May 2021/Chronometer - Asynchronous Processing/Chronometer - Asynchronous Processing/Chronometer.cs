using System.Collections.Generic;
using System.Diagnostics;
using Chronometer___Asynchronous_Processing.Contracts;

namespace Chronometer___Asynchronous_Processing
{
    public class Chronometer : IChronometer
    {
        private readonly Stopwatch sw;
        private readonly List<string> laps;
        public Chronometer()
        {
            this.sw = new Stopwatch();
            this.laps = new List<string>();
        }

        public string GetTime => $"{sw.Elapsed.Minutes:D2}:{sw.Elapsed.Seconds:D2}:{sw.Elapsed.Milliseconds:D4}";

        public List<string> Laps => this.laps;

        public string Lap()
        {
            this.laps.Add(this.GetTime);
            return this.GetTime;
        }

        public void Reset()
        {
            this.laps.Clear();
            this.sw.Reset();
        }

        public void Start()
        {
            this.sw.Start();
        }

        public void Stop()
        {
            this.sw.Stop();
        }
    }
}
