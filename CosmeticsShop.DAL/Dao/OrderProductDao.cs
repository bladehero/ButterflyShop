using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class OrderProductDao : BaseDao<OrderProduct>
    {
        public OrderProductDao(IDbConnection connection) : base("dbo.OrderProducts", connection) { }
    }
}
