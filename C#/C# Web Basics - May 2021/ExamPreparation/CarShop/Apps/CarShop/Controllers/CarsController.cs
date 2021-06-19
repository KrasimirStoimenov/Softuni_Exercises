using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Cars;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;
        private readonly IUserService userService;

        public CarsController(IValidator validator, ApplicationDbContext data, IUserService userService)
        {
            this.validator = validator;
            this.data = data;
            this.userService = userService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (this.userService.IsUserMechanic(this.User.Id))
            {
                return Unauthorized();
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddCarFormModel model)
        {
            if (this.userService.IsUserMechanic(this.User.Id))
            {
                return Unauthorized();
            }

            var errors = this.validator.ValidateCar(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id
            };

            this.data.Cars.Add(car);
            this.data.SaveChanges();

            return Redirect("/Cars/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var carsQuerry = this.data.Cars.AsQueryable();

            if (this.userService.IsUserMechanic(this.User.Id))
            {
                carsQuerry = carsQuerry.Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuerry = carsQuerry.Where(c => c.OwnerId == this.User.Id);
            }

            var cars = carsQuerry
                .Select(c => new CarListingModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Image = c.PictureUrl,
                    PlateNumber = c.PlateNumber,
                    Year = c.Year,
                    FixedIssues = c.Issues.Where(i => i.IsFixed).Count(),
                    RemainingIssues = c.Issues.Where(i => !i.IsFixed).Count()
                })
                .ToList();

            return View(cars);
        }
    }
}
