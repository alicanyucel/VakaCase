namespace VakaCase.Application.Abstractions;

public interface IDeviceNotifier
{
    Task DeviceCreatedAsync(object payload, CancellationToken cancellationToken);
    Task DeviceUpdatedAsync(object payload, CancellationToken cancellationToken);
    Task DeviceDeletedAsync(object payload, CancellationToken cancellationToken);
    Task DeviceViewedAsync(object payload, CancellationToken cancellationToken);
}
