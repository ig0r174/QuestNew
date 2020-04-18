using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Quest2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int nowLevel = 0;
        public static LevelStatus status = new LevelStatus();

        public MainWindow()
        {
            InitializeComponent();
            SetDefaultSettings();
            StartLevel(1);
        }

        private void SetDefaultSettings()
        {
            MyName.Content = Environment.UserName;
            CloseButton.MouseLeftButtonDown += CloseWindowClick;
            WindowBorder.MouseLeftButtonDown += MoveWindow;
            status.FinishGameEvent += EndGame;
            status.GoToNextLevelEvent += NextLevel;
        }

        private void StartLevel(int level)
        {
            nowLevel = level;
            LevelLabel.Content = level + " уровень";
            Hint.Content = GetHint();
            GenerateLevel();
        }

        private void NextLevel(object sender, EventArgs e)
        {
            StartLevel(++nowLevel);
        }

        private void EndGame(object sender, EventArgs e)
        {
            FinishGame();
        }

        private object GetHint()
        {
            string hintText;
            switch (nowLevel)
            {
                case 1:
                    hintText = "Истина в красном";
                    break;
                case 3:
                    hintText = "Царь всея Руси";
                    break;
                case 4:
                    hintText = "Нужно поковыряться";
                    break;
                case 6:
                    hintText = "Опять поковыряться";
                    break;
                default:
                    hintText = "–";
                    break;
            }
            return hintText;
        }

        private void GenerateLevel()
        {
            try
            {
                LevelFrame.Navigate(new System.Uri("Level" + nowLevel + ".xaml", UriKind.RelativeOrAbsolute));
            }
            catch (Exception)
            {
                MessageBox.Show("Ты прошел последний уровень!");
                return;
            }
        }

        private void ClearBody()
        {
            Body.Children.Clear();
        }

        public void FinishGame()
        {
            MessageBox.Show("Game over");
            CloseWindow();
        }

        private void CloseWindow()
        {
            this.Close();
        }

        private void CloseWindowClick(object sender, MouseButtonEventArgs e)
        {
            CloseWindow();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public static void GoToNextLevel()
        {
            status.SendNextLevelEvent();
        }
    }
}
