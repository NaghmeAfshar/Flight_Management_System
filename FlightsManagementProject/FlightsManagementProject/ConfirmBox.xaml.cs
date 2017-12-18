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
    /// Interaction logic for ConfirmBox.xaml
    /// </summary>
    public partial class ConfirmBox : Window
    {
        public  bool okClick = false;
        public ConfirmBox()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            okClick = true;
            Close();
        }
    }
}
