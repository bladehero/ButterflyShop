using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class CartDao : BaseDao<Cart>
    {
        public CartDao(IDbConnection connection) : base("dbo.Cart", connection) { }
    }
}
