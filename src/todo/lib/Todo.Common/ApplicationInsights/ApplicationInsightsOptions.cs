using FluentValidation;
using Todo.Common.FluentValidation;

namespace Todo.Common.ApplicationInsights;

public sealed class ApplicationInsightsOptions
{
    public string ConnectionString { get; set; } = string.Empty;
}

public sealed class ApplicationInsightsOptionsValidator : AbstractValidator<ApplicationInsightsOptions>
{
    public ApplicationInsightsOptionsValidator()
    {
        RuleFor(options => options.ConnectionString)
            .NotEmpty()
            .Trimmed()
            .Must(value => value.Contains("IngestionKey="))
                .WithMessage("{PropertyName} has to contain ingestion key.")
            .WithName("Application Insights connection string.");
    }
}