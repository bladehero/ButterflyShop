using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class OrderDao : BaseDao<Order>
    {
        public OrderDao(IDbConnection connection) : base("dbo.Orders", connection) { }
    }
}
