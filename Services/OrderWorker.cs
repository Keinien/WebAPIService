using System.Text.Json;

namespace WebAPIService.Services
{
    public class OrderWorker : BackgroundService
    {
        private readonly IOrderAggregator _aggregator;
        private readonly ILogger<OrderWorker> _logger;

        public OrderWorker(IOrderAggregator aggregator, ILogger<OrderWorker> logger)
        {
            _aggregator = aggregator;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var data = _aggregator.Export();
                if (data.Any())
                {
                    var json = JsonSerializer.Serialize(data);
                    Console.WriteLine($"{DateTime.Now:HH:mm:ss} {json}");
                }

                await Task.Delay(TimeSpan.FromSeconds(20), cancellationToken);
            }
        }
    }
}
