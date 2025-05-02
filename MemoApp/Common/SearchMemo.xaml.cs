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
           
        }
    }
}
