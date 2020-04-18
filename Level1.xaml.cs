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
using System.Windows.Threading;

namespace Quest2
{
    /// <summary>
    /// Логика взаимодействия для Level1.xaml
    /// </summary>
    public partial class Level1 : Page
    {
        private bool nextLevelFlag = false;
        private DispatcherTimer dispatcherTimer;
        private int timerSeconds = 10;

        public Level1()
        {
            InitializeComponent();
            StartTimer();
            this.KeyDown += SetFlag;
        }
        private void StartTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(UpdateBombTimer);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void UpdateBombTimer(object sender, EventArgs e)
        {
            if (timerSeconds <= 0) FinishGame();

            timerSeconds--;
            if (timerSeconds < 10)
                TimerLabel.Content = "00:00:0" + timerSeconds;
            else TimerLabel.Content = "00:00:" + timerSeconds;
            CommandManager.InvalidateRequerySuggested();
        }

        private void FinishGame()
        {
            MainWindow.status.SendFinishEvent();
        }

        private void SetFlag(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.R)
            {
                nextLevelFlag = true;
                dispatcherTimer.Stop();
            }
        }
        private void Level1_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!nextLevelFlag)
            {
                int maxLeft = Convert.ToInt32(Body.ActualWidth - Level1Button.ActualWidth);
                int maxTop = Convert.ToInt32(Body.ActualHeight - Level1Button.ActualHeight - BombImage.ActualHeight);
                Random rand = new Random();
                Level1Button.Margin = new Thickness(rand.Next(maxLeft), rand.Next(maxTop), 0, 0);
            }
            else
            {
                dispatcherTimer.Stop();
                MainWindow.GoToNextLevel();
            }

        }
    }
}
