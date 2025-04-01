using System.Collections.Concurrent;

namespace WebAPIService.Services
{
    public class InMemoryOrderAggregator : IOrderAggregator
    {
        private readonly ConcurrentDictionary<string, int> _orders = new();

        public void AddOrder(string productId, int quantity)
        {
            _orders.AddOrUpdate(productId, quantity, (_, exist) => exist + quantity);
        }

        public Dictionary<string, int> Export()
        {
            var data = _orders.ToDictionary(o => o.Key, o => o.Value);
            _orders.Clear();
            return data;
        }
    }
}
