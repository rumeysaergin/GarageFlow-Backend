
namespace GarageFlow.Domain.Entities;

public class VehicleMaintenanceRecord : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid VehicleId { get; set; }

    public string Description { get; set; } = string.Empty;
    public DateTime MaintenanceDate { get; set; }
    public int? Kilometer { get; set; }
    public int? NextMaintenanceKilometer { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }
    public decimal? Cost { get; set; }
    public string? Notes { get; set; }

    public Vehicle Vehicle { get; set; } = null!;
}
