using CookBook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Shared.Data.Dto
{
    public class IngredientDto : BaseEntity
    {
        public string Name { get; set; }
        public int Kcal { get; set; }
        public List<IngredientRecipe> IngredientRecipe { get; set; }
    }
}
