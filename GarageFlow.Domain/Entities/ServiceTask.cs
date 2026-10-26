
namespace GarageFlow.Domain.Entities;

public class ServiceTask : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid RepairOrderId { get; set; }
    public Guid? AssignedUserId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public RepairOrder RepairOrder { get; set; } = null!;
    public User? AssignedUser { get; set; }
}
