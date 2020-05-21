namespace BlazorSample.Domain.Core.Interfaces.Notifications {
    public interface INotification {
        string Key { get; }
        string Message { get; }
    }
}