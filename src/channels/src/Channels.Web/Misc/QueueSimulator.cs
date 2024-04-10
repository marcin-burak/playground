namespace Channels.Web.Misc;

public sealed class QueueSimulator(ILogger<QueueSimulator> logger)
{
    private readonly ILogger<QueueSimulator> _logger = logger;

    public async Task SendMessage(QueueMessage message, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(message);

        _logger.LogInformation("Sending message to queue...");

        await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);

        _logger.LogInformation("Message has been sent do queue.");
    }
}

public sealed class QueueMessage
{
    public QueueMessage(string message)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(message);
        Message = message;
    }

    public string Message { get; }
}