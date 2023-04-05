using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public string TotalCostStr
        {
            get { return String.Format("Total: ${0:0.00}", Items.Store.Sum((item) => item.quantity * Items.Data[item.itemId].cost)); }
        }

        public PlaceOrderWindow()
        {
            InitializeComponent();

            //orderList.ItemsSource = Items.Store.ToList().ConvertAll(x => Items.Data[x.itemId]);
            orderList.ItemsSource = Items.Store.ToList();

            Items.Store.CollectionChanged += StoreChanged;
        }

        private void StoreChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Update");
            orderList.ItemsSource = Items.Store.ToList();
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

            call_server_canvas.Visibility = Visibility.Visible;

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

            this.Close();


        }

        private void Confirmation_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            //if the checkbox is checked, show the place order button and make it clickable
            btn_order.Opacity = 1;
            btn_order.IsEnabled= true;

            //Place_Order_Button.Enabl

        }

        private void Place_Order_Button_Click(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            btn.Background = btn.Background == Brushes.LightGreen ? new BrushConverter().ConvertFrom("#FFDDDDDD") as SolidColorBrush : Brushes.LightGreen;
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/e5420458-8b16-4d2e-819c-b23ed8d56b29/how-do-i-change-the-background-color-of-a-button-in-wpf-on-a-mouse-click-?forum=wpf

            //Place_Order_Button.IsEnabled= false;
            //Place_Order_Label.Content = "Order Placed!";
            //ShowInformation("Your order has been placed!", "Order Placed Confirmation");

            place_order_canvas.Visibility= Visibility.Visible;
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


        private void call_server_close_Click(object sender, RoutedEventArgs e)
        {
            //close the dialog
            call_server_canvas.Visibility = Visibility.Collapsed;
        }

        private void call_server_cancel_button_Click(object sender, RoutedEventArgs e)
        {
            call_server_canvas.Visibility = Visibility.Collapsed;
        }

        private void place_order_canvas_close_Click(object sender, RoutedEventArgs e)
        {
            place_order_canvas.Visibility = Visibility.Collapsed;
        }

        private void btn_trackOrder_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            //find Main Window (for this project it is set to DietryRestrictionScreen as that is opened first
            //make the order tracker visible
            //Track_Order_Result_Popup
            MainWindow menuWindow;
            foreach (Window window in Application.Current.Windows)
            {
                if(window.Title.Equals("Menu Window"))
                {
                    menuWindow = (MainWindow)window;
                    menuWindow.Track_Order_Result_Popup.Visibility = Visibility.Visible;
                    this.Close();
                    break;
                }
            }
           



        }
    }
}
