using MediatR;
using TS.Result;
using VakaCase.Domain.Entities;
using VakaCase.Domain.Repositories;

namespace VakaCase.Application.Features.Devices.GetAlllDevice;

public sealed class GetAllDeviceQueryHandler(IDeviceRepository deviceRepository)
    : IRequestHandler<GetAllDeviceQuery, Result<List<Device>>>
{
    public Task<Result<List<Device>>> Handle(GetAllDeviceQuery request, CancellationToken cancellationToken)
    {
        var devices = deviceRepository.GetAll().Where(d => !d.IsDeleted).ToList();
        return Task.FromResult(Result<List<Device>>.Succeed(devices));
    }
}
