using CarShop.Data;
using CarShop.Data.Model;
using CarShop.Services;
using CarShop.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CarShop.Data.DataConstants;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public CarsController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var carsQuery = this.data
                .Cars
                .AsQueryable();

            var user = this.data.Users.FirstOrDefault(x => x.Id == this.User.Id);

            if (user == null)
            {
                return BadRequest();
            }

            if (user.IsMechanic)
            {
                carsQuery = carsQuery
                    .Where(x => x.Issues.Count() > 0);
            }
            else if (!user.IsMechanic)
            {
                carsQuery = carsQuery
                    .Where(x => x.OwnerId == this.User.Id);
            }

            var cars = carsQuery
                .Select(x => new CarsListingViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    PictureUrl = x.PictureUrl,
                    PlateNumber = x.PlateNumber,
                    Year = x.Year,
                    RemainingIssues = x.Issues.Where(y => y.IsFixed == false).Count(),
                    FixedIssues = x.Issues.Where(y => y.IsFixed == true).Count(),
                })
                .ToList();

            return View(cars);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddCarFormModel model)
        {
            var modelErrors = this.validator.ValidateCar(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var user = this.data.Users.FirstOrDefault(x => x.Id == this.User.Id);

            if (user.IsMechanic)
            {
                return Error("You are mechanic you cannot add cars.");
            }

            var car = new Car
            {
                Model = model.Model,
                OwnerId = this.User.Id,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                Year = model.Year,
            };

            this.data.Cars.Add(car);

            this.data.SaveChanges();

            return Redirect("/Cars/All");
        }
    }
}
