using AutoMapper;
using CookBook.Shared.Data.Dto;
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
        private readonly IMapper mapper;

        public RecipesController(AppDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecipeDto>>> Get()
        {
            var ListOfRecipes = await context.Recipes
                .Include(x => x.ListOfIngredients)
                .ThenInclude(x => x.Ingredient)
                .ToListAsync();


            var ListOfRecipesDto = mapper.Map<List<RecipeDto>>(ListOfRecipes);

            return ListOfRecipesDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> Get(int id)
        {
            var recipe = await context.Recipes
                .Include(x => x.ListOfIngredients)
                .ThenInclude(x => x.Ingredient)
                .FirstOrDefaultAsync();

            var recipeDto = mapper.Map<RecipeDto>(recipe);

            if (recipe == null) { return new NotFoundResult(); }

            return recipeDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post(RecipeDto recipeDto)
        {
            var recipe = mapper.Map<Recipe>(recipeDto);

            context.Recipes.Add(recipe);

            await context.SaveChangesAsync();

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var recipeToRemove = context.Recipes.FirstOrDefault(x => x.Id == id);

            context.Recipes.Remove(recipeToRemove);
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

            return new OkResult();
        }
    }
}
