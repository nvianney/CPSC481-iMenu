using System;
using System.Collections;
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
    /// Interaction logic for DietaryRestrictionsWindow.xaml
    /// </summary>
    public partial class DietaryRestrictionsWindow : Window
    {
        public DietaryRestrictionsWindow()
        {
            InitializeComponent();

            //Fill list with dietary restrictions
            DietaryRestrictionsListView.ItemsSource = Enum.GetValues(typeof(DietaryRestrictions));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Use those selected restrictions to filter the menu later
            IList selectedDietaryRestrictions = DietaryRestrictionsListView.SelectedItems;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
               
            this.Close();
        }
    }
}
