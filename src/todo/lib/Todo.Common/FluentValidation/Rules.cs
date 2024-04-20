using FluentValidation;

namespace Todo.Common.FluentValidation;

public static class Rules
{
    public static IRuleBuilderOptions<T, string> Trimmed<T>(this IRuleBuilderOptions<T, string> ruleBuilder) where T : class => ruleBuilder
        .Must(value => value.Length == value.Trim().Length)
            .WithMessage("{PropertyName} has to be trimmed.");

    public static IRuleBuilderOptions<T, Guid> NonEmptyGuid<T>(this IRuleBuilderOptions<T, Guid> ruleBuilder) where T : class => ruleBuilder
        .Must(value => value != Guid.Empty)
            .WithMessage("{PropertyName} has to be a non empty GUID.");

    public static IRuleBuilderOptions<T, IReadOnlyCollection<TItem>> NonEmptyGuid<T, TItem>(this IRuleBuilderOptions<T, IReadOnlyCollection<TItem>> ruleBuilder) where T : class => ruleBuilder
        .Must(collection => collection.Count == collection.Distinct().Count())
            .WithMessage("{PropertyName} has to contain distinct items.");
}
