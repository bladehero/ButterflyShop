namespace ButterflyShop.DAL.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float? OldPrice { get; set; }
    }
}
