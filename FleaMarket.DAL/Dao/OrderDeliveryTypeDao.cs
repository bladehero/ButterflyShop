using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class OrderDeliveryTypeDao : BaseDao<OrderDeliveryType>
    {
        public OrderDeliveryTypeDao(IDbConnection connection) : base("dbo.OrderDeliveryTypes", connection) { }
    }
}
