using CookBook.Shared.Data.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Client.Repositories
{
    public interface IIngredientRepository
    {
        Task CreateIngredient(IngredientDto ingredient);
        Task DeleteIngredient(int id);
        Task<IngredientDto> GetIngredient(int id);
        Task<List<IngredientDto>> GetListOfIngredients();
        Task UpdateIngredient(IngredientDto ingredient);
    }
}