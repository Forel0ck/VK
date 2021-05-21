using System;
using System.Collections.Generic;
using System.IO;
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
using static VK.ClassEntities;

namespace VK
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Captcha1.Visibility = Visibility.Hidden;
            imgCaptcha.Visibility = Visibility.Hidden;
            reload.Visibility = Visibility.Hidden;
            Captcha.Visibility = Visibility.Hidden;

            CaptchaMet();

        }


        public  void CaptchaMet()
        {

            String value = " ";

            value = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

            value += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";

            value += "1,2,3,4,5,6,7,8,9,0";

            char[] a = { ',' };

            String[] ar = value.Split(a);

            String pwd = " ";

            string temp = " ";

            Random random = new Random();


            for (int i = 0; i < 6; i++)

            {

                temp = ar[(random.Next(0, ar.Length))];



                pwd += temp;

            }


            Captcha1.Text = pwd;
        }



        private void tbExit_Click(object sender, RoutedEventArgs e)
        {

            var User = context.Person.ToList().
                Where(p => p.Name == this.Login.Text && p.Password == Pass.Password).FirstOrDefault(); 

            if ( User!=null )
            {
                var login = Convert.ToString(Login.Text);

                switch (User.IdRole)
                {
                    case 1:
                        this.Hide();
                        Windows.AdminWindow adminWindow = new Windows.AdminWindow(login.ToString());
                        adminWindow.ShowDialog();
                        this.Close();
                        break;

                    case 2:
                        this.Hide();
                        Windows.ManegerWindow manegerWindow = new Windows.ManegerWindow(login.ToString());
                        manegerWindow.ShowDialog();
                        this.Close();
                        break;

                    case 3:
                        this.Hide();
                        Windows.UserWindow userWindow = new Windows.UserWindow(login.ToString());
                        userWindow.ShowDialog();
                        this.Close();
                        break;

                    default:
                        break;
                }

            }
            else
            {
                MessageBox.Show("Вы ввели не правильно пароль или логин");

                InitializeComponent();
                Captcha1.Visibility = Visibility.Visible;
                imgCaptcha.Visibility = Visibility.Visible;
                reload.Visibility = Visibility.Visible;
                Captcha.Visibility = Visibility.Visible;

                if ((User != null) && (Captcha1.Text == Captcha.Text))
                {
                   var login = Convert.ToString(Login.Text);

                switch (User.IdRole)
                {
                    case 1:
                        Windows.AdminWindow adminWindow = new Windows.AdminWindow(login.ToString());
                        this.Hide();
                        adminWindow.ShowDialog();
                        this.Close();
                        break;

                    case 2:
                        Windows.ManegerWindow manegerWindow = new Windows.ManegerWindow(login.ToString());
                        this.Hide();
                        manegerWindow.ShowDialog();
                            this.Close();
                        break;

                    case 3:
                        Windows.UserWindow userWindow = new Windows.UserWindow(login.ToString());
                        this.Hide();
                        userWindow.ShowDialog();
                        this.Close();
                        break;

                    default:
                        break;
                }
                }
                else
                {
                    Captcha.Clear();
                    CaptchaMet();
                }
            }
            Login.Clear();
            Pass.Clear();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CaptchaMet();
        }


        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}
