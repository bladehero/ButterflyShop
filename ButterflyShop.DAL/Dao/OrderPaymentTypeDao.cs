using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class OrderPaymentTypeDao : BaseDao<OrderPaymentType>
    {
        public OrderPaymentTypeDao(IDbConnection connection) : base("dbo.OrderPaymentTypes", connection) { }
    }
}
