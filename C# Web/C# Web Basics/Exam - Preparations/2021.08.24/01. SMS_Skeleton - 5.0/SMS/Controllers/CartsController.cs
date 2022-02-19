using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly SMSDbContext data;

        public CartsController(SMSDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse Details()
        {
            var products = this.data.Carts
                .Where(x => x.User.Id == this.User.Id)
                .Select(x => new ProductListingViewModel
                {
                    Name = x.Products.Select(y => y.Name).FirstOrDefault(),
                    Price = x.Products.Select(y => y.Price).FirstOrDefault(),
                })
                .ToList();

            return this.View(products);
        }

        [Authorize]
        public HttpResponse Buy()
        {
            return Redirect("/");
        }
    }
}
