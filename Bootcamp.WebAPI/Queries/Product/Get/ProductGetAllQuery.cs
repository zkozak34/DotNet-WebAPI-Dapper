using Bootcamp.WebAPI.DTOs.ResponseDto;
using MediatR;

namespace Bootcamp.WebAPI.Queries.Product.Get
{
    public class ProductGetAllQuery : IRequest<ResponseDto<List<Models.Product>>>
    {
    }
}
