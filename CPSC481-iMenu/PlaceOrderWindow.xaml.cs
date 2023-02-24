﻿using System;
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

        private void Confirmation_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            //if the checkbox is checked, show the place order button and make it clickable
            Place_Order_Button.Opacity = 1;
            Place_Order_Button.IsEnabled= true;

            //Place_Order_Button.Enabl

        }

        private void Place_Order_Button_Click(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            btn.Background = btn.Background == Brushes.LightGreen ? new BrushConverter().ConvertFrom("#FFDDDDDD") as SolidColorBrush : Brushes.LightGreen;
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/e5420458-8b16-4d2e-819c-b23ed8d56b29/how-do-i-change-the-background-color-of-a-button-in-wpf-on-a-mouse-click-?forum=wpf

            Place_Order_Button.IsEnabled= false;
            Place_Order_Label.Content = "Order Placed!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
