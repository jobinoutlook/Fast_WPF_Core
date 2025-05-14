using Advanced_WPF.EF.Models;
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

namespace Advanced_WPF.EF
{
    /// <summary>
    /// Interaction logic for WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        public WorkersWindow()
        {
            InitializeComponent();
        }

        MyCompanyContext dbContext = new MyCompanyContext();

        private void Window_Initialized(object sender, EventArgs e)
        {
            List<Worker> result = dbContext.Workers.ToList();
            this.workers_dataGrid.ItemsSource = result;

            Save_Cancel_btn();

            workers_dataGrid.SelectedIndex=workers_dataGrid.Items.Count-1;
            //auto-adjust scrollbar
            //workers_dataGrid.UpdateLayout();
            workers_dataGrid.ScrollIntoView(this.workers_dataGrid.SelectedItem);

        }

        void Save_Cancel_btn()
        {
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            //-----------------------------
            btnAddNew.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnEdit.IsEnabled = true;
            //---------
            workers_dataGrid.IsEnabled = true;
        }

        void New_Edit_Del_btn()
        {
            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            //-----------------------------
            btnAddNew.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnEdit.IsEnabled = false;
            //---------
            workers_dataGrid.IsEnabled = false ;    
        }

        private void workers_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fill_Textboxes();
        }

        void Fill_Textboxes()
        {
            try
            {
                Worker worker = (Worker)workers_dataGrid.SelectedItem;
                if (worker != null)
                {
                    txt_Id.Text = worker.Id.ToString();
                    txt_Fname.Text = worker.Fname;
                    txt_LastName.Text = worker.Lname;
                    txt_Mobile.Text = worker.Mobile;
                    txt_Income.Text = worker.Income.ToString();
                    datePicker.Text = worker.Dob.ToString();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            New_Edit_Del_btn();
        }

       
        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            New_Edit_Del_btn();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            New_Edit_Del_btn();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save_Cancel_btn();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Save_Cancel_btn();
        }
    }
}
