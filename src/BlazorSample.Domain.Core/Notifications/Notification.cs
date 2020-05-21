using BlazorSample.Domain.Core.Interfaces.Notifications;

namespace BlazorSample.Domain.Core.Notifications {
    public class Notification : INotification {
        public string Key { get; }
        public string Message { get; }

        public Notification (string key, string message) {
            Key = key;
            Message = message;
        }
    }
}