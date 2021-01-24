using CookBook.Shared.Data.Dto;
using CookBook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookBook.Client.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly HttpClient httpClient;
        private string url = "api/recipes";

        public RecipeRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task CreateRecipe(RecipeDto recipeDto)
        {

            var response = await httpClient.PostAsJsonAsync(url, recipeDto);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
            }
        }
        public async Task<List<RecipeDto>> GetListOfRecipes()
        {
            var response = await httpClient.GetFromJsonAsync<List<RecipeDto>>(url);

            if (response == null)
            {
                Console.WriteLine("no recipe in list");
            }
            return response;
        }

        public async Task<RecipeDto> GetRecipe(int id)
        {
            RecipeDto recipe = new RecipeDto();


            var response = await httpClient.GetAsync($"{url}/{id}");

            var body = await response.Content.ReadAsStringAsync();

            return recipe;
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            var response = await httpClient.PutAsJsonAsync(url, recipe);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task DeleteRecipe(int id)
        {
            var response = await httpClient.DeleteAsync($"{url}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
