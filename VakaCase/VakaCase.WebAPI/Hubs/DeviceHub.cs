using Microsoft.AspNetCore.SignalR;

namespace VakaCase.WebAPI.Hubs;

public sealed class DeviceHub : Hub
{
    public const string DeviceCreatedMethod = "deviceCreated";
    public const string DeviceUpdatedMethod = "deviceUpdated";
    public const string DeviceDeletedMethod = "deviceDeleted";
    public const string DeviceViewedMethod = "deviceViewed";
}
