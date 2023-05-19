using gb_active_service_api.Models;
using System.Linq.Expressions;

namespace gb_active_service_api.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> GetByQuery(Expression<Func<TEntity, bool>> predicate);

        Task Create(TEntity entity);

        Task CreateMany(List<TEntity> entities);

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<int> SaveChanges();
    }
}
