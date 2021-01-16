using WebApplication2.DTO;

namespace WebApplication2.Services
{
    public interface ICartService
    {
        ListCartResponse ListCart(ListCartRequest listCart);
        bool AddItems(AddItemRequest request);
        bool DeleteCart(DeleteCartRequest rewuest);
        bool DeleteItemsFromCart(DeleteCartItemsRequest request);

    }
}
