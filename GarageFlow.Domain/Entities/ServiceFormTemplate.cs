
namespace GarageFlow.Domain.Entities;

public class ServiceFormTemplate : BaseEntity
{
    public Guid WorkshopId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? TemplateContent { get; set; }
    public bool IsActive { get; set; } = true;
}
