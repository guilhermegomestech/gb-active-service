using gb_active_service_api.Data.Contexts;
using gb_active_service_api.Interfaces.Repositories;
using gb_active_service_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace gb_active_service_api.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ActivesDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ActivesDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetByQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task Create(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task CreateMany(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
