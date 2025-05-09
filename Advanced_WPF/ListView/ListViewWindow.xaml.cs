using Advanced_WPF.MyClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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






        private void add_items_button_Click(object sender, RoutedEventArgs e)
        {
            this.multi_cols_listView.Items.Clear();
            add_user_record("1D", "Sara", "Parker", new DateTime(2023, 7, 31), "face1.jpg");
            add_user_record("2D", "Mike", "Peterson", new DateTime(2023, 6, 12), "face2.jpg");
            add_user_record("3D", "Lee", "Madson", new DateTime(2023, 1, 12), "face3.jpg");
        }

        Advanced_WPF.MyClass.User_Adder add_user_record(string my_id, string my_fname, string my_lname,
                             DateTime my_reg_date, String my_user_photo_name)
        {
            Advanced_WPF.MyClass.User_Adder user_info_adder;
            //-------------------
            //-------
            String fn;
            fn = Environment.CurrentDirectory + "\\Data\\Pics\\user\\" + my_user_photo_name;
            //---------
            user_info_adder = new MyClass.User_Adder(my_id, my_fname, my_lname,
                                                     my_reg_date,
                                                     new BitmapImage(new Uri(fn)));
            //----------------
            this.multi_cols_listView.Items.Add(user_info_adder);
            return user_info_adder;
        }



        private void add_list_button_Click(object sender, RoutedEventArgs e)
        {
            multi_cols_listView.Items.Clear();

            //----------------------------
            List<User_Adder> my_list = new List<User_Adder>();

            //------------------------------
            //-------
            String fn;
            fn = Environment.CurrentDirectory + "\\Data\\Pics\\user\\";
            //------------------------------
            my_list.Add(new Advanced_WPF.MyClass.User_Adder("1D", "Sara", "Manson", new DateTime(2023, 4, 13),
                        new BitmapImage(new Uri(fn + "face1.jpg"))));
            //------------------------------
            my_list.Add(new Advanced_WPF.MyClass.User_Adder("2D", "Mike", "Parker", new DateTime(2021, 7, 23),
                        new BitmapImage(new Uri(fn + "face2.jpg"))));
            //------------------------------
            my_list.Add(new Advanced_WPF.MyClass.User_Adder("3D", "Peter", "Lee", new DateTime(2020, 2, 11),
                        new BitmapImage(new Uri(fn + "face3.jpg"))));
            //--------------------
            this.multi_cols_listView.ItemsSource = my_list;

            foreach (User_Adder item in my_list)
            {
                this.multi_cols_listView.Items.Add(item);
            }

        }




    }
}
