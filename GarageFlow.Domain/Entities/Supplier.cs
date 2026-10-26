
namespace GarageFlow.Domain.Entities;

public class Supplier : BaseEntity
{
    public Guid WorkshopId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? ContactPerson { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? TaxNumber { get; set; }
    public string? Notes { get; set; }

    public ICollection<Part> Parts { get; set; } = new List<Part>();
    public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
