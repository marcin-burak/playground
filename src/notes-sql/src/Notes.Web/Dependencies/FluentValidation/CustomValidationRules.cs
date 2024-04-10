using FluentValidation;

namespace Notes.Web.Dependencies.FluentValidation;

public static class CustomValidationRules
{
    public static IRuleBuilder<T, string> Trimmed<T>(this IRuleBuilder<T, string> ruleBuilder) => ruleBuilder
        .Must(value => string.IsNullOrWhiteSpace(value) is false && value.Length == value.Trim().Length)
        .WithMessage("{PropertyName} has to be trimmed.");

    public static IRuleBuilder<T, string> SqlServerConnectionString<T>(this IRuleBuilder<T, string> ruleBuilder) => ruleBuilder
        .Must(value => string.IsNullOrWhiteSpace(value) is false && value.Contains("Server=") && value.Contains("Database="))
        .WithMessage("{PropertyName} has to be a valid SQL Server connection string, e.g. contain server and database parameters.");
}
