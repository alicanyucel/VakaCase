using AutoMapper;
using GenericRepository;
using MediatR;
using TS.Result;
using VakaCase.Domain.Entities;
using VakaCase.Domain.Repositories;
using VakaCase.Application.Abstractions;

namespace VakaCase.Application.Features.Devices.CreateDevices;

internal sealed class CreateDeviceCommandHandler(
    IDeviceRepository deviceRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IDeviceNotifier deviceNotifier) : IRequestHandler<CreateDeviceCommand, Result<string>>
{
    public IDeviceRepository DeviceRepository { get; } = deviceRepository;

    public async Task<Result<string>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        Device device = mapper.Map<Device>(request);
        await DeviceRepository.AddAsync(device, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await deviceNotifier.DeviceCreatedAsync(new
        {
            device.Id,
            device.Name,
            device.SerialNumber,
            device.IsActive,
            device.LastMaintenanceDate
        }, cancellationToken);

        return "Cihaz eklendi.";
    }
}
