using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class CharacteristicProductDao : BaseDao<CharacteristicProduct>
    {
        public CharacteristicProductDao(IDbConnection connection) : base("dbo.CharacteristicProducts", connection) { }
    }
}
