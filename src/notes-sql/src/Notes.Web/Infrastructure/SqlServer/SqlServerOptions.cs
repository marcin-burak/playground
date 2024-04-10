using FluentValidation;
using Notes.Web.Dependencies.FluentValidation;

namespace Notes.Web.Infrastructure.SqlServer;

public sealed class SqlServerOptions
{
    public string ConnectionString { get; set; } = string.Empty;
}

public sealed class SqlServerOptionsValidator : OptionsValidator<SqlServerOptions>
{
    public SqlServerOptionsValidator() : base()
    {
        RuleFor(options => options.ConnectionString)
            .NotEmpty()
            .Trimmed()
            .SqlServerConnectionString();
    }
}