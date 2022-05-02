using Bootcamp.WebAPI.DTOs.ResponseDto;
using MediatR;

namespace Bootcamp.WebAPI.Commands.Product.Delete
{
    public class ProductDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
