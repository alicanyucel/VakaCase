using FluentValidation;

namespace VakaCase.Application.Features.Devices.CreateDevices;

public sealed class CreateDeviceValidation : AbstractValidator<CreateDeviceCommand>
{
    public CreateDeviceValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Cihaz adı zorunludur.")
            .MinimumLength(2).WithMessage("Cihaz adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Cihaz adı en fazla 100 karakter olmalıdır.");

        RuleFor(x => x.SerialNumber)
            .NotEmpty().WithMessage("Seri numarası zorunludur.")
            .MinimumLength(3).WithMessage("Seri numarası en az 3 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Seri numarası en fazla 50 karakter olmalıdır.")
            .Matches("^[A-Za-z0-9-]+$")
            .WithMessage("Seri numarası sadece harf, rakam ve '-' karakteri içerebilir.");

        RuleFor(x => x.LastMaintenanceDate)
            .NotEmpty().WithMessage("Son bakım tarihi zorunludur.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Son bakım tarihi gelecek bir tarih olamaz.")
            .GreaterThan(new DateTime(2000, 1, 1)).WithMessage("Son bakım tarihi geçerli bir tarih olmalıdır.");

        RuleFor(x => x.isDeleted)
            .Equal(false)
            .WithMessage("Yeni oluşturulan cihaz silinmiş olarak işaretlenemez.");
    }
}
