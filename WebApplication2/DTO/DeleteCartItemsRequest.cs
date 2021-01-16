namespace WebApplication2.DTO
{
    public class DeleteCartItemsRequest : BaseCartRequest
    {
        public ItemData[] Items { get; set; }
    }
}
