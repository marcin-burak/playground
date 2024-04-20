using FluentValidation;

namespace Todo.Web.Api.Dependencies.OpenApi;

public sealed class OpenApiOptions
{
    public bool Enabled { get; set; }
}

public sealed class OpenApiOptionsValidator : AbstractValidator<OpenApiOptions>
{
    public OpenApiOptionsValidator(IWebHostEnvironment environment)
    {
        When(options => options.Enabled && environment.IsProduction(), () =>
        {
            RuleFor(options => options.Enabled)
                .Equal(false)
                .WithMessage("Open API definition has to be disabled in production environment.");
        });
    }
}