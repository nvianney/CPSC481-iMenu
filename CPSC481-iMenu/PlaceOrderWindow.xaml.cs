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

namespace CPSC481_iMenu
{
    /// <summary>
    /// Interaction logic for PlaceOrderWindow.xaml
    /// </summary>
    public partial class PlaceOrderWindow : Window
    {
        bool isCallServerPressed = false;
        readonly Window MainWindow;
        public PlaceOrderWindow(MainWindow mainWindow_given)
        {
            InitializeComponent();
            MainWindow = mainWindow_given;
        }

        private void Call_Server_Button_Click(object sender, RoutedEventArgs e)
        {
            //check if the button was pressed or not
            bool press = IsButtonPressed(isCallServerPressed);
            Button? btn = sender as Button;
            btn.Background = btn.Background == Brushes.LightGreen ? new BrushConverter().ConvertFrom("#FFDDDDDD") as SolidColorBrush : Brushes.LightGreen;
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/e5420458-8b16-4d2e-819c-b23ed8d56b29/how-do-i-change-the-background-color-of-a-button-in-wpf-on-a-mouse-click-?forum=wpf

            if (press)
                Call_Server_Label.Content = "Server is coming to Help, Please Wait!";
            //Server is coming to Help, Please Wait!
            else
                Call_Server_Label.Content = "Opps";
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
            this.Close();

            //Go back to "Main Window"
            MainWindow.Show();
            


        }
    }
}
