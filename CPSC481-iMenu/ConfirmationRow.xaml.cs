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
        public static readonly DependencyProperty TimestampProperty = DependencyProperty.Register(
            nameof(Timestamp),
            typeof(long),
            typeof(ConfirmationRow));

        public long Timestamp
        {
            get { return (long)GetValue(TimestampProperty); }
            set { SetValue(TimestampProperty, value); }
        }

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
            nameof(Id),
            typeof(int),
            typeof(ConfirmationRow));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty QuantityProperty = DependencyProperty.Register(
            nameof(Quantity),
            typeof(long),
            typeof(ConfirmationRow));

        public long Quantity
        {
            get { return (long)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        public string Title
        {
            get { return Items.Data[Id].name; }
        }

        public string ImagePath
        {
            get { return Items.Data[Id].imageName; }
        }

        public float Cost
        {
            get { return Items.Data[Id].cost; }
        }

        public string QuantityString
        {
            get { return String.Format("${0:0.00}*{1}=", Cost, Quantity); }
        }

        public string TotalCostString
        {
            get { return String.Format("${0:0.00}", Cost * Quantity); }
        }


        public ConfirmationRow()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Items.Store.Remove(Items.Store.First(x => x.timestamp == Timestamp));
        }
    }
}
