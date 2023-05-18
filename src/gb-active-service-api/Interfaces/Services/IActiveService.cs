using gb_active_service_api.Models;

namespace gb_active_service_api.Interfaces.Services
{
    public interface IActiveService : IDisposable
    {
        Task<List<Active>> GetAll();
        Task<Active> GetById(Guid id);
        
        Task Create(Active active);

        Task CreateMany(List<Active> actives);

        Task Update(Active active);

        Task Delete(Guid id);
    }
}
