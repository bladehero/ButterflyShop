using ButterflyShop.DAL.Models;

namespace ButterflyShop.Web.Models.AccountModels
{
    public class IndexVM
    {
        public User User { get; set; }

        public string Error { get; set; }
        public bool HasError => !string.IsNullOrWhiteSpace(Error);
        public bool UpdatedUserInfo { get; set; }
    }
}
