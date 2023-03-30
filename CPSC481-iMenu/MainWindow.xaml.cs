using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
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


        private static Boolean canDelete = false;


        Dictionary<Button, bool> filterButtonToIsSelected;
        Dictionary<Button, DietaryRestrictions> filterButtonToDietaryRestrictionEnum;
        SolidColorBrush selectedButtonColor = new SolidColorBrush(Color.FromRgb(230, 255, 253));

        public MainWindow(List<DietaryRestrictionModel> selectedDietaryRestrictionsFromWelcomeScreen)
        {
            InitializeComponent();

            menuList.ItemsSource = Items.Data;

            // O(n^2). Also bad code
            Items.Store.CollectionChanged += StoreChanged;

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

            //Set some filters to 'selected' based on welcome screen selection

            foreach (DietaryRestrictionModel dietaryRestriction in selectedDietaryRestrictionsFromWelcomeScreen) 
            {
                Button correspondingfilterButton = filterButtonToDietaryRestrictionEnum.FirstOrDefault(x => x.Value == dietaryRestriction.dietaryRestriction).Key;
                filterButtonToIsSelected[correspondingfilterButton] = true;
                correspondingfilterButton.Background = selectedButtonColor;
                updateMenuItemsList();
            }
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


        private void Call_Server_Button_Click(object sender, RoutedEventArgs e)
        {
            //check if the button was pressed or not
           // bool press = IsButtonPressed(isCallServerPressed);
            Button? btn = sender as Button;
            btn.Background = btn.Background == Brushes.LightGreen ? new BrushConverter().ConvertFrom("#FFDDDDDD") as SolidColorBrush : Brushes.LightGreen;
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/e5420458-8b16-4d2e-819c-b23ed8d56b29/how-do-i-change-the-background-color-of-a-button-in-wpf-on-a-mouse-click-?forum=wpf

            call_server_canvas.Visibility = Visibility.Visible;

            //Call_Server_Button.Opacity = 0.4;


        }

       
        private void delete_confirmation_close_Click(object sender, RoutedEventArgs e)
        {
            //when clicked the x button, close the canvas, make it collapse in visibility
            delete_confirmation_canvas.Visibility = Visibility.Collapsed;
        }

        private void delete_confirmation_no_button_Click(object sender, RoutedEventArgs e)
        {
            //do not delete the item
            canDelete = false;
            delete_confirmation_canvas.Visibility = Visibility.Collapsed;
        }

        private void delete_confirmation_yes_button_Click(object sender, RoutedEventArgs e)
        {
            //delete the item
            canDelete = true;
            delete_confirmation_canvas.Visibility = Visibility.Collapsed;
        }

        static bool Get_canDelete()
        {
            return canDelete;
        }

        private void call_server_close_Click(object sender, RoutedEventArgs e)
        {
            //close the dialog
            call_server_canvas.Visibility = Visibility.Collapsed;
        }

        private void call_server_cancel_button_Click(object sender, RoutedEventArgs e)
        {
            call_server_canvas.Visibility = Visibility.Collapsed;
        }

        private void Help_Button_Click(object sender, RoutedEventArgs e)
        {
            Help_Canvas_Intro.Visibility = Visibility.Visible;
        }

        private void Help_Exit_Click(object sender, RoutedEventArgs e)
        {
            Help_Canvas_Intro.Visibility = Visibility.Collapsed;
            Help_Tip2.Visibility = Visibility.Collapsed;
            Help_Tip3.Visibility = Visibility.Collapsed;
            Help_Tip4.Visibility = Visibility.Collapsed;
        }

      

        private void NextTipIntro_Click(object sender, RoutedEventArgs e)
        {
            Help_Canvas_Intro.Visibility = Visibility.Collapsed;
            Help_Tip2.Visibility = Visibility.Visible;
        }

        private void NextTip2_Click(object sender, RoutedEventArgs e)
        {
            Help_Tip2.Visibility = Visibility.Collapsed;
            Help_Tip3.Visibility = Visibility.Visible;
        }

        private void PreviousTip2_Click(object sender, RoutedEventArgs e)
        {
            Help_Canvas_Intro.Visibility = Visibility.Visible;
            Help_Tip2.Visibility = Visibility.Collapsed;
        }
        private void NextTip3_Click(object sender, RoutedEventArgs e)
        {
            Help_Tip3.Visibility = Visibility.Collapsed;
            Help_Tip4.Visibility = Visibility.Visible;
        }
        private void PreviousTip3_Click(object sender, RoutedEventArgs e)
        {
            Help_Tip3.Visibility = Visibility.Collapsed;
            Help_Tip2.Visibility = Visibility.Visible;
        }

        private void NextTip4_Click(object sender, RoutedEventArgs e)
        {
            Help_Tip4.Visibility = Visibility.Collapsed;
            //Help_Tip5.Visibility = Visibility.Visible;
        }

        private void PreviousTip4_Click(object sender, RoutedEventArgs e)
        {
            Help_Tip4.Visibility = Visibility.Collapsed;
            Help_Tip3.Visibility = Visibility.Visible;
        }

        private void Open_Settings(Object sender, RoutedEventArgs e)
        {
            Settings_Pop_up.Visibility = Visibility.Visible;
        }

        private void Close_Settings_popup_Click(object sender, RoutedEventArgs e)
        {
            Settings_Pop_up.Visibility = Visibility.Collapsed;
        }

        private void Change_language_button_Click(object sender, RoutedEventArgs e)
        {
            Change_language_pop_up.Visibility = Visibility.Visible;
            Settings_Pop_up.Visibility = Visibility.Collapsed;
        }

        private void Change_language_pop_up_close_Click(object sender, RoutedEventArgs e)
        {
            Change_language_pop_up.Visibility = Visibility.Collapsed;
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

        private void updateMenuItemsList() 
        {
            Dictionary<Button, bool> currentFilters = filterButtonToIsSelected.Where(o => o.Value is true).ToDictionary(i => i.Key, i => i.Value);

            List<DietaryRestrictions> currentDietaryRestrictions = new List<DietaryRestrictions>();

            foreach (Button button in currentFilters.Keys)
            {
                currentDietaryRestrictions.Add(filterButtonToDietaryRestrictionEnum[button]);
            }

            List<DishModel> filteredMenuItems = filterItemsOnDietaryRestrictions(Items.Data, currentDietaryRestrictions);

            menuList.ItemsSource = filteredMenuItems;
            Items.Store.CollectionChanged += StoreChanged;
        }

       
    }
}
