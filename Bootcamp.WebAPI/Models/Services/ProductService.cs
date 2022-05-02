using Bootcamp.WebAPI.DTOs;
using Bootcamp.WebAPI.DTOs.ResponseDto;
using Bootcamp.WebAPI.Repositories;

namespace Bootcamp.WebAPI.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #region Get All
        public async Task<ResponseDto<List<Product>>> GetAll() => ResponseDto<List<Product>>.Success(await _productRepository.GetAll(),200);
        #endregion

        #region Get By Id
        public async Task<ResponseDto<ProductDto>> GetById(int id)
        {
            var hasProduct = await _productRepository.GetById(id);
            //if (hasProduct == null)
            //    return ResponseDto<ProductDto>.Fail("Ürün bulunamadı", StatusCodes.Status404NotFound);
            return ResponseDto<ProductDto>.Success(new ProductDto(hasProduct),200);
        }
        #endregion

        #region Save
        public async Task<ResponseDto<ProductDto>> Save(Product product)
        {
            await _productRepository.Save(product);
            //return new CreatedAtRouteResult($"/api/products/{product.Id}",product);
            return ResponseDto<ProductDto>.Success(new ProductDto(await _productRepository.GetById(product.Id)),
                StatusCodes.Status201Created);
        }
        #endregion

        #region Delete
        public ResponseDto<NoContent> Delete(int id)
        {
            var hasProduct = _productRepository.GetById(id);
            //if (hasProduct == null)
            //    return ResponseDto<NoContent>.Fail("Ürün bulunamadı", StatusCodes.Status404NotFound);
            _productRepository.Delete(id);
            return ResponseDto<NoContent>.Success(StatusCodes.Status204NoContent);
        }
        #endregion

        #region Update
        public ResponseDto<NoContent> Update(Product product)
        {
            var hasProduct = _productRepository.GetById(product.Id);
            if (hasProduct == null)
                return ResponseDto<NoContent>.Fail("Ürün bulunamadı", StatusCodes.Status404NotFound);
            _productRepository.Update(product);
            return ResponseDto<NoContent>.Success(StatusCodes.Status204NoContent);
        }
        #endregion
    }
}
