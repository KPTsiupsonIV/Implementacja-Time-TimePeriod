using czas;
using System;
using System.Windows;
using System.Windows.Threading;

namespace ClockApp
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        TimePeriod currentTime;

        public MainWindow()
        {
            InitializeComponent();

            // Inicjalizacja timera
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            // Utworzenie obiektu TimePeriod z aktualnym czasem
            DateTime now = DateTime.Now;
            currentTime = new TimePeriod((byte)now.Hour, (byte)now.Minute, (byte)now.Second);

            // Wyświetlenie aktualnego czasu
            ClockText.Text = currentTime.ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Zaktualizowanie czasu i wyświetlenie go na ekranie
            currentTime = currentTime.PlusSeconds(1);
            TimerLabel.content = currentTime.ToString();
        }
    }
}
