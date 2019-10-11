using System;
using System.IO;
using System.Timers;
using System.ServiceProcess;

namespace NetCoreTestService
{
    public class HeartbeatTwo : ServiceBase
    {
        private readonly Timer _timer;

        public HeartbeatTwo()
        {
            ServiceName = "HeartBeatTwo";

            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\_test\HeartBeat.txt", lines); //todo: put this into config file
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            Stop();
        }

        protected override void OnPause()
        {
            Pause();
        }

        public void Start(string[] args)
        {
            _timer.Start();
        }

        public new void Stop()
        {
            _timer.Stop();
        }
    }
}
