﻿using System.ComponentModel;
using System.IO;

namespace ButterflyShop.Web
{
    public static class GlobalVariables
    {
        public static string ConnectionString = string.Empty;

        public static string ResourceDirectory => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public const string AssetsPath = "assets";
    }

    public static class ImageFolderNames
    {
        public const string ImagesFolder = "images";
        public const string BrandsFolder = "brands";
        public const string BrandLogosFolder = "logos";
        public const string BrandBackgroundsFolder = "backgrounds";
        public const string ProductsFolder = "products";
        public const string NoImage = "no_image.png";

        public static string ImagesPath => Path.Combine(GlobalVariables.AssetsPath, ImagesFolder);
        public static string NoImagePath => Path.Combine(ImagesPath, NoImage);

        public static string BrandLogosPath => Path.Combine(ImagesPath, BrandsFolder, BrandLogosFolder);
        public static string BrandBackgroundsPath => Path.Combine(ImagesPath, BrandsFolder, BrandBackgroundsFolder);
        public static string ProductsPath => Path.Combine(ImagesPath, ProductsFolder);
    }

    public enum UserRole
    {
        [Description("Пользователь")]
        User,
        [Description("Администратор")]
        Administrator
    }

    public enum AccountTab
    {
        Dashboard,
        Favourite,
        Orders,
        Info
    }

    public enum ProductOption
    {
        [Description("MinPrice")]
        MinPrice,
        [Description("MaxPrice")]
        MaxPrice
    }

    public enum OrderDeliveryTypes
    {
        [Description("Новая Почта")]
        NovaPoshta,
        [Description("Justin")]
        Justin,
        [Description("Доставка по Одессе")]
        ByOdessa
    }

    public enum OrderPaymentTypes
    {
        [Description("Наложенный")]
        CashOnDelivery,
        [Description("На карту")]
        OnCard
    }
}
