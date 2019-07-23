namespace ButterflyShop.DAL.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public int OrderStatus { get; set; }
        public int OrderDeliveryType { get; set; }
    }
}
