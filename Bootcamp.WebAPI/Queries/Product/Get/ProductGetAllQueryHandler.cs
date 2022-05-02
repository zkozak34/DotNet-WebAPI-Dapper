using Bootcamp.WebAPI.DTOs.ResponseDto;
using Bootcamp.WebAPI.Repositories;
using MediatR;

namespace Bootcamp.WebAPI.Queries.Product.Get
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, ResponseDto<List<Models.Product>>>
    {
        private readonly IProductRepository _productRepository;

        public ProductGetAllQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<List<Models.Product>>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromRepository = await _productRepository.GetAll();
            if (responseFromRepository.Count < 1)
            {
                return ResponseDto<List<Models.Product>>.Fail(StatusCodes.Status500InternalServerError);
            }
            return ResponseDto<List<Models.Product>>.Success(responseFromRepository, StatusCodes.Status200OK);
        }
    }
}
