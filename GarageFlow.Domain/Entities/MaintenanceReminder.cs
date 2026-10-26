
namespace GarageFlow.Domain.Entities;

public class MaintenanceReminder : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid VehicleId { get; set; }
    public Guid? CustomerId { get; set; }

    public string Description { get; set; } = string.Empty;
    public DateTime? ReminderDate { get; set; }
    public int? ReminderKilometer { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }

    public Vehicle Vehicle { get; set; } = null!;
    public Customer? Customer { get; set; }
}
