using Microsoft.AspNetCore.SignalR;
using VakaCase.Domain.Entities;

namespace VakaCase.WebAPI.Hubs;

public class DeviceHub : Hub
{
    public async Task NotifyDeviceDeleted(string deviceId)
    {
        await Clients.Others.SendAsync("DeviceDeleted", deviceId);
    }

    public async Task NotifyDeviceAdded(Device device)
    {
        await Clients.Others.SendAsync("DeviceAdded", device);
    }

    public async Task NotifyDeviceUpdated(Device device)
    {
        await Clients.Others.SendAsync("DeviceUpdated", device);
    }
}