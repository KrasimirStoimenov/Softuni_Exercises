using HandmadeHTTPServer.Models;
using HandmadeHTTPServer.Server.Controllers;
using HandmadeHTTPServer.Server.Http.HttpRequest;
using HandmadeHTTPServer.Server.Http.HttpResponse;

namespace Handmade_HTTP_Server.Controllers
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
            return View();
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
