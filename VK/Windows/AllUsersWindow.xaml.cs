using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AllUsersWindow.xaml
    /// </summary>
    public partial class AllUsersWindow : Window
    {
        public AllUsersWindow()
        {
            InitializeComponent();

            All.ItemsSource = context.Person.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (All.SelectedItem is Person person)
            {
                this.Hide();
                AddUsersWindow addUsersWindow = new AddUsersWindow(person);
                PersonData.IdPerson = person.IdPerson;
                addUsersWindow.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                AddUsersWindow addUsersWindow = new AddUsersWindow();
                addUsersWindow.ShowDialog();
                this.Close();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (All.SelectedItem is Person person)
            {
                context.Person.Remove(context.Person.Where(i => i.IdPerson == person.IdPerson).FirstOrDefault());
                context.SaveChanges();
                All.ItemsSource = context.Person.ToList();
            }
        }
    }
}
