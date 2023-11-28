using Microsoft.AspNetCore.Identity;

namespace Identity.Entities;

public sealed class AppUser : IdentityUser<string>
{
    public string NameLastName { get; set; }
}
