//using Microsoft.Net.te
using WebAPIService.Services;
using Xunit;


namespace WebAPIService.Tests
{
    public class InMemoryOrderAggregatorTests
    {
        [Fact]
        public void AddOrder_Test()
        {
            var aggregator = new InMemoryOrderAggregator();
            aggregator.AddOrder("456", 5);
            aggregator.AddOrder("456", 3);
            aggregator.AddOrder("789", 42);

            var result = aggregator.Export();

            Assert.Equal(2, result.Count);
            Assert.Equal(8, result["456"]);
            Assert.Equal(42, result["789"]);
        }

        [Fact]
        public void Export_Test()
        {
            var aggregator = new InMemoryOrderAggregator();
            aggregator.AddOrder("362", 15);
            aggregator.Export();

            var result = aggregator.Export();
            Assert.Empty(result);
        }
    }
}
