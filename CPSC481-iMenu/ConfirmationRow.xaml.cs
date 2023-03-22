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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC481_iMenu
{
    /// <summary>
    /// Interaction logic for ConfirmationRow.xaml
    /// </summary>
    public partial class ConfirmationRow : UserControl
    {
        public ConfirmationRow()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            if(ShowMessage("You are about to delete the item from the order", "Delete Confirmation"))
            {
                //calling another method to display the remove item confirmation.
                RemoveFoodItem();

                var mainWindow = Application.Current.Windows
           .Cast<Window>()
           .FirstOrDefault(window => window is PlaceOrderWindow) as PlaceOrderWindow;


            }

        }

        private Boolean ShowMessage(string msg, string WindowTitle)
        {
            //https://www.tutorialspoint.com/wpf/wpf_dialog_box.htm
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxResult result = MessageBox.Show(msg, WindowTitle, button);
            if (result == MessageBoxResult.Yes) { return true; }
            return false;
        }

        private void RemoveFoodItem()
        {
            var mainWindow = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is PlaceOrderWindow) as PlaceOrderWindow;

            if (mainWindow != null)
            {
                mainWindow.FoodItem1.Visibility = Visibility.Collapsed;
            }
        }

    }
}
