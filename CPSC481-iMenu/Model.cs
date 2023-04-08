using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

    public enum MenuItemCategory
    {
        STARTER,
        MAIN,
        SIDE,
        DRINK,
        DESSERT,
        SPECIAL,
    }

    public class DietaryRestrictionModel
    {
        public DietaryRestrictions dietaryRestriction { get; set; }
        public String dietaryRestrictionName { get; set; }
        public String imgSource { get; set; }
    }

    public class MenuItemCategoryModel
    {
        public MenuItemCategory menuItemCategory { get; set; }
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
           { DietaryRestrictions.PEANUT_FREE, new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.PEANUT_FREE, dietaryRestrictionName = "Nut Free", imgSource = "allergy_images/nut pree.png" }},
           { DietaryRestrictions.SEAFOOD_FREE, new DietaryRestrictionModel(){ dietaryRestriction = DietaryRestrictions.SEAFOOD_FREE, dietaryRestrictionName = "Seafood Free", imgSource = "allergy_images/Seafood.png" }}
        };
    }

    public static class MenuItemCategoryList
    {
        public static readonly Dictionary<MenuItemCategory, MenuItemCategoryModel> menuItemCategories = new Dictionary<MenuItemCategory, MenuItemCategoryModel>
        {
           { MenuItemCategory.STARTER, new MenuItemCategoryModel(){ menuItemCategory = MenuItemCategory.STARTER, imgSource ="sidebar/starter.png"}},
           { MenuItemCategory.MAIN, new MenuItemCategoryModel(){ menuItemCategory = MenuItemCategory.MAIN, imgSource = "sidebar/main.png" }},
           { MenuItemCategory.SIDE, new MenuItemCategoryModel() { menuItemCategory = MenuItemCategory.SIDE, imgSource = "sidebar/sides.png" }},
           { MenuItemCategory.DRINK, new MenuItemCategoryModel() { menuItemCategory = MenuItemCategory.DRINK, imgSource = "sidebar/drink.png" }},
           { MenuItemCategory.DESSERT, new MenuItemCategoryModel(){ menuItemCategory = MenuItemCategory.DESSERT, imgSource = "sidebar/dessert.png"}},
           { MenuItemCategory.SPECIAL, new MenuItemCategoryModel(){ menuItemCategory = MenuItemCategory.SPECIAL, imgSource = "sidebar/special.png"}},
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

        public DietaryRestrictionModel[] dietaryRestrictions { get; set; }
        public MenuItemCategoryModel menuItemCategory;
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
                            imageName = "/food_images/Spaghetti.jpg",
                            cost = 21.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.MAIN]
                        },
                        new DishModel()
                        {
                            name = "Steak",
                            description = "Angus beef",
                            imageName = "/food_images/Steak.jpg",
                            cost = 25.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.MAIN]
                        },
                        new DishModel()
                        {
                            name = "Veggie Burger",
                            description = "vegan patty with relish, tomato and lettuce on a whole-grain bun",
                            imageName = "/food_images/VeggieBurger.jpg",
                            cost = 17.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.MAIN]
                        },
                        new DishModel()
                        {
                            name = "Salmon salad",
                            description = "chopped vegetables, flaky fish, and tangy citrus dressing",
                            imageName = "/food_images/SalmonSalad.jpg",
                            cost = 13.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.MAIN]
                        },
                        new DishModel()
                        {
                            name = "Tiramisu cake",
                            description = "layered cake with coffee and rum",
                            imageName = "/food_images/TiramisuCake.jpg",
                            cost = 8.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.DESSERT]
                        },
                        new DishModel()
                        {
                            name = "Fries",
                            description = "deep fried potato sticks",
                            imageName = "/food_images/Fries.jpg",
                            cost = 6.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.SIDE]
                        },
                        new DishModel()
                        {
                            name = "Coca-Cola",
                            description = "flavoured soft drink",
                            imageName = "/food_images/Coca-Cola.jpg",
                            cost = 4.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.DRINK]
                        },
                        new DishModel()
                        {
                            name = "Orange Juice",
                            description = "made out of fresh oranges",
                            imageName = "/food_images/OrangeJuice.jpg",
                            cost = 5.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.DRINK]
                        },
                        new DishModel()
                        {
                            name = "Calamari",
                            description = "pieces of squid cooked for eating, usually cut into rings and fried",
                            imageName = "/food_images/Calamari.jpg",
                            cost = 11.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.STARTER]
                        },
                        new DishModel()
                        {
                            name = "Wings",
                            description = "deep fried chicken wings",
                            imageName = "/food_images/Wings.jpg",
                            cost = 7.34f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.SIDE]
                        },
                        new DishModel()
                        {
                            name = "Crab Cake",
                            description = "crab, shrimp, corn with panko crust, apple fennel salad, house-made tartar",
                            imageName = "/food_images/CrabCake.jpg",
                            cost = 20.75f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.STARTER]
                        },
                        new DishModel()
                        {
                            name = "Katsu Chicken Penut Salad",
                            description = "crispy chicken breast, julienne vegetables, arugula, miso ginger dressing",
                            imageName = "/food_images/KatsuChickenSalad.jpg",
                            cost = 24.25f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.MAIN]
                        },
                        new DishModel()
                        {
                            name = "Sushi Cone",
                            description = "tempura prawn, avocado, spicy mayo, tobiko",
                            imageName = "/food_images/SushiCone.jpg",
                            cost = 7.34f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.SIDE]
                        },
                        new DishModel()
                        {
                            name = "Roasted Corn Guacamole",
                            description = "Cilantro, fresh line, cherry tomatoes, serranos, feta cheese, warm tortilla chips",
                            imageName = "/food_images/CornGuacamole.jpg",
                            cost = 7.44f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.SIDE]
                        },
                        new DishModel()
                        {
                            name = "Avocado Roll",
                            description = "chili mayo, micro cilantro, teriyaki glaze",
                            imageName = "/food_images/AvocadoRoll.jpg",
                            cost = 12.46f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.SIDE]
                        },
                        new DishModel()
                        {
                            name = "Fish Tacos",
                            description = "two shrimps + fish tacos, guacamole, valentina's",
                            imageName = "/food_images/FishTaco.jpg",
                            cost = 15.75f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.MAIN]
                        },
                        new DishModel()
                        {
                            name = "Crispy Tofu Bowl",
                            description = "Korean chili spiced tofu, edamame, miso dressing, brown rice",
                            imageName = "/food_images/TofuBowl.jpg",
                            cost = 20.50f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.MAIN]
                        },
                        new DishModel()
                        {
                            name = "Apple Pie",
                            description = "hand-folded pastry, toasted almonds, Canadian maple ice cream",
                            imageName = "/food_images/ApplePie.jpg",
                            cost = 12.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.DESSERT]
                        },
                        new DishModel()
                        {
                            name = "Apple Juice",
                            description = "made out of fresh apples",
                            imageName = "/food_images/AppleJuice.jpg",
                            cost = 5.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.DRINK]
                        },
                        new DishModel()
                        {
                            name = "Sprite",
                            description = "flavourd soft drink",
                            imageName = "/food_images/Sprite.jpg",
                            cost = 5.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.DRINK]
                        },
                        new DishModel()
                        {
                            name = "Grapefruit Crudo",
                            description = "Bittersweet grapefruit, crunchy radishes, spicy-floral Fresno chile, toasted cashews",
                            imageName = "/food_images/GrapefruitCrudo.jpg",
                            cost = 8.50f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGETARIAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.VEGAN],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.STARTER]
                        },
                        new DishModel()
                        {
                            name = "Shrimp Cocktail",
                            description = "Chilled shrimp paired with tangy cocktail sauce.",
                            imageName = "/food_images/ShrimpCocktail.jpg",
                            cost = 10.75f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.GLUTEN_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.STARTER]
                        },
                        new DishModel()
                        {
                            name = "Poutine",
                            description = "Crispy french fries topped with cheese curds and gravy, a classic Canadian dish known as Poutine.",
                            imageName = "/food_images/Poutine.jpg",
                            cost = 6.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.SPECIAL]
                        },
                         new DishModel()
                        {
                            name = "Nanaimo bars",
                            description = "Classic Canadian dessert consisting of three layers - a crumbly chocolate and coconut base, a custard-flavored middle, and chocolate ganache on top",
                            imageName = "/food_images/NanaimoBars.jpg",
                            cost = 6.00f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.SPECIAL]
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
