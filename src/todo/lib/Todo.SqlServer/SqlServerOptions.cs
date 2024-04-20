using FluentValidation;
using Todo.Common.FluentValidation;

namespace Todo.SqlServer;

public sealed class SqlServerOptions
{
    public string ConnectionString { get; set; } = string.Empty;
}

public sealed class SqlServerOptionsValidator : AbstractValidator<SqlServerOptions>
{
    public SqlServerOptionsValidator()
    {
        RuleFor(options => options.ConnectionString)
            .NotEmpty()
            .Trimmed()
            .WithName("SQL Server connection string.");
    }
}