namespace ButterflyShop.DAL.Models
{
    public class OptionalParameterProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public int OptionalParameterId { get; set; }
        public string Value { get; set; }
    }
}
