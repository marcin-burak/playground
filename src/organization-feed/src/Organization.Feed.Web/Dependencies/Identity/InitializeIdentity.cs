using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Organization.Feed.Web.Dependencies.Identity;

internal sealed class InitializeIdentity(IdentityContext context, UserManager<IdentityUser<Guid>> userManager, IOptionsSnapshot<IdentityOptions> options)
{
    private readonly IdentityContext _context = context;
    private readonly UserManager<IdentityUser<Guid>> _userManager = userManager;
    private readonly IOptionsSnapshot<IdentityOptions> _options = options;


    public async ValueTask TryInitializeIdentity(CancellationToken cancellationToken)
    {
        if (_options.Value.MigrateOnStartup)
        {
            await _context.Database.MigrateAsync(cancellationToken);
        }

        if (_options.Value.SeedOnStartup)
        {
            var usersExist = await _context.Users.AnyAsync(cancellationToken);
            if (usersExist is false)
            {
                var result = await _userManager.CreateAsync(new IdentityUser<Guid>
                {
                    Id = Guid.Parse("3724daa9-fc2b-4100-bd14-a4ab1fd10b5a"),
                    UserName = "UserA"
                }, "P@ssw0rd");

                if (result.Succeeded is false)
                {
                    var errorMessage = string.Join("; ", result.Errors.Select(error => error.Description));
                    throw new InvalidOperationException($"Failed to seed identity database: '{errorMessage}'.");
                }
            }
        }
    }
}
