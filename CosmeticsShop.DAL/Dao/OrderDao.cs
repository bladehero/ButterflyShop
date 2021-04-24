using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class OrderDao : BaseDao<Order>
    {
        public OrderDao(IDbConnection connection) : base("dbo.Orders", connection) { }
    }
}
