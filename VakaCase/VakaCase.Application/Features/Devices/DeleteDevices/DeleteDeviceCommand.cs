using MediatR;
using TS.Result;

namespace VakaCase.Application.Features.Devices.DeleteDevices;

public sealed record DeleteDeviceByIdCommand(
 Guid Id) : IRequest<Result<string>>;
