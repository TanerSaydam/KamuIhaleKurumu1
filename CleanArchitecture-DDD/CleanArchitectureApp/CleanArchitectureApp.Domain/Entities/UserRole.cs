namespace CleanArchitectureApp.Domain.Entities;

public sealed class UserRole
{
    public string UserId { get; set; }
    public User User { get; set; }
    public string RoleId { get; set; }
    public Role Role { get; set; }
}