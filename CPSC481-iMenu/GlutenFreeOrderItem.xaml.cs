using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC481_iMenu
{
    /// <summary>
    /// Interaction logic for OrderItem.xaml
    /// </summary>
    public partial class GlutenFreeOrderItem : UserControl
    {
        public GlutenFreeOrderItem()
        {
            InitializeComponent();
        }

        private void Button_Click_Add_Quantity(object sender, RoutedEventArgs e)
        {
            //Ref: https://www.tutorialspoint.com/Chash-Program-to-Convert-Integer-to-String#:~:text=To%20convert%20an%20integer%20to,use%20the%20ToString()%20method
            //Ref: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number

            String curr_quantity_string = Quantity.Text;
            int curr_quantity_interger = Int32.Parse(curr_quantity_string);
            int updated_quantity_int = curr_quantity_interger + 1;
            String updated_quantity_string = updated_quantity_int.ToString();
            Quantity.Text = updated_quantity_string;


        }

        private void Button_Click_Decrease_Quantity(object sender, RoutedEventArgs e)
        {
            //Ref: https://www.tutorialspoint.com/Chash-Program-to-Convert-Integer-to-String#:~:text=To%20convert%20an%20integer%20to,use%20the%20ToString()%20method
            //Ref: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number

            String curr_quantity_string = Quantity.Text;
            int curr_quantity_interger = Int32.Parse(curr_quantity_string);
            int updated_quantity_int = curr_quantity_interger - 1;
            String updated_quantity_string = updated_quantity_int.ToString();
            Quantity.Text = updated_quantity_string;

            //incase the value is equal to 0, remove the food item.
            Boolean removeItem = false;
            if (updated_quantity_int <= 0)
            {
                //Item will be removed
                removeItem = ShowMessage("You are about to delete the item from the order", "Delete Confirmation");
                Quantity.Text = "1";
            }
            if(removeItem)
            {
                //remove the food item
                RemoveFoodItem();
                
            }
        }

        private Boolean ShowMessage(string msg, string WindowTitle)
        {
            //https://www.tutorialspoint.com/wpf/wpf_dialog_box.htm
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxResult result = MessageBox.Show(msg, WindowTitle, button);
            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            return false;
        }

        private void RemoveFoodItem()
        {
            var mainWindow = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is MainWindow) as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.Your_Order_GlutenFree_Item.Visibility = Visibility.Collapsed;
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            //if (ShowMessage("You are about to delete the item from the order", "Delete Confirmation"))
            {
                //RemoveFoodItem();
            }

            Show_delete_canvas();
          

        }
        private void Show_delete_canvas()
        {
            var mainWindow = Application.Current.Windows
          .Cast<Window>()
          .FirstOrDefault(window => window is MainWindow) as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.delete_confirmation_canvas.Visibility = Visibility.Visible;
                
            }
        }

    }
}
