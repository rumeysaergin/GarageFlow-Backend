
namespace GarageFlow.Domain.Entities;

public class Subscription : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid SubscriptionPlanId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = "Pending";

    public Workshop Workshop { get; set; } = null!;
    public SubscriptionPlan SubscriptionPlan { get; set; } = null!;
}
