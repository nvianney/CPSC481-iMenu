using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CPSC481_iMenu
{
    /// <summary>
    /// Interaction logic for PlaceOrderWindow.xaml
    /// </summary>
    public partial class PlaceOrderWindow : Page
    {
        bool isCallServerPressed = false;

        public PlaceOrderWindow()
        {
            InitializeComponent();
        }

        private void Call_Server_Button_Click(object sender, RoutedEventArgs e)
        {
            //check if the button was pressed or not
            bool press = IsButtonPressed(isCallServerPressed);
            Button? btn = sender as Button;
            btn.Background = btn.Background == Brushes.LightGreen ? new BrushConverter().ConvertFrom("#FFDDDDDD") as SolidColorBrush : Brushes.LightGreen;
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/e5420458-8b16-4d2e-819c-b23ed8d56b29/how-do-i-change-the-background-color-of-a-button-in-wpf-on-a-mouse-click-?forum=wpf

            //if (press)
            //    Call_Server_Label.Content = "Server is coming to Help, Please Wait!";
            ////Server is coming to Help, Please Wait!
            //else
            //    Call_Server_Label.Content = "Opps";
        }

        private bool IsButtonPressed(bool button_given)
        {
            if (button_given) //button is already pressed, change the state of the button
            {
                this.isCallServerPressed = false;
                return false;
            }
            this.isCallServerPressed = true;
            return true;
        }

        private void Go_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //Close this "Order Confirmation" Window
            //this.Close();

            //Go back to "Main Window"
            //MainWindow.Show();
            


        }

        private void Confirmation_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            //if the checkbox is checked, show the place order button and make it clickable
            //Place_Order_Button.Opacity = 1;
            //Place_Order_Button.IsEnabled= true;

            //Place_Order_Button.Enabl

        }

        private void Place_Order_Button_Click(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            btn.Background = btn.Background == Brushes.LightGreen ? new BrushConverter().ConvertFrom("#FFDDDDDD") as SolidColorBrush : Brushes.LightGreen;
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/e5420458-8b16-4d2e-819c-b23ed8d56b29/how-do-i-change-the-background-color-of-a-button-in-wpf-on-a-mouse-click-?forum=wpf

            //Place_Order_Button.IsEnabled= false;
            //Place_Order_Label.Content = "Order Placed!";
            ShowInformation("Your order has been placed!", "Order Placed Confirmation");
        }

  
        private void Increase_Quantity(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            String buttonName = btn.Name;
            Char buttonIndex = buttonName.Last();
            //gets the last character of the button name (which should be an integer)
            //can be used to update the label

            String labelName = "Food_Item_Quantity" + buttonIndex;
            //Label Name contains the lable of the quantity to be updated

           
            //get the current quantity
            //String old = Quantity.Text;
            //int oldint = (int)Convert.ToSingle(old);
            //oldint++;
            //Quantity.Text = (String)oldint.ToString();



            //Increase the quantity by 1

            //update the lable to represent the updated quantity
            //Call_Server_Label.Content = labelName;

            //UPdate the total cost

        }

        private void Decrease_Quantity(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            String buttonName = btn.Name;
            Char buttonIndex = buttonName.Last();
            //gets the last character of the button name (which should be an integer)
            //can be used to update the label

            String labelName = "Food_Item_Quantity" + buttonIndex;
            //Label Name contains the lable of the quantity to be updated

            //get the current quantity   
            
            //Decrease the quantity by 1

            //update the lable to represent the updated quantity
            //Call_Server_Label.Content = labelName;

            //update the total cost


        }

        private void Remove_Item_1_Click(object sender, RoutedEventArgs e)
        {
            ShowMessage("You are about to delete the item from the order", "Delete Confirmation");
            //calling another method to display the remove item confirmation.         
        }

        private void ShowMessage(string msg, string WindowTitle)
        {
            //https://www.tutorialspoint.com/wpf/wpf_dialog_box.htm
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxResult result = MessageBox.Show(msg, WindowTitle, button);          
        }
        private void ShowInformation(string msg, string WindowTitle)
        {
            //https://www.tutorialspoint.com/wpf/wpf_dialog_box.htm
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(msg, WindowTitle, button);          
        }

        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
