using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class CartDao : BaseDao<Cart>
    {
        public CartDao(IDbConnection connection) : base("dbo.Cart", connection) { }
    }
}
