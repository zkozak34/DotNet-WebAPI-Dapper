using System.Data;

namespace Bootcamp.WebAPI.Repositories
{
    public class UnitOfWork
    {
        private readonly IDbTransaction _transaction;

        public UnitOfWork(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }
    }
}
