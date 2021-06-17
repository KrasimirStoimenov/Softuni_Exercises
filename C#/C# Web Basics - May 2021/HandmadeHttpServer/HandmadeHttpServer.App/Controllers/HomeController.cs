using System;
using HandmadeHttpServer.Controllers;
using HandmadeHttpServer.Http.HttpRequest;
using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Index()
            => Text("Hello from My handmade web server");

        public HttpResponse LocalRedirect()
            => Redirect("/cats");

        public HttpResponse ToGoogle()
            => Redirect("https://google.com");

        public HttpResponse StaticFiles()
            => View();

        public HttpResponse Error()
            => throw new InvalidOperationException("Invalid action!");
    }
}
