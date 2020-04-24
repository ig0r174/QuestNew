using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;

namespace Quest2
{
    /// <summary>
    /// Логика взаимодействия для Level7.xaml
    /// </summary>
    public partial class Level7 : Page
    {
        private bool isAdded = false;
        private DateTime validDate = GetDate();

        private static DateTime GetDate()
        {
            Random rand = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }

        public Level7()
        {
            InitializeComponent();
            GenerateItems();
        }

        private void Date_OnSelectedDate(object sender, SelectionChangedEventArgs e)
        {
            if(Date.SelectedDate.ToString().Split(' ')[0] == validDate.ToString("d", CultureInfo.CreateSpecificCulture("ru-RU")) )
                MainWindow.GoToNextLevel();
        }

        private void GenerateItems()
        {
            var rand = new Random();
            var randId = rand.Next(1, 100);

            for (int i = 1; i <= rand.Next(randId, 100); i++)
            {
                TreeViewItem newChild = new TreeViewItem();
                newChild.Header = "Заголовок " + i;
                var elements = new List<string> { };
                for (int j = 1; j <= rand.Next(10, 20); j++)
                {
                    elements.Add("Элемент " + j);
                }

                if (!isAdded && i == randId)
                {
                    elements.Add(validDate.ToString("d", CultureInfo.CreateSpecificCulture("ru-RU")));
                    isAdded = true;
                }

                newChild.ItemsSource = elements.ToArray();
                Tree.Items.Add(newChild);
            }

            MessageBox.Show(randId.ToString());
        }
    }
}
