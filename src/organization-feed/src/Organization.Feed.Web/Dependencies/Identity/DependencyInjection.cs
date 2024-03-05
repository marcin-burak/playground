using Microsoft.AspNetCore.Identity;
using Organization.Feed.Web.Extensions;

namespace Organization.Feed.Web.Dependencies.Identity;

internal static class DependencyInjection
{
    public static IServiceCollection AddIdentityDependency(this IServiceCollection services, IConfiguration configuration) => services
        .AddOptionsByName<IdentityOptions>()
        .AddSqlServer<IdentityContext>(configuration.TryGetOptionsByName<IdentityOptions>()?.ConnectionString)
        .AddScoped<InitializeIdentity>()
        .AddIdentityCore<IdentityUser<Guid>>()
        .AddSignInManager()
        .AddEntityFrameworkStores<IdentityContext>()
        .Services
        .AddAuthentication()
        .AddApplicationCookie()
        .Services
        .ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "Authentication";
        });
}
