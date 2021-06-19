using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(IValidator validator, ApplicationDbContext data, IPasswordHasher passwordHasher)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register()
            => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var errors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                errors.Add($"User with {model.Username} already exists.");
            }
            if (this.data.Users.Any(e => e.Email == model.Email))
            {
                errors.Add($"User with email: {model.Email} already exists.");
            }
            if (errors.Any())
            {
                return Error(errors);
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email,
                IsMechanic = model.UserType == DataConstants.UserTypeMechanic
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
            => View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data.Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error($"Username and password combination is not valid!");
            }

            this.SignIn(userId);

            return Redirect("/Cars/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
