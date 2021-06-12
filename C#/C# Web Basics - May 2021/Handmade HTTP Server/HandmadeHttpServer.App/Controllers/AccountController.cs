using HandmadeHttpServer.Controllers;
using HandmadeHttpServer.Http.HttpRequest;
using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.App.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse ActionWithCookies()
        {
            const string cookieName = "MyFirstCookie";
            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];

                return Text($"Cookies already exist - {cookie}");
            }

            this.Response.AddCookie(cookieName, "My-Cookie-Value");
            this.Response.AddCookie("SecondCookie", "SecondCookieValue");

            return Text($"Cookies set!");
        }
    }
}
