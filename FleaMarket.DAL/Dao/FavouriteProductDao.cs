using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class FavouriteProductDao : BaseDao<FavouriteProduct>
    {
        public FavouriteProductDao(IDbConnection connection) : base("dbo.FavouriteProducts", connection) { }
    }
}
