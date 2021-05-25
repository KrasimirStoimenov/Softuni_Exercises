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
        }

        public string GetTime => this.sw.Elapsed.ToString();

        public List<string> Laps => throw new System.NotImplementedException();

        public string Lap()
        {
            return "some lap";
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
