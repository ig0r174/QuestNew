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

namespace Quest2
{
    /// <summary>
    /// Логика взаимодействия для Level4.xaml
    /// </summary>
    public partial class Level4 : Page
    {
        private Point MouseDownLocation;
        public Level4()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                MouseDownLocation = e.GetPosition(MainGrid);
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                MovingImage.Margin = new Thickness(e.GetPosition(MainGrid).X + MovingImage.Margin.Left - MouseDownLocation.X, e.GetPosition(MainGrid).Y + MovingImage.Margin.Top - MouseDownLocation.Y, 0, 0);
        }

        private void Level4_Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> checkBoxes = new List<string>() {};
            foreach (var item in ItemsList.Children)
            {
                var checkBox = item as CheckBox;
                if (checkBox.IsChecked ?? false && checkBox.Name.Length > 0)
                    checkBoxes.Add(checkBox.Name);
            }

            if (checkBoxes.Count == 4 && CheckRadioButton()) MainWindow.GoToNextLevel();
            else MessageBox.Show("Нет! Джон взял другие вещи или у кофты другой цвет!");
        }

        private bool CheckRadioButton()
        {
            return Green.IsChecked ?? false;
        }
    }
}
