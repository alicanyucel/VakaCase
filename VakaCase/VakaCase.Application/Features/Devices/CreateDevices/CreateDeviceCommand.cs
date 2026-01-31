using MediatR;
using TS.Result;

namespace VakaCase.Application.Features.Devices.CreateDevices;

public sealed record CreateDeviceCommand(string Name, string SerialNumber,bool IsActive,DateTime LastMaintenanceDate,bool isDeleted) : IRequest<Result<string>>;
