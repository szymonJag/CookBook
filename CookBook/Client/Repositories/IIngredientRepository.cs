using CookBook.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Client.Repositories
{
    public interface IIngredientRepository
    {
        Task CreateIngredient(Ingredient ingredient);
        Task DeleteIngredient(int id);
        Task<Ingredient> GetIngredient(int id);
        Task<List<Ingredient>> GetListOfIngredients();
        Task UpdateIngredient(Ingredient ingredient);
    }
}