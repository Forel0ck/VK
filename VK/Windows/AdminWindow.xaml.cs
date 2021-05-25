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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
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
        public AdminWindow(string login)
        {
            InitializeComponent();
            txtAd.Text = "Администратор " + login;
        }

        private void See_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AllUsersWindow allUsersWindow = new AllUsersWindow();
            allUsersWindow.ShowDialog();
            this.Close();
        }

        private void Off_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("cmd" ,"/c shutdown -s -t 00");
        }
    }
}
