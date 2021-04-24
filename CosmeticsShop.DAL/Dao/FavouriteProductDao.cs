using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class FavouriteProductDao : BaseDao<FavouriteProduct>
    {
        public FavouriteProductDao(IDbConnection connection) : base("dbo.FavouriteProducts", connection) { }
    }
}
