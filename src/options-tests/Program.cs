using Microsoft.Extensions.Options;
using OptionsTests;
using OptionsTests.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<Settings>().BindConfiguration(nameof(Settings)).Services
    .AddOptions<NamedSettings>().BindConfiguration(nameof(NamedSettings)).Services
    .AddOptions<NamedSettings>(NamedSettings.RedSettings).BindConfiguration($"{nameof(NamedSettings)}:{NamedSettings.RedSettings}").Services
    .AddHostedService<Worker>();

var app = builder.Build();

app.MapGet("options", (IOptions<Settings> settings) =>
{
    return settings.Value;
});

app.MapGet("options-snapshot", (IOptionsSnapshot<Settings> settings) =>
{
    return settings.Value;
});

app.MapGet("options/{instance}", (string instance, IOptionsSnapshot<NamedSettings> settings) =>
{
    return settings.Get(instance);
});

app.Run();