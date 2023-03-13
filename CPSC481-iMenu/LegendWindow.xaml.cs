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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CPSC481_iMenu
{
    /// <summary>
    /// Interaction logic for LegendWindow.xaml
    /// </summary>
    public partial class LegendWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            //https://www.tutorialspoint.com/wpf/wpf_dialog_box.htm
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show("Legend Window Close?", "Legend Window Close?", button);

            if (result == MessageBoxResult.Yes) { this.Close(); }
           

         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
