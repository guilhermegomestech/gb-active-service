using gb_active_service_api.Data.Contexts;
using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Interfaces.Repositories;
using gb_active_service_api.Models;
using gb_active_service_api.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace gb_active_service_api.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ActivesDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly INotificator _notificator;

        public Repository(ActivesDbContext context, INotificator notificator)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _notificator = notificator ?? throw new ArgumentNullException(nameof(notificator));
        }

        public async Task<List<TEntity>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _notificator.Handle(new Notification(ex.Message));
            }
            return null;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            try
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _notificator.Handle(new Notification(ex.Message));
            }
            return null;
        }

        public async Task<IEnumerable<TEntity>> GetByQuery(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                _notificator.Handle(new Notification(ex.Message));
            }
            return null;
        }

        public async Task Create(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                _notificator.Handle(new Notification(ex.Message));
            }
        }

        public async Task CreateMany(List<TEntity> entities)
        {
            try
            {
                _dbSet.AddRange(entities);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                _notificator.Handle(new Notification(ex.Message));
            }
        }

        public async Task Update(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                _notificator.Handle(new Notification(ex.Message));
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                _dbSet.Remove(new TEntity { Id = id });
                await SaveChanges();
            }
            catch (Exception ex)
            {
                _notificator.Handle(new Notification(ex.Message));
            }
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
