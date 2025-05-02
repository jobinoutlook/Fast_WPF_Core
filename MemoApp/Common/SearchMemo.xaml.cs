using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for TestMemo.xaml
    /// </summary>
    public partial class SearchMemo : Window
    {
        public SearchMemo()
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

        private void richTextBoxMemo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lblCharCount != null)
            {
                TextRange trRichtxtbox = new TextRange(this.richTextBoxMemo.Document.ContentStart, this.richTextBoxMemo.Document.ContentEnd);
                lblCharCount.Content = trRichtxtbox.Text.ReplaceLineEndings("").Length.ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int last_id = MemoApp.Properties.Settings.Default.last_id;

            string title_fn;
            string file_content;
            
            for (int id = 1; id < last_id + 1; id++)
            {
                ListBoxItem lbxItem = new ListBoxItem();
                lbxItem.Tag = id;
                title_fn = Environment.CurrentDirectory + "\\Data\\Docs\\" + id.ToString() + "_title" + ".dll";

                if (System.IO.File.Exists(title_fn))
                {
                    file_content=System.IO.File.ReadAllText(title_fn,Encoding.UTF8);
                    lbxItem.Content = file_content;
                    this.lbxSearchTitle.Items.Add(lbxItem);   
                }
                
                
            }
        }

       

        private void lbxTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lbxSearchTitle.SelectedIndex;

            if (index == -1) return;

            ListBoxItem li = new ListBoxItem();
            li = (ListBoxItem)lbxSearchTitle.Items[index];

            int sel_id = (int)li.Tag;
            string sel_title = (string)li.Content;

            txtMemoID.Text = sel_id.ToString();
            txtMemoTitle.Text = sel_title;

            string date_fn = Environment.CurrentDirectory + "\\Data\\Docs\\" + sel_id.ToString() + "_date" + ".dll";
            if (System.IO.File.Exists(date_fn))
            {
                datePicker.Text = System.IO.File.ReadAllText(date_fn, Encoding.UTF8);

            }
            //---------------------------
            string rtf_fn = Environment.CurrentDirectory + "\\Data\\Docs\\" + sel_id.ToString() + "_r" + ".dll";
            richTextBoxMemo.Document.Blocks.Clear();
            if (System.IO.File.Exists(rtf_fn))
            {
                TextRange tr = new TextRange(this.richTextBoxMemo.Document.ContentStart, this.richTextBoxMemo.Document.ContentEnd);
                System.IO.FileStream fs = new System.IO.FileStream(rtf_fn, System.IO.FileMode.OpenOrCreate);
                //-----
                tr.Load(fs, DataFormats.Rtf);
                fs.Dispose();
            }
            //---------------------------------------------------------------------
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            foreach (ListBoxItem item in lbxSearchTitle.Items)
            {
                item.Background = System.Windows.Media.Brushes.White;

                if (chkTitle.IsChecked == true)
                {
                    if (item.Content.ToString().Contains(txtSearchTitle.Text))
                    { 
                        item.Background = System.Windows.Media.Brushes.Yellow;
                    }
                }
                else
                {
                    if(item.Content.ToString() == txtSearchTitle.Text)
                    {
                        item.Background = System.Windows.Media.Brushes.Yellow;
                    }

                }
            }
        }
    }
}
