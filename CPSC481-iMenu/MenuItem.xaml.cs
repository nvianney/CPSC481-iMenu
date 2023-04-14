using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using static CPSC481_iMenu.Items;

namespace CPSC481_iMenu
{
    /// <summary>
    /// Interaction logic for MenuItem.xaml
    /// </summary>
    public partial class MenuItem : UserControl
    {

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
                   nameof(Id),
                   typeof(int),
                   typeof(MenuItem));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(MenuItem));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
            nameof(Description),
            typeof(string),
            typeof(MenuItem));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty CostProperty = DependencyProperty.Register(
            nameof(Cost),
            typeof(float),
            typeof(MenuItem));

        public float Cost
        {
            get { return (float)GetValue(CostProperty); }
            set { SetValue(CostProperty, value); }
        }

        public string CostString
        {
            get { return String.Format("${0:0.00}", Cost); }
        }

        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register(
            nameof(ImagePath),
            typeof(string),
            typeof(MenuItem));

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }


        public MenuItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Items.Store.ToList().FindIndex((elem) => elem.itemId == Id);

            if (index != -1)
            {
                List<AddedItem> items = Items.Store.ToList().ConvertAll((item) =>
                {
                    if (item.itemId == Id)
                    {
                        item.quantity += 1;
                    }
                    return item;
                });

                Items.Store.Clear();
                items.ForEach(item => Items.Store.Add(item));
            }
            else
            {
                Items.Store.Add(
                    new Items.AddedItem()
                    {
                        itemId = Id,
                        quantity = 1,
                    }
                );
            }
        }

        private void Expand_Button_Click(object sender, RoutedEventArgs e)
        {
            ItemWindow itemWindow = new ItemWindow(Id, false, ImagePath);
            itemWindow.Owner = Window.GetWindow(this);
            itemWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner; 
            itemWindow.Show();
        }
    }
}
