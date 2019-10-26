namespace ButterflyShop.DAL.Models
{
    public class ContactInfo : BaseEntity
    {
        public string Address { get; set; }
        public string Phones { get; set; }
        public string TimeTable { get; set; }
        public string GoogleUrl { get; set; }
    }
}
