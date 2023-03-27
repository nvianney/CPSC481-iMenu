using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            menuList.ItemsSource = Items.Data;

            // O(n^2). Also bad code
            Items.Store.CollectionChanged += StoreChanged;
        }

        private void StoreChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Update");
            orderList.ItemsSource = Items.Store.ToList().ConvertAll(x => Items.Data[x]);
        }

        public void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrderWindow window = new PlaceOrderWindow();
            window.Show();
        }
    }
}
