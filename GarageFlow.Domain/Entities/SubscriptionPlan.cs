
namespace GarageFlow.Domain.Entities;

public class SubscriptionPlan : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int DurationInDays { get; set; } = 30;
    public int MaxUsers { get; set; } = 3;
    public bool IsActive { get; set; } = true;
}
