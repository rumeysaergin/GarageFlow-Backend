
namespace GarageFlow.Domain.Entities;

public class PurchaseOrderItem : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid PurchaseOrderId { get; set; }
    public Guid PartId { get; set; }

    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }

    public PurchaseOrder PurchaseOrder { get; set; } = null!;
    public Part Part { get; set; } = null!;
}
