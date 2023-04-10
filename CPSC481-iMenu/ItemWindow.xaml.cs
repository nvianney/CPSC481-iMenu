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
using System.Windows.Shapes;
using static CPSC481_iMenu.Items;

namespace CPSC481_iMenu
{
    /// <summary>
    /// Interaction logic for ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {
        private int id;
        private bool isEdit;
        public ItemWindow(int Id, bool isEdit, string ImagePath, long Quantity=0, string TotalCostString = "0")
        {
            InitializeComponent();

            this.id = Id;
            this.isEdit = isEdit;

            DishModel dish = Items.Data[Id];
            ItemTitle.Text = dish.name;
            ItemDescription.Text = dish.description;
            ItemIngredientsList.ItemsSource = dish.ingredients;

            ItemImage.Source = new BitmapImage(new Uri(ImagePath, UriKind.Relative));

            if (isEdit)
            {
                AddButton.Content = "Update";
                ItemCost.Text = TotalCostString;
                ItemQuantity.Text = Quantity.ToString();
            }
            else
            {
                AddButton.Content = "Add";
                ItemCost.Text = dish.cost.ToString();
                ItemQuantity.Text = "1";
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public DietaryRestrictionModel[] ImageAllergyPath
        {
            get { return Items.Data[id].dietaryRestrictions; } //not working....
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Items.Store.ToList().FindIndex((elem) => elem.itemId == id);

            if (index != -1)
            {
                List<AddedItem> items = Items.Store.ToList().ConvertAll((item) =>
                {
                    if (item.itemId == id)
                    {
                        if (isEdit)
                        {
                            item.quantity = int.Parse(ItemQuantity.Text);
                        }
                        else
                        {
                            item.quantity += int.Parse(ItemQuantity.Text);
                        }
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
                        itemId = id,
                        quantity = int.Parse(ItemQuantity.Text),
                    }
                );
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            int currentQuantity;
            if (int.TryParse(ItemQuantity.Text, out currentQuantity))
            {
                // subtract 1 from current quantity and update the text
                ItemQuantity.Text = (currentQuantity - 1).ToString();
            }
            //TODO: update ItemCost as well? 
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            int currentQuantity;
            if (int.TryParse(ItemQuantity.Text, out currentQuantity))
            {
                // add 1 to current quantity and update the text
                ItemQuantity.Text = (currentQuantity + 1).ToString();
            }
        }
    }
}
