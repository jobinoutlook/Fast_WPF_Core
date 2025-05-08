using System;
using System.Collections.Generic;
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

namespace Fast_WPF_Core
{
    /// <summary>
    /// Interaction logic for ResWindow.xaml
    /// </summary>
    public partial class ResWindow : Window
    {
        public ResWindow()
        {
            InitializeComponent();
        }

        

       

        private void btnLoadWin_Click(object sender, RoutedEventArgs e)
        {
            Object  obj = this.TryFindResource("LoadButtonWidth");
            if (obj != null)
            {
                lblWinRes.Content = obj;
                lblWinRes.Width = (double)obj;

            }
            else
            {
                lblWinRes.Content = "Resource not found";
            }

        }

        private void btnLoadApp_Click(object sender, RoutedEventArgs e)
        {
            Object obj = Application.Current.TryFindResource("My_ButtonFontSize");
            if (obj != null)
            {
                lblAppRes.Content = obj;
            }
            else
            {
                lblAppRes.Content = "Resource not found";
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSaveWinRes_Click(object sender, RoutedEventArgs e)
        {
            double d;
            Boolean r = double.TryParse(txtWindowRes.Text, out d);
            if (r)
            {
                this.Resources["LoadButtonWidth"] = d;
            }
        }

        private void btnSaveAppRes_Click(object sender, RoutedEventArgs e)
        {
            double d;
            Boolean r = double.TryParse(txtApplicationRes.Text, out d);
            if (r)
            {
                Application.Current.Resources["My_ButtonFontSize"] = d;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
