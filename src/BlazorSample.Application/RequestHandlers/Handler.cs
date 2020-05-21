using BlazorSample.Application.Interfaces.RequestHandlers;
using BlazorSample.Domain.Core.Interfaces.Notifications;

namespace BlazorSample.Application.RequestHandlers {
    public abstract class Handler {

        private readonly INotificationContext _notificationContext;
        protected INotificationContext NotificationContext => _notificationContext;

        public Handler (INotificationContext notificationContext) {
            _notificationContext = notificationContext;
        }

    }
}