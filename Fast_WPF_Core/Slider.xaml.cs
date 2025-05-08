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
    /// Interaction logic for Slider.xaml
    /// </summary>
    public partial class Slider : Window
    {
        public Slider()
        {
            InitializeComponent();
        }

        private void MySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //if (txtSliderVal != null)
            //{
            //    txtSliderVal.Text = Math.Round(MySlider.Value,2).ToString();
            //}

            if (button != null)
            {
                button.Width = Math.Round(MySlider.Value, 2);
            }

        }

        

        private void MySlider_Copy_valuechanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            if (button != null)
            {
                button.Height = Math.Round(MySlider_Copy.Value, 2);
            }
        }
    }
}
