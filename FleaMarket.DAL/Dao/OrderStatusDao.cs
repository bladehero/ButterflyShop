using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class OrderStatusDao : BaseDao<OrderStatus>
    {
        public OrderStatusDao(IDbConnection connection) : base("dbo.OrderStatuses", connection) { }
    }
}
