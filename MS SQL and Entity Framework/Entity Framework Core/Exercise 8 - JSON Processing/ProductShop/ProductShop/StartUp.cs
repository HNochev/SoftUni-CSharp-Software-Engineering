using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();

            //productShopContext.Database.EnsureDeleted();
            //productShopContext.Database.EnsureCreated();

            //string usersJson = File.ReadAllText("../../../Datasets/users.json");
            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //string categoriyProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportUsers(productShopContext, usersJson);
            //ImportProducts(productShopContext, productsJson);
            //ImportCategories(productShopContext, categoriesJson);
            //ImportCategoryProducts(productShopContext, categoriyProductsJson);

            //Console.WriteLine(result);

            //Problem 5
            //var result = GetProductsInRange(productShopContext);

            //File.WriteAllText(@"..\..\..\JsonResults\products-in-range.json", result);

            //Problem 6
            //var result = GetSoldProducts(productShopContext);

            //File.WriteAllText(@"..\..\..\JsonResults\users-sold-products.json", result);

            //Problem 7
            //var result = GetCategoriesByProductsCount(productShopContext);

            //File.WriteAllText(@"..\..\..\JsonResults\categories-by-products.json", result);

            //Problem 8
            var result = GetUsersWithProducts(productShopContext);

            File.WriteAllText(@"..\..\..\JsonResults\users-and-products.json", result);

            //Console.WriteLine(result);
        }

        //Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
               .Users
               .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
               .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
               .Select(x => new
               {
                   firstName = x.FirstName,
                   lastName = x.LastName,
                   age = x.Age,
                   soldProducts = new
                   {
                       count = x.ProductsSold.Count(ps => ps.Buyer != null),
                       products = x.ProductsSold
                           .Where(p => p.Buyer != null)
                           .Select(p => new
                           {
                               name = p.Name,
                               price = p.Price
                           })
                   }
               })
               .ToList();

            var finalUserProducts = new
            {
                usersCount = users.Count,
                users = users
            };

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var result = JsonConvert.SerializeObject(finalUserProducts, Formatting.Indented, jsonSerializerSettings);

            return result;
        }

        //Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = (x.CategoryProducts.Sum(y => y.Product.Price) / x.CategoryProducts.Count).ToString("f2"),
                    totalRevenue = x.CategoryProducts.Sum(y => y.Product.Price).ToString("f2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result;
        }

        //Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(z => z.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Where(y => y.BuyerId != null)
                    .Select(y => new
                    {
                        name = y.Name,
                        price = y.Price,
                        buyerFirstName = y.Buyer.FirstName,
                        buyerLastName = y.Buyer.LastName,
                    })
                    .ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var reslut = JsonConvert.SerializeObject(users, Formatting.Indented);

            return reslut;
        }

        //Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}",
                })
                .OrderBy(x => x.price)
                .ToList();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dboCategoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dboCategoryProducts);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dboCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null);

            var categories = mapper.Map<IEnumerable<Category>>(dboCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dboProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dboProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}