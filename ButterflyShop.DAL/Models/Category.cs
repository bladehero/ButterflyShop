namespace ButterflyShop.DAL.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
