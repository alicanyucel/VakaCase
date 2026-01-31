using MediatR;
using TS.Result;
using VakaCase.Domain.Repositories;

namespace VakaCase.Application.Features.Devices.DeleteDevices;

public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, Result<string>>
{
    private readonly IDeviceRepository _deviceRepository;

    public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<string>> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await _deviceRepository.GetByExpressionAsync(d => d.Id == request.Id, cancellationToken);
        if (device == null || device.IsDeleted)
        return Result<string>.Failure("Cihaz bulunamadı veya zaten silinmiş.");
        device.IsDeleted = true;
        _deviceRepository.Update(device);
        return Result<string>.Succeed("Cihaz başarıyla soft delete yapıldı.");
    }
}
