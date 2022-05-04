using Bootcamp.Core.Dtos.ResponseDto;
using MediatR;

namespace Bootcamp.Service.Queries.Product.Get
{
    public class ProductGetAllQuery : IRequest<ResponseDto<List<Entities.Entities.Concrete.Product>>>
    {
    }
}
