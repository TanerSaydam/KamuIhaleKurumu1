using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Context;

public sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Ignore<IdentityUserToken<string>>();
        //builder.Ignore<IdentityUserClaim<string>>();
        //builder.Ignore<IdentityUserRole<string>>();
        //builder.Ignore<IdentityRoleClaim<string>>();
        //builder.Ignore<IdentityUserLogin<string>>();
    }
}
