using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class FavouriteProductDao : BaseDao<FavouriteProduct>
    {
        public FavouriteProductDao(IDbConnection connection) : base("dbo.FavouriteProducts", connection) { }
    }
}
