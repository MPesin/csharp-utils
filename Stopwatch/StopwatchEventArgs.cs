using System;

namespace Utils.Stopwatch
{
    public class StopwatchEventArgs : EventArgs
    {
        public StopwatchEventArgs(TimeSpan elapsed)
        {
            Elapsed = elapsed;
        }

        public TimeSpan Elapsed { get; }
    }
}