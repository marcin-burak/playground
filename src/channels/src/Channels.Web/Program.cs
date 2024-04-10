using Channels.Web.Misc;
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(_ => Channel.CreateUnbounded<QueueMessage>());
builder.Services.AddSingleton<QueueSimulator>();
builder.Services.AddHostedService<QueueWorker>();

var app = builder.Build();

app.MapPost("/api/test", async (ILogger<Program> logger, QueueSimulator queue, CancellationToken cancellationToken) =>
{
    logger.LogInformation("Processing HTTP request...");

    await queue.SendMessage(new("Test message"), cancellationToken);

    logger.LogInformation("Processed HTTP request.");
});

app.MapPost("/api/test/channels", async (ILogger<Program> logger, Channel<QueueMessage> channel, CancellationToken cancellationToken) =>
{
    logger.LogInformation("Processing HTTP request...");

    await channel.Writer.WriteAsync(new("Test message"), cancellationToken);

    logger.LogInformation("Processed HTTP request.");
});

app.Run();