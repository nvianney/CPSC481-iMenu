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
        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
            nameof(Id),
            typeof(int),
            typeof(OrderItem));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(OrderItem));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register(
            nameof(ImagePath),
            typeof(string),
            typeof(OrderItem));

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public static readonly DependencyProperty CostProperty = DependencyProperty.Register(
            nameof(Cost),
            typeof(string),
            typeof(OrderItem));

        public string Cost
        {
            get { return (string)GetValue(CostProperty); }
            set { SetValue(CostProperty, value); }
        }


        public OrderItem()
        {
            InitializeComponent();
        }
    }
}
