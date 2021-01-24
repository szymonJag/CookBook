using AutoMapper;
using CookBook.Shared.Data.Dto;
using CookBook.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Server.Mappers
{
    public class IngredientMapper
    {
        private IMapper mapper;

        public IngredientMapper()
        {
            mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Ingredient, IngredientDto>()
                      .ReverseMap();
                
            }).CreateMapper();
        }

        public IngredientDto Map(Ingredient ingredient)
        {
            return mapper.Map<IngredientDto>(ingredient);
        }

        public Ingredient Map(IngredientDto ingredient)
        {
            return mapper.Map<Ingredient>(ingredient);
        }

        public List<IngredientDto> Map(List<Ingredient> ingredients)
        {
            return mapper.Map<List<Ingredient>, List<IngredientDto>>(ingredients);
        }
    }
}
