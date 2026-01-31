using MediatR;
using TS.Result;
using VakaCase.Domain.Entities;

namespace VakaCase.Application.Features.Devices.GetByIdDevice;

public sealed record GetByIdDeviceQuery(Guid Id) : IRequest<Result<Device>>;
