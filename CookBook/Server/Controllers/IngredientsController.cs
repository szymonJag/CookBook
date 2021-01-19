using CookBook.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController
    {
        private readonly AppDbContext context;

        public IngredientsController(AppDbContext context)
        {
            this.context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Ingredient>>> Get()
        {
            return await context.IngredientsTable.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> Get(int id)
        {
            var ingredient = await context.IngredientsTable
                .Include(x => x.IngredientRecipe)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ingredient == null) { return new NoContentResult(); }

            return ingredient;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Ingredient ingredient)
        {
            context.IngredientsTable.Add(ingredient);
            await context.SaveChangesAsync();
            return ingredient.Id;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var ingredientToRemove = context.IngredientsTable.FirstOrDefault(x => x.Id == id);

            context.IngredientsTable.Remove(ingredientToRemove);
            await context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Ingredient ingredient)
        {
            if (!context.IngredientsTable.Contains(ingredient))
            {
                return new BadRequestResult();
            }

            context.Entry(ingredient).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
