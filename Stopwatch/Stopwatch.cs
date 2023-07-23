using System;
using System.Timers;

namespace Utils.Stopwatch
{
    public class Stopwatch : IDisposable
    {
        private readonly Timer _timer;
        private readonly System.Diagnostics.Stopwatch _sw;
        private TimeSpan _lastElapsed;

        public Stopwatch(TimeSpan interval)
        {
            _timer = new Timer
            {
                Interval = interval.TotalMilliseconds
            };
            _timer.Elapsed += OnElapsed;
            _sw = new System.Diagnostics.Stopwatch();
        }

        public event EventHandler<StopwatchEventArgs> Elapsed;

        public void Start()
        {
            _timer.Start();
            _sw.Start();
        }

        public void Restart()
        {
            _timer.Start();
            _sw.Restart();
        }

        public void Stop()
        {
            _timer.Stop();
            _sw.Stop();
        }

        public void Reset()
        {
            _timer.Stop();
            _sw.Reset();
            SetLastElapsed(TimeSpan.Zero);
        }

        private void OnElapsed(object sender, object e)
        {
            if (!_sw.IsRunning)
                return;

            SetLastElapsed(TimeSpan.FromMilliseconds(_sw.Elapsed.TotalMilliseconds));
        }

        private void SetLastElapsed(TimeSpan value)
        {
            _lastElapsed = value;
            Elapsed?.Invoke(this, new StopwatchEventArgs(_lastElapsed));
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}