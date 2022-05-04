using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Entities.Concrete;
using Bootcamp.Entities.Dtos;

namespace Bootcamp.Service.Services.Abstract
{
    public interface IProductService
    {
        Task<ResponseDto<List<Product>>> GetAll();
        Task<ResponseDto<ProductDto>> GetById(int id);
        Task<ResponseDto<ProductDto>> Save(Product product);
        ResponseDto<NoContent> Delete(int id);
        ResponseDto<NoContent> Update(Product product);
    }
}
