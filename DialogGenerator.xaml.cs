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

namespace SAMPDev
{
    /// <summary>
    /// Interaction logic for DialogGenerator.xaml
    /// </summary>
    public partial class DialogGenerator : Window
    {
        public DialogGenerator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cbxDialogType.SelectedIndex = -1;
            txtTitle.Text = "";
            rtbTextContent.Document.Blocks.Clear();
            txtButton1.Text = "";
            txtButton2.Text = "";
            txtPlayerid.Text = "";
            txtDialogID.Text = "";
            rtbCodeResult.Document.Blocks.Clear();


        }

        private void rtbCodeResult_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtButton1.Text = "Ok";
            txtButton2.Text = "Cancel";
            txtPlayerid.Text = "playerid";
            txtDialogID.Text = "0";
          //  TextRange textRange = new TextRange(rtbTextContent.Document.ContentStart, rtbTextContent.Document.ContentEnd);
          //  rtbTextContent.AppendText("\\n");
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            rtbCodeResult.Document.Blocks.Clear();
            TextRange textRange = new TextRange(rtbTextContent.Document.ContentStart, rtbTextContent.Document.ContentEnd);
            string combobox = ((ComboBoxItem)cbxDialogType.SelectedItem).Content.ToString();
            String Result = "ShowPlayerDialog(" + txtPlayerid.Text + "," + txtDialogID.Text + "," + combobox + ",\"" + txtTitle.Text + "\",\"" + textRange.Text + "\",\"" + txtButton1.Text + "\",\"" + txtButton2.Text + "\");";
            pnlResult.IsEnabled = true;
            rtbCodeResult.AppendText(Result);
            Clipboard.SetText(Result);
            System.Windows.MessageBox.Show("Your Dialog has been copied to your clipboard\nUse CTRL + V to paste where ever you want", "Info", MessageBoxButton.OK, MessageBoxImage.Information);  

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rtbTextContent.Document.Blocks.Clear();
            rtbCodeResult.Document.Blocks.Clear();
            cbxDialogType.SelectedIndex = 0;
        }

        private void btnAddItemLine_MouseDown(object sender, MouseButtonEventArgs e)
        {

          
        }

        private void pnlResult_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("To actually generate this dialog you must know what each of the parameters mean : \n\nPlayer ID : This parameter consists of the playerid where the dialog will popup\nDialog ID : This parameter is where you assign the dialog to a unique number\nDialog Style : This is where they assign what the dialog must do, it can ask the user for a input or it can display a normal message\nDialog Title : This is where you place the text of what the dialog's title (header) is\nDialog Content : This is where the main message is displayed to the user");

        }

        private void btnAddItemLine_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtbTextContent.Document.ContentStart, rtbTextContent.Document.ContentEnd);
            rtbTextContent.AppendText("\\n");
        }
    }
}
