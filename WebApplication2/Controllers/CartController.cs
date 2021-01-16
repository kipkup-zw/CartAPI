using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.DTO;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CartController : ControllerBase
    {

        private readonly ILogger<CartController> _logger;
        private readonly ICartService _cartService;

        public CartController(ILogger<CartController> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }


        [HttpGet]
        [Route("~/[controller]/[action]/{id}")]
        public ListCartResponse List(int id)
        {
            var res = _cartService.ListCart(new ListCartRequest { UserId = id });
            return res;
        }

        [HttpPut]
        public bool AddItems([FromBody] AddItemRequest request)
        {
            var res = _cartService.AddItems(request);
            return res;
        }

        [HttpDelete]
        [Route("~/[controller]/[action]/{id}")]
        public bool Delete(int id)
        {
            var res = _cartService.DeleteCart(new DeleteCartRequest { UserId = id });
            return res;
        }


        [HttpDelete]
        public bool DeleteCartItems([FromBody] DeleteCartItemsRequest request)
        {
            var res = _cartService.DeleteItemsFromCart(request);
            return res;
        }


    }
}
