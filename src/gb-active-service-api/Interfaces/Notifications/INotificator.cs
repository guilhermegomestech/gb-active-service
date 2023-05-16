using gb_active_service_api.Notifications;

namespace gb_active_service_api.Interfaces.Notifications
{
    public interface INotificator
    {
        List<Notification> GetNotifications();
        bool HasNotification();
        void Handle(Notification notification);
    }
}
