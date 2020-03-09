using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class OptionalParameterProductDao : BaseDao<OptionalParameterProduct>
    {
        public OptionalParameterProductDao(IDbConnection connection) : base("dbo.OptionalParameterProducts", connection) { }
    }
}
