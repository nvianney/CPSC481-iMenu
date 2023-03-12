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
        String name;
        String description;
        String imageName;
        String[] ingredients;

        Allergens[] allergens;
        DietaryRestrictions[] dietaryRestrictions;
    }
}
