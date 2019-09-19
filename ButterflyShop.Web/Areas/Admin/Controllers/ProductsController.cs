using ButterflyShop.DAL.Models;
using ButterflyShop.Web.Areas.Admin.Models.ProductsModel;
using ButterflyShop.Web.Controllers;
using ButterflyShop.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ButterflyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _ProductList(string search)
        {
            var products = UnitOfWork.StoredProcedures.GetProductsInfo_Admin(search);
            return PartialView(products);
        }

        public IActionResult _Product(int? id)
        {
            var model = new ProductVM()
            {
                ProductId = id.GetValueOrDefault()
            };

            var product = UnitOfWork.Products.FindById(id);
            if (product != null)
            {
                model.BrandId = product.BrandId;
                model.Name = product.Name;
                model.Description = product.Description;
            }

            model.Brands = UnitOfWork.Brands.FindAll();
            model.Categories = UnitOfWork.Categories.FindAll();
            model.Characteristics = UnitOfWork.Characteristics.FindAll();
            model.OptionalParameters = UnitOfWork.OptionalParameters.FindAll();
            model.ProductImages = UnitOfWork.ProductImages.Find(x => x.ProductId == id);

            model.SelectedCategories = UnitOfWork.CategoryProducts.Find(x => x.ProductId == id).Select(x => x.CategoryId);
            model.SelectedCharacteristics = UnitOfWork.CharacteristicProducts.Find(x => x.ProductId == id).Select(x => x.CharacteristicId);
            model.SelectedOptionalParameters = UnitOfWork.StoredProcedures.GetOptionalParametersForProduct_Admin(id).Select(x => x.Id);

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult SaveProduct(ProductVM productVM)
        {
            bool success;
            try
            {
                #region Product
                var product = new Product
                {
                    BrandId = productVM.BrandId,
                    Description = productVM.Description,
                    Name = productVM.Name
                };
                UnitOfWork.Products.Merge(product);
                #endregion

                #region Categories
                var productCategories = UnitOfWork.CategoryProducts.Find(x => x.ProductId == product.Id);
                foreach (var categoryId in productVM.SelectedCategories)
                {
                    if (productCategories.FirstOrDefault(x => x.CategoryId == categoryId) is CategoryProduct categoryProduct)
                    {
                        categoryProduct.IsDeleted = false;
                        productCategories = productCategories.Where(x => x.CategoryId != categoryId);
                    }
                    else
                    {
                        categoryProduct = new CategoryProduct
                        {
                            CategoryId = categoryId,
                            ProductId = product.Id
                        };
                    }
                    UnitOfWork.CategoryProducts.Merge(categoryProduct);
                }
                foreach (var categoryProduct in productCategories)
                {
                    categoryProduct.IsDeleted = false;
                    UnitOfWork.CategoryProducts.Merge(categoryProduct);
                }
                #endregion

                #region Product Images

                foreach (var file in Request.Form.Files)
                {
                    try
                    {
                        if (file.Length > 0)
                        {
                            var filename = $"{product.Name}_{DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds}.{Path.GetExtension(file.Name)}";
                            var path = Path.Combine(GlobalVariables.ResourceDirectory, ImageFolderNames.ImagesPath, filename);
                            using (var fs = new FileStream(path, FileMode.Create))
                            {
                                file.CopyToAsync(fs);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion

                success = true;
            }
            catch (Exception)
            {
                success = false;
            }

            return Json(new { success });
        }

        [HttpPost]
        public IActionResult RemoveProductImage(int id)
        {
            bool success;
            try
            {
                success = UnitOfWork.ProductImages.Delete(id);
            }
            catch (Exception)
            {
                success = false;
            }

            return Json(new { success });
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }
    }
}