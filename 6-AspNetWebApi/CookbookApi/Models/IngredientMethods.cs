using System;
using System.ComponentModel.DataAnnotations.Schema;
using CookbookApi.Utils;

namespace CookbookApi.Models
{
    public partial class Ingredient
    {
        [NotMapped]
        public string Text
        {
            get
            {
                return IngredientFormatter.FormatIngredient(Quantity, Unit, Food);
            }
        }
    }
}
