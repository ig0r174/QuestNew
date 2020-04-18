using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Quest2
{
    /// <summary>
    /// Логика взаимодействия для Level2.xaml
    /// </summary>
    public partial class Level2 : Page
    {
        string[] questionsArray = new string[] { "Сколько секунд длился таймер?", "Сколько всего было проводов?", "Клавиша обезвреживания?" };
        string[] answersArray = new string[] { "10", "4", "R" };
        private int questionId;
        public Level2()
        {
            InitializeComponent();
        }

        private void SetPoliceman(int step)
        {
            Policeman.Source = new BitmapImage(new Uri(@"/police_" + step + ".png", UriKind.RelativeOrAbsolute));
        }

        private void Level2_Button_Click(object sender, RoutedEventArgs e)
        {
            if (questionsArray.Length - 1 < questionId)
            {
                SetPoliceman(3);
                MessageBox.Show("В следующий раз не лезь, а то она тебя сожрёт!");
                MainWindow.GoToNextLevel();
                return;
            }

            if (questionId == 0)
            {
                AddTextBox();
                SetPoliceman(2);
            } else if (!VerifyAnswer())
            {
                ReturnBadAnswer();
                return;
            }

            questionId++;
            Question.Text = questionsArray[questionId - 1];
        }

        private bool VerifyAnswer()
        {
            if ( GetAnswer() == answersArray[questionId - 1]) return true;
            else return false;
        }

        private void ReturnBadAnswer()
        {
            MessageBox.Show("Вспоминай!");
        }

        private void AddTextBox()
        {
            TextBox textBox = new TextBox()
            {
                Name = "Answer",
                Width = 100,
                Height = 18,
            };
            MainGrid.Children.Add(textBox);
        }

        private string GetAnswer()
        {
            var answer = "";
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    var tb = item as TextBox;
                    answer = tb.Text;
                }
            }
            return answer;
        }
    }
}
