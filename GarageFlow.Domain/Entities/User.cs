
namespace GarageFlow.Domain.Entities;

public class User : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid? RoleId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public Workshop Workshop { get; set; } = null!;
    public Role? Role { get; set; }
}
