using System.ComponentModel.DataAnnotations;

namespace Organization.Feed.Web.Dependencies.Identity;

internal sealed class IdentityOptions
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;

    public bool MigrateOnStartup { get; set; }

    public bool SeedOnStartup { get; set; }
}
