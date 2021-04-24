using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class OrderDeliveryTypeDao : BaseDao<OrderDeliveryType>
    {
        public OrderDeliveryTypeDao(IDbConnection connection) : base("dbo.OrderDeliveryTypes", connection) { }
    }
}
