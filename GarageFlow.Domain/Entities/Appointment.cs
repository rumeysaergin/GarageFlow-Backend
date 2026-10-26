
namespace GarageFlow.Domain.Entities;

public class Appointment : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid VehicleId { get; set; }

    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = "Scheduled";
    public string? Notes { get; set; }

    public Customer Customer { get; set; } = null!;
    public Vehicle Vehicle { get; set; } = null!;
}
