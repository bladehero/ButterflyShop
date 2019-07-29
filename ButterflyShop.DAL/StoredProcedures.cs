using ButterflyShop.DAL.Dao;
using ButterflyShop.DAL.Models.StoredProcedureModels;
using Dapper;
using System.Data;

namespace ButterflyShop.DAL
{
    public class StoredProcedures : DataAccessObject
    {
        public StoredProcedures(IDbConnection connection) : base(connection) { }

        public ProductItemInfo_Result GetItemsInfo(int count, bool newItems, bool saleItems)
        {
            return Connection.Execute("");
        }
    }
}
