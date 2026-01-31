using MediatR;
using VakaCase.WebAPI.Abstractions;

namespace VakaCase.WebAPI.Controllers;

public class DevicesController : ApiController
{
    public DevicesController(IMediator mediator) : base(mediator)
    {
    }
}
