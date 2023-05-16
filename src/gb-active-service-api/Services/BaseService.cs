using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Notifications;

namespace gb_active_service_api.Services
{
    public class BaseService
    {
        private readonly INotificator _notificator;

        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificate(string message)
        {
            _notificator.Handle(new Notification(message));
        }
    }
}
