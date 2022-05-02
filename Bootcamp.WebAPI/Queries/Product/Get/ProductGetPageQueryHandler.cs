using AutoMapper;
using Bootcamp.WebAPI.DTOs;
using Bootcamp.WebAPI.DTOs.ResponseDto;
using Bootcamp.WebAPI.Repositories;
using MediatR;

namespace Bootcamp.WebAPI.Queries.Product.Get
{
    public class ProductGetPageQueryHandler : IRequestHandler<ProductGetPageQuery, ResponseDto<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductGetPageQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<ProductDto>>> Handle(ProductGetPageQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _productRepository.GetWithPage(request.Page, request.PageSize);
            if (responseFromDb.Count < 1)
                return ResponseDto<List<ProductDto>>.Fail("Belirtilen aralıkta ürün bulunamadı!", StatusCodes.Status500InternalServerError);
            return ResponseDto<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(responseFromDb), StatusCodes.Status200OK);
        }
    }
}
