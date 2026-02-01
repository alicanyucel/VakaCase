using Microsoft.AspNetCore.SignalR;
using VakaCase.Application.Abstractions;
using VakaCase.WebAPI.Hubs;

namespace VakaCase.Infrastructure.SignalR;

internal sealed class SignalRDeviceNotifier : IDeviceNotifier
{
    private readonly IHubContext<DeviceHub> _hubContext;

    public SignalRDeviceNotifier(IHubContext<DeviceHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public Task DeviceCreatedAsync(object payload, CancellationToken cancellationToken)
    {
        return _hubContext.Clients.All
            .SendAsync(DeviceHub.DeviceCreatedMethod, payload, cancellationToken);
    }

    public Task DeviceUpdatedAsync(object payload, CancellationToken cancellationToken)
    {
        return _hubContext.Clients.All
            .SendAsync(DeviceHub.DeviceUpdatedMethod, payload, cancellationToken);
    }

    public Task DeviceDeletedAsync(object payload, CancellationToken cancellationToken)
    {
        return _hubContext.Clients.All
            .SendAsync(DeviceHub.DeviceDeletedMethod, payload, cancellationToken);
    }

    public Task DeviceViewedAsync(object payload, CancellationToken cancellationToken)
    {
        return _hubContext.Clients.All
            .SendAsync(DeviceHub.DeviceViewedMethod, payload, cancellationToken);
    }
}