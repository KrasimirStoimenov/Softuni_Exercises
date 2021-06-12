using HandmadeHttpServer.App.Models;
using HandmadeHttpServer.Controllers;
using HandmadeHttpServer.Http.HttpRequest;
using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.App.Controllers
{
    public class AnimalsController : Controller
    {
        public AnimalsController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Cats()
        {
            const string nameKey = "Name";
            const string ageKey = "Age";

            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey) ? query[nameKey] : "the cats";

            var catAge = query.ContainsKey(ageKey) ? int.Parse(query[ageKey]) : 0;

            var viewModel = new CatViewModel
            {
                Name = catName,
                Age = catAge
            };

            return View(viewModel);
        }

        public HttpResponse Dogs()
        {
            return View(new DogViewModel
            {
                Name = "Rex",
                Age = 3,
                Breed = "Street Perfect"
            });
        }

        public HttpResponse Bunnies()
        {
            return View("Rabbits");
        }

        public HttpResponse Turtles()
        {
            return View("Animals/Wild/Turtles");
        }
    }
}
