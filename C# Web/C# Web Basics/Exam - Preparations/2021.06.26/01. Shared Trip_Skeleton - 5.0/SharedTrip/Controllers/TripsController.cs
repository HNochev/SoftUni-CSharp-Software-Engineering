using Microsoft.EntityFrameworkCore;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public TripsController(
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
                .Trips
                .AsQueryable();

            var trips = tripsQuery
                .Select(x => new TripListingViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    Seats = x.Seats,
                    DepartureTime = x.DepartureTime.ToString("F"),
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(CreateTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Seats = model.Seats,
                ImagePath = model.ImagePath,
                Description = model.Description,
            };

            this.data.Trips.Add(trip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = data.Trips
                .Where(x => x.Id == tripId)
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("s"),
                    Seats = x.Seats,
                    CarImage = x.ImagePath,
                    Description = x.Description,
                })
                .FirstOrDefault();

            if (trip == null)
            {
                return BadRequest();
            }

            return View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var user = data.Users
                .Include(x => x.UserTrips)
                .FirstOrDefault(x => x.Id == this.User.Id);
            var trip = data.Trips.FirstOrDefault(x => x.Id == tripId);

            if (user.UserTrips.Any(x => x.TripId == tripId))
            {
                return Error("You are already signed in for this trip.");
            }

            if(trip.Seats == 0)
            {
                return Error("No more space in this car.");
            }

            var tripUser = new UserTrip
            {
                TripId = tripId,
                UserId = this.User.Id,
            };

            if (tripUser == null)
            {
                return BadRequest();
            }

            trip.Seats = trip.Seats - 1;

            this.data.UserTrips.Add(tripUser);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
