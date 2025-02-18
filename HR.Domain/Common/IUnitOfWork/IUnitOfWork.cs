using HR.Domain.Common.IRepository;

namespace HR.Domain.Common.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync();

        void StartTransaction();
        Task StartTransactionAsync();

        void Commit();
        Task CommitAsync();

        void Rollback();
        Task RollbackAsync();
    }
}
