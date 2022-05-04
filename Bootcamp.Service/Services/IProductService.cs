using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Entities.Dtos;
using Bootcamp.Entities.Entities.Concrete;

namespace Bootcamp.Service.Services
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
