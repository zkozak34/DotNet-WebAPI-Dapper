using AutoMapper;
using Bootcamp.WebAPI.DTOs;
using Bootcamp.WebAPI.Models;

namespace Bootcamp.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
