using Bootcamp.Core.Dtos.ResponseDto;
using MediatR;

namespace Bootcamp.Service.Queries.Product.Get
{
    public class ProductGetByIdQuery : IRequest<ResponseDto<Entities.Concrete.Product>>
    {
        public int Id { get; set; }
    }
}
