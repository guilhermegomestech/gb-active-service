using gb_active_service_api.Models;

namespace gb_active_service_api.Interfaces.Services
{
    public interface IDependencyService : IDisposable
    {
        Task<List<Dependency>> GetAll();
        Task<Dependency> GetById(Guid id);
        
        Task Create(Dependency entity);

        Task CreateMany(List<Dependency> entities);

        Task Update(Dependency entity);

        Task Delete(Guid id);
    }
}
