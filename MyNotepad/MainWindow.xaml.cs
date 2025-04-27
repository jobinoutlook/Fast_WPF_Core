using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

       

        private void Addmenu_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
        }

        private void Exitmenu_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Saveasmenu_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sf = new Microsoft.Win32.SaveFileDialog();
            sf.Title = "Save data in text file";
            sf.Filter = "Text files|*.txt";
            sf.AddExtension = true;
            bool? sf_status = sf.ShowDialog();
            if (sf_status!=null && sf_status == true) 
            {
                System.IO.File.WriteAllText(sf.FileName, textBox.Text, Encoding.UTF8);
            }
        }




        private void Openmenu_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Title = "Read data from text file";
            openFileDialog.Filter = "Text files|*.txt";

            openFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                string content = System.IO.File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
                textBox.Text = content;
            
            }
            
        }

        private void mnuUndo_Click(object sender, RoutedEventArgs e)
        {
            textBox.Undo();
        }

        private void mnuRedo_Click(object sender, RoutedEventArgs e)
        {
            textBox.Redo();
        }

        private void mnuCopy_Click(object sender, RoutedEventArgs e)
        {
            textBox.Copy();
        }

        private void mnuCut_Click(object sender, RoutedEventArgs e)
        {
            textBox.Cut();
        }

        private void mnuPaste_Click(object sender, RoutedEventArgs e)
        {
            textBox.Paste();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            textBox.SelectAll();
        }

        //View
        private void wordwrap_Click(object sender, RoutedEventArgs e)
        {
            if(wordwrap.IsChecked)
            {
                textBox.TextWrapping = TextWrapping.Wrap;
                textBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
            else
            {
                textBox.TextWrapping = TextWrapping.NoWrap;
                textBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
        }

        private void mnuZoomout_Click(object sender, RoutedEventArgs e)
        {
            double fontSize = textBox.FontSize;
            if (fontSize > 8)
                textBox.FontSize = fontSize - 4;
        }

        private void mnuZoomin_Click(object sender, RoutedEventArgs e)
        {
            double fontSize = textBox.FontSize;
            if (fontSize < 100)
                textBox.FontSize = fontSize + 4;
        }

        private void mnuDefaultZoom_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontSize = 18;
        }

        
       

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            MyNotepad.AboutUs aboutUs = new MyNotepad.AboutUs();
            aboutUs.ShowDialog();
        }

        private void Editmenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Editmenu_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}