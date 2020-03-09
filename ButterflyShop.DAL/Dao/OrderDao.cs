using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class OrderDao : BaseDao<Order>
    {
        public OrderDao(IDbConnection connection) : base("dbo.Orders", connection) { }
    }
}
