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
    /// Interaction logic for ErrorMessage.xaml
    /// </summary>
    public partial class ErrorBox : Window
    {
        public ErrorBox(string text)
        {
            InitializeComponent();
            textBlock1.Text = text;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
