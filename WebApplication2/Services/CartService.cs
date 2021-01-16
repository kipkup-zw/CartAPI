using Microsoft.Extensions.Logging;
using System.Linq;
using WebApplication2.DTO;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class CartService : ICartService
    {
        private readonly ILogger _logger;
        private readonly ICartRepository _cartRepository;

        const int itemPrice = 20;

        public CartService(ILogger<CartService> logger, ICartRepository cartRepository)
        {
            _logger = logger;
            _cartRepository = cartRepository;
        }

        public bool AddItems(AddItemRequest request)
        {
            return _cartRepository.AddItems(request.UserId, request?.items);
        }

        public bool DeleteCart(DeleteCartRequest request)
        {
            return _cartRepository.DeleteCart(request.UserId);
        }

        public bool DeleteItemsFromCart(DeleteCartItemsRequest request)
        {
            return _cartRepository.DeleteItemsFromCart(request.UserId, request?.Items);
        }

        public ListCartResponse ListCart(ListCartRequest request)
        {
            var itemData =_cartRepository.ListCart(request.UserId);
            var response = BuildResponseFromItemData(itemData);
            return response;
        }

        private ListCartResponse BuildResponseFromItemData(ItemDataBase[] itemData)
        {
            var cartItems = itemData.Select(item => new CartItemData() { Id = item.Id, Quentity = item.Quentity, TotalPrice = item.Quentity * itemPrice } ).ToArray();
            return new ListCartResponse() { TotalPrice = cartItems.Sum(item=> item.TotalPrice), Items = cartItems };
        }
    }
}
