using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightsManagementProject
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
           
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            //messsageText.Content="لطفا کمی صبر نمایید";
            Mouse.OverrideCursor = Cursors.Wait;
            ServicesReferences.Service1Client service = new ServicesReferences.Service1Client();


            bool[] result=service.Login(username.Text, password.Password);
            if (result != null)
            {
                MainWindow m = new MainWindow(result, service, username.Text, password.Password);
                m.Show();
                Mouse.OverrideCursor = null;
                this.Close();
                return;
            }
            //messsageText.Content = "";
            Mouse.OverrideCursor = null;
            ErrorBox error = new ErrorBox("نام کاربری یا رمز عبور اشتباه است!");
            error.ShowDialog();
            
            
            
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
