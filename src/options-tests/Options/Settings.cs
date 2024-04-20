namespace OptionsTests.Options;

public sealed class Settings
{
    public string Content { get; set; } = string.Empty;

    public IReadOnlyCollection<string> Contents { get; set; } = Array.Empty<string>();

    public OptionSet Set { get; set; } = new();

    public IReadOnlyCollection<OptionSet> Sets { get; set; } = Array.Empty<OptionSet>();
}

public sealed class OptionSet
{
    public string Label { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}