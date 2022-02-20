using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services;
using FootballManager.ViewModels.Players;
using Microsoft.EntityFrameworkCore;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly FootballManagerDbContext data;
        private readonly IValidator validator;

        public PlayersController(
            FootballManagerDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var playersQuery = this.data
                .Players
                .AsQueryable();

            var players = playersQuery
                .Select(x => new PlayerListingViewModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ImageUrl = x.ImageUrl,
                    Position = x.Position,
                    Description = x.Description,
                    Endurance = x.Endurance,
                    Speed = x.Speed,
                })
                .ToList();

            return View(players);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var playersQuery = this.data
                .Players
                .Include(x => x.UserPlayers)
                .Where(x => x.UserPlayers.Any(y => y.UserId == this.User.Id))
                .AsQueryable();

            var players = playersQuery
                .Select(x => new PlayerListingViewModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ImageUrl = x.ImageUrl,
                    Position = x.Position,
                    Description = x.Description,
                    Endurance = x.Endurance,
                    Speed = x.Speed,
                })
                .ToList();

            return View(players);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddPlayerFormModel model)
        {
            var modelErrors = this.validator.ValidatePlayer(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = byte.Parse(model.Speed.ToString()),
                Endurance = byte.Parse(model.Endurance.ToString()),
                Description = model.Description,
            };

            this.data.Players.Add(player);

            this.data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse AddToCollection(int playerId)
        {
            var user = this.data.Users
                .Include(x => x.UserPlayers)
                .FirstOrDefault(x => x.Id == this.User.Id);

            var player = this.data.Players
                .FirstOrDefault(x => x.Id == playerId);

            if (player == null)
            {
                return Error("You have chosen invalid Player.");
            }

            if (user == null)
            {
                return Error("Invalid User.");
            }

            if (user.UserPlayers.Any(x => x.PlayerId == player.Id))
            {
                return Error($"The player - '{player.FullName}' is already in your collection.");
            }

            var userPlayer = new UserPlayer
            {
                UserId = this.User.Id,
                PlayerId = player.Id,
            };

            this.data.UserPlayers.Add(userPlayer);

            this.data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            var user = this.data.Users
                .FirstOrDefault(x => x.Id == this.User.Id);

            var player = this.data.Players
                .FirstOrDefault(x => x.Id == playerId);

            var userPlayer = this.data.UserPlayers
                .FirstOrDefault(x => x.PlayerId == player.Id && x.UserId == user.Id);

            if (player == null)
            {
                return Error("Invalid Player.");
            }

            if (user == null)
            {
                return Error("Invalid User.");
            }

            if (userPlayer == null)
            {
                return Error("The player you try to delete is not valid.");
            }

            this.data.UserPlayers.Remove(userPlayer);

            this.data.SaveChanges();

            return Redirect("/Players/Collection");
        }
    }
}
