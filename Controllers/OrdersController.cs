using Microsoft.AspNetCore.Mvc;
using WebAPIService.Model;
using WebAPIService.Services;

namespace WebAPIService.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IOrderAggregator _aggregator;

        public OrderController(IOrderAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        [HttpPost]
        public IActionResult PostOrder([FromBody] List<OrderItem> orders)
        {
            if (orders == null || orders.Count == 0)
            {
                return BadRequest("Je vyžadována alespoň jedna objednávka.");
            }

            foreach (var order in orders)
            {
                _aggregator.AddOrder(order.ProductId, order.Quantity);
            }

            return Accepted();
        }
    }
}
