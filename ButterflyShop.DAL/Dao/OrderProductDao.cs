using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class OrderProductDao : BaseDao<OrderProduct>
    {
        public OrderProductDao(IDbConnection connection) : base("dbo.OrderProducts", connection) { }
    }
}
