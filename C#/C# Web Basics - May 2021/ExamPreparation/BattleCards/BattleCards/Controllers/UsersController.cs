using System.Linq;
using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Services;
using BattleCards.ViewModels.Users;
using BattleCards.ViwModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace BattleCards.Controllers
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
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var errors = this.validator.ValidateUser(model);
            if (errors.Any())
            {
                return Error(errors);
            }

            if (this.data.Users.Any(u => u.Username == model.Username && u.Email == u.Email))
            {
                return Error($"User with username '{model.Username}' already exist.");
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.HashPassword(model.Password),
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
                return Error("Username and password combination is not valid.");
            }

            this.SignIn(userId);

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
