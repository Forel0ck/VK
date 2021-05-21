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
    /// 

    public partial class AllUsersWindow : Window
    {

        List<string> qtyList = new List<string>() {"Все","10","50","100" };
        List<Person> people = new List<Person>();
        List<Role> roleList = new List<Role>();
        private int selectNotes = 0;
        private int numPage = 0;

        public AllUsersWindow()
        {
            InitializeComponent();

            cmbQty.ItemsSource = qtyList;
            cmbQty.SelectedIndex = 0;

            AllUser.ItemsSource = context.Person.ToList();

            AllUser.ItemsSource = context.Person.ToList();
            roleList = ClassEntities.context.Role.ToList();
            roleList.Insert(0, new Role { RoleName = "Все роли" });
            cmbSortRole.ItemsSource = roleList;
            cmbSortRole.DisplayMemberPath = "RoleName";
            cmbSortRole.SelectedIndex = 0;

            Filter();

        }

        private void Filter()
        {
            people = ClassEntities.context.Person.ToList();

            if (cmbSortRole.SelectedIndex != 0)
            {
                people = people.Where(i => i.IdRole == cmbSortRole.SelectedIndex).ToList();
            }

            people = people.Where(i => i.FIO.Contains(txtSearch.Text)).ToList();

            if(cmbQty.SelectedIndex == 0)
            {
                numPage = 0;
            }
            if(cmbQty.SelectedIndex != 0)
            {
                selectNotes = Convert.ToInt32(cmbQty.SelectedItem);
            }
            else
            {
                selectNotes = people.ToList().Count();
            }

            people = people.Skip(numPage * selectNotes).Take(selectNotes).ToList();
            AllUser.ItemsSource = people;

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
                this.Show();
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AllUser.SelectedItem is Person person)
            {
               var resMass = MessageBox.Show($"Вы хотите удалить пользователя {person.Name}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass==MessageBoxResult.Yes)
                {
                    context.Person.Remove(context.Person.Where(i => i.IdPerson == person.IdPerson).FirstOrDefault());
                    context.SaveChanges();
                    AllUser.ItemsSource = context.Person.ToList();
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
            if (AllUser.SelectedItem is Person person)
            {
                var resMAss = MessageBox.Show($"Вы хотите изменить пользователя {person.Name}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMAss==MessageBoxResult.Yes)
                {
                    this.Hide();
                    AddUsersWindow addUsersWindow = new AddUsersWindow(person);
                    PersonData.IdPerson = person.IdPerson;
                    addUsersWindow.ShowDialog();
                    this.Show();
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


        private void cmbSortRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbQty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnRihgt_Click(object sender, RoutedEventArgs e)
        {
            if(people.ToList().Count > 0 && people.ToList().Count() >= selectNotes)
            {
                numPage++;
                Filter();
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            if(numPage != 0)
            {
                numPage--;
                Filter();
            }
            
        }
    }
}
