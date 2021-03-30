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

namespace VK
{

    public partial class MainWindow : Window
    {
        List<Person> peopleList = new List<Person>();
        string path = @"C:\Users\user\Desktop\vk.txt";

        public MainWindow()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader(path))
            {
               string srRead  = sr.ReadToEnd();
                if(srRead != "")
                {
                    Login.Text = srRead.Split()[0];
                    Pass.Text = srRead.Split()[1];
                }
              

            }

            Captcha1.Visibility = Visibility.Hidden;
            imgCaptcha.Visibility = Visibility.Hidden;
            reload.Visibility = Visibility.Hidden;
            Captcha.Visibility = Visibility.Hidden;

            CaptchaMet();

            peopleList.Add(new Person { Login = "Forelock",Pass = "1234",Id = "1",Name = "Сергей Панченко"});
            peopleList.Add(new Person { Login = "Den",Pass = "1111",Id = "2",Name = "Денис Большачков"});
            peopleList.Add(new Person { Login = "Gyss",Pass = "2222",Id = "3",Name = "Никита Козлов"});
            peopleList.Add(new Person { Login = "Riba",Pass = "3333",Id = "4",Name = "Сергей Панченко"});
            peopleList.Add(new Person { Login = "Cheburek",Pass = "4444",Id = "5",Name = "Никита Симонов"});

        }


        public void swblocknot()
        {
          

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                if (Save.IsChecked == true)
                {
                    sw.Write(Login.Text);
                    sw.Write(" ");
                    sw.Write(Pass.Text);
                    sw.Close();
                }
            }
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


        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            swblocknot();

            Person user = peopleList.Where(p => p.Login == this.Login.Text && p.Pass == this.Pass.Text).FirstOrDefault(); 

            if ( user!=null )
            {
                var login = Convert.ToString(Login.Text);

                this.Hide();
                NEXT next = new NEXT(login.ToString());
                next.ShowDialog();
                this.Show();
            }
            else
            {
                InitializeComponent();
                Captcha1.Visibility = Visibility.Visible;
                imgCaptcha.Visibility = Visibility.Visible;
                reload.Visibility = Visibility.Visible;
                Captcha.Visibility = Visibility.Visible;

                if ((user != null) && (Captcha1.Text == Captcha.Text))
                {
                    var login = Convert.ToString(Login.Text);

                    this.Hide();
                    NEXT next = new NEXT(login.ToString());
                    next.ShowDialog();
                    this.Show();
                }
                else
                {
                    Captcha.Clear();
                    CaptchaMet();
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CaptchaMet();
        }

    }

}
