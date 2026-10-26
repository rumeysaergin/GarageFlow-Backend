
namespace GarageFlow.Domain.Entities;

public class Invoice : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? RepairOrderId { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal Subtotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Unpaid";
    public string? Notes { get; set; }

    public Customer Customer { get; set; } = null!;
    public RepairOrder? RepairOrder { get; set; }
    public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
