using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class FavouriteProductDao : BaseDao<FavouriteProduct>
    {
        public FavouriteProductDao(IDbConnection connection) : base("dbo.FavouriteProducts", connection) { }
    }
}
