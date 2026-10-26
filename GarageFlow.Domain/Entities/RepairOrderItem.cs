
namespace GarageFlow.Domain.Entities;

public class RepairOrderItem : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid RepairOrderId { get; set; }
    public Guid? PartId { get; set; }

    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }
    public decimal LaborCost { get; set; }
    public decimal Discount { get; set; }

    public RepairOrder RepairOrder { get; set; } = null!;
    public Part? Part { get; set; }
}
