using CookBook.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Client.Repositories
{
    public interface IRecipeRepository
    {
        Task CreateRecipe(Recipe recipe);
        Task DeleteRecipe(int id);
        Task<List<Recipe>> GetListOfRecipes();
        Task<Recipe> GetRecipe(int id);
        Task UpdateRecipe(Recipe recipe);
    }
}