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
    /// Interaction logic for DialogBoxCity.xaml
    /// </summary>
    public partial class DialogBoxCity : Window
    {
        public bool okClick = false;
        public string result;
        public int selectedCountry;
        public DialogBoxCity(ServicesReferences.Service1Client s,int k)
        {
            InitializeComponent();
            Country.ItemsSource = s.GetComboCountry().Tables[0].DefaultView;
            Country.SelectedValue=k;
        }
            
            private void OK_Click(object sender, RoutedEventArgs e)
        {
            okClick = true;
            result = textBox1.Text;
            selectedCountry =(int) Country.SelectedValue;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        }
    }
