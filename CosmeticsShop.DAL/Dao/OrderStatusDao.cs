using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class OrderStatusDao : BaseDao<OrderStatus>
    {
        public OrderStatusDao(IDbConnection connection) : base("dbo.OrderStatuses", connection) { }
    }
}
