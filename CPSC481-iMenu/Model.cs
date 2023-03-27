using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481_iMenu
{
    public enum DietaryRestrictions
    {
        VEGETARIAN,
        VEGAN,
        GLUTEN_FREE,
        DAIRY_FREE,
        PEANUT_FREE,
        SEAFOOD_FREE
    }

    public class DietaryRestrictionModel
    {
        public DietaryRestrictions dietaryRestriction { get; set; }
        public String dietaryRestrictionName { get; set; }
        public String imgSource { get; set; }
    }

    public static class DietaryRestrictionList
    {
        public static readonly Dictionary<DietaryRestrictions, DietaryRestrictionModel> dietaryRestrictions = new Dictionary<DietaryRestrictions, DietaryRestrictionModel>
        {
           { DietaryRestrictions.VEGETARIAN, new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.VEGETARIAN, dietaryRestrictionName = "Vegetarian", imgSource ="allergy_images/Vegetarian.png" } },
           { DietaryRestrictions.VEGAN, new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.VEGAN, dietaryRestrictionName = "Vegan", imgSource = "allergy_images/Vegan.png" }},
           { DietaryRestrictions.GLUTEN_FREE, new DietaryRestrictionModel() { dietaryRestriction = DietaryRestrictions.GLUTEN_FREE, dietaryRestrictionName = "Gluten Free", imgSource = "allergy_images/gluten free.png" } },
           { DietaryRestrictions.DAIRY_FREE, new DietaryRestrictionModel() { dietaryRestriction = DietaryRestrictions.DAIRY_FREE, dietaryRestrictionName = "Dairy Free", imgSource = "allergy_images/dairy free.png" } },
           { DietaryRestrictions.PEANUT_FREE, new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.PEANUT_FREE, dietaryRestrictionName = "Peanut Free", imgSource = "allergy_images/nut pree.png" }},
           { DietaryRestrictions.SEAFOOD_FREE, new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.SEAFOOD_FREE, dietaryRestrictionName = "Seafood Free", imgSource = "allergy_images/Seafood.png" }}
        };
    }

    class DishModel
    {
        public int itemId { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String imageName { get; set; }
        public float cost { get; set; }
        public String[] ingredients { get; set; }

        public DietaryRestrictionModel[] dietaryRestrictions;
    }

    /*
     * 
     * NOTE: the whole class below is terrible code. Never do something like this! It is only used here because it simplifies
     * a lot of logic; however, it is not scalable code and will guarantee problems in the future. 
     * 
     * Terrible: use singleton to store menu data, and global variable to store state
     * Better: use a programming architectural pattern (MVC, MVVM, etc.) to store state, and use a file to store and load data.
     * 
     */
    internal class Items
    {
        private static List<DishModel> _items = null;

        public static List<DishModel> Data
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<DishModel>
                    {
                        new DishModel()
                        {
                            name = "Spaghetti",
                            description = "Made with whole-wheat pasta and a 50/50 blend of beef and pork meatballs",
                            imageName = "/ChummyJoes.png",
                            cost = 21.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            }
                        },
                        new DishModel()
                        {
                            name = "Steak",
                            description = "Angus beef",
                            imageName = "/ChummyJoes.png",
                            cost = 21.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            }
                        },
                        new DishModel()
                        {
                            name = "Veggie Burger",
                            description = "vegan patty with relish, tomato and lettuce on a whole-grain bun",
                            imageName = "/ChummyJoes.png",
                            cost = 17.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            }
                        },
                        new DishModel()
                        {
                            name = "Tiramisu cake",
                            description = "layered cake with coffee and rum",
                            imageName = "/ChummyJoes.png",
                            cost = 8.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                            }
                        },
                        new DishModel()
                        {
                            name = "Salmon salad",
                            description = "chopped vegetables, flaky fish, and tangy citrus dressing",
                            imageName = "/ChummyJoes.png",
                            cost = 8.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            }
                        },
                    };

                    for (int i = 0; i < _items.Count; i++)
                    {
                        _items[i].itemId = i;
                    }
                }

                return _items;
            }
        }

        internal class AddedItem
        {
            public long timestamp { get; set; }
            public int itemId { get; set; }
            public int quantity { get; set; }
        }

        // timestamp, itemId
        public static ObservableCollection<AddedItem> Store = new ObservableCollection<AddedItem>();
    }
    /*
     * End of terrible code
     */
}
