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
namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : Window
    {
        public Image()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            image.Stretch = Stretch.Fill;
        }

        private void btnFill_Copy_Click(object sender, RoutedEventArgs e)
        {
            image.Stretch = Stretch.Uniform;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            //string file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Pics", "6.jpg");

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                if (System.IO.File.Exists(textBox.Text))
                {
                    image.Source = new BitmapImage(new Uri(textBox.Text));
                }
            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

            ofd.Title = "Select your image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
            if(ofd.ShowDialog()==true)
            {
                this.textBox.Text = ofd.FileName;
            }
            

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
