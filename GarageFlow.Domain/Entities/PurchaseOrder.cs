
namespace GarageFlow.Domain.Entities;

public class PurchaseOrder : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid SupplierId { get; set; }

    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    public Supplier Supplier { get; set; } = null!;
    public ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
}
