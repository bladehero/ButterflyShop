using ButterflyShop.DAL.Models;
using System.Collections.Generic;

namespace ButterflyShop.Web.Areas.Admin.Models.ProductsModel
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public IEnumerable<int> SelectedCategories { get; set; }
        public IEnumerable<int> SelectedOptionalParameters { get; set; }
        public IEnumerable<int> SelectedCharacteristics { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Characteristic> Characteristics { get; set; }
        public IEnumerable<OptionalParameter> OptionalParameters { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }

        public ProductVM()
        {
            SelectedCategories = new List<int>();
            SelectedCharacteristics = new List<int>();
            SelectedOptionalParameters = new List<int>();

            Brands = new List<Brand>();
            Categories = new List<Category>();
            Characteristics = new List<Characteristic>();
            OptionalParameters = new List<OptionalParameter>();
            ProductImages = new List<ProductImage>();
        }
    }

    public class ItemVM
    {
        public int ItemId { get; set; }
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public IEnumerable<int> SelectedOptionalParameters { get; set; }

        public ItemVM()
        {
            SelectedOptionalParameters = new List<int>();
        }
    }
}
