namespace Todo.Common.Domain;

public sealed class TodoListTitle
{
    public TodoListTitle(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        value = value.Trim();

        if (value.Length < MinLength)
        {
            throw new ArgumentException($"Title has to be at least {MinLength} characters long.", nameof(value));
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"Title has to be at most {MaxLength} characters long.", nameof(value));
        }

        Value = value;
    }

    public string Value { get; }

    public const int MinLength = 1;

    public const int MaxLength = 500;

    public override string ToString() => Value;
}
