using MediatR;
using TS.Result;
using VakaCase.Application.Abstractions;
using GenericRepository;
using VakaCase.Domain.Repositories;

namespace VakaCase.Application.Features.Devices.DeleteDevices;

public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, Result<string>>
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDeviceNotifier _deviceNotifier;

    public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork, IDeviceNotifier deviceNotifier)
    {
        _deviceRepository = deviceRepository;
        _unitOfWork = unitOfWork;
        _deviceNotifier = deviceNotifier;
    }

    public async Task<Result<string>> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await _deviceRepository.GetByExpressionAsync(d => d.Id == request.Id, cancellationToken);
        if (device == null || device.IsDeleted)
        return Result<string>.Failure("Cihaz bulunamadı veya zaten silinmiş.");
        device.IsDeleted = true;
        _deviceRepository.Update(device);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _deviceNotifier.DeviceDeletedAsync(new
        {
            device.Id
        }, cancellationToken);

        return Result<string>.Succeed("Cihaz başarıyla soft delete yapıldı.");
    }
}
