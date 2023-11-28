namespace KIKWebApi.Models;

public sealed class UserRole : Entity
{
    public string UserId { get; set; }
    public string RoleName { get; set; }
}