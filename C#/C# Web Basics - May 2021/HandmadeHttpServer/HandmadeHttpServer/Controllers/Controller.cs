using System.Runtime.CompilerServices;
using HandmadeHttpServer.Results;
using HandmadeHttpServer.Http.HttpRequest;
using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.Controllers
{
    public abstract class Controller
    {
        protected Controller(HttpRequest request)
        {
            this.Request = request;
            this.Response = new HttpResponse(HttpStatusCode.OK);
        }

        protected HttpRequest Request { get; init; }
        protected HttpResponse Response { get; init; }

        protected ActionResult Text(string text)
        {
            return new TextResult(this.Response,text);
        }

        protected ActionResult Html(string html)
        {
            return new HtmlResult(this.Response,html);
        }

        protected ActionResult Redirect(string location)
        {
            return new RedirectResult(this.Response,location);
        }

        protected ActionResult View([CallerMemberName] string viewName = "")
        {
            return new ViewResult(this.Response,viewName, GetControllerName(), null);
        }

        protected ActionResult View(string viewName, object model)
        {
            return new ViewResult(this.Response,viewName, this.GetControllerName(), model);
        }

        protected ActionResult View(object model, [CallerMemberName] string viewName = "")
        {
            return new ViewResult(this.Response,viewName, this.GetControllerName(), model);
        }

        private string GetControllerName()
        {
            return this.GetType().Name.Replace(nameof(Controller), string.Empty);
        }
    }
}
