using Git.Data;
using Git.Data.Models;
using Git.Models.Commit;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public CommitsController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var tripsQuery = this.data
                .Commits
                .Where(x => x.CreatorId == this.User.Id)
                .AsQueryable();

            var trips = tripsQuery
                .Select(x => new CommitListingViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    RepoName = x.Repository.Name,
                    CreatedOn = x.CreatedOn.ToString("F"),
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repo = this.data
                .Repositories
                .FirstOrDefault(x => x.Id == id);

            var commitToRepo = new CommitToRepoViewModel
            {
                Id = repo.Id,
                Name = repo.Name,
            };

            return View(commitToRepo);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(string id, CreateCommitFormModel model)
        {
            var modelErrors = this.validator.ValidateCommit(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var commit = new Commit
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = this.User.Id,
                RepositoryId = id,
            };

            this.data.Commits.Add(commit);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.data.Commits.FirstOrDefault(x => x.Id == id);

            this.data.Commits.Remove(commit);

            this.data.SaveChanges();

            return Redirect("/Commits/All");
        }
    }
}
