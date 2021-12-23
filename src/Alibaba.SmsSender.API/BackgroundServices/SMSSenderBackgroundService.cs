using Alibaba.SmsSender.API.Models;
using System.Threading.Channels;

namespace Alibaba.SmsSender.API.BackgroundServices;

public class SMSSenderBackgroundService : BackgroundService
{
    private static readonly Channel<SMSDto> _smsChannel;
    public static ChannelWriter<SMSDto> SMSChannelWriter { get; }
    private readonly ILogger<SMSSenderBackgroundService> _logger;
    static SMSSenderBackgroundService()
    {
        _smsChannel = Channel.CreateUnbounded<SMSDto>(new UnboundedChannelOptions
        {
            SingleWriter = false,
            SingleReader = true,
        });
        SMSChannelWriter = _smsChannel.Writer;
    }
    public SMSSenderBackgroundService(ILogger<SMSSenderBackgroundService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var smsDto in _smsChannel.Reader.ReadAllAsync())
        {
            await Task.Delay(TimeSpan.FromSeconds(8));
            _logger.LogInformation("{@SMS}", smsDto);
        }
    }
}
