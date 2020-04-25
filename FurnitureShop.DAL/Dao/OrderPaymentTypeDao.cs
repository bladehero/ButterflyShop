using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class OrderPaymentTypeDao : BaseDao<OrderPaymentType>
    {
        public OrderPaymentTypeDao(IDbConnection connection) : base("dbo.OrderPaymentTypes", connection) { }
    }
}
