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
    /// Interaction logic for TeleportCommandGen.xaml
    /// </summary>
    public partial class TeleportCommandGen : Window
    {
        public Boolean isMessageChecked;
        public Boolean isInteriorChecked;

        int MessageEntered = 1;
        int InteriorEntered = 1;
        public TeleportCommandGen()
        {
            InitializeComponent();
        }

        private void rbInteriorYes_Checked(object sender, RoutedEventArgs e)
        {
            label5.Visibility = System.Windows.Visibility.Visible;
            txtInterior.Visibility = System.Windows.Visibility.Visible;

        }

        private void rbInteriorNo_Checked(object sender, RoutedEventArgs e)
        {
            txtInterior.Text = "";
            InteriorEntered = 0;
            label5.Visibility = System.Windows.Visibility.Hidden;
            txtInterior.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label5.Visibility = System.Windows.Visibility.Hidden;
            txtInterior.Visibility = System.Windows.Visibility.Hidden;

            label7.Visibility = System.Windows.Visibility.Hidden;
            txtMessage.Visibility = System.Windows.Visibility.Hidden;

            lblMessageColor.Visibility = System.Windows.Visibility.Hidden;
            cbxMessageColor.Visibility = System.Windows.Visibility.Hidden;


        }

        private void rbMessageYes_Checked(object sender, RoutedEventArgs e)
        {
            label7.Visibility = System.Windows.Visibility.Visible;
            txtMessage.Visibility = System.Windows.Visibility.Visible;

            lblMessageColor.Visibility = System.Windows.Visibility.Visible;
            cbxMessageColor.Visibility = System.Windows.Visibility.Visible;
        }

        private void rbMessageNo_Checked(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            MessageEntered = 0;
            cbxMessageColor.SelectedIndex = -1;
            label7.Visibility = System.Windows.Visibility.Hidden;
            txtMessage.Visibility = System.Windows.Visibility.Hidden;


            lblMessageColor.Visibility = System.Windows.Visibility.Hidden;
            cbxMessageColor.Visibility = System.Windows.Visibility.Hidden;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            txtXValue.Text = "";
            txtYValue.Text = "";
            txtZValue.Text = "";
            txtAValue.Text = "";
            rbInteriorNo.IsChecked = true;
            rbMessageNo.IsChecked = true;
            txtCommandName.Text = "";
            txtXValue.Focus();



        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
           
            string Message = "";
            string PlayerPos = "";
            string FacingAngle = "";
            string SetInterior = "";
            string color = "";
            string command = txtCommandName.Text;

            if ((txtXValue.Text == "") || (txtYValue.Text == "") || (txtZValue.Text == "") || (txtAValue.Text == "") || (txtCommandName.Text == ""))
            {
                System.Windows.MessageBox.Show("You missed required fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtXValue.Focus();
            }
            else
            { 
                double nX, nY, nZ, nA;
                bool isNumericX = Double.TryParse(txtXValue.Text, out nX);
                bool isNumericY = Double.TryParse(txtYValue.Text, out nY);
                bool isNumericZ = Double.TryParse(txtZValue.Text, out nZ);
                bool isNumericA = Double.TryParse(txtAValue.Text, out nA);

                if ((isNumericX == false) || (isNumericY == false) || (isNumericZ == false) || (isNumericA == false))
                {
                    System.Windows.MessageBox.Show("Sorry, but you can only enter numerical values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    
                    PlayerPos = "SetPlayerPos(playerid, " + txtXValue.Text + "," + txtYValue.Text + "," + txtZValue.Text + ");";
                    FacingAngle = "SetPlayerFacingAngle(playerid, " + txtAValue.Text + ");";
                    if (rbInteriorYes.IsChecked == true)
                    {
                        if (txtInterior.Text == "")
                        {
                            InteriorEntered = 0;
                            System.Windows.MessageBox.Show("You have to enter a interior ID", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            InteriorEntered = 1;
                            SetInterior = "SetPlayerInterior(playerid, " + txtInterior.Text + ");";
                        }
                        

                    }
                    if (rbMessageYes.IsChecked == true)
                   
                        if ((cbxMessageColor.SelectedIndex == -1) || (txtMessage.Text == ""))
                        {
                            MessageEntered = 0;
                            System.Windows.MessageBox.Show("You have to select a message color", "ERROR",MessageBoxButton.OK,MessageBoxImage.Error);
                        } 
                        else
                        {
                            MessageEntered = 1;
                            string combobox = ((ComboBoxItem)cbxMessageColor.SelectedItem).Content.ToString();

                            if (combobox == "Green")
                            {
                                 color = "0xFF49E441";
                            }
                            if (combobox == "Blue")
                            {
                                 color = "0xFF369ECF";
                            }

                            Message = "SendClientMessage(playerid, " + color + ",\"" + txtMessage.Text + "\");";
                        }
                       
                    }
                if ((MessageEntered == 1) && (InteriorEntered == 1))
                {
                        GeneratedCode genCode = new GeneratedCode(Message, PlayerPos, FacingAngle, SetInterior, color, command);
                        genCode.Show();
                }
                   


                }
            }

        }
    }
