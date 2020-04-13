using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Quest2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool level1Flag = false;

        public MainWindow()
        {
            InitializeComponent();
            CloseButton.MouseLeftButtonDown += CloseWindow;
            WindowBorder.MouseLeftButtonDown += MoveWindow;
            MyName.Content = Environment.UserName;
            Window.KeyDown += SetFlag;
            StartLevel();
        }

        private void SetFlag(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K)
            {
                level1Flag = true;
            }
        }

        private void StartLevel()
        {
            
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if( !level1Flag)
            {
                int maxLeft = Convert.ToInt32(Body.ActualWidth - Level2Button.ActualWidth);
                int maxTop = Convert.ToInt32(Body.ActualHeight - Level2Button.ActualHeight);
                Random rand = new Random();
                Level2Button.Margin = new Thickness(rand.Next(maxLeft), rand.Next(maxTop), 0, 0);
            } else
            {
                MessageBox.Show("NextLevel");
            }
            
        }
    }
}
