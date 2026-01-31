using AutoMapper;
using VakaCase.Application.Features.Devices.CreateDevices;
using VakaCase.Application.Features.Devices.UpdateDevice;
using VakaCase.Domain.Entities;

namespace VakaCase.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDeviceCommand, Device>().ReverseMap();
        CreateMap<UpdateDeviceCommand, Device>().ReverseMap();
    }
}
