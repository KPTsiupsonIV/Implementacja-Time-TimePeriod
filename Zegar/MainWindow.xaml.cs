using System;
using System.Windows;
using System.Windows.Threading;
using czas;

namespace Zegar
{
    public partial class MainWindow : Window
    {
        private Time currentTime;
        private int labelNumber = 1;
        public MainWindow()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            currentTime = new Time((byte)now.Hour, (byte)now.Minute, (byte)now.Second);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timerRicker;
            timer.Start();
        }

        private void timerRicker(object sender, EventArgs e)
        {
            currentTime = currentTime.PlusMilli(1);
            Czas.Content = currentTime.ToString();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if(labelNumber == 1)
            {
                Stoper1.Content = currentTime.ToString();
                labelNumber++;
            }
            else if(labelNumber == 2)
            {
                Stoper2.Content = currentTime.ToString();
                labelNumber++;
            }
            else if (labelNumber == 3)
            {
                Stoper3.Content = currentTime.ToString();
                labelNumber++;
            }
            else if (labelNumber == 4)
            {
                Stoper4.Content = currentTime.ToString();
                labelNumber++;
            }else if (labelNumber ==5)
            {
                Stoper5.Content = currentTime.ToString();
                labelNumber++;
            }
            else if (labelNumber == 6)
            {
                Stoper6.Content = currentTime.ToString();
                labelNumber++;
            }
            else if (labelNumber == 7)
            {
                Stoper7.Content = currentTime.ToString();
                labelNumber = 1;
            }

        }

        private void StoperButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
