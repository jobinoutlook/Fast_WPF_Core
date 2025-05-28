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

namespace Adv_WPF.Toolbar_Ribbon
{
    /// <summary>
    /// Interaction logic for wpf_StatusBar.xaml
    /// </summary>
    public partial class wpf_StatusBar : Window
    {
        public wpf_StatusBar()
        {
            InitializeComponent();
        }

        private void st_btn_info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I am Info Button");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //MessageBox.Show("I am Zoom Combobox");
            if (cbxZoom.SelectedIndex == 0)
            {
                textBox.FontSize = 7;
            }

            else if (cbxZoom.SelectedIndex == 1)
            {
                textBox.FontSize = 10;
            }
            else if (cbxZoom.SelectedIndex == 2)
            {
                textBox.FontSize = 14;
            }
            else if (cbxZoom.SelectedIndex == 3)
            {
                textBox.FontSize = 18;
            }
            else if (cbxZoom.SelectedIndex == 4)
            {
                textBox.FontSize = 21;
            }


        }

       
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            lblCount.Content = textBox.Text.Length.ToString();
        }
    }
}
