namespace WebApplication2.DTO
{
    public class ListCartResponse
    {
        public CartItemData[] Items { get; set; }
        public int TotalPrice { get; set; }
    }
}
