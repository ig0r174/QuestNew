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
    /// Логика взаимодействия для Level3.xaml
    /// </summary>
    public partial class Level3 : Page
    {
        public Level3()
        {
            InitializeComponent();
            SetComboBoxesValues();
        }

        private void SetComboBoxesValues()
        {
            for (int i = 1; i <= 31; i++)
                DaysComboBox.Items.Add(i);

            foreach (var month in new string[] { "Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря" })
                MonthsComboBox.Items.Add(month);

            for (int i = 1900; i <= 2020; i++)
                YearsComboBox.Items.Add(i);
        }

        private void Level3_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder("", 50);
            foreach (var item in ControlsGrid.Children)
            {
                if( item is ComboBox)
                {
                    var cb = item as ComboBox;
                    sb.Append(cb.SelectedItem);
                }
            }

            if (sb.ToString() == "7Октября1952") MainWindow.GoToNextLevel();
            else MessageBox.Show("Неверный ответ!");
        }

    }
}
