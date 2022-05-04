using Bootcamp.Core.Dtos.ResponseDto;
using MediatR;

namespace Bootcamp.Service.Commands.Product.Delete
{
    public class ProductDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
