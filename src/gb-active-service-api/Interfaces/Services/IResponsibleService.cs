using gb_active_service_api.Models;

namespace gb_active_service_api.Interfaces.Services
{
    public interface IResponsibleService : IDisposable
    {
        Task<List<Responsible>> GetAll();
        Task<Responsible> GetById(Guid id);
        
        Task Create(Responsible entity);

        Task CreateMany(List<Responsible> entities);

        Task Update(Responsible entity);

        Task Delete(Guid id);
    }
}
