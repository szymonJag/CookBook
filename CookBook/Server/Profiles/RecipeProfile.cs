using AutoMapper;
using CookBook.Shared.Data.Dto;
using CookBook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Server.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>()
                .ForMember(dest => dest.ListOfIngredients, conf => conf.MapFrom(src => src.ListOfIngredients))
                .ReverseMap();

            CreateMap<IngredientRecipe, IngredientRecipeDto>()
                .ForMember(dest => dest.Ingredient, conf => conf.MapFrom(src => src.Ingredient))
                .ForMember(dest => dest.Recipe, conf => conf.MapFrom(src => src.Recipe))
                .ReverseMap();
        }
    }
}
