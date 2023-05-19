using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Interfaces.Repositories;
using gb_active_service_api.Interfaces.Services;
using gb_active_service_api.Models;

namespace gb_active_service_api.Services
{
    public class ActiveService : BaseService, IActiveService
    {
        private readonly IActiveRepository _activeRepository;

        public ActiveService(
            INotificator notificator,
            IActiveRepository activeRepository
            ) : base(notificator)
        {
            _activeRepository = activeRepository;
        }

        public async Task<List<Active>> GetAll()
        {
            return await _activeRepository.GetAll();
        }

        public async Task<Active> GetById(Guid id)
        {
            return await _activeRepository.GetById(id);
        }

        public async Task Create(Active active)
        {
            if (_activeRepository.GetByQuery(t => t.Name == active.Name).Result.Any())
            {
                Notificate("O ativo " + active.Name + " já está cadastrado.");
                return;
            }

            await _activeRepository.Create(active);
        }

        public async Task CreateMany(List<Active> actives)
        {
            await _activeRepository.CreateMany(actives);
        }

        public async Task Update(Active active)
        {
            if (_activeRepository.GetByQuery(t => t.Name == active.Name && t.Id != active.Id).Result.Any())
            {
                Notificate("O ativo " + active.Name + " já está cadastrado.");
                return;
            }

            await _activeRepository.Update(active);
        }

        public async Task Delete(Guid id)
        {
            await _activeRepository.Delete(id);
        }

        public void Dispose()
        {
            _activeRepository?.Dispose();
        }
    }
}
