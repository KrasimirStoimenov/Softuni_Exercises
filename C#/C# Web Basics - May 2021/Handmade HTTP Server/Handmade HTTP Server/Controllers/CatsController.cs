using HandmadeHTTPServer.Server.Controllers;
using HandmadeHTTPServer.Server.Http.HttpRequest;
using HandmadeHTTPServer.Server.Http.HttpResponse;

namespace HandmadeHTTPServer.Controllers
{
    public class CatsController : Controller
    {
        public CatsController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Create()
        {
            return View();
        }

        public HttpResponse Save()
        {
            var name = this.Request.Form["Name"];
            var age = this.Request.Form["Age"];

            return Text($"{name} - {age}");
        }
    }
}
