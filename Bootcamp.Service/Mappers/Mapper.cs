using AutoMapper;
using Bootcamp.Entities.Dtos;
using Bootcamp.Entities.Entities.Concrete;

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
