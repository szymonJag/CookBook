using CookBook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Shared.Data.Dto
{
    public class IngredientRecipeDto : BaseEntity
    {
        public int IngredientId { get; set; }
        public int Amount { get; set; }
        public IngredientDto Ingredient { get; set; }
        public RecipeDto Recipe { get; set; }
    }
}
