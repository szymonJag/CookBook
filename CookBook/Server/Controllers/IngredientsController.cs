﻿using AutoMapper;
using CookBook.Shared.Data.Dto;
using CookBook.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
namespace CookBook.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public IngredientsController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<List<IngredientDto>>> Get()
        {

            var ListOfIngredients = await context.Ingredients.ToListAsync();

            var ListOfIngredientsDto = mapper.Map<List<IngredientDto>>(ListOfIngredients);

            return ListOfIngredientsDto;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDto>> Get(int id)
        {
            var ingredient = await context.Ingredients
                .Include(x => x.IngredientRecipe)
                .FirstOrDefaultAsync(x => x.Id == id);

            var ingredientDto = mapper.Map<IngredientDto>(ingredient);

            if (ingredient == null) { return new NoContentResult(); }

            return ingredientDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(IngredientDto ingredientDto)
        {
            var entity = mapper.Map<Ingredient>(ingredientDto);

            context.Ingredients.Add(entity);
            await context.SaveChangesAsync();

            return entity.Id;

            
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var ingredientToRemove = context.Ingredients.FirstOrDefault(x => x.Id == id);

            context.Ingredients.Remove(ingredientToRemove);
            await context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task<ActionResult> Put(IngredientDto ingredientDto)
        {
            var ingredient = mapper.Map<Ingredient>(ingredientDto);

            if (!context.Ingredients.Contains(ingredient))
            {
                return new BadRequestResult();
            }

            context.Entry(ingredient).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
