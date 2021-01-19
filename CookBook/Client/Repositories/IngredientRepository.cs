using CookBook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookBook.Client.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly HttpClient httpClient;
        private string url = "api/ingredients";

        public IngredientRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreateIngredient(Ingredient ingredient)
        {
            var response = await httpClient.PostAsJsonAsync(url, ingredient);

            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"the id of the ingredient is: {body}");
            }
            else
            {
                Console.WriteLine(body);
            }
        }

        public async Task<List<Ingredient>> GetListOfIngredients()
        {
            var response = await httpClient.GetFromJsonAsync<List<Ingredient>>(url);

            if (response == null)
            {
                Console.WriteLine("no ingredients in list");
            }
            return response;
        }

        public async Task<Ingredient> GetIngredient(int id)
        {
            Ingredient ingredient = new Ingredient();

            var response = await httpClient.GetAsync($"{url}/{id}");

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                ingredient = JsonSerializer.Deserialize<Ingredient>(await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    });
            }

            return ingredient;
        }

        public async Task UpdateIngredient(Ingredient ingredient)
        {
            var response = await httpClient.PutAsJsonAsync(url, ingredient);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task DeleteIngredient(int id)
        {
            var response = await httpClient.DeleteAsync($"{url}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
