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
                            description = "Whole-wheat spaghetti with tomato sauce and a 50/50 blend of beef and pork meatballs",
                            imageName = "/food_images/Spaghetti.jpg",
                            cost = 21.00f,
                            ingredients = new string[]
                            {
                                "Whole-wheat pasta",
                                "Beef",
                                "Pork",
                                "Breadcrumbs",
                                "Onion",
                                "Garlic",
                                "Egg",
                                "Milk",
                                "Parmesan cheese",
                                "Olive oil",
                                "Salt",
                                "Pepper"
                            },
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
                            description = "Juicy steak cooked to perfection with a side of fries",
                            imageName = "/food_images/Steak.jpg",
                            cost = 25.00f,
                            ingredients = new string[]
                            {
                                "Beef",
                                "Potatoes",
                                "Salt",
                                "Pepper",
                                "Butter",
                                "Garlic",
                                "Parsley"
                            },
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
                            description = "Veggie patty with relish, tomato and lettuce on a whole-grain bun",
                            imageName = "/food_images/VeggieBurger.jpg",
                            cost = 17.00f,
                            ingredients = new string[]
                            {
                                "Veggie patty",
                                "Relish",
                                "Tomato",
                                "Lettuce",
                                "Pickles",
                                "American cheese",
                                "Ketchup and mayo",
                                "Whole-grain bun"
                            },
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
                            description = "Mixed greens, veggies, and flaky grilled salmon tossed in a tangy citrus dressing",
                            imageName = "/food_images/SalmonSalad.jpg",
                            cost = 13.00f,
                            ingredients = new string[]
                            {
                                "Spinach",
                                "Lettuce",
                                "Arugula",
                                "Cherry tomatoes",
                                "Cucumbers",
                                "Red onion",
                                "Salmon fillet",
                                "Lemon",
                                "Olive oil",
                                "Salt",
                                "Pepper"
                            },
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
                            description = "Layered cake with espresso and rum-soaked ladyfingers",
                            imageName = "/food_images/TiramisuCake.jpg",
                            cost = 8.00f,
                            ingredients = new string[]
                            {
                                "Mascarpone cheese",
                                "Espresso",
                                "Rum",
                                "Ladyfingers",
                                "Egg yolks",
                                "Sugar",
                                "Heavy cream",
                                "Cocoa powder"
                            },
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
                            name = "French fries",
                            description = "Crispy and salty deep-fried potato sticks",
                            imageName = "/food_images/Fries.jpg",
                            cost = 6.00f,
                            ingredients = new string[]
                            {
                                "Potatoes",
                                "Salt",
                                "Oil"
                            },
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
                            description = "Flavoured soft drink",
                            imageName = "/food_images/Coca-Cola.jpg",
                            cost = 4.00f,
                            ingredients = new string[]
                            {
                                "Coca-Cola"
                            },
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
                            description = "Made out of fresh oranges",
                            imageName = "/food_images/OrangeJuice.jpg",
                            cost = 5.00f,
                            ingredients = new string[]
                            {
                                "Oranges"
                            },
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
                            description = "Tender pieces of squid, usually cut into rings and fried",
                            imageName = "/food_images/Calamari.jpg",
                            cost = 11.00f,
                            ingredients = new string[]
                            {
                                "Squid",
                                "Flour",
                                "Cornmeal",
                                "Salt",
                                "Pepper",
                                "Oil"
                            },
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.STARTER]
                        },
                        new DishModel()
                        {
                            name = "Chicken Wings",
                            description = "Deep fried chicken wings",
                            imageName = "/food_images/Wings.jpg",
                            cost = 7.34f,
                            ingredients = new string[]
                            {
                                "Chicken wings",
                                "Flour",
                                "Cornmeal",
                                "Salt",
                                "Pepper",
                                "Oil"
                            },
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
                            description = "Crab, shrimp, corn with panko crust, apple fennel salad, house-made tartar",
                            imageName = "/food_images/CrabCake.jpg",
                            cost = 20.75f,
                            ingredients = new string[]
                            {
                                "Crab meat",
                                "Shrimp",
                                "Corn",
                                "Panko breadcrumbs",
                                "Egg",
                                "Mayonnaise",
                                "Dijon mustard",
                                "Lemon",
                                "Green apple",
                                "Fennel",
                                "Red onion",
                                "Mayonnaise",
                                "Lemon juice",
                                "Salt",
                                "Pepper"
                            },
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.DAIRY_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.STARTER]
                        },
                        new DishModel()
                        {
                            name = "Katsu Chicken Penut Salad",
                            description = "Crispy chicken breast, julienne vegetables, arugula, miso ginger dressing",
                            imageName = "/food_images/KatsuChickenSalad.jpg",
                            cost = 24.25f,
                            ingredients = new string[]
                            {
                                "Chicken breast",
                                "Panko breadcrumbs",
                                "Flour",
                                "Egg",
                                "Arugula",
                                "Carrots",
                                "Cucumber",
                                "Red bell pepper",
                                "Green onions",
                                "Ginger",
                                "Miso paste",
                                "Rice vinegar",
                                "Soy sauce",
                                "Honey",
                                "Garlic",
                                "Lime juice",
                                "Peanuts",
                                "Salt",
                                "Pepper",
                                "Oil"
                            },
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.MAIN]
                        },
                        new DishModel()
                        {
                            name = "Sushi Cone",
                            description = "A hand-held sushi cone with crispy tempura prawn, avocado, spicy mayo, and tobiko",
                            imageName = "/food_images/SushiCone.jpg",
                            cost = 7.34f,
                            ingredients = new string[]
                            {
                                "Sushi rice",
                                "Seaweed",
                                "Prawn",
                                "Avocado",
                                "Spicy mayo",
                                "Tobiko (flying fish roe)",
                                "Soy sauce",
                                "Wasabi",
                                "Pickled ginger"
                            },
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.SIDE]
                        },
                        new DishModel()
                        {
                            name = "Roasted Corn Guacamole",
                            description = "Fresh guacamole with roasted corn. Served with warm tortilla chips.",
                            imageName = "/food_images/CornGuacamole.jpg",
                            cost = 7.44f,
                            ingredients = new string[]
                            {
                                "Avocado",
                                "Roasted corn",
                                "Cilantro",
                                "Lime",
                                "Cherry tomatoes",
                                "Serrano peppers",
                                "Feta cheese",
                                "Tortilla chips",
                                "Salt",
                                "Pepper"
                            },
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
                            description = "Avocado, spicy mayo, tobiko",
                            imageName = "/food_images/AvocadoRoll.jpg",
                            cost = 12.46f,
                            ingredients = new string[]
                            {
                                "Sushi rice",
                                "Nori seaweed",
                                "Avocado",
                                "Spicy mayo",
                                "Soy sauce",
                                "Wasabi",
                                "Pickled ginger"
                            },
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
                            description = "Two tacos filled with crispy fish, topped with guacamole and a spicy sauce",
                            imageName = "/food_images/FishTaco.jpg",
                            cost = 15.75f,
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                            },
                            ingredients = new string[]
                            {
                                "White fish fillets",
                                "Corn tortillas",
                                "Avocado",
                                "Tomatoes",
                                "Red onion",
                                "Cilantro",
                                "Lime juice",
                                "Jalapeño peppers",
                                "Garlic",
                                "Cumin",
                                "Paprika",
                                "Salt",
                                "Pepper",
                                "Vegetable oil"
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.MAIN]
                        },
                        new DishModel()
                        {
                            name = "Crispy Tofu Bowl",
                            description = "Korean chili spiced tofu, edamame, miso dressing, brown rice",
                            imageName = "/food_images/TofuBowl.jpg",
                            cost = 20.50f,
                            ingredients = new string[]
                            {
                                "Firm tofu",
                                "Cornstarch",
                                "Oil",
                                "Korean chili paste",
                                "Soy sauce",
                                "Honey",
                                "Garlic",
                                "Ginger",
                                "Edamame",
                                "Brown rice",
                                "Miso",
                                "Rice vinegar",
                                "Sesame oil",
                                "Sesame seeds",
                                "Green onions",
                                "Carrots",
                                "Cucumbers",
                                "Red pepper",
                                "Salt",
                                "Pepper"
                            },
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
                            description = "Classic apple pie with a flaky crust and cinnamon spice",
                            imageName = "/food_images/ApplePie.jpg",
                            cost = 12.00f,
                            ingredients = new string[]
                            {
                                "Granny Smith apples",
                                "Pie crust",
                                "Butter",
                                "Cinnamon",
                                "Sugar",
                                "Flour",
                                "Lemon juice",
                                "Vanilla extract"
                            },
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
                            description = "Made out of fresh apples",
                            imageName = "/food_images/AppleJuice.jpg",
                            cost = 5.00f,
                            ingredients = new string[]
                            {
                                "Apples",
                            },
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
                            description = "Flavourd soft drink",
                            imageName = "/food_images/Sprite.jpg",
                            cost = 5.00f,
                            ingredients = new string[]
                            {
                                "Sprite",
                            },
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
                            ingredients = new string[]
                            {
                                "Grapefruit",
                                "Radishes",
                                "Fresno chile",
                                "Cashews",
                            },
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
                            ingredients = new string[]
                            {
                                "Large shrimp",
                                "Lemon",
                                "Ketchup",
                                "Worcestershire sauce",
                                "Hot sauce",
                                "Salt",
                                "Pepper",
                            },
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
                            description = "Crispy french fries topped with cheese curds and gravy",
                            imageName = "/food_images/Poutine.jpg",
                            cost = 6.00f,
                            ingredients = new string[]
                            {
                                "Potatoes",
                                "Cheese curds",
                                "Beef gravy",
                            },
                            dietaryRestrictions = new DietaryRestrictionModel[]{
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.PEANUT_FREE],
                                DietaryRestrictionList.dietaryRestrictions[DietaryRestrictions.SEAFOOD_FREE],
                            },
                            menuItemCategory = MenuItemCategoryList.menuItemCategories[MenuItemCategory.SPECIAL]
                        },
                         new DishModel()
                        {
                            name = "Nanaimo bars",
                            description = "Dessert consisting a chocolate and coconut base, a custard middle, and chocolate ganache on top",
                            imageName = "/food_images/NanaimoBars.jpg",
                            cost = 6.00f,
                            ingredients = new string[]
                            {
                                "Graham cracker crumbs",
                                "Coconut flakes",
                                "Butter",
                                "Granulated sugar",
                                "Cocoa powder",
                                "Eggs",
                                "Vanilla extract",
                                "Heavy cream",
                                "Unsalted butter",
                                "Powdered sugar",
                                "Semi-sweet chocolate chips",
                            },
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
