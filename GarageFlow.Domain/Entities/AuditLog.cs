
namespace GarageFlow.Domain.Entities;

public class AuditLog : BaseEntity
{
    public Guid? WorkshopId { get; set; }
    public Guid? UserId { get; set; }

    public string Action { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? EntityId { get; set; }
    public string? Details { get; set; }
    public string? IpAddress { get; set; }
    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
}
