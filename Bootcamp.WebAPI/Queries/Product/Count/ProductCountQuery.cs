using Bootcamp.WebAPI.DTOs.ResponseDto;
using MediatR;

namespace Bootcamp.WebAPI.Queries.Product.Count
{
    public class ProductCountQuery : IRequest<ResponseDto<int>>
    {
    }
}
