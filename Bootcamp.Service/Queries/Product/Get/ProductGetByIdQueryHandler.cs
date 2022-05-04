using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Core.Utilities.Aspects;
using Bootcamp.Repository.Repositories;
using MediatR;

namespace Bootcamp.Service.Queries.Product.Get
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQuery, ResponseDto<Entities.Entities.Concrete.Product>>
    {
        private readonly IProductRepository _productRepository;

        public ProductGetByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [LoggerAspect]
        public async Task<ResponseDto<Entities.Entities.Concrete.Product>> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
        {
            var responseFromRepository = await _productRepository.GetById(request.Id);
            if (responseFromRepository == null)
            {
                return ResponseDto<Entities.Entities.Concrete.Product>.Fail(500);
            }
            return ResponseDto<Entities.Entities.Concrete.Product>.Success(responseFromRepository, 200);
        }
    }
}
