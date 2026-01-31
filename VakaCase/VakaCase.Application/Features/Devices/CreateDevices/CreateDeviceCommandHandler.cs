using AutoMapper;
using GenericRepository;
using MediatR;
using TS.Result;
using VakaCase.Domain.Entities;
using VakaCase.Domain.Repositories;

namespace VakaCase.Application.Features.Devices.CreateDevices;

internal sealed class CreateDeviceCommandHandler(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateDeviceCommand, Result<string>>
{
    public IDeviceRepository DeviceRepository { get; } = deviceRepository;

    public async Task<Result<string>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        Device device = mapper.Map<Device>(request);
        await DeviceRepository.AddAsync(device, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Cihaz eklendi.";
    }
}
