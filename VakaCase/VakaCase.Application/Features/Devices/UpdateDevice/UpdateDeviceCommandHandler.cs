using AutoMapper;
using GenericRepository;
using MediatR;
using TS.Result;
using VakaCase.Application.Abstractions;
using VakaCase.Domain.Repositories;

namespace VakaCase.Application.Features.Devices.UpdateDevice;

internal sealed class UpdateDeviceCommandHandler(
    IDeviceRepository deviceRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IDeviceNotifier deviceNotifier) : IRequestHandler<UpdateDeviceCommand, Result<string>>
{
    public IDeviceRepository DeviceRepository { get; } = deviceRepository;

    public async Task<Result<string>> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await DeviceRepository.GetByExpressionAsync(d => d.Id == request.Id, cancellationToken);
        if (device is null || device.IsDeleted)
        return Result<string>.Failure("Cihaz bulunamadı.");
        mapper.Map(request, device);
        DeviceRepository.Update(device);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await deviceNotifier.DeviceUpdatedAsync(new
        {
            device.Id,
            device.Name,
            device.SerialNumber,
            device.IsActive,
            device.LastMaintenanceDate,
            device.IsDeleted
        }, cancellationToken);

        return Result<string>.Succeed("Cihaz başarıyla güncellendi.");
    }
}
