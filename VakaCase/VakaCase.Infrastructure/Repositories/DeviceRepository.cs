using GenericRepository;
using VakaCase.Domain.Entities;
using VakaCase.Domain.Repositories;
using VakaCase.Infrastructure.Context;

namespace VakaCase.Infrastructure.Repositories;

internal sealed class DeviceRepository : Repository<Device, ApplicationDbContext>, IDeviceRepository
{
    public DeviceRepository(ApplicationDbContext context) : base(context)
    {

    }
}
