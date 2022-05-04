using Bootcamp.Core.Dtos.ResponseDto;
using MediatR;

namespace Bootcamp.Service.Queries.Product.Count
{
    public class ProductCountQuery : IRequest<ResponseDto<int>>
    {
    }
}
