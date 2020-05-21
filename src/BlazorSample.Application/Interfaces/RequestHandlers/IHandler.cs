using BlazorSample.Domain.Core.Notifications;

namespace BlazorSample.Application.Interfaces.RequestHandlers {
    public interface IHandler {
        NotificationContext NotificationContext { get; }
    }
}