﻿using System.IO;
using static ButterflyShop.Web.ImageFolderNames;

namespace ButterflyShop.Web.Extensions
{
    public static class ImagePathExtension
    {
        public static string BrandLogoImage(string source) => ImageForFolder(source, BrandLogosPath);
        public static string BrandBackgroundImage(string source) => ImageForFolder(source, BrandBackgroundsPath);
        public static string ProductImage(string source) => ImageForFolder(source, ProductsPath);

        public static string ImageForFolder(string source, string folder)
        {
            var path = Path.Combine(folder, source);
            return File.Exists(Path.Combine(GlobalVariables.ResourceDirectory, path)) ? path : ImageFolderNames.NoImagePath;
        }
    }
}