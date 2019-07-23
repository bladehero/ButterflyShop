using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class OrderStatusDao : BaseDao<OrderStatus>
    {
        public OrderStatusDao(IDbConnection connection) : base("dbo.OrderStatuses", connection) { }
    }
}
