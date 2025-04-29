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
    /// Interaction logic for MyUsers.xaml
    /// </summary>
    public partial class MyUsers : Window
    {
        public MyUsers()
        {
            InitializeComponent();
        }

        private void btnAddMemmo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Filter = "Jpg files|*.jpg";
            op.ShowDialog();
            //---------------
            if (op.FileName == "")
            {
                return;
            }
            //------load and show image-------
            user_image_loader(op.FileName);
            //---------------------------------
        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            int user_index = this.cbxUsers.SelectedIndex;
            if (user_index == -1)
            {
                MessageBox.Show("Please select user");
                return;
            }

            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter username");
                return;
            }

            if (txtPasswordBox.Password == "")
            {
                MessageBox.Show("Please enter password");
                return;
            }

            if (txtConfirmPasswordBox.Password!= txtPasswordBox.Password)
            {
                MessageBox.Show("Please use similar password");
                return;
            }

            if (user_index == 0)
            {
                MemoApp.Properties.Settings.Default.first_user_name = txtUserName.Text;
                MemoApp.Properties.Settings.Default.first_user_pass = txtPasswordBox.Password;

            }
            else if (user_index == 1)
            {
                MemoApp.Properties.Settings.Default.second_user_name = txtUserName.Text;
                MemoApp.Properties.Settings.Default.second_user_pass = txtPasswordBox.Password;
            }
            else if (user_index == 2)
            {
                MemoApp.Properties.Settings.Default.third_user_name = txtUserName.Text;
                MemoApp.Properties.Settings.Default.third_user_pass = txtPasswordBox.Password;
            }

            MemoApp.Properties.Settings.Default.Save();

            if (imgUser.Source == null)
            {
                
                MessageBox.Show("Saved");
                return;
            }

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            BitmapSource bmp= (BitmapSource)imgUser.Source;

            encoder.Frames.Add(BitmapFrame.Create(bmp));

            string fn = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "Pics", "user", cbxUsers.SelectedIndex.ToString() + ".jpg");
            using (FileStream fs = new FileStream(fn, FileMode.Create))
            {
                encoder.Save(fs);
            }

            MessageBox.Show("Saved by Image");
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int user_index = this.cbxUsers.SelectedIndex;

            if (user_index == 0)
            {
                txtUserName.Text = MemoApp.Properties.Settings.Default.first_user_name;
                txtPasswordBox.Password = MemoApp.Properties.Settings.Default.first_user_pass;

            }
            else if (user_index == 1)
            {
                txtUserName.Text = MemoApp.Properties.Settings.Default.second_user_name;
                txtPasswordBox.Password = MemoApp.Properties.Settings.Default.second_user_pass;
            }
            else if (user_index == 2)
            {
                txtUserName.Text = MemoApp.Properties.Settings.Default.third_user_name;
                txtPasswordBox.Password = MemoApp.Properties.Settings.Default.third_user_pass;
            }

            string fn = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "Pics", "user", cbxUsers.SelectedIndex.ToString() + ".jpg");

            user_image_loader(fn);
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

        private void UsersWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.cbxUsers.SelectedIndex = 0;
        }
    }
}
