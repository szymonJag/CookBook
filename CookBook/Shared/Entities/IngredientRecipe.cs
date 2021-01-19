using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Shared.Entities
{
    public class IngredientRecipe : BaseEntity
    {
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public int Amount { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
    }
}
