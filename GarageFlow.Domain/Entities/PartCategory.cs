
namespace GarageFlow.Domain.Entities;

public class PartCategory : BaseEntity
{
    public Guid WorkshopId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
