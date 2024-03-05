using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Organization.Feed.Web.Dependencies.Identity;

internal sealed class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityUserContext<IdentityUser<Guid>, Guid, IdentityUserClaim<Guid>, IdentityUserLogin<Guid>, IdentityUserToken<Guid>>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityUser<Guid>>()
            .ToTable("User")
            .HasKey(user => user.Id)
            .IsClustered(false);

        builder
            .Entity<IdentityUserLogin<Guid>>()
            .ToTable("Login")
            .HasKey(userLogin => new { userLogin.LoginProvider, userLogin.ProviderKey })
            .IsClustered(false);

        builder
            .Entity<IdentityUserToken<Guid>>()
            .ToTable("Token")
            .HasKey(userToken => new { userToken.UserId, userToken.LoginProvider, userToken.Name })
            .IsClustered(false);

        builder.Entity<IdentityUserClaim<Guid>>()
            .ToTable("Claim");
    }
}
