using ButterflyShop.DAL.Dao;
using ButterflyShop.DAL.Models.StoredProcedureModels;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace ButterflyShop.DAL
{
    public class StoredProcedures : DataAccessObject
    {
        public StoredProcedures(IDbConnection connection) : base(connection) { }

        public IEnumerable<ProductItemInfo_Result> GetItemsInfo(int count, bool? newItems = null, bool? saleItems = null)
        {
            var obj = new
            {
                @count = count,
                @newItems = newItems,
                @saleItems = saleItems
            };
            var result = Connection.Query<ProductItemInfo_Result>("dbo.GetItemsInfo", obj, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
