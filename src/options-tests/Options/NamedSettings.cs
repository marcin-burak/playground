namespace OptionsTests.Options;

public sealed class NamedSettings
{
    public const string RedSettings = nameof(RedSettings);
    public const string BlueSettings = nameof(BlueSettings);
    public const string GreenSettings = nameof(GreenSettings);

    public string Color { get; set; } = string.Empty;

    public bool Enabled { get; set; }
}
