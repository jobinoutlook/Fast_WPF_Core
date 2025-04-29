using System;
using System.Collections.Generic;
using System.IO;
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

namespace MemoApp.Users
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txtPasswordBox.Password == "")
            {
                MessageBox.Show("Invalid password");
                return;
            }

            string correct_pass = "not_defined";

            if (cbxUserName.SelectedIndex == 0)
            {
                correct_pass = MemoApp.Properties.Settings.Default.first_user_pass;
            }
            if (cbxUserName.SelectedIndex == 1)
            {
                correct_pass = MemoApp.Properties.Settings.Default.second_user_pass;
            }
            if (cbxUserName.SelectedIndex == 2)
            {
                correct_pass = MemoApp.Properties.Settings.Default.third_user_pass;
            }
            if (txtPasswordBox.Password != correct_pass)
            {
                MessageBox.Show("Please enter the correct password");
                return;
            }
            else
            {
                this.DialogResult = true;
            }
        
        }

        private void cbxUserName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fn = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "Pics", "user", cbxUserName.SelectedIndex.ToString() + ".jpg");

            user_image_loader(fn);
        }

        private void winLogin_Loaded(object sender, RoutedEventArgs e)
        {
            string username;

            username = MemoApp.Properties.Settings.Default.first_user_name;
            cbxUserName.Items.Add(username);

            username = MemoApp.Properties.Settings.Default.second_user_name;
            cbxUserName.Items.Add(username);

            username = MemoApp.Properties.Settings.Default.third_user_name;
            cbxUserName.Items.Add(username);
            //---------------------------
            cbxUserName.SelectedIndex = 0;
        }

        void user_image_loader(string fn)
        {
            if (System.IO.File.Exists(fn) == true)
            {
                BitmapImage bm = new BitmapImage();
                FileStream fs = new FileStream(fn, FileMode.Open);
                //--------------
                bm.BeginInit();
                bm.CacheOption = BitmapCacheOption.OnLoad;
                bm.StreamSource = fs;
                bm.EndInit();
                //--------------
                this.imgUser.Source = bm;
                //----------------------------------
                bm = null;
                fs.Dispose();
                //----------------------------------
            }
            else
            {
                this.imgUser.Source = null;
            }


        }
    }
}
