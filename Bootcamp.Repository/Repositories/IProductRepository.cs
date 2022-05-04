using Bootcamp.Entities.Entities.Concrete;

namespace Bootcamp.Repository.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<bool> Save(Product product);
        Task<bool> Delete(int id);
        Task<bool> Update(Product product);
        Task<List<Product>> GetWithPage(int page, int pagesize);

        Task<bool> TransferByStoreProcedure(AccountTransfer accountTransferCommand);
        Task<bool> Transfer(AccountTransfer accountTransferCommand);
        Task<int> TotalCountByFunction();
    }
}
