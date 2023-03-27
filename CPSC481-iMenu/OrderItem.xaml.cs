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
    /// Interaction logic for OrderItem.xaml
    /// </summary>
    public partial class OrderItem : UserControl
    {

        public static readonly DependencyProperty TimestampProperty = DependencyProperty.Register(
            nameof(Timestamp),
            typeof(long),
            typeof(OrderItem));

        public long Timestamp
        {
            get { return (long)GetValue(TimestampProperty); }
            set { SetValue(TimestampProperty, value); }
        }

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
            nameof(Id),
            typeof(int),
            typeof(OrderItem));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty QuantityProperty = DependencyProperty.Register(
            nameof(Quantity),
            typeof(long),
            typeof(OrderItem));

        public long Quantity
        {
            get { return (long)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        public String Title
        {
            get { return Items.Data[Id].name; }
        }

        public string ImagePath
        {
            get { return Items.Data[Id].imageName; }
        }

        public string Cost
        {
            get { return String.Format("${0:0.00}", Items.Data[Id].cost); }
        }

        public int quantity = 1;


        public OrderItem()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Items.Store.Remove(Items.Store.First(x => x.timestamp == Timestamp));
        }
    }
}
