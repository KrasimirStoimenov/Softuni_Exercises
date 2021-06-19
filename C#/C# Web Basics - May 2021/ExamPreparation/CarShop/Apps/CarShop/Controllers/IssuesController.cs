using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Issues;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IUserService userService;
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public IssuesController(IUserService userService, ApplicationDbContext data, IValidator validator)
        {
            this.userService = userService;
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            var carWithIssue = this.data
                .Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarIssuesViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    Issues = c.Issues.Select(i => new IssueListingViewModel
                    {
                        Id = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed
                    })
                })
                .FirstOrDefault();

            if (carWithIssue == null)
            {
                return Error($"Car with ID {carId} does not exists.");
            }

            return View(carWithIssue);
        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            if (this.userService.IsUserMechanic(this.User.Id))
            {
                return Unauthorized();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(string carId, AddIssueFormModel model)
        {
            if (this.userService.IsUserMechanic(this.User.Id))
            {
                return Unauthorized();
            }

            var errors = this.validator.ValidateIssue(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var currentCar = this.data.Cars.FirstOrDefault(c => c.Id == carId);

            if (currentCar == null)
            {
                return Error($"Car with Id: {carId} does not exist");
            }

            var issue = new Issue
            {
                CarId = currentCar.Id,
                Description = model.Description,
                IsFixed = false
            };

            this.data.Issues.Add(issue);
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

    }
}
