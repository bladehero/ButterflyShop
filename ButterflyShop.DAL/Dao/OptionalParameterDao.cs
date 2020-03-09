using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class OptionalParameterDao : BaseDao<OptionalParameter>
    {
        public OptionalParameterDao(IDbConnection connection) : base("dbo.OptionalParameters", connection) { }
    }
}
