using MemoApp.Common;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MemoApp
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

       

        

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bg_Changer();

            

        }

        void Bg_Changer()
        {
            if (cbxBgImages.SelectedIndex == -1)
            {
                return;
            }


            string fn = System.IO.Path.Combine(Environment.CurrentDirectory
                        , "Data", "Pics", "Bg", cbxBgImages.SelectedIndex.ToString() + ".jpg");
            Uri uri = new Uri(fn);
            System.Windows.Media.ImageBrush imageBrush =
                new ImageBrush(new BitmapImage(uri));

            if (radFill.IsChecked == true)
            {
                imageBrush.Stretch = Stretch.Fill;
            }
            else if (radUniform.IsChecked == true)
            {
                imageBrush.Stretch = Stretch.UniformToFill;
            }

            this.Background = imageBrush;

            MemoApp.Properties.Settings.Default.selected_image_index = cbxBgImages.SelectedIndex;
            MemoApp.Properties.Settings.Default.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.canvasAbout.Visibility = Visibility.Hidden;
            int selectedIndex = MemoApp.Properties.Settings.Default.selected_image_index;

            this.cbxBgImages.SelectedIndex = selectedIndex;

            //digital clock
            lblTime.Content = System.DateTime.Now.ToString("HH:mm:ss");
            //---------
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            UpdateCalender();
            //--------------------
            MemoApp.Users.LoginWindow loginWindow = new Users.LoginWindow();
            loginWindow.ShowDialog();

            if (loginWindow.DialogResult==false)
            {
                this.Close();
            }

        }

        void UpdateCalender()
        {
            lblYear.Content = System.DateTime.Now.Year.ToString();
            
            //--------month-----------
            int monthNumber = System.DateTime.Now.Month;
            string monthName = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);
            lblMonth.Content = monthName;

            lblDayOfMonth.Content=System.DateTime.Now.Day;

            lblDayName.Content = System.DateTime.Today.DayOfWeek;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            lblTime.Content = System.DateTime.Now.ToString("HH:mm:ss");
        }

        private void radFill_Checked(object sender, RoutedEventArgs e)
        {
            Bg_Changer();
        }

        private void radUniform_Checked(object sender, RoutedEventArgs e)
        {
            Bg_Changer();
        }

        private void btnAboutMenu_Click(object sender, RoutedEventArgs e)
        {
            if (canvasAbout.Visibility == Visibility.Visible)
            {
                canvasAbout.Visibility = Visibility.Hidden;
            }
            else
            {
                canvasAbout.Visibility = Visibility.Visible;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit?", "Alert!", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK) {

                this.Close();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnToolsMenu_Click(object sender, RoutedEventArgs e)
        {
            MemoApp.Users.MyUsers myuser = new Users.MyUsers();
            myuser.ShowDialog();
        }

        private void btnAboutSubMenu_Click(object sender, RoutedEventArgs e)
        {
            AboutUs aboutUs = new AboutUs();
            aboutUs.ShowDialog();
        }

        private void btnAddMemmo_Click(object sender, RoutedEventArgs e)
        {
            MemoWindow memoWindow = new MemoWindow();   
            memoWindow.ShowDialog();
        }
    }
}
