using System.Collections.Generic;

namespace Chronometer___Asynchronous_Processing.Contracts
{
    public interface IChronometer
    {
        public string GetTime { get; }

        public List<string> Laps { get; }

        public void Start ();

        public void Stop ();

        public string Lap ();

        public void Reset ();
    }
}
