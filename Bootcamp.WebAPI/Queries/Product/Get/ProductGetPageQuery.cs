using Bootcamp.WebAPI.DTOs;
using Bootcamp.WebAPI.DTOs.ResponseDto;
using MediatR;

namespace Bootcamp.WebAPI.Queries.Product.Get
{
    public class ProductGetPageQuery : IRequest<ResponseDto<List<ProductDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
