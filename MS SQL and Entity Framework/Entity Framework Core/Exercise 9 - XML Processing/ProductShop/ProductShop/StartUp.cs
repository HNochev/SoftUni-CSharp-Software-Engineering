using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Linq;
using XmlFacade;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            //ImportUsers(context, usersXml);
            //ImportProducts(context, productsXml);
            //ImportCategories(context, categoriesXml);
            //ImportCategoryProducts(context, categoryProductsXml);

            //Problem 5
            //var result = GetProductsInRange(context);

            //Problem 6
            //var result = GetSoldProducts(context);

            //Problem 7
            //var result = GetCategoriesByProductsCount(context);

            //Problem 8
            var result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string root = "Users";

            var userDto = XmlConverter.Deserializer<UserInputModel>(inputXml, root);

            var users = userDto.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
            })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string root = "Products";

            var productDto = XmlConverter.Deserializer<ProductInputModel>(inputXml, root);

            var users = context.Users.Select(x => x.Id);

            var products = productDto
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerId = x.BuyerId,
                    SellerId = x.SellerId,
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";

            var categoryDto = XmlConverter.Deserializer<CategoryInputModel>(inputXml, root);

            var categories = categoryDto
                .Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name,
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string root = "CategoryProducts";

            var categoryProductsDto = XmlConverter.Deserializer<CategoryProductImputModel>(inputXml, root);

            var categories = context.Categories.Select(x => x.Id);
            var products = context.Products.Select(x => x.Id);

            var categoryProducts = categoryProductsDto
                .Where(x => categories.Contains(x.CategoryId) && products.Contains(x.ProductId))
                .Select(x => new CategoryProduct
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId,
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductsInRangeOutputModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerName = $"{x.Buyer.FirstName} {x.Buyer.LastName}",
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            var result = XmlConverter.Serialize<ProductsInRangeOutputModel>(products, "Products");

            return result;
        }

        //Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new SoldProductsUserOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Products = x.ProductsSold
                    .Select(y => new SoldProductOutputObject
                    {
                        Name = y.Name,
                        Price = y.Price,
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var result = XmlConverter.Serialize<SoldProductsUserOutputModel>(users, "Users");

            return result;
        }

        //Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoryByProductsOutputModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(y => y.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(y => y.Product.Price),
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var result = XmlConverter.Serialize<CategoryByProductsOutputModel>(categories, "Categories");

            return result;
        }

        //Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToArray()
                .Where(x => x.ProductsSold.Any())
                .OrderByDescending(x => x.ProductsSold.Count())
                .Select(x => new UsersAndProductsUserOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new UsersAndProductsSoldProductOutputModel
                    {
                        Count = x.ProductsSold.Count(),
                        Products = x.ProductsSold.Select(y => new UsersAndProductsProductOutputModel
                        {
                            Name = y.Name,
                            Price = y.Price,
                        })
                        .OrderByDescending(y => y.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var usersAndProducts = new UsersAndProductsUsersOutputModel
            {
                Count = context.Users
                .Count(x => x.ProductsSold.Any()),
                Users = users,
            };

            var result = XmlConverter.Serialize<UsersAndProductsUsersOutputModel>(usersAndProducts, "Users");

            return result;
        }
    }
}