using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookBook.Shared.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        
        public virtual List<IngredientRecipe> ListOfIngredients { get; set; }
    }
}
