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
        public MainWindow()
        {
            InitializeComponent();
            Captcha1.Visibility = Visibility.Hidden;
            imgCaptcha.Visibility = Visibility.Hidden;
            reload.Visibility = Visibility.Hidden;
            Captcha.Visibility = Visibility.Hidden;

            CaptchaMet();
        }

        public void swBlocknot()
        {
            string path = @"C:\Users\user\Desktop\vk.txt";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                if (Save.IsChecked == true)
                {
                    sw.WriteLine();
                    sw.WriteLine(Login.Text);
                    sw.WriteLine(Pass.Text);
                    return;
                }
            }
        }

        public void srBlocknot()
        {
            string path = @"C:\Users\user\Desktop\vk.txt";

            using (StreamReader sr = new StreamReader(path))
            {
                string result = sr.ReadToEnd();
                return;
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
            swBlocknot();
            srBlocknot();

            //if ((Login.ToString == ) && (Pass.ToString == ))
            //{
                var login = Convert.ToString(Login.Text);

                this.Hide();
                NEXT next = new NEXT(login.ToString());
                next.ShowDialog();
                this.Show();
            //    }
            //    else
            //    {
            //        InitializeComponent();
            //        Captcha1.Visibility = Visibility.Visible;
            //        imgCaptcha.Visibility = Visibility.Visible;
            //        reload.Visibility = Visibility.Visible;
            //        Captcha.Visibility = Visibility.Visible;

            //        if ((Login.ToString == ) && (Pass.ToString == ) && (Captcha1.Text == Captcha.Text))
            //        {
            //            var login = Convert.ToString(Login.Text);

            //            this.Hide();
            //            NEXT next = new NEXT(login.ToString());
            //            next.ShowDialog();
            //            this.Show();
            //        }
            //    }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CaptchaMet();
        }

    }

}
