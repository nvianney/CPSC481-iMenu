﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        readonly List<DietaryRestrictionModel> dietaryRestrictions= new List<DietaryRestrictionModel>
        {
           new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.VEGETARIAN, dietaryRestrictionName = "Vegetarian", imgSource ="allergy_images/Vegetarian.png" },
           new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.VEGAN, dietaryRestrictionName = "Vegan", imgSource = "allergy_images/Vegan.png" },
           new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.GLUTEN_FREE, dietaryRestrictionName = "Gluten Free", imgSource = "allergy_images/gluten free.png" },
           new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.DIARY_FREE, dietaryRestrictionName = "Diary Free", imgSource = "allergy_images/dairy free.png" },
           new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.PEANUT_FREE, dietaryRestrictionName = "Peanut Free", imgSource = "allergy_images/nut pree.png" },
           new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.SEAFOOD_FREE, dietaryRestrictionName = "Seafood Free", imgSource = "allergy_images/Seafood.png" }
        };

        public DietaryRestrictionsWindow()
        {
            InitializeComponent();

            DietaryRestrictionsListView.ItemsSource = dietaryRestrictions;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Use those selected restrictions to filter the menu later
            IList selectedDietaryRestrictions = DietaryRestrictionsListView.SelectedItems;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
               
            this.Close();
        }

        private void DietaryRestrictionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
