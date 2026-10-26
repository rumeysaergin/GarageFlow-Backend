
namespace GarageFlow.Domain.Entities;

public class StockMovement : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid PartId { get; set; }
    public Guid? RepairOrderId { get; set; }

    public string MovementType { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public string? ReferenceNumber { get; set; }
    public string? Notes { get; set; }
    public DateTime MovementDate { get; set; } = DateTime.UtcNow;

    public Part Part { get; set; } = null!;
    public RepairOrder? RepairOrder { get; set; }
}
