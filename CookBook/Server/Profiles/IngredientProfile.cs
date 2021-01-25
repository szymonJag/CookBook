using AutoMapper;
using CookBook.Shared.Data.Dto;
using CookBook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Server.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>()
                .ForMember(x => x.IngredientRecipe, opt=>opt.MapFrom(src=>src.IngredientRecipe))
                .ReverseMap();
        }
    }
}
