using Microsoft.AspNetCore.SignalR;
using VakaCase.Domain.Entities;

namespace VakaCase.WebAPI.Hubs;

public class DeviceHub : Hub
{
    public const string DeviceCreatedMethod = "DeviceCreated";
    public const string DeviceUpdatedMethod = "DeviceUpdated";
    public const string DeviceDeletedMethod = "DeviceDeleted";
    public const string DeviceViewedMethod = "DeviceViewed";

    public async Task NotifyDeviceDeleted(string deviceId)
    {
        await Clients.Others.SendAsync(DeviceDeletedMethod, deviceId);
    }

    public async Task NotifyDeviceAdded(Device device)
    {
        await Clients.Others.SendAsync(DeviceCreatedMethod, device);
    }

    public async Task NotifyDeviceUpdated(Device device)
    {
        await Clients.Others.SendAsync(DeviceUpdatedMethod, device);
    }
}