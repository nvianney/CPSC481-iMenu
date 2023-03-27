using System;
using System.Collections.Generic;
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
        public int id = -1;
        public String name { get; set; }
        public String description { get; set; }
        public String imageName { get; set; }
        public String[] ingredients { get; set; }

        Allergens[] allergens;
        DietaryRestrictions[] dietaryRestrictions;
    }

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
                            imageName = "/ChummyJoes.png"
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
    }
}
