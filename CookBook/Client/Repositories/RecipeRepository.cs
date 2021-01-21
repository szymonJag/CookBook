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
        public async Task CreateRecipe(Recipe recipe)
        {

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            string json = JsonSerializer.Serialize(recipe, options);

            var response = await httpClient.PostAsJsonAsync(url, json);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
            }
        }
        public async Task<List<Recipe>> GetListOfRecipes()
        {
            var response = await httpClient.GetFromJsonAsync<List<Recipe>>(url);

            if (response == null)
            {
                Console.WriteLine("no recipe in list");
            }
            return response;
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            Recipe recipe = new Recipe();
            var response = await httpClient.GetAsync($"{url}/{id}");

            if (response.IsSuccessStatusCode)
            {

                recipe = JsonSerializer.Deserialize<Recipe>(await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    });
            }

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
