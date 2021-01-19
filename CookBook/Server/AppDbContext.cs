using CookBook.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        

        public DbSet<Ingredient> IngredientsTable { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipesTable { get; set; }
        public DbSet<Recipe> RecipesTable { get; set; }
    }
}
