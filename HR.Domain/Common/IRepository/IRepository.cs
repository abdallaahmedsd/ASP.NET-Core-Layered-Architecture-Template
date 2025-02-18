using System.Linq.Expressions;

namespace HR.Domain.Common.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? fillter = null);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? fillter = null);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> fillter);
        TEntity? Get(Expression<Func<TEntity, bool>> fillter);
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Table { get; }
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
