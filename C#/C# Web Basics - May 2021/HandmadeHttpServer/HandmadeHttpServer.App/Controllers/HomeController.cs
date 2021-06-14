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
        {
            return Text("Hello from My handmade web server");
        }

        public HttpResponse LocalRedirect()
        {
            return Redirect("/cats");
        }

        public HttpResponse ToGoogle()
        {
            return Redirect("https://google.com");
        }
    }
}
