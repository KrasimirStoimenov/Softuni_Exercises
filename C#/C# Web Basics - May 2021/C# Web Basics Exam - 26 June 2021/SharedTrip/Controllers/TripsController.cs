using System;
using System.Linq;
using System.Globalization;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SharedTrip.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public TripsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add()
            => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(TripAddFormModel model)
        {
            var errorList = this.validator.ValidateTrip(model);

            var isValidDepartureTime = DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var departureTime);

            if (!isValidDepartureTime)
            {
                errorList.Add("Invalid departure time added.");
            }

            if (errorList.Any())
            {
                return Error(errorList);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                DepartureTime = departureTime,
                Description = model.Description,
                Seats = model.Seats,
            };

            trip.UserTrips.Add(new UserTrip
            {
                UserId = this.User.Id
            });

            trip.Seats--; //business requirement - asked in slido if user who creates the trip should take one place for him.

            this.data.Trips.Add(trip);
            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.data.Trips
                .Where(t=>t.Seats > 0)
                .Select(t => new TripListingViewModel
                {
                    Id = t.Id,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Seats = t.Seats
                })
                .ToList();


            return View(trips);
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var currentTrip = this.data.Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsListingModel
                {
                    Id = t.Id,
                    ImagePath = t.ImagePath,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                    Description = t.Description
                })
                .FirstOrDefault();

            return View(currentTrip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            var trip = this.data.Trips
                .Where(t => t.Id == tripId)
                .FirstOrDefault();

            var currentUser = this.data.Users
                .Include(u => u.UserTrips)
                .Where(u => u.Id == this.User.Id)
                .FirstOrDefault();

            if (currentUser.UserTrips.Any(t => t.TripId == tripId))
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (trip.Seats == 0)
            {
                return Error("Not free spaces left.");
            }

            currentUser.UserTrips.Add(new UserTrip { Trip = trip, UserId = this.User.Id });
            trip.Seats--;

            this.data.SaveChanges();
            return Redirect("/Trips/All");
        }

    }
}
