using MediatR;
using TS.Result;
using VakaCase.Domain.Entities;
using VakaCase.Domain.Repositories;

namespace VakaCase.Application.Features.Devices.GetByIdDevice;


public sealed class GetByIdDeviceQueryHandler(IDeviceRepository deviceRepository) : IRequestHandler<GetByIdDeviceQuery, Result<Device>>
{
    public async Task<Result<Device>> Handle(GetByIdDeviceQuery request, CancellationToken cancellationToken)
    {
        var device = await deviceRepository.GetByExpressionAsync(d => d.Id == request.Id, cancellationToken);
        if (device is null || device.IsDeleted)
        return Result<Device>.Failure("Cihaz bulunamadı.");
        return Result<Device>.Succeed(device);
    }
}