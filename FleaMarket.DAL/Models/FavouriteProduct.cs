namespace FleaMarket.DAL.Models
{
    public class FavouriteProduct : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
