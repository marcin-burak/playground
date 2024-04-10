using System.Threading.Channels;

namespace Channels.Web.Misc;

public sealed class QueueWorker(Channel<QueueMessage> channel, QueueSimulator queue) : BackgroundService
{
    private readonly ChannelReader<QueueMessage> _reader = channel.Reader;
    private readonly QueueSimulator _queue = queue;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested is false)
        {
            var message = await _reader.ReadAsync(stoppingToken);
            await _queue.SendMessage(message, stoppingToken);
        }
    }
}