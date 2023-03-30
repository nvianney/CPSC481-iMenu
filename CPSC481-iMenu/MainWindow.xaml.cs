using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        Dictionary<Button, bool> filterButtonToIsSelected;
        Dictionary<Button, DietaryRestrictions> filterButtonToDietaryRestrictionEnum;
        Dictionary<Button, MenuItemCategory> sidebarButtonToMenuItemCategoryEnum;
        Button sidebarButtonSelected;
        SolidColorBrush selectedButtonColor = new SolidColorBrush(Color.FromRgb(187, 231, 252));

        public MainWindow(List<DietaryRestrictionModel> selectedDietaryRestrictionsFromWelcomeScreen)
        {
            InitializeComponent();

            menuList.ItemsSource = Items.Data;

            // O(n^2). Also bad code
            Items.Store.CollectionChanged += StoreChanged;

            sidebarButtonSelected = this.StartersButton;
            sidebarButtonSelected.Background = selectedButtonColor;

            filterButtonToIsSelected = new Dictionary<Button, bool>()
            {
                {this.VeganButton, false},
                {this.VegetarianButton, false},
                {this.NutFreeButton, false},
                {this.SeafoodFreeButton, false},
                {this.GlutenFreeButton, false},
                {this.DairyFreeButton, false},
            };

            filterButtonToDietaryRestrictionEnum = new Dictionary<Button, DietaryRestrictions>()
            {
                {this.VeganButton, DietaryRestrictions.VEGAN},
                {this.VegetarianButton, DietaryRestrictions.VEGETARIAN},
                {this.NutFreeButton, DietaryRestrictions.PEANUT_FREE},
                {this.SeafoodFreeButton, DietaryRestrictions.SEAFOOD_FREE},
                {this.GlutenFreeButton, DietaryRestrictions.GLUTEN_FREE},
                {this.DairyFreeButton, DietaryRestrictions.DAIRY_FREE},
            };

            sidebarButtonToMenuItemCategoryEnum = new Dictionary<Button, MenuItemCategory>()
            {
                {this.StartersButton, MenuItemCategory.STARTER},
                {this.MainsButton, MenuItemCategory.MAIN},
                {this.SidesButton, MenuItemCategory.SIDE},
                {this.DrinksButton, MenuItemCategory.DRINK},
                {this.DessertsButton, MenuItemCategory.DESSERT},
            };

            //Set some filters to 'selected' based on welcome screen selection
            foreach (DietaryRestrictionModel dietaryRestriction in selectedDietaryRestrictionsFromWelcomeScreen) 
            {
                Button correspondingfilterButton = filterButtonToDietaryRestrictionEnum.FirstOrDefault(x => x.Value == dietaryRestriction.dietaryRestriction).Key;
                filterButtonToIsSelected[correspondingfilterButton] = true;
                correspondingfilterButton.Background = selectedButtonColor;
            }

            updateMenuItemsList();

        }

        private void StoreChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Update");
            orderList.ItemsSource = Items.Store.ToList();
        }

        public void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrderWindow window = new PlaceOrderWindow();
            window.Show();
        }

        private void btn_legend_Click(object sender, RoutedEventArgs e)
        {
            LegendWindow window = new LegendWindow();
            window.Show();

            //this.Close();
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            Button filterButtonClicked = (Button) e.Source;

            filterButtonToIsSelected[filterButtonClicked] = !filterButtonToIsSelected[filterButtonClicked];

            if (filterButtonToIsSelected[filterButtonClicked] is false) //Filter Button Not Selected
            {
                filterButtonClicked.Background = new SolidColorBrush(Colors.White);
            }
            else //Filter Button Selected
            {
                filterButtonClicked.Background = selectedButtonColor;
            }

            updateMenuItemsList();
        }

        private void Sidebar_Button_Click(object sender, RoutedEventArgs e) 
        {
            Button sidebarButtonClicked = (Button)e.Source;

            if (sidebarButtonClicked != sidebarButtonSelected) //different button than current has been pressed
            {
                sidebarButtonSelected.Background = new SolidColorBrush(Colors.White);
                sidebarButtonClicked.Background = selectedButtonColor;
                sidebarButtonSelected = sidebarButtonClicked;
                updateMenuItemsList();
            }
        }

        private List<DishModel> filterItemsOnDietaryRestrictions(List<DishModel> menuItems, List<DietaryRestrictions> dietaryRestrictions) 
        {
            List<DishModel> filteredMenuItems = menuItems;

            foreach(DietaryRestrictions dietaryRestriction in dietaryRestrictions) 
            {
                filteredMenuItems = filteredMenuItems.Where(
                    o => o.dietaryRestrictions.Contains(DietaryRestrictionList.dietaryRestrictions[dietaryRestriction])).ToList();
            }

            return filteredMenuItems;
        }

        private List<DishModel> filterItemsOnMenuCategory(List<DishModel> menuItems, MenuItemCategory menuItemCategory)
        {
            List<DishModel> filteredMenuItems = menuItems.Where(o => o.menuItemCategory.menuItemCategory == menuItemCategory).ToList();

            return filteredMenuItems;
        }

        private void updateMenuItemsList() 
        {
            //Filter menu for dietary restrictions
            Dictionary<Button, bool> currentFilters = filterButtonToIsSelected.Where(o => o.Value is true).ToDictionary(i => i.Key, i => i.Value);

            List<DietaryRestrictions> currentDietaryRestrictions = new List<DietaryRestrictions>();

            foreach (Button button in currentFilters.Keys)
            {
                currentDietaryRestrictions.Add(filterButtonToDietaryRestrictionEnum[button]);
            }

            List<DishModel> filteredMenuItems = filterItemsOnDietaryRestrictions(Items.Data, currentDietaryRestrictions);

            //Filter menu for categories
            MenuItemCategory currentMenuItemCategory = sidebarButtonToMenuItemCategoryEnum[sidebarButtonSelected];
            filteredMenuItems = filterItemsOnMenuCategory(filteredMenuItems, currentMenuItemCategory);

            //Apply changes
            menuList.ItemsSource = filteredMenuItems;
            Items.Store.CollectionChanged += StoreChanged;
        }
    }
}
