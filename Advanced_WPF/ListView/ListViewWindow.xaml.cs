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
using System.Xml;

namespace Advanced_WPF.ListView
{
    /// <summary>
    /// Interaction logic for ListViewWindow.xaml
    /// </summary>
    public partial class ListViewWindow : Window
    {
        public ListViewWindow()
        {
            InitializeComponent();

            lblCount.Content = my_listView.Items.Count;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            my_listView.Items.Add(txtAdd.Text);
            lblCount.Content = my_listView.Items.Count;

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            my_listView.Items.Clear();
            lblCount.Content = my_listView.Items.Count;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int sel_index = my_listView.SelectedIndex;
            if (sel_index > -1 && sel_index < my_listView.Items.Count)
            {
                my_listView.Items.RemoveAt(sel_index);
                lblCount.Content = my_listView.Items.Count;
            }
        }

        

        private void btnInfoClear_Click(object sender, RoutedEventArgs e)
        {
            img_listView.Items.Clear();
        }

        private void btnAddImgColumn_Click(object sender, RoutedEventArgs e)
        {
            //img_listView.Items.Clear();
            ImageAdder("1.png", "About");
            ImageAdder("2.png", "Memo");
            ImageAdder("3.png", "Docs");
            ImageAdder("4.png", "Settings");
            ImageAdder("5.png", "Test");
            ImageAdder("6.png", "Test 1");
            ImageAdder("7.png", "Test 2");
        }

        void ImageAdder(string imgFileName,string lblText)
        {
            ListViewItem li = new ListViewItem();
            StackPanel sp = new StackPanel();
            Image img = new Image();
            Label lbl = new Label();
            //-------------------------------
            sp.Orientation = Orientation.Horizontal;
            img.Width = 32;
            img.Height = 32;
            lbl.Content = lblText;

            string fn = Environment.CurrentDirectory + "\\Data\\Pics\\" + imgFileName;
            img.Source=new BitmapImage(new Uri(fn));
            sp.Children.Add(img);
            sp.Children.Add(lbl);

            li.Content = sp;
            img_listView.Items.Add(li);
        }

        private void img_listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int si =  img_listView.SelectedIndex;

        }
    }
}
