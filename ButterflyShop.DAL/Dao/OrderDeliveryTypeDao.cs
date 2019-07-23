using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class OrderDeliveryTypeDao : BaseDao<OrderDeliveryType>
    {
        public OrderDeliveryTypeDao(IDbConnection connection) : base("dbo.OrderDeliveryTypes", connection) { }
    }
}
