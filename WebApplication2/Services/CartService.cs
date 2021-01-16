using Microsoft.Extensions.Logging;
using System;
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
            try
            {
                _logger.LogInformation("Enter");
                var result = _cartRepository.AddItems(request.UserId, request?.items);
                _logger.LogInformation("Exit");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e}");
                return false;
            }
        }

        public bool DeleteCart(DeleteCartRequest request)
        {
            try
            {
                _logger.LogInformation("Enter");
                var result = _cartRepository.DeleteCart(request.UserId);
                _logger.LogInformation("Exit");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e}");
                return false;
            }
        }

        public bool DeleteItemsFromCart(DeleteCartItemsRequest request)
        {
            try
            {
                _logger.LogInformation("Enter");
                var result = _cartRepository.DeleteItemsFromCart(request.UserId, request?.Items);
                _logger.LogInformation("Exit");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e}");
                return false;
            }
        }

        public ListCartResponse ListCart(ListCartRequest request)
        {
            try
            {
                _logger.LogInformation("Enter");
                var itemData = _cartRepository.ListCart(request.UserId);
                var response = BuildResponseFromItemData(itemData);
                _logger.LogInformation("Exit");
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e}");
                return null;
            }

        }

        private ListCartResponse BuildResponseFromItemData(ItemDataBase[] itemData)
        {
            var cartItems = itemData.Select(item => new CartItemData() { Id = item.Id, Quentity = item.Quentity, TotalPrice = item.Quentity * itemPrice }).ToArray();
            return new ListCartResponse() { TotalPrice = cartItems.Sum(item => item.TotalPrice), Items = cartItems };
        }
    }
}
