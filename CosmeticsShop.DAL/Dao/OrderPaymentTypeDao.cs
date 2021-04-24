using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class OrderPaymentTypeDao : BaseDao<OrderPaymentType>
    {
        public OrderPaymentTypeDao(IDbConnection connection) : base("dbo.OrderPaymentTypes", connection) { }
    }
}
