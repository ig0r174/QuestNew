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
using System.Xml;
using HtmlAgilityPack;

namespace Quest2
{
    /// <summary>
    /// Логика взаимодействия для Level5.xaml
    /// </summary>

    public class CourseItem
    {
        public string Currency { get; set; }
        public double Course { get; set; }
    }

    public partial class Level5 : Page
    {
        private List<string> randomCourses = new List<string>{ };

        public Level5()
        {
            InitializeComponent();
            GenerateListView();
        }

        private void GenerateListView()
        {
            var courses = GetCourses();
            Random random = new Random();

            foreach (KeyValuePair<string, double> entry in courses)
            {
                Courses.Items.Add(new CourseItem { Currency = entry.Key, Course = entry.Value });
            }

            for (int i = 1; i <= 3; i++)
            {
                int index = random.Next(courses.Count);
                KeyValuePair<string, double> pair = courses.ElementAt(index);
                NeededCourses.Text += pair.Key;
                randomCourses.Add(pair.Key);
                if (i < 3) NeededCourses.Text += "\n";
            }

        }

        private Dictionary<string, double> GetCourses()
        {
            Dictionary<string, double> courses = new Dictionary<string, double>();
            var htmlDoc = new HtmlWeb().Load("https://www.cbr.ru/currency_base/daily/");
            var rows = htmlDoc.DocumentNode.SelectNodes("//table[@class='data']//tr//td");

            var key = "";
            int line = 1;
            foreach (var cell in rows) {
                if (line == 6) line = 1;

                if (line == 4)
                {
                    key = cell.InnerText;
                    courses.Add(key, 0);
                } else if( line == 5) courses[key] = Convert.ToDouble(cell.InnerText);

                line++;
            }
            return courses;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
                ListBoxCourses.Items.Add(((CourseItem)Courses.SelectedItems[0]).Currency + "=" + ((CourseItem)Courses.SelectedItems[0]).Course);
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            ListBoxCourses.Items.Clear();
        }

        private void Level5_Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> selectedCourses = ListBoxCourses.Items.Cast<string>().Select(p => p.Split('=')[0]).ToList();
            if (selectedCourses.All(randomCourses.Contains) && selectedCourses.Count == randomCourses.Count) MainWindow.GoToNextLevel();
            else MessageBox.Show("Нет! Андрей в ярости!");
        }
    }
}
