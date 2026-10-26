
namespace GarageFlow.Domain.Entities;

public class Expense : BaseEntity
{
    public Guid WorkshopId { get; set; }

    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; } = DateTime.UtcNow;
    public string? PaymentMethod { get; set; }
    public string? DocumentNumber { get; set; }
    public string? Notes { get; set; }
}
