using Bootcamp.Core.Dtos.ResponseDto;
using MediatR;

namespace Bootcamp.Service.Commands.Product.Add
{
    public class ProductAddCommand : IRequest<ResponseDto<NoContent>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
