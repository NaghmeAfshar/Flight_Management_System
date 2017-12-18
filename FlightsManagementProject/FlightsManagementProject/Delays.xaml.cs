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
using System.Data;

namespace FlightsManagementProject
{
    /// <summary>
    /// Interaction logic for Delays.xaml
    /// </summary>
    public partial class Delays : Window
    {private  int flightID;
        ServicesReferences.Service1Client Service;
       string username;
        string password;
        public Delays(ServicesReferences.Service1Client serv,int FlightID,string usr,string pass)
        {
            Service = serv;
            InitializeComponent();
            flightID = FlightID;
            Delays_Grid.ItemsSource=Service.GetGridDelay_Cause(FlightID).Tables[0].DefaultView;
            Delays_TypeCombo.ItemsSource = Service.GetComboDelay_Type().Tables[0].DefaultView;
            username = usr;
            password = pass;
        }

        private void button43_Click(object sender, RoutedEventArgs e)
        {
            Service.InsertDelay_Cause((short)Delays_TypeCombo.SelectedValue,flightID,
                new TextRange(Delays_Description.Document.ContentStart, Delays_Description.Document.ContentEnd).Text,username,password);
            Delays_Grid.ItemsSource = Service.GetGridDelay_Cause(flightID).Tables[0].DefaultView;
        }
        
    }
}
