using System.Collections.Generic;
using System.Diagnostics;
using Chronometer___Asynchronous_Processing.Contracts;

namespace Chronometer___Asynchronous_Processing
{
    public class Chronometer : IChronometer
    {
        private readonly Stopwatch sw;

        public Chronometer()
        {
            this.sw = new Stopwatch();
            this.Laps = new List<string>();
        }

        public string GetTime => this.sw.Elapsed.ToString();

        public List<string> Laps => string.Join(\n, Laps);

        public string Lap()
        {
            this.Laps.Add(this.GetTime);
            return this.GetTime;
        }

        public void Reset()
        {
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
