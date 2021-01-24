using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Shared.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public int Kcal { get; set; }
        public virtual List<IngredientRecipe> IngredientRecipe { get; set; }
    }
}
