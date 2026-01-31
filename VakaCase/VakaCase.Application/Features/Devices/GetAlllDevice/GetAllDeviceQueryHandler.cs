using TS.Result;
using VakaCase.Domain.Entities;
using VakaCase.Domain.Repositories;

namespace VakaCase.Application.Features.Devices.GetAlllDevice;

public class GetAllDevicesQueryHandler
{
    private readonly IDeviceRepository _deviceRepository;

    public GetAllDevicesQueryHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<List<Device>>> Handle(GetAllDeviceQuery request, CancellationToken cancellationToken)
    {
        var devices = _deviceRepository.GetAll().Where(d => !d.IsDeleted).ToList();
        return Result<List<Device>>.Succeed(devices);
    }
}
