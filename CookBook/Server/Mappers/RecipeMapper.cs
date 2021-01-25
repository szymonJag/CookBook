using AutoMapper;
using CookBook.Shared.Data.Dto;
using CookBook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Server.Mappers
{
    public class RecipeMapper
    {
        private IMapper mapper;

        public RecipeMapper()
        {
            mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Recipe, RecipeDto>()
                      .ForMember(dest => dest.ListOfIngredients, conf => conf.MapFrom(src => src.ListOfIngredients))
                      .ReverseMap();
            }).CreateMapper();

        }
        public RecipeDto Map(Recipe recipe)
        {
            return mapper.Map<RecipeDto>(recipe);
        }

        public Recipe Map(RecipeDto recipeDto)
        {
            return mapper.Map<Recipe>(recipeDto);
        }
        
        public List<RecipeDto> Map(List<Recipe> recipes)
        {
            return mapper.Map<List<Recipe>, List<RecipeDto>>(recipes);
        }
    }
}

