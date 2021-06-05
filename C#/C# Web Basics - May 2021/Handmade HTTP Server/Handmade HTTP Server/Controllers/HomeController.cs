using HandmadeHTTPServer.Server.Controllers;
using HandmadeHTTPServer.Server.Http.HttpRequest;
using HandmadeHTTPServer.Server.Http.HttpResponse;

namespace Handmade_HTTP_Server.Controllers
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
            return Redirect("/dogs");
        }

        public HttpResponse ToGoogle()
        {
            return Redirect("https://google.com");
        }
    }
}
