using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Timers;
using System.Windows.Threading;
using System.ComponentModel;
using Timer.Models;

namespace Timer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ClockModel ClockModel { get; set; }

        private static System.Timers.Timer timer;

        private bool Lock = true;

        public MainWindow()
        {
            Topmost = true;

            InitializeComponent();

            DateTime nowTime = DateTime.Now;

            ClockModel = new ClockModel { Hour = nowTime.Hour, Minute = nowTime.Minute, Second = nowTime.Second};

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            DataContext = this;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (ClockModel.Second + 1 == 60)
            {
                ClockModel.Second = 0;
                if (ClockModel.Minute + 1 == 60)
                {
                    ClockModel.Minute = 0;
                    if (ClockModel.Hour + 1 == 24)
                    {
                        ClockModel.Hour = 0;
                    }
                    else
                    {
                        ClockModel.Hour += 1;
                    }
                }
                else
                {
                    ClockModel.Minute += 1;
                }
            }
            else
            {
                ClockModel.Second += 1;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Lock)
            {
                DragMove();
            } 
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Lock = !Lock;
        }
    }
}
