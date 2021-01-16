using System.Collections.Generic;
using WebApplication2.DTO;
using System.Linq;

namespace WebApplication2.Repositories
{


    public class CartRepository : ICartRepository
    {

        private static Dictionary<int, List<ItemDataBase>> _carts;

        static CartRepository()
        {
            _carts = new Dictionary<int, List<ItemDataBase>>();
        }

        public bool AddItems(int userId, ItemDataBase[] items)
        {
            if (!_carts.TryGetValue(userId, out var dbItems))
            {
                _carts[userId] = new List<ItemDataBase>(items);
                return true;
            }

            foreach (var item in items)
            {
                var search = new ItemSearch(item.Id);
                var ind = dbItems.FindIndex(search.HasId);
                if (ind < 0)
                {
                    dbItems.Add(item);
                }
                else
                {
                    dbItems[ind].Quentity += item.Quentity;
                }
            }

            return true;
        }


        public bool DeleteCart(int userId)
        {
            _carts.Remove(userId);
            return true;
        }

        public bool DeleteItemsFromCart(int userId, ItemData[] items)
        {
            if (!_carts.TryGetValue(userId, out var dbItems))
                return true;

            foreach (var item in items)
            {
                var search = new ItemSearch(item.Id);
                var ind = dbItems.FindIndex(search.HasId);

                if (ind >= 0)
                    dbItems[ind].Quentity -= item.Quentity;
            }

            dbItems = dbItems.Where(item => item.Quentity > 0).ToList();
            return true;
        }

        public ItemDataBase[] ListCart(int userId)
        {
            if (!_carts.TryGetValue(userId, out var dbItems))
                return new ItemData[0];

            return dbItems.ToArray();
        }
    }


    public class ItemSearch
    {
        int _id;

        public ItemSearch(int id)
        {
            _id = id;
        }

        public bool HasId(ItemDataBase item)
        {
            return item.Id == _id;
        }
    }
}
