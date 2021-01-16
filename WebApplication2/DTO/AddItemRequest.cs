namespace WebApplication2.DTO
{
    public class AddItemRequest : BaseCartRequest
    {
        public ItemData[] items { get; set; }
    }
}
