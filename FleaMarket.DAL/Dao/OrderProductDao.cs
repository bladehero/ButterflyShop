using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class OrderProductDao : BaseDao<OrderProduct>
    {
        public OrderProductDao(IDbConnection connection) : base("dbo.OrderProducts", connection) { }
    }
}
