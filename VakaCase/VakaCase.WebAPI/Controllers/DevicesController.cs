using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VakaCase.Application.Features.Devices.CreateDevices;
using VakaCase.Application.Features.Devices.DeleteDevices;
using VakaCase.Application.Features.Devices.GetAlllDevice;
using VakaCase.Application.Features.Devices.GetByIdDevice;
using VakaCase.Application.Features.Devices.UpdateDevice;
using VakaCase.WebAPI.Abstractions;

namespace VakaCase.WebAPI.Controllers;

[AllowAnonymous]
public class DevicesController : ApiController
{
    public DevicesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetById([FromBody] GetByIdDeviceQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);

        if (result is null)
        {
            return NotFound(new { message = "Cihaz bulunamadı." });
        }

        if (result.IsSuccessful is false)
        {
            return BadRequest(new { message = result.ToString() });
        }

        if (result.Data is null)
        {
            return NotFound(new { message = "Cihaz bulunamadı." });
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        if (response.IsSuccessful)
        {
            return StatusCode(response.StatusCode, new { message = "Cihaz başarıyla oluşturuldu.", data = response.Data });
        }

        return StatusCode(response.StatusCode, new { message = response.ToString() });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        if (response.IsSuccessful)
        {
            return StatusCode(response.StatusCode, new { message = "Cihaz başarıyla silindi.", data = response.Data });
        }

        return StatusCode(response.StatusCode, new { message = response.ToString() });

    }

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllDeviceQuery(), cancellationToken);

        if (response.IsSuccessful is false)
        {
            return BadRequest(new { message = response.ToString() });
        }

        return Ok(response);

    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateDeviceCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        if (response.IsSuccessful)
        {
            return StatusCode(response.StatusCode, new { message = "Cihaz başarıyla güncellendi.", data = response.Data });
        }
        return StatusCode(response.StatusCode, new { message = response.ToString() });

    }

}
