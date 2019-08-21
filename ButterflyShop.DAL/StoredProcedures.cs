using ButterflyShop.DAL.Dao;
using ButterflyShop.DAL.Models;
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
        public IEnumerable<Category> CategoriesForProduct(int productId)
        {
            var obj = new
            {
                @productId = productId
            };
            var result = Connection.Query<Category>("dbo.CategoriesForProduct", obj, commandType: CommandType.StoredProcedure);
            return result;
        }
        public IEnumerable<ProductImage> GetProductImages(int productId)
        {
            var obj = new
            {
                @productId = productId
            };
            var result = Connection.Query<ProductImage>("dbo.GetProductImages", obj, commandType: CommandType.StoredProcedure);
            return result;
        }
        public IEnumerable<ItemWithParameters_Result> GetItemWithParameters(int productId)
        {
            var obj = new
            {
                @productId = productId
            };
            var result = Connection.Query<ItemWithParameters_Result>("dbo.GetItemWithParameters", obj, commandType: CommandType.StoredProcedure);
            return result;
        }
        public string MD5HashPassword(string password)
        {
            var result = Connection.ExecuteScalar<string>($"select dbo.MD5HashPassword('{password}')");
            return result;
        }
        public int GetUserRoleId(string role)
        {
            var result = Connection.ExecuteScalar<int>($"select dbo.GetUserRoleId('{role}')");
            return result;
        }
    }
}
