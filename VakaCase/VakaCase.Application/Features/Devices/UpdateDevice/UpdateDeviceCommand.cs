using MediatR;
using TS.Result;

namespace VakaCase.Application.Features.Devices.UpdateDevice;

public sealed record UpdateDeviceCommand(Guid Id,string Name, string SerialNumber, bool IsActive, DateTime LastMaintenanceDate, bool isDeleted) : IRequest<Result<string>>;
