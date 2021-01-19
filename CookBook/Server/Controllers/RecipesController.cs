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
    public class RecipesController
    {
        private readonly AppDbContext context;

        public RecipesController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> Get()
        {
            return await context.RecipesTable.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> Get(int id)
        {
            var recipe = await context.RecipesTable
                .Include(x => x.ListOfIngredients)
                .FirstOrDefaultAsync();

            if (recipe == null) { return new NotFoundResult(); }

            return recipe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Recipe recipe)
        {
            context.RecipesTable.Add(recipe);
            await context.SaveChangesAsync();
            return recipe.Id;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var recipeToRemove = context.RecipesTable.FirstOrDefault(x => x.Id == id);

            context.RecipesTable.Remove(recipeToRemove);
            await context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Recipe recipe)
        {
            context.Entry(recipe).State = EntityState.Modified;

            foreach (var recipeItem in recipe.ListOfIngredients)
            {
                if (recipeItem.Id != 0)
                {
                    context.Entry(recipeItem).State = EntityState.Modified;
                }
                else
                {
                    context.Entry(recipeItem).State = EntityState.Added;
                }
            }

            //var idsOfAddresses = recipe.ListOfIngredients.Select(x => x.Id).ToList();
            //var ingredientsToDelete = await context
            //    .RecipesTable
            //    .Where(x=>!idsOfAddresses.Contains(x.Id) && x.)
            //    //.Where(x => !idsOfAddresses.Contains(x.Id) && x.1 == recipe.Id)
            //    .ToListAsync();

            //context.RemoveRange(ingredientsToDelete);

            //await context.SaveChangesAsync();

            //return NoContent();

            return new OkResult();
        }
    }
}
