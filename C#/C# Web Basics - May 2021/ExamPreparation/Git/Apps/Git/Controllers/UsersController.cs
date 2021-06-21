using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
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
        public HttpResponse Register(UserRegisterViewModel model)
        {
            var errors = this.validator.ValidateUser(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }
        public HttpResponse Login()
            => View();

        [HttpPost]
        public HttpResponse Login(UserLoginViewModel model)
        {
            var errors = this.validator.ValidateUserLogin(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var currentUserId = this.data.Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();


            if (currentUserId == null)
            {
                return Error($"Wrong username or password!");
            }

            this.SignIn(currentUserId);

            return Redirect("/Repositories/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
