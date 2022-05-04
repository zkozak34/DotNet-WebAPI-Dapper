using AutoMapper;
using Bootcamp.Entities.Concrete;
using Bootcamp.Entities.Dtos;

namespace Bootcamp.Service.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
