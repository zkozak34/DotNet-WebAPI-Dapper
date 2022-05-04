using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Repository.Abstract;
using MediatR;

namespace Bootcamp.Service.Queries.Product.Get
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, ResponseDto<List<Entities.Concrete.Product>>>
    {
        private readonly IProductRepository _productRepository;

        public ProductGetAllQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<List<Entities.Concrete.Product>>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromRepository = await _productRepository.GetAll();
            if (responseFromRepository.Count < 1)
            {
                return ResponseDto<List<Entities.Concrete.Product>>.Fail(500);
            }
            return ResponseDto<List<Entities.Concrete.Product>>.Success(responseFromRepository, 200);
        }
    }
}
