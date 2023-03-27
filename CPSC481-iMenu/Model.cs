using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481_iMenu
{
    enum Allergens
    {
        NUT, DAIRY
    }

    enum DietaryRestrictions
    {
        VEGETARIAN,
        VEGAN,
        GLUTEN_FREE,
        DIARY_FREE,
        PEANUT_FREE,
        SEAFOOD_FREE
    }

    class DishModel
    {
        public int id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String imageName { get; set; }
        public String cost { get; set; }
        public String[] ingredients { get; set; }

        Allergens[] allergens;
        DietaryRestrictions[] dietaryRestrictions;
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
                            cost = "21.00",
                        }
                    };

                    for (int i = 0; i < _items.Count; i++)
                    {
                        _items[i].id = i;
                    }
                }

                return _items;
            }
        }

        public static ObservableCollection<int> Store = new ObservableCollection<int>();
    }
    /*
     * End of terrible code
     */
}
