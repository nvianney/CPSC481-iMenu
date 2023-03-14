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
    public enum DietaryRestrictions
    {
        VEGETARIAN,
        VEGAN,
        GLUTEN_FREE,
        DIARY_FREE,
        PEANUT_FREE,
        SEAFOOD_FREE
    }

    public class DietaryRestrictionModel
    {
        public DietaryRestrictions dietaryRestriction { get; set; }
        public String dietaryRestrictionName { get; set; }
        public String imgSource { get; set; }
    }

    class DishModel
    {
        String name;
        String description;
        String imageName;
        String[] ingredients;

        Allergens[] allergens;
        DietaryRestrictionModel[] dietaryRestrictions;
    }
}
