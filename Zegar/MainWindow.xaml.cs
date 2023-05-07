using System;
using System.Windows;
using System.Windows.Threading;
using czas;

namespace Zegar
{
    public partial class MainWindow : Window
    {
        private Time currentTime;

        public MainWindow()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            currentTime = new Time((byte)now.Hour, (byte)now.Minute, (byte)now.Second);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerRicker;
            timer.Start();
        }

        private void timerRicker(object sender, EventArgs e)
        {
            currentTime = currentTime.PlusSeconds(1);
            Czas.Content = currentTime.ToString();
        }
    }
}
