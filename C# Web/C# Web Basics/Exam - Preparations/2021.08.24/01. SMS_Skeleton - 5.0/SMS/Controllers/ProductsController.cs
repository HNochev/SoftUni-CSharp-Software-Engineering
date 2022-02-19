using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Data.Models;
using SMS.Models;
using SMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IValidator validator;

        public ProductsController(
            SMSDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Create() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateProductFormModel model)
        {
            var modelErrors = this.validator.ValidateProduct(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };

            this.data.Products.Add(product);

            this.data.SaveChanges();

            return Redirect("/");
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(string productId, CreateProductFormModel model)
        {
            var user = this.data.Users
                .FirstOrDefault(x => x.Id == this.User.Id);

            var product = data.Products
                .Where(x => x.Id == productId)
                .Select(x => new ProductListingViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                })
                .FirstOrDefault();

            var productForm = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };

            if (product == null || productForm == null)
            {
                return Error("Is not valid.");
            }

            user.Cart.Products
                .ToList()
                .Add(productForm);

            this.data.SaveChanges();

            return View(product);
        }

        /*[HttpPost]
        [Authorize]
        public HttpResponse Add(CreateProductFormModel model)
        {
            var user = this.data.Users
                .FirstOrDefault(x => x.Id == this.User.Id);

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };

            user.Cart.Products
                .ToList()
                .Add(product);

            this.data.SaveChanges();

            return Redirect("/Carts/Details");
        }*/
    }
}
