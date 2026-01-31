using MediatR;
using TS.Result;
using VakaCase.Domain.Entities;

namespace VakaCase.Application.Features.Devices.GetAlllDevice;

public sealed record GetAllDeviceQuery() : IRequest<Result<List<Device>>>;
