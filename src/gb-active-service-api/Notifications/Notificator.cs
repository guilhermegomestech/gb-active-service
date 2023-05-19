using gb_active_service_api.Interfaces.Notifications;

namespace gb_active_service_api.Notifications
{
    public class Notificator : INotificator
    {
        private List<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
