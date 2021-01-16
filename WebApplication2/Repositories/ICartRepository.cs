using WebApplication2.DTO;

namespace WebApplication2.Repositories
{
    public interface ICartRepository
    {
        ItemDataBase[] ListCart(int userId);
        bool AddItems(int userId, ItemDataBase[] items);
        bool DeleteCart(int userId);
        bool DeleteItemsFromCart(int userId, ItemData[] items);
    }
}
