using System.Linq;
using MyWebServer.Http;
using MyWebServer.Controllers;
using SharedTrip.Data;
using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SharedTrip.Data.Models;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(ApplicationDbContext data, IValidator validator, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.validator = validator;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register()
            => View();

        [HttpPost]
        public HttpResponse Register(UserRegisterFormModel model)
        {
            var errorList = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                errorList.Add($"Username {model.Username} already exist.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                errorList.Add($"Email address is already used.");
            }

            if (errorList.Any())
            {
                return Error(errorList);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = passwordHasher.HashPassword(model.Password)
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
            => View();

        [HttpPost]
        public HttpResponse Login(UserLoginFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data.Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Invalid username or password.");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
