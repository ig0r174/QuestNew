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
    /// Логика взаимодействия для Level6.xaml
    /// </summary>
    public partial class Level6 : Page
    {
        public Level6()
        {
            InitializeComponent();
        }

        private void ElementClick(object sender, RoutedEventArgs e)
        {
            var element = sender as MenuItem;
            if (element.Name == "TrueElement") MainWindow.GoToNextLevel();
            else MessageBox.Show("Не тот элемент!");
        }
    }
}
