
namespace GarageFlow.Domain.Entities;

public class Vehicle : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid CustomerId { get; set; }

    public string PlateNumber { get; set; } = string.Empty;
    public string? VinNumber { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int? ModelYear { get; set; }
    public int? CurrentKilometer { get; set; }
    public string? FuelType { get; set; }
    public string? Notes { get; set; }

    public Workshop Workshop { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public ICollection<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();
    public ICollection<VehicleMaintenanceRecord> MaintenanceRecords { get; set; } = new List<VehicleMaintenanceRecord>();
}
