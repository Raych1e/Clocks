using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Models
{
    public class ClockModel : INotifyPropertyChanged
    {
        private int _hour;
        public int Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                _hour = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Hour"));
            }
        }

        private int _minute;
        public int Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                _minute = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Minute"));
            }
        }

        private int _second;
        public int Second
        {
            get
            {
                return _second;
            }
            set
            {
                _second = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Second"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }
    }
}
