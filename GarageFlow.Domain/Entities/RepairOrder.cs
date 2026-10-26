
namespace GarageFlow.Domain.Entities;

public class RepairOrder : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid VehicleId { get; set; }
    public Guid? AssignedTechnicianId { get; set; }

    public string OrderNumber { get; set; } = string.Empty;
    public string Complaint { get; set; } = string.Empty;
    public string? Diagnosis { get; set; }
    public string? Notes { get; set; }
    public string Status { get; set; } = "Received";
    public int? KilometerAtService { get; set; }
    public DateTime OpenedAt { get; set; } = DateTime.UtcNow;
    public DateTime? EstimatedCompletionAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public Workshop Workshop { get; set; } = null!;
    public Vehicle Vehicle { get; set; } = null!;
    public User? AssignedTechnician { get; set; }
    public ICollection<RepairOrderItem> Items { get; set; } = new List<RepairOrderItem>();
}
