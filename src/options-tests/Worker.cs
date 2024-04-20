using Microsoft.Extensions.Options;
using OptionsTests.Options;
using System.Text.Json;

namespace OptionsTests;

public sealed class Worker(IOptionsMonitor<Settings> options, ILogger<Worker> logger) : BackgroundService
{
    private readonly static JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web);
    private readonly IOptionsMonitor<Settings> _options = options;
    private readonly ILogger<Worker> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var options = _options.CurrentValue;
        using var onOptionsChangedScope = _options.OnChange(settings =>
        {
            options = settings;
        });

        while (cancellationToken.IsCancellationRequested is false)
        {
            _logger.LogInformation("BACKGROUND: '{Settings}'.", JsonSerializer.Serialize(options, _jsonOptions));
            await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        }
    }
}