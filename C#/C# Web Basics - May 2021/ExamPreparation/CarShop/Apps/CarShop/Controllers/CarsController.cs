using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        public HttpResponse All()
            => View();
    }
}
