using HandmadeHTTPServer.Server.Http;
using HandmadeHTTPServer.Server.Http.HttpResponse;
using System.IO;

namespace HandmadeHTTPServer.Server.Responses
{
    public class ViewResponse : HttpResponse
    {
        private const char pathSeparator = '/';

        public ViewResponse(string viewName, string controllerName)
            : base(HttpStatusCode.OK)
        {
            this.GetHtml(viewName, controllerName);
        }

        private void GetHtml(string viewName, string controllerName)
        {
            if (!viewName.Contains(pathSeparator))
            {
                viewName = controllerName + pathSeparator + viewName;
            }

            var viewPath = Path.GetFullPath("./Views/" + viewName.TrimStart(pathSeparator) + ".cshtml");

            if (!File.Exists(viewPath))
            {
                this.PrepareMissingViewError(viewPath);

                return;
            }

            var viewContent = File.ReadAllText(viewPath);

            this.PrepareContent(viewContent, HttpContentType.Html);
        }

        private void PrepareMissingViewError(string viewPath)
        {
            this.StatusCode = HttpStatusCode.NotFound;

            var errorMessage = $"View '{viewPath}' was not found.";

            this.PrepareContent(errorMessage, HttpContentType.PlainText);
        }
    }
}
