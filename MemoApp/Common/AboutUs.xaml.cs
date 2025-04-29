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

namespace MemoApp.Common
{
    /// <summary>
    /// Interaction logic for AboutUs.xaml
    /// </summary>
    public partial class AboutUs : Window
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string fn = Environment.CurrentDirectory + "\\MemoApp.exe";
            System.Diagnostics.FileVersionInfo finfo;
            finfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(fn);

            lblCompanyName.Content = finfo.CompanyName;
            lblProductName.Content = finfo.ProductName;
            lblVersion.Content = finfo.ProductVersion;
            lblWebsite.Content = finfo.Comments;
            lblAllRights.Content = finfo.LegalCopyright;
        }
    }
}
