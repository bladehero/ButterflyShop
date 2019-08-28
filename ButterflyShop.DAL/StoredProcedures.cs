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

        public IEnumerable<ProductItemInfo_Result> GetItemsInfo(int? count, bool? newItems = null, bool? saleItems = null, int? userId = null)
        {
            var obj = new
            {
                @count = count,
                @newItems = newItems,
                @saleItems = saleItems,
                @userId = userId
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
            var result = Connection.ExecuteScalar<int>($"select dbo.GetUserRoleId(N'{role}')");
            return result;
        }
        public IEnumerable<GetCategoryHierarchy_Result> GetCategoryHierarchy(int? toLevelId = null)
        {
            var obj = new
            {
                @toLevelId = toLevelId
            };
            var result = Connection.Query<GetCategoryHierarchy_Result>("dbo.GetCategoryHierarchy", obj, commandType: CommandType.StoredProcedure);
            return result;
        }
        public IEnumerable<ProductItemInfo_Result> GetFavouriteProductInfo(int userId)
        {
            var obj = new
            {
                @userId = userId
            };
            var result = Connection.Query<ProductItemInfo_Result>("dbo.GetFavouriteProductInfo", obj, commandType: CommandType.StoredProcedure);
            return result;
        }
        public IEnumerable<ProductItemInfo_Result> SearchItemInfo(int? userId, int? categoryId = null, int? brandId = null, string search = null, double? minPrice = null, double? maxPrice = null)
        {
            var obj = new
            {
                @userId = userId,
                @categoryId = categoryId,
                @brandId = brandId,
                @search = search,
                @minPrice = minPrice,
                @maxPrice = maxPrice
            };
            var result = Connection.Query<ProductItemInfo_Result>("dbo.SearchItemInfo", obj, commandType: CommandType.StoredProcedure);
            return result;
        }
        
    }
}
