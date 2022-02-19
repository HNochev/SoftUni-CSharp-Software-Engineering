using CarShop.Data;
using CarShop.Data.Model;
using CarShop.Services;
using CarShop.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public IssuesController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            var user = data.Users.FirstOrDefault(x => x.Id == this.User.Id);

            var car = this.data.Cars
                .Where(x => x.Id == carId)
                .Select(x => new CarIssuesViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    IsMechanic = user.IsMechanic,
                    Issues = x.Issues
                        .Select(y => new IssuesViewModel
                        {
                            Id = y.Id,
                            Description = y.Description,
                            IsFixed = y.IsFixed,
                            IsFixedInformation = y.IsFixed ? "Yes" : "Not Yet",
                        })
                        .ToList()
                })
                .FirstOrDefault();

            if (user == null || car == null)
            {
                return BadRequest();
            }

            return View(car);
        }

        [Authorize]
        public HttpResponse Add(string carId) => View(new AddIssueViewModel
        {
            CarId = carId,
        });

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model)
        {
            var modelErrors = this.validator.ValidateIssue(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var user = this.data.Users.FirstOrDefault(x => x.Id == this.User.Id);

            var issue = new Issue
            {
                Description = model.Description,
                CarId = model.CarId,
                IsFixed = false,
            };

            this.data.Issues.Add(issue);

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId} ");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            var issuse = data.Issues.FirstOrDefault(x => x.Id == issueId);

            data.Issues.Remove(issuse);

            data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            var user = data.Users.FirstOrDefault(x => x.Id == this.User.Id);

            if(user == null || !user.IsMechanic)
            {
                return BadRequest();
            }

            var issuse = data.Issues.FirstOrDefault(x => x.Id == issueId);

            issuse.IsFixed = true;

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}