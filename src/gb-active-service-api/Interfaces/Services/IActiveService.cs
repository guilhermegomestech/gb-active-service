using gb_active_service_api.Models;

namespace gb_active_service_api.Interfaces.Services
{
    public interface IActiveService : IDisposable
    {
        Task<List<Active>> GetAll();
        Task<Active> GetById(Guid id);
        
        Task Create(Active entity);

        Task CreateMany(List<Active> entities);

        Task Update(Active entity);

        Task Delete(Guid id);
    }
}
