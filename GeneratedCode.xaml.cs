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
    /// Interaction logic for GeneratedCode.xaml
    /// </summary>
    public partial class GeneratedCode : Window
    {
        string Message = "";
        string PlayerPos = "";
        string FacingAngle = "";
        string SetInterior = "";
        string color = "";
        string command = "";
        public GeneratedCode(String _Message, String _PlayerPos, String _FacingAngle, String _SetInterior, String _Color, String _Command)
        {
            InitializeComponent();
            Message = _Message;
            PlayerPos = _PlayerPos;
            FacingAngle = _FacingAngle;
            SetInterior = _SetInterior;
            color = _Color;
            command = _Command;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            richTextBox.AppendText("CMD:" + command + "(playerid, params[])\n{\n\t" + PlayerPos + "\n\t" + FacingAngle + "\n\t" + SetInterior + "\n\t" + Message + "\n\treturn 1;\n}" + System.Environment.NewLine);
            
            
        }
    }
}
