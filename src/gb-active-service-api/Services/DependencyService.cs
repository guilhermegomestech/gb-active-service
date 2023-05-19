using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Interfaces.Repositories;
using gb_active_service_api.Interfaces.Services;
using gb_active_service_api.Models;

namespace gb_active_service_api.Services
{
    public class DependencyService : BaseService, IDependencyService
    {
        private readonly IDependencyRepository _dependencyRepository;

        public DependencyService(
            INotificator notificator,
            IDependencyRepository dependencyRepository
            ) : base(notificator)
        {
            _dependencyRepository = dependencyRepository;
        }

        public async Task<List<Dependency>> GetAll()
        {
            return await _dependencyRepository.GetAll();
        }

        public async Task<Dependency> GetById(Guid id)
        {
            return await _dependencyRepository.GetById(id);
        }

        public async Task Create(Dependency dependency)
        {
            if (_dependencyRepository.GetByQuery(t => t.Description == dependency.Description).Result.Any())
            {
                Notificate("A dependência " + dependency.Description + " já está cadastrada.");
                return;
            }

            await _dependencyRepository.Create(dependency);
        }

        public async Task CreateMany(List<Dependency> dependencys)
        {
            await _dependencyRepository.CreateMany(dependencys);
        }

        public async Task Update(Dependency dependency)
        {
            if (_dependencyRepository.GetByQuery(t => t.Description == dependency.Description && t.Id != dependency.Id).Result.Any())
            {
                Notificate("A dependência " + dependency.Description + " já está cadastrada.");
                return;
            }

            await _dependencyRepository.Update(dependency);
        }

        public async Task Delete(Guid id)
        {
            await _dependencyRepository.Delete(id);
        }

        public void Dispose()
        {
            _dependencyRepository?.Dispose();
        }
    }
}
