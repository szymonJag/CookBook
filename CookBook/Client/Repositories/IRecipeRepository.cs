using CookBook.Shared.Data.Dto;
using CookBook.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Client.Repositories
{
    public interface IRecipeRepository
    {
        Task CreateRecipe(RecipeDto recipeDto);
        Task DeleteRecipe(int id);
        Task<List<RecipeDto>> GetListOfRecipes();
        Task<RecipeDto> GetRecipe(int id);
        Task UpdateRecipe(Recipe recipe);
    }
}