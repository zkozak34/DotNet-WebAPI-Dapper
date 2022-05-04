using Bootcamp.WebAPI.Commands.Transfer;
using Bootcamp.WebAPI.Models;

namespace Bootcamp.WebAPI.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<bool> Save(Product product);
        Task<bool> Delete(int id);
        Task<bool> Update(Product product);
        Task<List<Product>> GetWithPage(int page, int pagesize);

        Task<bool> TransferByStoreProcedure(AccountTransferCommand accountTransferCommand);
        Task<bool> Transfer(AccountTransferCommand accountTransferCommand);
        Task<int> TotalCountByFunction();
    }
}
