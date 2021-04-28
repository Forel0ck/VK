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
using System.Windows.Shapes;
using static VK.ClassEntities;

namespace VK.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChekWindow.xaml
    /// </summary>
    public partial class ChekWindow : Window
    {
        public ChekWindow()
        {
            InitializeComponent();

            All.ItemsSource = context.Person.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
