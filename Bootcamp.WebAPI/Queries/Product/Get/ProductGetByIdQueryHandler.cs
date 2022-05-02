using Bootcamp.WebAPI.DTOs.ResponseDto;
using Bootcamp.WebAPI.Repositories;
using MediatR;

namespace Bootcamp.WebAPI.Queries.Product.Get
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQuery, ResponseDto<Models.Product>>
    {
        private readonly IProductRepository _productRepository;

        public ProductGetByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<Models.Product>> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
        {
            var responseFromRepository = await _productRepository.GetById(request.Id);
            if (responseFromRepository == null)
            {
                return ResponseDto<Models.Product>.Fail(StatusCodes.Status500InternalServerError);
            }
            return ResponseDto<Models.Product>.Success(responseFromRepository, StatusCodes.Status200OK);
        }
    }
}
