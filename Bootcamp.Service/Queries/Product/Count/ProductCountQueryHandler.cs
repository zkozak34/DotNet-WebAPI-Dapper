using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Repository.Repositories;
using MediatR;

namespace Bootcamp.Service.Queries.Product.Count
{
    public class ProductCountQueryHandler : IRequestHandler<ProductCountQuery, ResponseDto<int>>
    {
        private readonly IProductRepository _productRepository;

        public ProductCountQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<int>> Handle(ProductCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _productRepository.TotalCountByFunction();
            return ResponseDto<int>.Success(count, 200);
        }
    }
}
