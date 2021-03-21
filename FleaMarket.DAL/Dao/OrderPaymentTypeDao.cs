using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class OrderPaymentTypeDao : BaseDao<OrderPaymentType>
    {
        public OrderPaymentTypeDao(IDbConnection connection) : base("dbo.OrderPaymentTypes", connection) { }
    }
}
