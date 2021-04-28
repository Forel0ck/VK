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

namespace VK.Windows
{
    /// <summary>
    /// Логика взаимодействия для ManegerWindow.xaml
    /// </summary>
    public partial class ManegerWindow : Window
    {
        public ManegerWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public ManegerWindow(string login)
        {
            InitializeComponent();
            txtMg.Text = "Менеджер " + login;
        }

        private void See_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChekWindow chekWindow = new ChekWindow();
            chekWindow.ShowDialog();
            this.Show();
            this.Close();
        }
    }
}
