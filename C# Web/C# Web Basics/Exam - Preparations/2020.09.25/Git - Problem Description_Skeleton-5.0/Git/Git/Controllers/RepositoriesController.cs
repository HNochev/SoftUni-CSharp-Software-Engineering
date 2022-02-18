using Git.Data;
using Git.Data.Models;
using Git.Models.Repository;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Git.Data.DataConstants;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            var tripsQuery = this.data
                .Repositories
                .AsQueryable();

            if (this.User.IsAuthenticated)
            {
                tripsQuery = tripsQuery
                    .Where(x => x.OwnerId == this.User.Id || x.IsPublic);
            }
            else
            {
                tripsQuery = tripsQuery
                    .Where(x => x.IsPublic);
            }

            var trips = tripsQuery
                .Select(x => new RepoListingViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    OwnerName = x.Owner.Username,
                    CommitsCount = x.Commits.Count(),
                    CreatedOn = x.CreatedOn.ToString("F"),
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Create() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateRepoFormModel model)
        {
            var modelErrors = this.validator.ValidateRepo(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var repo = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == RepoTypePublic,
                OwnerId = this.User.Id,
                CreatedOn = DateTime.UtcNow,
            };

            this.data.Repositories.Add(repo);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}
