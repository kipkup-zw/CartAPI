using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.DTO;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]
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
        public ListCartResponse List(int id)
        {
            var res = _cartService.ListCart(new ListCartRequest() { UserId = id});
            return res;
        }

        [HttpPut]
        [Route("~/[controller]/[action]")]
        public bool AddItems([FromBody] AddItemRequest request)
        {
            var res = _cartService.AddItems(request);
            return res;
        }

        [HttpDelete]
        [Route("~/[controller]/[action]")]
        public bool Delete([FromBody] DeleteCartRequest request)
        {
            var res = _cartService.DeleteCart(request);
            return res;
        }


        [HttpDelete]
        [Route("~/[controller]/[action]")]
        public bool DeleteCartItems([FromBody] DeleteCartItemsRequest request)
        {
            var res = _cartService.DeleteItemsFromCart(request);
            return res;
        }


    }
}
