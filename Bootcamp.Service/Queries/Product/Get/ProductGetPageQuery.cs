using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Entities.Dtos;
using MediatR;

namespace Bootcamp.Service.Queries.Product.Get
{
    public class ProductGetPageQuery : IRequest<ResponseDto<List<ProductDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
