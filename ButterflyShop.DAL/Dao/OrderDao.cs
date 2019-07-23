using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class OrderDao : BaseDao<Order>
    {
        public OrderDao(IDbConnection connection) : base("dbo.Orders", connection) { }
    }
}
