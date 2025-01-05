//using Microsoft.AspNetCore.Mvc;

//namespace CourseSales.API.Controllers
//{
//    public class OrdersController(IOrderService, orderService) : CustomBaseController
//    {
//        [Route("api/[controller]")]
//        [ApiController]
//        public class OrdersController : ControllerBase
//        {
//            private readonly IOrderService _orderService;

//            public OrdersController(IOrderService orderService)
//            {
//                _orderService = orderService;
//            }

//            [HttpPost]
//            public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
//            {
//                var result = await _orderService.CreateOrderAsync(dto);
//                if (!result.Success) return BadRequest(result.Message);

//                return Ok(result.Data);
//            }

//            [HttpGet("{userId}")]
//            public async Task<IActionResult> GetOrders(int userId)
//            {
//                var orders = await _orderService.GetOrdersByUserIdAsync(userId);
//                return Ok(orders);
//            }
//        }
//    }
//}
