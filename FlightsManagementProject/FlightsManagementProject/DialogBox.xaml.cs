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
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        public bool okClick = false;
        public string result;
        public DialogBox(string text)
        {
            InitializeComponent();
            textBlock1.Text = text;
        }
        public DialogBox()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            okClick = true;
            result = textBox1.Text;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
        
    }
}
