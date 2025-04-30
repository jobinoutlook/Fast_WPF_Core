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

namespace MemoApp.Common
{
    /// <summary>
    /// Interaction logic for MemoWindow.xaml
    /// </summary>
    public partial class MemoWindow : Window
    {
        public MemoWindow()
        {
            InitializeComponent();
        }

        

        private void btnLeftAlign_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.AlignLeft.Execute(null, this.richTextBoxMemo);
        }

        private void btnCenterAlign_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.AlignCenter.Execute(null, this.richTextBoxMemo);
        }

        private void btnRightAlign_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.AlignRight.Execute(null, this.richTextBoxMemo);
        }

        private void btnIncreaseIndent_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.IncreaseIndentation.Execute(null, this.richTextBoxMemo);
        }

        private void btnDecreaseIndent_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.DecreaseIndentation.Execute(null, this.richTextBoxMemo);
        }

        private void btnBold_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.ToggleBold.Execute(null, this.richTextBoxMemo);
        }

        private void btnItalic_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.ToggleItalic.Execute(null, this.richTextBoxMemo);
        }

        private void btnUnderline_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.ToggleUnderline.Execute(null, this.richTextBoxMemo);
        }

        private void btnIncreaseFont_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.IncreaseFontSize.Execute(null, this.richTextBoxMemo);
        }

        private void btnDecreaseFont_Click(object sender, RoutedEventArgs e)
        {
            EditingCommands.DecreaseFontSize.Execute(null, this.richTextBoxMemo);
        }

        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
            richTextBoxMemo.Cut();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            richTextBoxMemo.Copy();
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            richTextBoxMemo.Paste();
        }

        private void btUndo_Click(object sender, RoutedEventArgs e)
        {
            richTextBoxMemo.Undo();
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            richTextBoxMemo.Redo();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.groupBox.IsEnabled = false;
            this.btnSave.IsEnabled = false;
        }

        

        private void btnNewMemo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.groupBox.IsEnabled = true;
                this.btnSave.IsEnabled = true;
                //--------------------
                this.btnNewMemo.IsEnabled = false;
                //---------------------
                this.txtMemoTitle.Text = "";
                this.datePicker.SelectedDate = DateTime.Now;
                this.richTextBoxMemo.Document.Blocks.Clear();
                //---------------------
                int last_id;
                last_id = MemoApp.Properties.Settings.Default.last_id;
                this.txtMemoID.Text = (last_id + 1).ToString();
                //--------------
                this.txtMemoTitle.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //--------------------------------
                if (this.txtMemoTitle.Text == "")
                {
                    MessageBox.Show("Enter the title!");
                    return;
                }
                if (this.datePicker.Text == "")
                {
                    MessageBox.Show("Enter the date!");
                    return;
                }
                //---------
                //--------------------------------
                this.groupBox.IsEnabled = false;
                this.btnSave.IsEnabled = false;
                //--------------------
                this.btnNewMemo.IsEnabled = true;
                //-----------save last id in settings----------
                int last_id;
                last_id = MemoApp.Properties.Settings.Default.last_id;
                last_id = last_id + 1;
                MemoApp.Properties.Settings.Default.last_id = last_id;
                MemoApp.Properties.Settings.Default.Save();
                //----------------save title,date and rtf------------------------------
                string title_fn;
                string date_fn;
                string rtf_fn;
                if(!System.IO.Directory.Exists(Environment.CurrentDirectory + "\\Data\\Docs\\"))
                {
                    System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "\\Data\\Docs\\");
                }
                title_fn = Environment.CurrentDirectory + "\\Data\\Docs\\" + last_id.ToString() + "_title" + ".dll";
                date_fn = Environment.CurrentDirectory + "\\Data\\Docs\\" + last_id.ToString() + "_date" + ".dll";
                rtf_fn = Environment.CurrentDirectory + "\\Data\\Docs\\" + last_id.ToString() + "_r" + ".dll";
                //--------------save data------
                System.IO.File.WriteAllText(title_fn, this.txtMemoTitle.Text, Encoding.UTF8);
                System.IO.File.WriteAllText(date_fn, this.datePicker.Text, Encoding.UTF8);
                //---------------------------------------------------------------------
                TextRange tr = new TextRange(this.richTextBoxMemo.Document.ContentStart, this.richTextBoxMemo.Document.ContentEnd);
                System.IO.FileStream fs = new System.IO.FileStream(rtf_fn, System.IO.FileMode.OpenOrCreate);
                //-----
                tr.Save(fs, DataFormats.Rtf);
                fs.Dispose();
                //---------------------------------------------
                MessageBox.Show("Saved!");
                this.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.F2)//add memo
                {
                    if (this.btnNewMemo.IsEnabled == true)
                    {
                        btnNewMemo_Click(sender, e);
                    }

                }
                //---------------------
                //---------------------
                if (e.Key == Key.F5)//save
                {
                    if (this.btnSave.IsEnabled == true)
                    {
                        btnSave_Click(sender, e);
                    }
                }
                //---------------------
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
