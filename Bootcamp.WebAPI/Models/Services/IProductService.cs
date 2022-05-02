using Bootcamp.WebAPI.DTOs;
using Bootcamp.WebAPI.DTOs.ResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.WebAPI.Models.Services
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
