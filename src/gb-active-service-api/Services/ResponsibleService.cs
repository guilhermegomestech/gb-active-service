using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Interfaces.Repositories;
using gb_active_service_api.Interfaces.Services;
using gb_active_service_api.Models;

namespace gb_active_service_api.Services
{
    public class ResponsibleService : BaseService, IResponsibleService
    {
        private readonly IResponsibleRepository _responsibleRepository;

        public ResponsibleService(
            INotificator notificator,
            IResponsibleRepository responsibleRepository
            ) : base(notificator)
        {
            _responsibleRepository = responsibleRepository;
        }

        public async Task<List<Responsible>> GetAll()
        {
            return await _responsibleRepository.GetAll();
        }

        public async Task<Responsible> GetById(Guid id)
        {
            return await _responsibleRepository.GetById(id);
        }

        public async Task Create(Responsible responsible)
        {
            if (_responsibleRepository.GetByQuery(t => t.Name == responsible.Name).Result.Any())
            {
                Notificate("O responsável " + responsible.Name + " já está cadastrado.");
                return;
            }

            await _responsibleRepository.Create(responsible);
        }

        public async Task CreateMany(List<Responsible> responsibles)
        {
            await _responsibleRepository.CreateMany(responsibles);
        }

        public async Task Update(Responsible responsible)
        {
            if (_responsibleRepository.GetByQuery(t => t.Name == responsible.Name && t.Id != responsible.Id).Result.Any())
            {
                Notificate("O responsável " + responsible.Name + " já está cadastrado.");
                return;
            }

            await _responsibleRepository.Update(responsible);
        }

        public async Task Delete(Guid id)
        {
            await _responsibleRepository.Delete(id);
        }

        public void Dispose()
        {
            _responsibleRepository?.Dispose();
        }
    }
}
