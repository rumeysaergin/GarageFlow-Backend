
namespace GarageFlow.Domain.Entities;

public class SupplierPayment : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid SupplierId { get; set; }
    public Guid? PurchaseOrderId { get; set; }

    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string PaymentMethod { get; set; } = string.Empty;
    public string? ReferenceNumber { get; set; }
    public string? Notes { get; set; }

    public Supplier Supplier { get; set; } = null!;
    public PurchaseOrder? PurchaseOrder { get; set; }
}
