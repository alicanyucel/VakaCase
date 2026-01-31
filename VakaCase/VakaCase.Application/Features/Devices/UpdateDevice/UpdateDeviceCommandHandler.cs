using AutoMapper;
using GenericRepository;
using MediatR;
using TS.Result;
using VakaCase.Domain.Repositories;

namespace VakaCase.Application.Features.Devices.UpdateDevice;

internal sealed class UpdateDeviceCommandHandler(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateDeviceCommand, Result<string>>
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
        return Result<string>.Succeed("Cihaz başarıyla güncellendi.");
    }
}
