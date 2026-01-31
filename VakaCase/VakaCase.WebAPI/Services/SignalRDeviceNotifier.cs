using Microsoft.AspNetCore.SignalR;
using VakaCase.Application.Abstractions;
using VakaCase.WebAPI.Hubs;

namespace VakaCase.WebAPI.Services;

internal sealed class SignalRDeviceNotifier(IHubContext<DeviceHub> hubContext) : IDeviceNotifier
{
    public Task DeviceCreatedAsync(object payload, CancellationToken cancellationToken)
    {
        return hubContext.Clients.All.SendAsync(DeviceHub.DeviceCreatedMethod, payload, cancellationToken);
    }

    public Task DeviceUpdatedAsync(object payload, CancellationToken cancellationToken)
    {
        return hubContext.Clients.All.SendAsync(DeviceHub.DeviceUpdatedMethod, payload, cancellationToken);
    }

    public Task DeviceDeletedAsync(object payload, CancellationToken cancellationToken)
    {
        return hubContext.Clients.All.SendAsync(DeviceHub.DeviceDeletedMethod, payload, cancellationToken);
    }

    public Task DeviceViewedAsync(object payload, CancellationToken cancellationToken)
    {
        return hubContext.Clients.All.SendAsync(DeviceHub.DeviceViewedMethod, payload, cancellationToken);
    }
}
