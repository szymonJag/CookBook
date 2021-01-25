using CookBook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Shared.Data.Dto
{
    public class RecipeDto : BaseEntity
    {
        public string Name { get; set; }

        public List<IngredientRecipeDto> ListOfIngredients { get; set; } = new List<IngredientRecipeDto>();
    }
}
