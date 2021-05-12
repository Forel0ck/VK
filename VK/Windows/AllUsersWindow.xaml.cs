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


        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
                this.Hide();
                AddUsersWindow addUsersWindow = new AddUsersWindow();
                addUsersWindow.ShowDialog();
                this.Close();
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (All.SelectedItem is Person person)
            {
               var resMass = MessageBox.Show($"Вы хотите удалить пользователя {person.Name}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass==MessageBoxResult.Yes)
                {
                    context.Person.Remove(context.Person.Where(i => i.IdPerson == person.IdPerson).FirstOrDefault());
                    context.SaveChanges();
                    All.ItemsSource = context.Person.ToList();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (All.SelectedItem is Person person)
            {
                var resMAss = MessageBox.Show($"Вы хотите изменить пользователя {person.Name}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMAss==MessageBoxResult.Yes)
                {
                    this.Hide();
                    AddUsersWindow addUsersWindow = new AddUsersWindow(person);
                    PersonData.IdPerson = person.IdPerson;
                    addUsersWindow.ShowDialog();
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
