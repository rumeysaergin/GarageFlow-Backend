
namespace GarageFlow.Domain.Entities;

public class InvoiceItem : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid InvoiceId { get; set; }

    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }
    public decimal TaxRate { get; set; }
    public decimal Discount { get; set; }
    public decimal LineTotal { get; set; }

    public Invoice Invoice { get; set; } = null!;
}
