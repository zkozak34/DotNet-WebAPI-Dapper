using Bootcamp.Core.Dtos.ResponseDto;
using MediatR;

namespace Bootcamp.Service.Commands.Product.Update
{
    public class ProductUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
