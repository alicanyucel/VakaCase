using VakaCase.Domain.Abstractions;

namespace VakaCase.Domain.Entities;

public class Device:Entity
{
    public string Name { get; set; } = default!;
    public string SerialNumber { get; set; } = default!;
    public bool IsActive { get; set; } = false;
    public DateTime LastMaintenanceDate { get; set; }
    public bool IsDeleted { get; set; }=false;
}
