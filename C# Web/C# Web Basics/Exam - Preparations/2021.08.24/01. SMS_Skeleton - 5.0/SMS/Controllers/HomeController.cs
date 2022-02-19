namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly SMSDbContext data;

        public HomeController(SMSDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Home/IndexLoggedIn");
            }

            return this.View();
        }

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var products = this.data.Products
                .Select(x => new ProductListingViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                })
                .ToList();

            return this.View(products);
        }
    }
}