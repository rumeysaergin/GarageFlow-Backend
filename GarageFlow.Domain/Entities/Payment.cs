
namespace GarageFlow.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid InvoiceId { get; set; }

    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string PaymentMethod { get; set; } = string.Empty;
    public string? TransactionReference { get; set; }
    public string? Notes { get; set; }

    public Invoice Invoice { get; set; } = null!;
}
