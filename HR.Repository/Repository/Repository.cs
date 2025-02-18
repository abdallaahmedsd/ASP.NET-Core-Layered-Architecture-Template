using HR.Domain.Common.IRepository;
using HR.Repository.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.Repository.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(AppDbContext context) 
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Table => _dbSet.AsQueryable();

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> fillter)
        {
            return _dbSet.FirstOrDefault(fillter);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? fillter = null)
        {
            return fillter != null ? _dbSet.Where(fillter).AsEnumerable() : _dbSet.AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? fillter = null)
        {
            return  fillter != null ? await _dbSet.Where(fillter).ToListAsync() : await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> fillter)
        {
            return await _dbSet.FirstOrDefaultAsync(fillter);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
