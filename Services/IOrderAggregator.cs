namespace WebAPIService.Services
{
    public interface IOrderAggregator
    {
        void AddOrder(string productId, int quantity);
        Dictionary<string, int> Export();
    }
}
