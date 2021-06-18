using HandmadeHttpServer.Controllers;
using HandmadeHttpServer.Http.HttpRequest;
using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.App.Controllers
{
    public class CatsController : Controller
    {
        public CatsController(HttpRequest request)
            : base(request)
        {
        }

        [HttpGet]
        public HttpResponse Create()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Save()
        {
            var name = this.Request.Form["Name"];
            var age = this.Request.Form["Age"];

            return Text($"{name} - {age}");
        }
    }
}
