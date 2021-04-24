using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class CartDao : BaseDao<Cart>
    {
        public CartDao(IDbConnection connection) : base("dbo.Cart", connection) { }
    }
}
