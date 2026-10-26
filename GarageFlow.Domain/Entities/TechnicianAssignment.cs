
namespace GarageFlow.Domain.Entities;

public class TechnicianAssignment : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid RepairOrderId { get; set; }
    public Guid UserId { get; set; }

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    public RepairOrder RepairOrder { get; set; } = null!;
    public User User { get; set; } = null!;
}
