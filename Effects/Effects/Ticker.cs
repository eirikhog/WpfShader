using System;
using System.ComponentModel;
using System.Timers;

namespace Effects
{
    public class Ticker : INotifyPropertyChanged
    {
        public Ticker()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        public string Now
        {
            get { return DateTime.Now.ToLongTimeString(); }
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Now)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
