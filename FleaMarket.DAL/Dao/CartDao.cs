using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class CartDao : BaseDao<Cart>
    {
        public CartDao(IDbConnection connection) : base("dbo.Cart", connection) { }
    }
}
