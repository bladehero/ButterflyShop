using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class OptionalParameterProductDao : BaseDao<OptionalParameterProduct>
    {
        public OptionalParameterProductDao(IDbConnection connection) : base("dbo.OptionalParameterProducts", connection) { }
    }
}
