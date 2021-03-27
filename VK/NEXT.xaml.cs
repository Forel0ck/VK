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

namespace VK
{
    /// <summary>
    /// Логика взаимодействия для NEXT.xaml
    /// </summary>
    public partial class NEXT : Window
    {
        public NEXT()
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
        public NEXT(string login)
        {
            InitializeComponent();
            txtNext.Text = "Салам Алейкум " + login;
        }
    }
}
