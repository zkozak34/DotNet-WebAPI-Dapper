using Bootcamp.WebAPI.DTOs;
using Bootcamp.WebAPI.DTOs.ResponseDto;
using MediatR;

namespace Bootcamp.WebAPI.Commands.Product.Add
{
    public class ProductAddCommand : IRequest<ResponseDto<NoContent>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
